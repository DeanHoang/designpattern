using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Database.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }
        public float Price { get; set; }
        public int NumInStock { get; set; }
        public string Description { get; set; }
        public int IsAvailable { get; set; }
        [ForeignKey("UserId")]
        public virtual User Users { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

    }
}
