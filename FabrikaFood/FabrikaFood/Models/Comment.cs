using FabrikaFood.Abstractions;

namespace FabrikaFood.Models
{
    //Data model for comments coming from the database.
    public class Comment: TableData
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public string MenuItemId { get; set; }
    }
}
