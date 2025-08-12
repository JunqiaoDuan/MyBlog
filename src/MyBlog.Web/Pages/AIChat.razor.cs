using MudBlazor;

namespace MyBlog.Web.Pages
{
    public partial class AIChat
    {
        private string _enteredMessage { get; set; } = "";
        private string _selectedModel { get; set; } = "model1";
        private List<KeyValuePair<string, string>> _models = [
            new KeyValuePair<string, string>("model1", "model1"),
            new KeyValuePair<string, string>("model2", "model2"),
            new KeyValuePair<string, string>("model3sdfdsfsdf", "model3sdfdsfsdf"),
        ];

        private void SendMessage()
        {
            // Add logic to send message and update chat history
            _enteredMessage = "";
        }
    }
}
