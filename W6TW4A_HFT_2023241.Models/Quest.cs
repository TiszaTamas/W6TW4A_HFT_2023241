using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6TW4A_HFT_2023241.Models
{
    internal class Quest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Questid;

        int Markid;

        [StringLength(240)]
        string Objective;

        [StringLength(240)]
        string ClientName;


        [StringLength(6)] 
        string DifficuktyRating;

        [StringLength(240)]
        string Reward;

        bool Completed;
    }
}
