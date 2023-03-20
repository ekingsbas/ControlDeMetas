using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;


namespace ControlDeMetas.Client.Pages
{
    public partial class Dialog
    {
        private bool _isDialogVisible = false;
        private string _dialogTitle = "Dialog Title";
        private string _dialogMessage = "Dialog Message";

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        private async Task ShowDialog()
        {
            _isDialogVisible = true;
            await JSRuntime.InvokeVoidAsync("showModal", "dialog-example");
        }

        private void CloseDialog(bool dialogResult)
        {
            _isDialogVisible = false;
            JSRuntime.InvokeVoidAsync("hideModal", "dialog-example", dialogResult);
        }
    }
}
