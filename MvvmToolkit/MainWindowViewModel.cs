namespace MvvmToolkit;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string name;


    private bool CanSend(string message)
    {
        return !string.IsNullOrEmpty(message);
    }

    //[RelayCommand]
    //private void CreateReceive()
    //{
    //    viewModel = new MessengerViewModel();
    //}

    [RelayCommand(IncludeCancelCommand = true)]
    private async Task<string> Load(CancellationToken token)
    {
        try
        {
            await Task.Delay(TimeSpan.FromSeconds(3), token);
            return "Load Success";
        }
        catch (Exception e)
        {
            return "Load Cancel";
        }
        
        
    }

    [RelayCommand(CanExecute = nameof(CanSend))]
    private void Send(string message)
    {
        WeakReferenceMessenger.Default.Send(new InfoMessage
        {
            Date = DateTime.Now,
            Message = message

        });
    }
}