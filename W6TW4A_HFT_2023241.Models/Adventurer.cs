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
    public class Adventurer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdventurerId { get; set; }

        public int QuestId { get; set; }

        [Required]
        [StringLength(240)]
        public string Name { get; set; }

        [StringLength(240)]
        public string PartyName { get; set; }

        [Required]
        [StringLength(6)]
        public string Rank { get; set; }

        [StringLength(240)]
        public string ResidingTown { get; set; }

        public virtual Quest Quest { get; set; }

        public Adventurer()
        {
            
        }

        public Adventurer(string a)
        {
            string[] split=a.Split("/");
            AdventurerId = int.Parse(split[0]);
            QuestId = int.Parse(split[1]);
            Name = split[2];
            PartyName = split[3];
            Rank = split[4];
            ResidingTown = split[5];
        }
        public override bool Equals(object obj)
        {
            Adventurer a = obj as Adventurer;
            if (a == null)
            {
                return false;
            }
            else
            {
                return this.Name == a.Name
                    && this.AdventurerId == a.AdventurerId
                    && this.QuestId == a.QuestId
                    && this.ResidingTown==a.ResidingTown
                    && this.Rank==a.Rank
                    && this.PartyName == a.PartyName;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.PartyName, this.AdventurerId, this.QuestId, this.ResidingTown,this.Rank);
        }
    }
}
