using APppSql.DataAccess;
using APppSql.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace APppSql
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Contacts> DB_ContactList;
        public MainPage()
        {
            this.InitializeComponent();
            ReadContactList_Loaded();
        }

        private async void SubmitContact_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
            if (TxtName.Text != "" & TxtPhone.Text != "")
            {
                Db_Helper.Insert(new Contacts(TxtName.Text, TxtPhone.Text));
                MessageDialog messageDialog = new MessageDialog("Success");
                await messageDialog.ShowAsync();
                ReadContactList_Loaded();
            }
            else
            {
                MessageDialog messageDialog = new MessageDialog("Please fill two fields");
                await messageDialog.ShowAsync();
            }
        }
        private void ReadContactList_Loaded()
        {
            ReadAllContactsList dbcontacts = new ReadAllContactsList();
            DB_ContactList = dbcontacts.GetAllContacts();
            listBoxobj.ItemsSource = DB_ContactList.OrderByDescending(i => i.Id).ToList();
        }

        private void listBoxobj_ItemClick(object sender, ItemClickEventArgs e)
        {
            Contacts contact = (Contacts)e.ClickedItem;
            TxtName.Text = contact.Name;
            TxtPhone.Text = contact.PhoneNumber;
        }
    }
}
