using Wps.Domain.Abstract;
using Wps.Domain.Entities;
using System.Collections.Generic;

namespace Wps.Domain.Concrete
{
    public class EFWordUserRep : IWordUserRep
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<WordUser> WordUser
        {
            get { return context.WordUsers; }
        }

        public void SaveWordUser(WordUser WordUser)
        {

            if (WordUser.WordUserID == 0)
            {
                context.WordUsers.Add(WordUser);
            }
            else
            {
                WordUser dbEntry = context.WordUsers.Find(WordUser.WordUserID);
                if (dbEntry != null)
                {
                    dbEntry.WordUserID = WordUser.WordUserID;
                    dbEntry.English = WordUser.English;
                    dbEntry.Swahili = WordUser.Swahili;
                    dbEntry.CategoryID = WordUser.CategoryID;
                    dbEntry.Name = WordUser.Name;
                    dbEntry.Email = WordUser.Email;
                    //dbEntry.Sound = WordUser.Sound;
                }
            }
            context.SaveChanges();
        }

        public WordUser DeleteWordUser(int WordUserID)
        {
            WordUser dbEntry = context.WordUsers.Find(WordUserID);
            if (dbEntry != null)
            {
                context.WordUsers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
