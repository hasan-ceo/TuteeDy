using Wps.Domain.Abstract;
using Wps.Domain.Entities;
using System.Collections.Generic;

namespace Wps.Domain.Concrete
{
    public class EFNewsletterRep : INewsletterRep
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Newsletter> Newsletter
        {
            get { return context.Newsletters; }
        }

        public void SaveNewsletter(Newsletter newspaper)
        {

            if (newspaper.NewsletterID == 0)
            {
                context.Newsletters.Add(newspaper);
            }
            else
            {
                Newsletter dbEntry = context.Newsletters.Find(newspaper.NewsletterID);
                if (dbEntry != null)
                {
                    dbEntry.NewsletterID = newspaper.NewsletterID;
                    dbEntry.Name  = newspaper.Name ;
                    dbEntry.Email = newspaper.Email ;
                }
            }
            context.SaveChanges();
        }

        public Newsletter DeleteNewsletter(int NewsletterID)
        {
            Newsletter dbEntry = context.Newsletters.Find(NewsletterID);
            if (dbEntry != null)
            {
                context.Newsletters.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
