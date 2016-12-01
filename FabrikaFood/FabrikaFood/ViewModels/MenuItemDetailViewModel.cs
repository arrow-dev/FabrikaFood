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
        //The selected MenuItem
        public MenuItem Item { get; set; }

        public MenuItemDetailViewModel(MenuItem menuItem)
        {
            Item = menuItem;
            Title = "Fabrikam Food - " + menuItem.Title;
            RefreshList();
        }

        ObservableCollection<CommentViewModel> comments = new ObservableCollection<CommentViewModel>();
        //List of comments to display.
        public ObservableCollection<CommentViewModel> Comments
        {
            get { return comments; }
            set { SetProperty(ref comments, value, "Comments"); }
        }

        private String newComment;
        //Bound to the editor used for adding and editing comments.
        public string NewComment
        {
            get { return newComment; }
            set { SetProperty(ref newComment, value, "NewComment");}
        }

        Command refreshCmd;
        public Command RefreshCommand => refreshCmd ?? (refreshCmd = new Command(async () => await ExecuteRefreshCommand()));
        //Refresh the comments.
        async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                //Get the comments for the selected MenuItem
                var list = await App.GetCloudService().client.GetTable<Comment>().Where(c => c.MenuItemId == Item.Id).ToListAsync();
                //Clear the existing comments before repopulating the list.
                Comments.Clear();
                foreach (var comment in list)
                {
                    var viewModel = new CommentViewModel
                    {
                        UserId = comment.UserId,
                        MenuItemId = comment.MenuItemId,
                        Content = comment.Content,
                        Id = comment.Id
                    };
                    //If the logged in user posted the commment then set show actions to true. This is databound to the visibility of the edit and delete controls on the Xaml list template.
                    if (comment.UserId == App.GetCloudService().CurrentUser.UserId)
                    {
                        viewModel.ShowActions = true;
                    }
                    Comments.Add(viewModel);
                }
                    
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
        //Post a comment
        public Command PostCommentCommand
            => postCommentCommand ?? (postCommentCommand = new Command(async () => await ExecutePostCommentCommand()));

        async Task ExecutePostCommentCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                //Create a new comment object
                var comment = new Comment()
                {
                    Content = NewComment,
                    MenuItemId = Item.Id,
                    UserId = App.CloudService.CurrentUser.UserId
                };
                //Add it to the comment table.
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

        Command deleteCommentCommand;
        //Delete a comment.
        public Command DeleteCommentCommand
            => deleteCommentCommand ?? (deleteCommentCommand = new Command<string>(async (string id) => await ExecuteDeleteCommentCommand(id)));

        async Task ExecuteDeleteCommentCommand(string id)
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                //Get comment object by id then delete.
                var comment = await App.CloudService.GetTable<Comment>().ReadItemAsync(id);
                await App.CloudService.GetTable<Comment>().DeleteItemAsync(comment);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }
            finally
            {
                IsBusy = false;
                RefreshList();
            }
        }

        Command updateCommentCommand;
        //Edit a comment
        public Command UpdateCommentCommand
            => updateCommentCommand ?? (updateCommentCommand = new Command<string>(async (string id) => await ExecuteUpdateCommentCommand(id)));

        async Task ExecuteUpdateCommentCommand(string id)
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                //Get comment object by Id
                var comment = await App.CloudService.GetTable<Comment>().ReadItemAsync(id);
                //Update the the content to the new comment property bound to the editor.
                comment.Content = NewComment;
                //Pass the edited comment object back to the update method.
                await App.CloudService.GetTable<Comment>().UpdateItemAsync(comment);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }
            finally
            {
                IsBusy = false;
                RefreshList();
            }
        }

    }
}
