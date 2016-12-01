namespace FabrikaFood.ViewModels
{
    //A view model for displaying list of comments.
    public class CommentViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string MenuItemId { get; set; }
        public string Content { get; set; }
        public bool ShowActions { get; set; }
    }
}
