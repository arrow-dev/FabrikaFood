using FabrikaFood.Abstractions;
using FabrikaFood.Pages;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FabrikaFood.ViewModels
{
    class MenuPageViewModel: BaseViewModel
    {
        public MenuPageViewModel()
        {
            Title = "Fabrikam Food - Our Menu";
            RefreshList();
        }

        ObservableCollection<Models.MenuItem> items = new ObservableCollection<Models.MenuItem>();

        public ObservableCollection<Models.MenuItem> Items
        {
            get { return items; }
            set { SetProperty(ref items, value, "Items"); }
        }

        Models.MenuItem selectedItem;
        public Models.MenuItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                SetProperty(ref selectedItem, value, "SelectedItem");
                if (selectedItem != null)
                {
                    Application.Current.MainPage.Navigation.PushAsync(new Pages.MenuItemDetail(selectedItem));
                    SelectedItem = null;
                }
            }
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
                var table = App.CloudService.GetTable<Models.MenuItem>();
                var list = await table.ReadAllItemsAsync();
                Items.Clear();
                foreach (var item in list)
                    Items.Add(item);
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

        Command mapCommand;

        public Command MapCommand
            => mapCommand ?? (mapCommand = new Command(async () => await ExecuteMapCommand()));

        async Task ExecuteMapCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MapPage());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
