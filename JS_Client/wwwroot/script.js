let adventurers = [];
let connection;
let adventurerIdToUpdate = -1;
let adventurerResidentToUpdate;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:8351/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AdventurerCreated", (user, message) => {
        getdata();
    });

    connection.on("AdventurerDeleted", (user, message) => {
        getdata();
    });

    connection.on("AdventurerUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:8351/adventurer')
        .then(x => x.json())
        .then(y => {
            adventurers = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    adventurers.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.adventurerId + "</td><td>"
        + t.name + "</td><td>"
        + t.rank + "</td><td>" 
        + t.partyName + "</td><td>" +
        `<button type="button" onclick="remove(${t.adventurerId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.adventurerId})">Update</button>`
            +`</td></tr>`;
    });
}

function showupdate(id) {
    document.getElementById('nameupdate').value = adventurers.find(x => x['adventurerId'] == id)['name'];
    document.getElementById('partyupdate').value = adventurers.find(x => x['adventurerId'] == id)['partyName'];
    document.getElementById('rankupdate').value = adventurers.find(x => x['adventurerId'] == id)['rank'];
    document.getElementById('updateformdiv').style.display = 'flex';
    adventurerIdToUpdate = id;
    adventurerResidentToUpdate = adventurers.find(x => x['adventurerId'] == id)['residingTown'];
}

function create() {
    let name = document.getElementById('adventurername').value;
    let party = document.getElementById('adventurerparty').value;
    let rank = document.getElementById('adventurerrank').value;
    fetch('http://localhost:8351/adventurer', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, partyName:party, rank:rank })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('nameupdate').value;
    let party = document.getElementById('partyupdate').value;
    let rank = document.getElementById('rankupdate').value;
    fetch('http://localhost:8351/adventurer', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, partyName: party, rank: rank, adventurerId: adventurerIdToUpdate, residingTown : adventurerResidentToUpdate})
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function remove(id) {
    fetch('http://localhost:8351/adventurer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}