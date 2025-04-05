using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.CORE.Entities
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage ="İsim alanı boş geçilemez")]
        public string Name { get; set; }
                
        public decimal ListPrice { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; }
        public int Discount { get; set; }

        //Mapping
        public List<Comment> Comments { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
