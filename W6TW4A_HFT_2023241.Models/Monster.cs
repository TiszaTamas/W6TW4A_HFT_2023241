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

        [Required]
        public int Markid;

        [StringLength(240)]
        public string Name;

        [StringLength(480)]
        public string Appearance;

        [StringLength(6)]
        public string Rank;

        [StringLength(240)]
        public string Weakness;

        [StringLength(240)]
        public string UsefulParts;

        public virtual ICollection<Quest> Quests { get; set; }
        
    }
}
