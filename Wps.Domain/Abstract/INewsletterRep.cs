using System.Collections.Generic;
using Wps.Domain.Entities;

namespace Wps.Domain.Abstract
{

    public interface INewsletterRep
    {
        IEnumerable<Newsletter> Newsletter { get; }
        void SaveNewsletter(Newsletter newsletter);
        Newsletter DeleteNewsletter(int NewsletterID);
    }
}
