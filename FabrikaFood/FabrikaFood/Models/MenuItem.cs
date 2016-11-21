using System.Collections.ObjectModel;

namespace FabrikaFood.Models
{
    public class MenuItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Collection<Comment> Comments { get; set; }

        public MenuItem()
        {
            Comments = new Collection<Comment>();
        }
    }
}
