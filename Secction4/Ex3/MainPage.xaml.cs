using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Ex3.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Ex3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<NewsItem> NewsItems;
        public MainPage()
        {
            this.InitializeComponent();
            my_Frame.Navigate(typeof(Financial));
            TitlePage.Text = "Financial";
            BackButton.Visibility = Visibility.Collapsed;
            NewsItems = new ObservableCollection<NewsItem>(); 

        }

        private void HamberButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void ListBox_Hamburger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(my_Frame.CanGoBack) BackButton.Visibility = Visibility.Visible;
            else BackButton.Visibility = Visibility.Collapsed;
            if (Financial.IsSelected)
            {
                my_Frame.Navigate(typeof(Financial));
                TitlePage.Text = "Financial";
            }
            if (Food.IsSelected)
            {
                my_Frame.Navigate(typeof(Food));
                TitlePage.Text = "Food";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(TitlePage.Text == "Financial")
            {
                my_Frame.Navigate(typeof(Food));
                TitlePage.Text = "Food";
            }
            else
            {
                my_Frame.Navigate(typeof(Financial));
                TitlePage.Text = "Financial";
            }
        }
    }
}
