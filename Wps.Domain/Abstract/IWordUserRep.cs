using System.Collections.Generic;
using Wps.Domain.Entities;

namespace Wps.Domain.Abstract
{

    public interface IWordUserRep
    {
        IEnumerable<WordUser> WordUser { get; }
        void SaveWordUser(WordUser WordUser);
        WordUser DeleteWordUser(int WordUserID);
    }
}
