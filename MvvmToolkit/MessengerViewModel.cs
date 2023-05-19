using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace MvvmToolkit
{
    internal class MessengerViewModel :ObservableRecipient, IRecipient<InfoMessage>
    {
        //public MessengerViewModel()
        //{
        //    WeakReferenceMessenger.Default.Register(this);
        //    //WeakReferenceMessenger.Default.Register<Value>();
        //}
        public MessengerViewModel()
        {
            IsActive = true;
        }

        public void Receive(InfoMessage message)
        {
            MessageBox.Show($"{message.Date.ToShortDateString()},{message.Message}");
        }
    }
}
