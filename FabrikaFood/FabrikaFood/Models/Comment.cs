using FabrikaFood.Abstractions;

namespace FabrikaFood.Models
{
    public class Comment: TableData
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public string MenuItemId { get; set; }
    }
}
