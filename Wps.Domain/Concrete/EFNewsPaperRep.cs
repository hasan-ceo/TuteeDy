using Wps.Domain.Abstract;
using Wps.Domain.Entities;
using System.Collections.Generic;

namespace Wps.Domain.Concrete
{
    public class EFNewsPaperRep : INewsPaperRep
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<NewsPaper> NewsPaper
        {
            get { return context.NewsPapers; }
        }

        public void SaveNewsPaper(NewsPaper newspaper)
        {

            if (newspaper.NewsPaperID == 0)
            {
                context.NewsPapers.Add(newspaper);
            }
            else
            {
                NewsPaper dbEntry = context.NewsPapers.Find(newspaper.NewsPaperID);
                if (dbEntry != null)
                {
                    dbEntry.NewsPaperID = newspaper.NewsPaperID;
                    dbEntry.Title  = newspaper.Title ;
                    dbEntry.SiteLink = newspaper.SiteLink ;
                }
            }
            context.SaveChanges();
        }

        public NewsPaper DeleteNewsPaper(int NewsPaperID)
        {
            NewsPaper dbEntry = context.NewsPapers.Find(NewsPaperID);
            if (dbEntry != null)
            {
                context.NewsPapers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
