using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6TW4A_HFT_2023241.Models
{
    public class Adventurer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Adventurerid;

        public int Questid;

        [StringLength(240)]
        public string Name;

        [StringLength(240)]
        public string PartyName;

        [StringLength(6)]
        public string Rank;

        [StringLength(240)]
        public string ResidingTown;

        public virtual Quest Quest { get; set; }

        public Adventurer()
        {
            
        }

        public Adventurer(string a)
        {
            string[] split=a.Split("/");
            Adventurerid = int.Parse(split[0]);
            Questid = int.Parse(split[1]);
            Name = split[2];
            PartyName = split[3];
            Rank = split[4];
            ResidingTown = split[5];


        }
    }
}
