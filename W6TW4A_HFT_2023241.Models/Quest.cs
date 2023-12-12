using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace W6TW4A_HFT_2023241.Models
{
    public class Quest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestId { get; set; }

        [Required]
        [StringLength(240)]
        public string Objective { get; set; }

        [StringLength(6)]
        public string DifficultyRating { get; set; }

        [StringLength(240)]
        public string ClientName { get; set; }

        [StringLength(240)]
        public string Reward { get; set; }

        public bool Completed { get; set; }

        [JsonIgnore]
        public virtual ICollection<Adventurer> Adventurers { get; set; }

        public Quest()
        {
            Adventurers = new HashSet<Adventurer>();
        }

        [JsonIgnore]
        public virtual ICollection<Monster> Monsters { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        public Quest(string a, bool b)
        {
            string[] split=a.Split("/");
            QuestId = int.Parse(split[0]);
            Objective = split[1];
            DifficultyRating = split[2];
            ClientName = split[3];
            Reward = split[4];
            Completed = b;
        }

    }
}
