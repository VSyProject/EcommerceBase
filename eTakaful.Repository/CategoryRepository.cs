using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class CategoryReponsitory : BaseRepository<Category>, ICategoryReponsitory
    {

        public CategoryReponsitory(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Category>> GetCategoryParrent()
        {
            var category = DbContext.Categories.Where(c => c.ParentId == null)
                .Include(c => c.Products.Where(p => p.Name == "ip")).ToListAsync();
            return await DbContext.Categories.Where(c => c.ParentId == null).ToListAsync();
        }
    }
}
