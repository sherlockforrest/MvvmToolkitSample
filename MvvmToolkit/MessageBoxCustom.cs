using System.Windows;

namespace MvvmToolkit
{
    internal class MessageBoxCustom : IMessageService
    {
        public void ShowMessage(object owner, string message)
        {
            MessageBox.Show(message);
        }
    }
}