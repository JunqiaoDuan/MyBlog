using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MyBlog.Service.Shared.Interfaces.AI.Model;
using OpenAI.Chat;

namespace MyBlog.Web.Pages
{
    public partial class AIChat
    {
        #region Property

        private string _enteredMessage { get; set; } = "";
        private AIModel? _selectedModel { get; set; }
        private List<AIModel> _aiModels = [];

        private List<AIChatMessage> _aiChatMessages = [];

        private static readonly Queue<DateTime> _sendTimestamps = new();
        private static readonly object _sendLock = new();

        #endregion

        #region Event

        protected override async Task OnInitializedAsync()
        {

            // data init
            await retrieveEnabledModels();
            await retrieveDefaultModel();

            await base.OnInitializedAsync();
        }

        private async Task OnKeyDown(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await OnSendMessageClicked();
            }
        }

        private async Task OnSendMessageClicked()
        {
            if (!CanSendMessage())
            {
                _aiChatMessages.Add(AIChatMessage.CreateAssistantMessage("You can only send 2 messages per minute. Please wait."));
                StateHasChanged();
                return;
            }

            if (string.IsNullOrWhiteSpace(_enteredMessage))
            {
                return;
            }

            _sendTimestamps.Enqueue(DateTime.UtcNow);

            _aiChatMessages.Add(AIChatMessage.CreateUserMessage(_enteredMessage));

            try
            {
                if (_selectedModel == null)
                {
                    throw new Exception("Please select Model");
                }

                var _aiService = _aiServiceFactory.GetService(_selectedModel.Provider);
                if (_aiService == null)
                {
                    _aiChatMessages.Add(AIChatMessage.CreateAssistantMessage("AI service not found."));
                    return;
                }

                _enteredMessage = "";

                await _aiService.ChatAsync(_aiChatMessages, _selectedModel.Code);
                StateHasChanged();

            }
            catch (Exception ex)
            {
                _aiChatMessages.Add(AIChatMessage.CreateAssistantMessage($"Error: {ex.Message}"));
                return;
            }
        }

        #endregion

        #region Private method

        private bool CanSendMessage()
        {
            var now = DateTime.UtcNow;
            lock (_sendLock)
            {
                while (_sendTimestamps.Count > 0 && (now - _sendTimestamps.Peek()).TotalSeconds > 60)
                {
                    _sendTimestamps.Dequeue();
                }
                return _sendTimestamps.Count < 2;
            }
        }

        private async Task retrieveEnabledModels()
        {
            var models = await _aiModelService.GetAllEnableModelsAsync();
            _aiModels = models;
        }

        private async Task retrieveDefaultModel()
        {
            var model = await _aiModelService.GetDefaultModel("");
            if (model != null)
            {
                _selectedModel = model;
            }
        }

        #endregion

    }
}
