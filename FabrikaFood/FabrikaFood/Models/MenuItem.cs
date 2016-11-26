using FabrikaFood.Abstractions;

namespace FabrikaFood.Models
{
    public class MenuItem: TableData
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
