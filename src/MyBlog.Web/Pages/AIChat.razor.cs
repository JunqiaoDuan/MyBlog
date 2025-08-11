using MudBlazor;

namespace MyBlog.Web.Pages
{
    public partial class AIChat
    {
        private string _enteredMessage { get; set; } = "";
        private MudTextField<string> multilineReference;

        private void SendMessage()
        {
            // Add logic to send message and update chat history
            _enteredMessage = "";
        }
    }
}
