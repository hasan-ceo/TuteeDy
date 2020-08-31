using System.Collections.Generic;
using Wps.Domain.Entities;

namespace Wps.Domain.Abstract
{

    public interface IWordRep
    {
        IEnumerable<Word> Word { get; }
        void SaveWord(Word word);
        Word DeleteWord(int WordID);
    }
}
