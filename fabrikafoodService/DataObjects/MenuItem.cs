using Microsoft.Azure.Mobile.Server;
using System.Collections.ObjectModel;

namespace fabrikafoodService.DataObjects
{
    public class MenuItem:EntityData
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual Collection<Comment> Comments { get; set; }
    }
}