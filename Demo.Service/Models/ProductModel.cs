using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int NumInStock { get; set; }
        public string Description { get; set; }
        public int IsAvailable { get; set; }
        public ICollection<CategoryModel> Categories { get; set; }
       
    }
}
