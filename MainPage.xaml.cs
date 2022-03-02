using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static UWP.Model.Sound;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Sound> Sounds;
        private List<MenuItem> MenuItems;
        public MainPage()
        {
            this.InitializeComponent();
            Sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(Sounds);

            MenuItems = new List<MenuItem>();
            MenuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/animals.png",
                Category = SoundCategory.Animals
            });

            MenuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/cartoon.png",
                Category = SoundCategory.Cartoons
            });

            MenuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/taunt.png",
                Category = SoundCategory.Taunts
            });

            MenuItems.Add(new MenuItem
            {
                IconFile = "Assets/Icons/warning.png",
                Category = SoundCategory.Warnings
            });
            Back.Visibility = Visibility.Collapsed;


        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.GetAllSounds(Sounds);
            CategoryTextBlock.Text = "All Sounds";
            Menu.SelectedItem = null;
            Back.Visibility = Visibility.Collapsed;
        }

        private void Menu_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            CategoryTextBlock.Text = menuItem.Category.ToString();
            SoundManager.GetSoundByCategory(Sounds, menuItem.Category);
            Back.Visibility = Visibility.Visible;
        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound)e.ClickedItem;
            SoundMedia.Source = new Uri(BaseUri, sound.AudioFile);
            SoundMedia.AreTransportControlsEnabled = true;
            SoundMedia.TransportControls.IsCompact = true;
        }
    }
}
