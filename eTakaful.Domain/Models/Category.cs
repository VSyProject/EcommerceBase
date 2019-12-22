using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Category : BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sort { get; set; }
        public bool IsDisplayHomePage { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
