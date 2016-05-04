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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IDUN3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InitPage : Page
    {
        public bool Pass;

        public InitPage()
        {
            this.InitializeComponent();
        }


        private void Save(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ObjectIDTB.Text)) { Pass = false; } else { Pass = true; }
            if (string.IsNullOrWhiteSpace(ObjectNameTB.Text)) { Pass = false; } else { Pass = true; }
            if (string.IsNullOrWhiteSpace(ObjectDescriptionTB.Text)) { Pass = false; } else { Pass = true; }
            if (string.IsNullOrWhiteSpace(MaintenanceOrgIDTB.Text)) { Pass = false; } else { Pass = true; }
            if (string.IsNullOrWhiteSpace(MaintenanceOrgNameTB.Text)) { Pass = false; } else { Pass = true; }
            if (string.IsNullOrWhiteSpace(SiteTB.Text)) { Pass = false; } else { Pass = true; }

            if (Pass == true)
            {
                var x = (Application.Current as IDUN3.App);

   

                x.DisplayOptionsList.Remove(x.DisplayOptionsList.Single(y => y.Title == "Initialization"));

                x.DisplayOptionsList.Add(new DisplayOption { Title = "Usage", ClassType = typeof(ConfigurationPages.ConfigurationPage), Enabled="-" });
                x.DisplayOptionsList.Add(new DisplayOption { Title = "Temperature", ClassType = typeof(ConfigurationPages.ConfigurationPage), Enabled = "-" });
                x.DisplayOptionsList.Add(new DisplayOption { Title = "Pressure", ClassType = typeof(ConfigurationPages.ConfigurationPage), Enabled = "-" });
                x.DisplayOptionsList.Add(new DisplayOption { Title = "Humidity", ClassType = typeof(ConfigurationPages.ConfigurationPage), Enabled = "-" });
                x.DisplayOptionsList.Add(new DisplayOption { Title = "Accelerometer", ClassType = typeof(ConfigurationPages.ConfigurationPage), Enabled = "-" });
                x.DisplayOptionsList.Add(new DisplayOption { Title = "Magnetometer", ClassType = typeof(ConfigurationPages.ConfigurationPage),Enabled = "-" });
                x.DisplayOptionsList.Add(new DisplayOption { Title = "Gyroscope", ClassType = typeof(ConfigurationPages.ConfigurationPage), Enabled = "-" });
                x.DisplayOptionsList.Add(new DisplayOption { Title = "Finalize", ClassType = typeof(ConfigurationPages.FinalizeConfiguration) });
            }

        }
    }
}
