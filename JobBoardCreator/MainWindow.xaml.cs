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
using ValidationResult = System.Printing.ValidationResult;

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
            missionGeerGeneratorService = new TravellerMissionGeneratorService();
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
            GenerateIssueDate();
        }

        private void GenerateIssueDate()
        {
            var random = new Random();
            var year = random.Next(83389, 83391);
            var month = random.Next(1, 13);
            var day = random.Next(1, 31);

            IssueDay.Text = Convert.ToString(day);
            IssueMonth.Text = Convert.ToString(month);
            IssueYear.Text = Convert.ToString(year);
        }

        private void GeneateExpiryDate()
        {
            var random = new Random();
            var year = random.Next(83390, 83399);
            var month = random.Next(5, 13);
            var day = random.Next(9, 31);

            ExpiryDay.Text = Convert.ToString(day);
            ExpiryMonth.Text = Convert.ToString(month);
            ExpiryYear.Text = Convert.ToString(year);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GeneateExpiryDate();
        }

        private (int x, int y) GenerateSubsector(Random random)
        {
            var x = random.Next(0, 4);
            var y = random.Next(0, 4);
            return (x, y);
        }

        private List<(int x, int y)>[,] Subsectors = new List<(int x, int y)>[,]
        {
            //Top row
            { 
                //Kendrick
                new List<(int x, int y)> {(1,1),(6,1),(8,1),(5,2),(7,2),(2,3),(5,3),(6,3),(6,3),(5,4),(7,4),(3,5),(6,5),(7,5),(8,5),(1,6),(5,6),(8,6),(4,7),(6,7),(2,8),(3,8),(4,8),(1,9),(2,9),(4,9),(6,9),(2,10),(6,10),(7,10)},
                //Wynona
                new List<(int x, int y)>{ (1,1),(6,1),(8,1),(1,2),(8,2),(4,3),(6,4),(7,4),(2,5),(3,5),(7,6),(2,7),(5,7),(8,7),(4,8),(6,8),(8,8),(1,10),(3,10),(4,9),(6,10),(7,10)}, 
                //Olivehurst
                new List<(int x, int y)>
                {
                    (1,1),(2,1),(6,1),(1,2),(7,2),(8,2),(1,3),(2,3),(4,3),(5,3),(6,3),(8,3),(6,4),(2,5),(5,5),(6,5),
                    (8,5),(2,6),(4,6),(3,7),(7,7),(4,7),(4,8),(7,8),(7,9),(3,10),(7,10)
                }, 
                //Payette
                new List<(int x, int y)>
                {
                    (5,1),(6,1),(6,2),(2,3),(3,4),(6,4),(1,5),(2,5),(5,6),
                    (7,6),(8,6),(3,7),(6,7),(8,7),(4,8),(5,8),(3,9),(4,9),
                    (8,9),(2,9),(6,10),(8,10),
                },
            },
            //Second Row
            {
                //Oren Wastes 1
                new List<(int x, int y)>
                {
                    (2,1),(4,1),(1,2),(3,2),(5,2),(7,2),(1,3),(8,2),(4,3),(5,3),
                    (6,3),(7,3),(8,3),(1,4),(2,4),(3,4),(4,4),(6,4),(8,4),(4,5),
                    (5,5),(6,5),(8,5),(3,6),(4,6),(7,6),(1,7),(2,7),(4,7),(7,7),
                    (8,7),(1,8),(2,8),(5,8),(6,8),(7,8),(6,9),(8,9),(5,10),(6,10),
                    (8,10)
                },
                //Oren Wastes 2
                new List<(int x, int y)>
                {
                    (1,1),(3,2),(4,2),(2,3),(4,3),(5,3),(8,3),(7,5),(6,5),(4,6),
                    (4,8),(4,9),(7,9),(5,10),
                },
                //Oren Wastes 3
                new List<(int x, int y)>{
                    (2,1),(7,1),(1,2),(5,2),(8,2),(2,3),(5,3),(7,3),(8,3),(3,4),
                    (5,4),(6,4),(3,5),(7,5),(1,6),(6,6),(1,7),(4,7),(5,7),(1,8),
                    (3,8),(5,8),(7,8),(1,9),(4,9),(6,9),(5,10),(6,10),

                },
                //Oren Wastes 4
                new List<(int x, int y)>
                {
                    (2,1),(3,1),(3,2),(7,2),(6,3),(5,4),(4,5),(1,6),(6,7),(7,7),
                    (4,9),(5,9),(6,9),(7,9),(7,10),(8,10)
                },
            },
            //Third row
            {
                //Doland
                new List<(int x, int y)>
                {
                    (5,1),(6,1),(3,2),(5,2),(7,2),(3,3),(5,3),(7,3),(3,4),(5,4),
                    (2,4),(6,4),(2,5),(8,5),(1,7),(2,7),(3,7),(5,7),(6,6),(8,7),
                    (3,8),(5,8),(8,8),(2,9),(3,9),(4,9),(6,9),(4,10),(6,10),(8,10),
                },
                //New Islands
                new List<(int x, int y)>
                {
                    (1,1),(8,1),(7,2),(3,3),(5,3),(1,5),(7,5),(1,6),(7,6),(6,6),
                    (5,7),(1,10),(2,10),(6,9),(8,8),
                },
                //Old Islands
                new List<(int x, int y)>
                {
                    (2,2),(3,3),(5,3),(7,2),(1,4),(7,4),(8,3),(3,5),(6,5),(7,5),
                    (4,6),(1,9),
                },
                //Stacyville
                new List<(int x, int y)>
                {
                    (2,1),(5,1),(7,2),(1,3),(3,3),(4,3),(7,3),(3,4),(6,3),(7,4),
                    (5,5),(7,5),(3,6),(2,6),(2,7),(3,7),(8,7),(7,8),(6,8),(8,8),
                    (8,9),(1,9),(2,9),(2,10),(4,9),(6,10),
                },
            },
            //Fourth Row
            {
                //Intercourse
                new List<(int x, int y)>
                {
                    (2,2),(1,3),(8,3),(2,4),(4,5),(7,6),(8,6),(7,7),(4,7),(7,8),
                    (2,8),(7,9),(2,9),(1,10),(2,10),(6,10),(8,10),
                },
                //Citra
                new List<(int x, int y)>
                {
                    (2,1),(4,1),(6,1),(7,1),(3,2),(4,2),(6,2),(3,3),(5,3),(3,4),
                    (4,4),(7,4),(1,5),(4,5),(5,5),(6,5),(7,6),(1,7),(5,8),(4,9),
                    (1,10),
                },
                //Wallwern
                new List<(int x, int y)>
                {
                    (1,1),(2,1),(4,2),(6,1),(5,3),(6,3),(7,3),(1,4),(3,4),(1,5),
                    (3,5),(3,6),(2,6),(3,7),(5,7),(8,6),(4,8),(2,9),(3,9),(4,9),
                    (6,8),(7,8),(4,10),(5,10),
                },
                //Zaleski
                new List<(int x, int y)>
                {
                    (4,1),(7,1),(3,2),(8,2),(6,3),(8,3),(5,4),(6,4),(7,4),(8,4),
                    (2,5),(3,5),(4,5),(6,5),(7,5),(3,6),(4,6),(6,7),(7,8),(8,7),
                    (5,9),
                },
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
            GenerateXY();
        }

        private void GenerateXY()
        {
            var random = new Random();
            var subsector = GenerateSubsector(random);

            var planet = GeneratePlanet(subsector, random);
            subsector = (subsector.x + 1, subsector.y + 1);

            SenderSubsectorX.Text = Convert.ToString(subsector.x);
            SenderSubsectorY.Text = Convert.ToString(subsector.y);

            SenderPlanetX.Text = Convert.ToString(planet.x);
            SenderPlanetY.Text = Convert.ToString(planet.y);
        }

        private TravellerMissionGeneratorService missionGeerGeneratorService;

        private void GenerateMission()
        {
            var mission = missionGeerGeneratorService.GenerateTravellerMission();
            Mission.Text = mission.Mission;
            Ally.Text = mission.Ally;
            Enemy.Text = mission.Enemy;
            Patron.Text = mission.Patron;
            PatronQuirk.Text = mission.PatronQuirk;
            Target.Text = mission.Target;
            TargetQuirk.Text = mission.TargetQuirk;
            Opposition.Text = mission.Opposition;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            GenerateMission();
        }

        private void GeneratePayment()
        {
            var payment = new Random();
            Payment.Text = $"{payment.Next(1000,1000000000)}Cr";
        }

        private void GenerateCurrentActives(int numberAccepted)
        {
            var rand = new Random();
            NumberActive.Text = Convert.ToString(rand.Next(0, numberAccepted));
        }

        private int GenerateCurrentAccepts(int maxAccepts)
        {
            var rand = new Random();
            var numb = rand.Next(0, maxAccepts);
            StartingAccepted.Text = Convert.ToString(numb);

            return numb;
        }

        private int GenerateMaxAccepts()
        {
            var rand = new Random();
            var numb = rand.Next(1, 1025);
            MaximumAccepted.Text = Convert.ToString(numb);

            return numb;
        }

        private void GenerateAllActives()
        {
            var max = GenerateMaxAccepts();
            var currentAccepts = GenerateCurrentAccepts(max);
            GenerateCurrentActives(currentAccepts);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            GenerateMission();
            GenerateXY();
            GenerateIssueDate();
            GeneateExpiryDate();
            GeneratePayment();
            GenerateAllActives();
        }
    }
}
