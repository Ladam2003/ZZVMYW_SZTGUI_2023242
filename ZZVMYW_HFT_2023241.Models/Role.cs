using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ZZVMYW_HFT_2023241.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }


        //Rövidités
        public string Abbreviation { get; set; }

        public int TeamId { get; set; }
        public int PlayerId { get; set; }

        [JsonIgnore]
        public virtual Team Team { get; set; }


        public virtual Player Player { get;  set; }

        public Role()
        {
            
        }

        public Role(string line)
        {
            string[] splited = line.Split('#');
            RoleId = int.Parse(splited[0]);
            RoleName = splited[1];
            Abbreviation = splited[2];
            TeamId = int.Parse(splited[3]);
            PlayerId = int.Parse(splited[4]);
        }
    }
}
