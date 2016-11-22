using FabrikaFood.Abstractions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FabrikaFood.Models
{
    public class MenuItem: TableData
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public MenuItem()
        {
            Comments = new Collection<Comment>();
        }
    }
}
