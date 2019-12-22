using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Service.ViewModels
{
    public class ProductViewModel
    {      
        public string Name { get; set; }
        public string Sku { get; set; }
        public DateTime PublicationDate { get; set; }       
        public decimal Price { get; set; }
        public int Views { get; set; }
        public string Keyword { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }        
    }
}
