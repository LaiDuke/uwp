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
using App1.Repository;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Sound> Sounds;
        private List<MenuItems> MenuItem;
        public MainPage()
        {
            this.InitializeComponent();
            Sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(Sounds);
        }

        private void HamberButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryTextBlock.Text = "All Sound";
            SoundManager.GetAllSounds(Sounds);
            BackButton.Visibility = Visibility.Collapsed;
            MenuItem = new List<MenuItems>();
            MenuItem.Add(new MenuItems("Assets/Icons/animals.png", SoundCategory.Animals));
            MenuItem.Add(new MenuItems("Assets/lcons/cartoon.png", SoundCategory.Cartoon));
            MenuItem.Add(new MenuItems("Assets/iconsitaunt.png", SoundCategory.Taunts));
            MenuItem.Add(new MenuItems("Assets/Icons/warning.png", SoundCategory.Warnings));
        }

        private void ListBox_Hamburger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private async void GridView_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Any())
                {
                    var storageFile = items[0] as StorageFile;
                    var fileType = storageFile.FileType;
                    StorageFolder folder = ApplicationData.Current.LocalFolder;
                    if(fileType.ToLower().EndsWith(".wav"))
                    {
                        StorageFile newFile = await storageFile.CopyAsync(folder, storageFile.Name, NameCollisionOption.GenerateUniqueName);
                        MyMedia.SetSource(await storageFile.OpenAsync(FileAccessMode.Read), fileType);
                        MyMedia.Play();
                    }
                }
            }
        }

        private void GridView_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
            e.DragUIOverride.Caption = "";
            e.DragUIOverride.IsCaptionVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsGlyphVisible = true;
        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
