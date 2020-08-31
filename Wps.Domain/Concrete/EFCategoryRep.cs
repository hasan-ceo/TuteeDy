using Wps.Domain.Abstract;
using Wps.Domain.Entities;
using System.Collections.Generic;

namespace Wps.Domain.Concrete
{
    public class EFCategoryRep : ICategoryRep
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Category> Category
        {
            get { return context.Categories; }
        }

        public void SaveCategory(Category category)
        {

            if (category.CategoryID == "")
            {
                context.Categories.Add(category);
            }
            else
            {
                Category dbEntry = context.Categories.Find(category.CategoryID);
                if (dbEntry != null)
                {
                    dbEntry.CategoryID = category.CategoryID;
                    dbEntry.CategoryName = category.CategoryName;
                }
            }
            context.SaveChanges();
        }

        public Category DeleteCategory(int CategoryID)
        {
            Category dbEntry = context.Categories.Find(CategoryID);
            if (dbEntry != null)
            {
                context.Categories.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
