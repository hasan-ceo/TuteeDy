using Wps.Domain.Abstract;
using Wps.Domain.Entities;
using System.Collections.Generic;

namespace Wps.Domain.Concrete
{
    public class EFWordRep : IWordRep
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Word> Word
        {
            get { return context.Words; }
        }

        public void SaveWord(Word word)
        {

            if (word.WordID == 0)
            {
                context.Words.Add(word);
            }
            else
            {
                Word dbEntry = context.Words.Find(word.WordID);
                if (dbEntry != null)
                {
                    dbEntry.WordID = word.WordID;
                    dbEntry.English = word.English;
                    dbEntry.Swahili = word.Swahili;
                    dbEntry.CategoryID = word.CategoryID;
                    dbEntry.Sound = word.Sound;
                }
            }
            context.SaveChanges();
        }

        public Word DeleteWord(int WordID)
        {
            Word dbEntry = context.Words.Find(WordID);
            if (dbEntry != null)
            {
                context.Words.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
