using MyBlog.Service.Shared.Dtos.Queries;

namespace MyBlog.Web.Shared
{
    public partial class NavMenu
    {
        private ProfileQueryView? blogOwner;
        private bool hideChatBadge = false;

        protected override async Task OnInitializedAsync()
        {
            var profiles = await _profileService.GetProfilesAsync();
            blogOwner = profiles.FirstOrDefault(p => p.Name == "Name");
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
