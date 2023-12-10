using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6TW4A_HFT_2023241.Models
{
    public class Monster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Monsterid;

        [StringLength(240)]
        public string Name;

        [StringLength(480)]
        public string Appearance;

        [StringLength(8)]
        public string Rank;

        [StringLength(240)]
        public string Weakness;

        [StringLength(240)]
        public string UsefulParts;

        public virtual ICollection<Quest> Quests { get; set; }

        public Monster()
        {
            
        }

        public Monster(string a)
        {
            string[] split = a.Split("/");
            Monsterid = int.Parse(split[0]);
            Name = split[1];
            Rank = split[2];
            Appearance = split[3];
            Weakness = split[4];
            UsefulParts = split[5];
        }

    }
}
