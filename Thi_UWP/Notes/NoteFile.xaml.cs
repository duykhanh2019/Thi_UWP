using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Thi_UWP.Notes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NoteFile : Page
    {
        public NoteFile()
        {
            this.InitializeComponent();

            string contentFile = DateTime.Now.ToString("yyyy-MM-dd-hh-mm");

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile tokenFile = storageFolder.CreateFileAsync(contentFile + ".txt", Windows.Storage.CreationCollisionOption.ReplaceExisting).GetAwaiter().GetResult();
            Windows.Storage.FileIO.WriteTextAsync(tokenFile, contentFile).GetAwaiter().GetResult();
            Debug.WriteLine(tokenFile.Path);

        }

        private void ReadNoteFile()
        {
           Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
           Windows.Storage.StorageFile tokenFile = storageFolder.CreateFileAsync("newFile.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting).GetAwaiter().GetResult();
           Windows.Storage.FileIO.ReadTextAsync(tokenFile).GetAwaiter().GetResult();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonRefresh_Onclick(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var files = storageFolder.GetFilesAsync().GetAwaiter().GetResult();
            Debug.WriteLine(files);
        }
    }
}
