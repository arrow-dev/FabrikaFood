namespace FabrikaFood.ViewModels
{
    public class CommentViewModel
    {
        public string UserId { get; set; }
        public string MenuItemId { get; set; }
        public string Content { get; set; }
        public bool ShowActions { get; set; }
    }
}
