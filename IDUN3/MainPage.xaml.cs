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
using static IDUN3.App;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IDUN3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();


            if (!(Application.Current as IDUN3.App).doInit)
            {
                (Application.Current as IDUN3.App).DisplayOptionsList.Add(new DisplayOption { Title = "Initialization", ClassType = typeof(InitPage) });
            }
             
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            DisplayListBox.ItemsSource = (Application.Current as IDUN3.App).DisplayOptionsList;
            if (Window.Current.Bounds.Width < 640)
            {
                DisplayListBox.SelectedIndex = -1;
                
            }
            else
            {
                DisplayListBox.SelectedIndex = 0;
            }
        }

        private void DisplayControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ListBox DisplayListBox = sender as ListBox;
            DisplayOption s = DisplayListBox.SelectedItem as DisplayOption;
            if (s != null)
            {
                var Config = (Application.Current as App).MeasurementConfiguration.Where(x => x.Measurement == s.Title).SingleOrDefault();
                DisplayFrame.Navigate(s.ClassType, Config);
            }
        }

        //public class DisplayBindingConverter : IValueConverter
        //{

        //    public object Convert(object value, Type targetType, object parameter, string language)
        //    {
        //        DisplayOption s = value as DisplayOption;
        //        return s.Title;

        //    }

        //    public object ConvertBack(object value, Type targetType, object parameter, string language)
        //    {
        //        return true;
        //    }
        //}

    }
}
