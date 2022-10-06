using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YG.Data.Models
{
    public class Monter
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Name { get; set; }


        public string Attribute { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public Monter()
        {
            this.Skill = new HashSet<Skill>();
        }
        public virtual ICollection<Skill> Skill { get; set; }


    }
}
