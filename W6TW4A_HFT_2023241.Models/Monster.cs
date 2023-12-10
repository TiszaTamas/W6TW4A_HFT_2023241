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
        public int MonsterId { get; set; }

        [Required]
        [StringLength(240)]
        public string Name { get; set; }

        [StringLength(480)]
        public string Appearance { get; set; }

        [StringLength(8)]
        public string Rank { get; set; }

        [StringLength(240)]
        public string Weakness { get; set; }

        [StringLength(240)]
        public string UsefulParts { get; set; }

        public virtual ICollection<Quest> Quests { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }

        public Monster()
        {
            
        }

        public Monster(string a)
        {
            string[] split = a.Split("/");
            MonsterId = int.Parse(split[0]);
            Name = split[1];
            Rank = split[2];
            Appearance = split[3];
            Weakness = split[4];
            UsefulParts = split[5];
        }

    }
}
