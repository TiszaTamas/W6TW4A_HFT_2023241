using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6TW4A_HFT_2023241.Models
{
    internal class Adventurer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Adventurerid;

        int Questid;

        [StringLength(240)]
        string Name;

        [StringLength(240)]
        string PartyName;

        [StringLength(6)]
        string Rank;

        [StringLength(240)]
        string ResidingTown;

        int GoldBalance;
    }
}
