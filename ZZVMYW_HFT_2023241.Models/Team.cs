using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ZZVMYW_HFT_2023241.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        [Required]
        [StringLength(50)]
        public string TeamName { get; set; }

        [StringLength(50)]
        public string Division { get; set; }

        public DateTime EstablishmentDate { get; set; }
        public string Nationality { get; set; }
        public int CoachId { get; set; }

        [JsonIgnore]
        public virtual Coach Coach { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public Team()
        {
            
        }
        public Team(string line)
        {
            string[] splited = line.Split('#');
            TeamId = int.Parse(splited[0]);
            TeamName = splited[1];
            Division = splited[2];
            EstablishmentDate = DateTime.Parse(splited[3].Replace('.','-'));
            Nationality = splited[4];
            CoachId = int.Parse(splited[5]);
        }
    }
}
