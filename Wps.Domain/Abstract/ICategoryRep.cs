using System.Collections.Generic;
using Wps.Domain.Entities;

namespace Wps.Domain.Abstract
{

    public interface ICategoryRep
    {
        IEnumerable<Category> Category { get; }
        void SaveCategory(Category category);
        Category DeleteCategory(int CategoryID);
    }
}
