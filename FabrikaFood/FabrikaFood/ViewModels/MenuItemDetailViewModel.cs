using FabrikaFood.Abstractions;
using FabrikaFood.Models;
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

        private String newComment;

        public string NewComment
        {
            get { return newComment; }
            set { SetProperty(ref newComment, value, "NewComment");}
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
                var list = await App.GetCloudService().client.GetTable<Comment>().Where(c => c.MenuItemId == Item.Id).ToListAsync();
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

        Command postCommentCommand;

        public Command PostCommentCommand
            => postCommentCommand ?? (postCommentCommand = new Command(async () => await ExecutePostCommentCommand()));

        async Task ExecutePostCommentCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                var comment = new Comment()
                {
                    Content = NewComment,
                    MenuItemId = Item.Id,
                    UserId = App.CloudService.CurrentUser.UserId
                };

                await App.CloudService.GetTable<Comment>().CreateItemAsync(comment);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }
            finally
            {
                IsBusy = false;
                NewComment = string.Empty;
                RefreshList();
            }
        }

    }
}
