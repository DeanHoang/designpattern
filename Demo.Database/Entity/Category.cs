using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Database.Entity
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
