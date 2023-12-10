using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6TW4A_HFT_2023241.Models
{
    public class Quest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Questid;

        public int Markid;

        [StringLength(240)]
        public string Objective;

        [StringLength(240)]
        public string ClientName;


        [StringLength(6)]
        public string DifficuktyRating;

        [StringLength(240)]
        public string Reward;

        public bool Completed;

        public virtual ICollection<Adventurer> Adventurer { get; set; }

        public Quest()
        {
            Adventurer = new HashSet<Adventurer>();
        }

        public ICollection<Monster> Monsters { get; set; }
    }
}
