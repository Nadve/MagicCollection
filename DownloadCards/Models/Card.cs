using System.Collections.Generic;

namespace DownloadCards.Models
{
    internal class Card
    {
        public int CardId { get; set; }
        public string Name { get; set; }
        public string Set { get; set; }
        public string CollectorNumber { get; set; }

        public virtual ICollection<Record> Records { get; set; }
        public virtual ICollection<Possession> Possessions { get; set; }
    }
}
