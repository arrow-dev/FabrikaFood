
using FabrikaFood.Models;
using FabrikaFood.ViewModels;
using System;
using Xamarin.Forms;

namespace FabrikaFood.Pages
{
    public partial class MenuItemDetail : ContentPage
    {
        public MenuItemDetail(Models.MenuItem menuItem = null)
        {
            InitializeComponent();
            BindingContext = new MenuItemDetailViewModel(menuItem);
        }

        private void PostComment_Clicked(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            if (!Editor.IsVisible)
            {
                PostCommentButton.Text = "Cancel";
                PostCommentButton.BackgroundColor = Color.Red;
                Editor.IsVisible = true;
                Editor.Focus();
                PostButton.IsVisible = true;
            }
            else
            {
                PostCommentButton.Text = "Post Comment";
                PostCommentButton.BackgroundColor = Color.Teal;
                Editor.IsVisible = false;
                PostButton.IsVisible = false;
            }
            
        }

        private async void EditButton_OnClicked(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            if (!Editor.IsVisible)
            {
                PostCommentButton.Text = "Cancel";
                PostCommentButton.BackgroundColor = Color.Red;
                Editor.IsVisible = true;
                Editor.Focus();
                UpdateButton.IsVisible = true;
                var comment =
                    await App.GetCloudService().GetTable<Comment>().ReadItemAsync(clickedButton.CommandParameter.ToString());
                UpdateButton.CommandParameter = comment.Id;
                Editor.Text = comment.Content;
            }
            else
            {
                PostCommentButton.Text = "Post Comment";
                PostCommentButton.BackgroundColor = Color.Teal;
                Editor.IsVisible = false;
                UpdateButton.IsVisible = false;
                Editor.Text = string.Empty;
            }
        }
    }
}
