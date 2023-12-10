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

        public int GoldBalance;

        public virtual Quest Quest { get; set; }
    }
}
