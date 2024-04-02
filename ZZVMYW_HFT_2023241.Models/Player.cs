using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ZZVMYW_HFT_2023241.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }

        [Required]
        [StringLength(100)]
        public string PlayerName { get; set; }

        public string Nationality { get; set; }

        public int Age { get; set; }

        [JsonIgnore]
        public virtual ICollection<Role> Roles { get; set; }
        [JsonIgnore]
        public virtual ICollection<Team> Teams { get; set; }

        public Player()
        {
            
        }
        public Player(string line)
        {
            string[] splited = line.Split('#');
            PlayerId = int.Parse(splited[0]);
            PlayerName = splited[1];
            Nationality = splited[2];
            Age = int.Parse(splited[3]);
        }
    }
}
