using MudBlazor;
using MyBlog.Service.Shared.Interfaces.AI.Model;

namespace MyBlog.Web.Pages
{
    public partial class AIChat
    {
        #region Property

        private string _enteredMessage { get; set; } = "";
        private string _selectedModel { get; set; } = "";
        private List<AIModel> _aiModels = [];

        #endregion

        #region Event

        protected override async Task OnInitializedAsync()
        {

            // data init
            await retrieveEnabledModels();
            await retrieveDefaultModel();

            await base.OnInitializedAsync();
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
                _selectedModel = model.Code;
            }
        }

        #endregion

    }
}
