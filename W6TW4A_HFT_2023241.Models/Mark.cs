using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6TW4A_HFT_2023241.Models
{
    public class Mark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MarkId { get; set; }

        public int QuestId { get; set; }
        public int MonsterId { get; set; }

        public virtual Quest Quest { get; private set; }
        public virtual Monster Monster { get; private set; }

        public Mark(string a)
        {
            string[] split = a.Split("/");
            MarkId = int.Parse(split[0]);
            QuestId = int.Parse(split[1]);
            MonsterId = int.Parse(split[2]);
        }

        public Mark()
        {
            
        }
    }
}
