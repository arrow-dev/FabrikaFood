using FabrikaFood.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using MenuItem = FabrikaFood.Models.MenuItem;

namespace FabrikaFood.ViewModels
{
    class MenuItemDetailViewModel: BaseViewModel
    {
        public MenuItem Item { get; set; }

        public MenuItemDetailViewModel(MenuItem menuItem)
        {
            Item = menuItem;
            Title = menuItem.Title;
            RefreshList();
        }

        ObservableCollection<Models.Comment> comments = new ObservableCollection<Models.Comment>();

        public ObservableCollection<Models.Comment> Comments
        {
            get { return comments; }
            set { SetProperty(ref comments, value, "Comments"); }
        }

        Command refreshCmd;
        public Command RefreshCommand => refreshCmd ?? (refreshCmd = new Command(async () => await ExecuteRefreshCommand()));

        async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                var list = await App.CloudService.GetComments(Item.Id);
                Comments.Clear();
                foreach (var comment in list)
                    Comments.Add(comment);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[TaskList] Error loading items: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task RefreshList()
        {
            await ExecuteRefreshCommand();
            MessagingCenter.Subscribe<MenuPageViewModel>(this, "ItemsChanged", async (sender) =>
            {
                await ExecuteRefreshCommand();
            });
        }
    }
}
