using FabrikaFood.Abstractions;
using FabrikaFood.Models;

namespace FabrikaFood.ViewModels
{
    class MenuItemDetailViewModel: BaseViewModel
    {
        public MenuItem Item { get; set; }

        public MenuItemDetailViewModel(MenuItem menuItem)
        {
            Item = menuItem;
            Title = menuItem.Title;
        }
    }
}
