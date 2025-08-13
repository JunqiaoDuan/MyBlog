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
            if (string.IsNullOrWhiteSpace(_enteredMessage))
            {
                return;
            }

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
