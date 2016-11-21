using Microsoft.Azure.Mobile.Server;

namespace fabrikafoodService.DataObjects
{
    public class Comment:EntityData
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public string MenuItemId { get; set; }

        public virtual MenuItem MenuItem { get; set; }
    }
}