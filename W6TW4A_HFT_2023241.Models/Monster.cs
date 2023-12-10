using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6TW4A_HFT_2023241.Models
{
    internal class Monster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Monsterid;

        [Required]
        int Markid;

        [StringLength(240)]
        string Name;

        [StringLength(480)]
        string Appearance;

        [StringLength(6)]
        string Rank;

        [StringLength(240)]
        string Weakness;

        [StringLength(240)]
        string UsefulParts;
        
    }
}
