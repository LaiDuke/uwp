using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private string fileName = "test.txt";
        private async void WriteFile_Click(object sender, RoutedEventArgs e)
        {
            var folder = ApplicationData.Current.LocalFolder;
            var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, TextTextBox.Text);
            TextTextBox.Text = "-";
            var message = new MessageDialog("Done bro!");
            await message.ShowAsync();
        }

        private async void ReadFile_Click(object sender, RoutedEventArgs e)
        {
            var folder = ApplicationData.Current.LocalFolder;
            var file = await folder.GetFileAsync(fileName);
            var text = await FileIO.ReadTextAsync(file);
            TextTextBox.Text = text;

        }

        private async void BtnImage_Click(object sender, RoutedEventArgs e)
        {
            var pictures = await KnownFolders.PicturesLibrary.GetFilesAsync();
            if (pictures.Any())
            {
                var pic = pictures[0];
                using (var fileStream = await pic.OpenAsync(FileAccessMode.Read)) 
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    await bitmapImage.SetSourceAsync(fileStream);
                    DisplayImage.Source = bitmapImage;
                }
            }    
        }

        private async void Pick_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;

            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
                using (var fileStream = await file.OpenAsync(FileAccessMode.Read))
                {

                BitmapImage bitmapImage = new BitmapImage();
                await bitmapImage.SetSourceAsync(fileStream);
                DisplayImage.Source = bitmapImage;
                TextTextBox.Text = "xem ảnh đi con";
            }
            else
            {
                TextTextBox.Text = "Operation cancelled.";
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var saveFile = new FileSavePicker()
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            saveFile.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            saveFile.SuggestedFileName = "New Document";
            var file = await saveFile.PickSaveFileAsync();
            if(){

            }
        }
    }
}
