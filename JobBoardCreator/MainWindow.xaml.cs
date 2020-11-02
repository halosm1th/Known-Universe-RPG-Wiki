using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using TravellerWiki.Data;

namespace JobBoardCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Jobs = new List<TravellerJobBoardJob>();
        }

        private List<TravellerJobBoardJob> Jobs;

        private void SaveList()
        {
            var converted = JsonConvert.SerializeObject(Jobs);
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "JobOffers";
            dialog.DefaultExt = ".json";
            dialog.Filter = "Json (.json) |*.json";
            var result = dialog.ShowDialog();

            if (result == true)
            {
                var fn = dialog.FileName;
                File.WriteAllText(fn,converted);
            }
        }

        private int ConvertInt(string ConvertName, string convertValue)
        {
            var couldParse = int.TryParse(convertValue,out var result);

            if (couldParse)
            {
                return result;
            }

            MessageBox.Show($"Error, incorrect {ConvertName}, saving with -1", $"Error, {ConvertName}", MessageBoxButton.OK,
                MessageBoxImage.Error);
            return -1;
        }

        private string GetSenderLocation()
        {
            return $"{SenderPlanetX.Text},{SenderPlanetY.Text}:{SenderSubsectorX.Text}'{SenderSubsectorY.Text}.{SenderSector.Text}";
        }

        private string GetIssuedDate()
        {
            var day = ConvertInt("Issue Day",IssueDay.Text);
            var month = ConvertInt("Issue Month",IssueMonth.Text);
            var year = ConvertInt("Issue Year",IssueYear.Text);
            return $"{day}/{month}/{year}";
        }

        private string GetExpiryDate()
        {
            var day = ConvertInt("Expiry Day", ExpiryDay.Text);
            var month = ConvertInt("Expiry Month", ExpiryMonth.Text);
            var year = ConvertInt("Expiry Year", ExpiryYear.Text);
            return $"{day}/{month}/{year}";
        }

        private TravellerJobBoardJob CreateJobPosting()
        {
            var jobPayment = ConvertInt("payment", Payment.Text);
            var accepted = ConvertInt("accepted", StartingAccepted.Text);
            var maxAccepted = ConvertInt("max accepted", MaximumAccepted.Text);
            var active = ConvertInt("active", NumberActive.Text);

            if (jobPayment < 0 || accepted < 0 || maxAccepted < 0 || active < 0)
            {
                throw new ArgumentException("Error, invalid argument");
            }

            var senderLocation = GetSenderLocation();
            var travellerJob = new TravellerJobBoardJob(Title.Text,Description.Text,jobPayment,
                accepted,maxAccepted,active,JobVisible.IsChecked ?? true,
                SenderName.Text,senderLocation,JobBoardOfferedOn.Text,GetExpiryDate(),GetIssuedDate(),
                Mission.Text,Patron.Text,Target.Text,Opposition.Text,PatronQuirk.Text,TargetQuirk.Text,
                Ally.Text,Enemy.Text);
            return travellerJob;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Jobs.Add(CreateJobPosting());
                AddList.Content = $"Add To List [{Convert.ToString(Jobs.Count)}]";

                ResetText();
            }
            catch (ArgumentException)
            {

            }
        }

        private void ResetText()
        {
            Title.Text = "";
            Description.Text = "";
            Payment.Text = "";
            StartingAccepted.Text = "";
            NumberActive.Text = "";
            MaximumAccepted.Text = "";
            JobVisible.IsChecked = true;
            SenderName.Text = "";
            SenderPlanetX.Text = "";
            SenderPlanetY.Text = "";
            SenderSubsectorX.Text = "";
            SenderSubsectorY.Text = "";
            IssueDay.Text = "";
            IssueMonth.Text = "";
            IssueYear.Text = "83390";
            ExpiryDay.Text = "";
            ExpiryMonth.Text = "";
            ExpiryYear.Text = "83390";
            
            Mission.Text = "";
            PatronQuirk.Text = "";
            TargetQuirk.Text = "";
            Target.Text = "";
            Patron.Text = "";
            Opposition.Text = "";
            Ally.Text = "";
            Enemy.Text = "";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveList();
            Environment.Exit(0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            var year = random.Next(83389, 83391);
            var month = random.Next(1, 13);
            var day = random.Next(1, 31);

            IssueDay.Text = Convert.ToString(day);
            IssueMonth.Text = Convert.ToString(month);
            IssueYear.Text = Convert.ToString(day);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            var year = random.Next(83390, 83399);
            var month = random.Next(5, 13);
            var day = random.Next(9, 31);

            ExpiryDay.Text = Convert.ToString(day);
            ExpiryMonth.Text = Convert.ToString(month);
            ExpiryYear.Text = Convert.ToString(day);
        }

        private (int x, int y) GenerateSubsector(Random random)
        {
            var x = random.Next(1, 5);
            var y = random.Next(1, 5);
            return (x, y);
        }

        private List<(int x, int y)>[,] Subsectors = new List<(int x, int y)>[,]
        {
            //Top row
            { 
                //Kendrick
                new List<(int x, int y)> {(1,1),(6,1),(8,1),(5,2),(7,2),(2,3),(5,3),(6,3),(6,3),(5,4),(7,4),(3,5),(6,5),(7,5),(8,5),(1,6),(5,6),(8,6),(4,7),(6,7),(2,8),(3,8),(4,8),(1,9),(2,9),(4,9),(6,9),(2,10),(6,10),(7,10)},
                //Wynona
                new List<(int x, int y)>{}, 
                //Olivehurst
                new List<(int x, int y)>{}, 
                //Payette
                new List<(int x, int y)>{},
            },
            //Second Row
            {
                //Oren Wastes 1
                new List<(int x, int y)>{},
                //Oren Wastes 2
                new List<(int x, int y)>{},
                //Oren Wastes 3
                new List<(int x, int y)>{},
                //Oren Wastes 4
                new List<(int x, int y)>{},
            },
            //Third row
            {
                //Doland
                new List<(int x, int y)>{},
                //New Islands
                new List<(int x, int y)>{},
                //Old Islands
                new List<(int x, int y)>{},
                //Stacyville
                new List<(int x, int y)>{},
            },
            //Fourth Row
            {
                //Intercourse
                new List<(int x, int y)>{},
                //Citra
                new List<(int x, int y)>{},
                //Wallwern
                new List<(int x, int y)>{},
                //Zaleski
                new List<(int x, int y)>{},
            },


        };

        private (int x, int y) GeneratePlanet((int x, int y) Subsector, Random random)
        {
            var subsector = Subsectors[Subsector.x, Subsector.y];
            var planet = random.Next(0, subsector.Count);
            return subsector[planet];
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            var subsector = GenerateSubsector(random);

            var planet = GeneratePlanet(subsector, random);

            SenderSubsectorX.Text = Convert.ToString(subsector.x);
            SenderSubsectorY.Text = Convert.ToString(subsector.y);

            SenderPlanetX.Text = Convert.ToString(planet.x);
            SenderPlanetY.Text = Convert.ToString(planet.y);
        }
    }
}
