using System.Collections.Generic;
using Wps.Domain.Entities;

namespace Wps.Domain.Abstract
{

    public interface INewsPaperRep
    {
        IEnumerable<NewsPaper> NewsPaper { get; }
        void SaveNewsPaper(NewsPaper newspaper);
        NewsPaper DeleteNewsPaper(int NewsPaperID);
    }
}
