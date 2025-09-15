using MyBlog.Service.Shared.Dtos.Queries;

namespace MyBlog.Web.Shared
{
    public partial class NavMenu
    {
        private bool hideChatBadge = false;

        protected override async Task OnInitializedAsync()
        {
        }

        private async void OnMenuClick(string menuCode)
        {
            if (menuCode == "chat")
            {
                hideChatBadge = true;
                StateHasChanged();
            }

            var queueClient = _queueService.GetQueueClient("click-menu");
            await queueClient.CreateIfNotExistsAsync();
            await queueClient.SendMessageAsync($"Clicked {menuCode}");
        }
    }
}
