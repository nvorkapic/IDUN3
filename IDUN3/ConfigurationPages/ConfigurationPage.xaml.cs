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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IDUN3.ConfigurationPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConfigurationPage : Page
    {
        public Configuration Config { get; set; }

        public ConfigurationPage()
        {
            this.InitializeComponent();

            EnableUsageThreshold.Checked += EnableUsageThreshold_Change;
            EnableUsageThreshold.Unchecked += EnableUsageThreshold_Change;

            EnableConfig.Checked += EnableConfig_Change;
            EnableConfig.Unchecked += EnableConfig_Change;
        }

        private void EnableConfig_Change(object sender, RoutedEventArgs e)
        {
            DefBtn.IsEnabled = !DefBtn.IsEnabled;
            if (ConfigurationPanel.Visibility == Visibility.Collapsed)
            {
                ConfigurationPanel.Visibility = Visibility.Visible;
            }
            else
            {
                ConfigurationPanel.Visibility = Visibility.Collapsed;
            }
            
        }

        private void EnableUsageThreshold_Change(object sender, RoutedEventArgs e)
        {
            ThresholdBottom.IsEnabled = !ThresholdBottom.IsEnabled;
            ThresholdCeiling.IsEnabled = !ThresholdCeiling.IsEnabled;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Config = e.Parameter as Configuration;
            this.DataContext = Config;

        }

        private void LoadDefaults(object sender, RoutedEventArgs e)
        {
            Config.Report = 1;
            Config.Interval = 1000;
            Config.Threshold = false;
            Config.ThresholdBottomValue = null;
            Config.ThresholdCeilingValue = null;

            IntervalSetting.Text = "1000";
            EnableUsageThreshold.IsChecked = Config.Threshold;
            ThresholdBottom.Text = "";
            ThresholdBottom.IsEnabled = false;
            ThresholdCeiling.Text = "";
            ThresholdCeiling.IsEnabled = false;
            FirstOptionReporting.IsChecked = true;

        }

        private void SaveDataBoxBot(object sender, RoutedEventArgs e)
        {
            Config.ThresholdBottomValue = double.Parse(ThresholdBottom.Text);
           
        }
        private void SaveDataBoxCei(object sender, RoutedEventArgs e)
        {
            Config.ThresholdCeilingValue = double.Parse(ThresholdCeiling.Text);

        }

        private void PanelOnLoad(object sender, RoutedEventArgs e)
        {
            if (Config.Enabled == true)
            {
                ConfigurationPanel.Visibility = Visibility.Visible;
            }
            else
            {
                ConfigurationPanel.Visibility = Visibility.Collapsed;
            }
        }
    }
}
