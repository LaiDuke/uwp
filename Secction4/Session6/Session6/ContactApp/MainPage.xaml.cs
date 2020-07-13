using ContactApp.Models;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ContactApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Contact> Contacts;
        public MainPage()
        {
            this.InitializeComponent();
            Contacts = new ObservableCollection<Contact>() {
                new Contact(){ FirstName="Dai",LastName="Ho"},
                new Contact(){ FirstName="Giang",LastName="Nguyen"},
                new Contact(){ FirstName="Tuan",LastName="Tran"},
                new Contact(){ FirstName="Tu",LastName="Ha"}
            };
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog message;
            if (FirstNameTextBox.Text == "")
            {
                message = new MessageDialog("Input first name!");
            }
            else if (LastNameTextBox.Text == "")
            {
                message = new MessageDialog("Input lastName!");
            }
            else
            {
                Contacts.Add(new Contact() { FirstName = FirstNameTextBox.Text, LastName = LastNameTextBox.Text });
                message = new MessageDialog("Them Thanh cong");
            }
            await message.ShowAsync();
        }
    }
}
