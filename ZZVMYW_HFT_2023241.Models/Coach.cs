using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZZVMYW_HFT_2023241.Models
{
    public class Coach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoachId { get; set; }
        [Required]
        [StringLength(100)]
        public string CoachName { get; set;}

        public string Nationality { get; set; }

        public int Age { get; set; }
        [JsonIgnore]
        public virtual ICollection<Team> Teams { get; set; }

        public Coach()
        {
            Teams = new HashSet<Team>();
        }
        public Coach(string line)
        {
            string[] splited = line.Split('#');
            CoachId = int.Parse(splited[0]);
            CoachName = splited[1];
            Nationality = splited[2];
            Age = int.Parse(splited[3]);
            Teams = new HashSet<Team>();
        }
    }
}
