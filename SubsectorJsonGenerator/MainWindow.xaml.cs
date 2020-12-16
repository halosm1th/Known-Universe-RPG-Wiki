using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using TravellerUniverse;

namespace SubsectorJsonGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<World> worlds = new List<World>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var name = Name.Text;
            var x = Convert.ToInt32(WorldX.Text);
            var y = Convert.ToInt32(WorldY.Text);

            var starportQuality = ((StarportQuality) StarportQuality.SelectedIndex);
            var worldSize = ((WorldSize) WorldSize.SelectedIndex);
            var atmosphere = ((WorldAtmosphere) WorldAtmosphere.SelectedIndex);
            var hydrographics = WorldHydrographics.SelectedIndex;
            var controllingGovernmentType = WorldPrimaryGov.SelectedIndex;
            var population = WorldPopulation.SelectedIndex;
            var exactPop = PopulationExact.Text;
            var lawLevel = WorldLawLevel.SelectedIndex;
            var techLevel = WorldTechLevel.SelectedIndex;

            var temperature = WorldTemperature.Text;
            var quirk = WorldQuirk.Text;
            var controllingGov = CurrentGovernment.Text;

            var factions = GetFactions();

            var fuelDepo = HasFuelDepo.IsChecked ?? false;
            var militaryBase = HasMilitaryBase.IsChecked ?? false;
            var otherBase = HasOtherBase.IsChecked ?? false;

            var world = new World(name,x,y,starportQuality,worldSize,atmosphere,
                hydrographics,controllingGovernmentType,population,lawLevel,techLevel,
                controllingGov,quirk,temperature,factions,
                militaryBase,fuelDepo,otherBase,exactPop);
            worlds.Add(world);

            Name.Text = "";
            WorldX.Text = "";
            WorldY.Text = "";

            StarportQuality.SelectedIndex = 0;
            WorldSize.SelectedIndex = 0;
            WorldAtmosphere.SelectedIndex = 0;
            WorldHydrographics.SelectedIndex = 0;
            WorldPrimaryGov.SelectedIndex = 0;
            WorldLawLevel.SelectedIndex = 0;
            WorldTechLevel.SelectedIndex = 0;

            WorldTemperature.SelectedIndex = 0;
            WorldQuirk.SelectedIndex = 0;
            CurrentGovernment.SelectedIndex = 0;

            HasGroup1.IsChecked = false; 
            Group1Backer.SelectedIndex = 0;
            Group1Size.SelectedIndex = 0;
            Group1Type.SelectedIndex = 0;

            HasGroup2.IsChecked = false;
            Group2Backer.SelectedIndex = 0;
            Group2Size.SelectedIndex = 0;
            Group2Type.SelectedIndex = 0;

            HasGroup3.IsChecked = false;
            Group3Backer.SelectedIndex = 0;
            Group3Size.SelectedIndex = 0;
            Group3Type.SelectedIndex = 0;

            HasFuelDepo.IsChecked = false;
            HasMilitaryBase.IsChecked = false;
            HasOtherBase.IsChecked = false;
        }

        private List<(string govType, string govSize, string backer)> GetFactions()
        {
            var factions = new List<(string, string, string)>();

            if (HasGroup1.IsChecked ?? false)
            {
                var type = Group1Type.Text;
                var size = Group1Size.Text;
                var backer = Group1Backer.Text;
                factions.Add((type,size,backer));
            }

            if (HasGroup2.IsChecked ?? false)
            {
                var type = Group2Type.Text;
                var size = Group2Size.Text;
                var backer = Group2Backer.Text;
                factions.Add((type, size, backer));
            }

            if (HasGroup3.IsChecked ?? false)
            {
                var type = Group3Type.Text;
                var size = Group3Size.Text;
                var backer = Group3Backer.Text;
                factions.Add((type, size, backer));
            }

            return factions;
        }

        private void Enable1(object sender, RoutedEventArgs e)
        {
            Group1Backer.IsEnabled = HasGroup1.IsChecked ?? false;
            Group1Size.IsEnabled = HasGroup1.IsChecked ?? false;
            Group1Type.IsEnabled = HasGroup1.IsChecked ?? false;
        }
        private void Enable2(object sender, RoutedEventArgs e)
        {
            Group2Backer.IsEnabled = HasGroup2.IsChecked ?? false;
            Group2Size.IsEnabled = HasGroup2.IsChecked ?? false;
            Group2Type.IsEnabled = HasGroup2.IsChecked ?? false;
        }
        private void Enable3(object sender, RoutedEventArgs e)
        {
            Group3Backer.IsEnabled = HasGroup3.IsChecked ?? false;
            Group3Size.IsEnabled = HasGroup3.IsChecked ?? false;
            Group3Type.IsEnabled = HasGroup3.IsChecked ?? false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var json = JsonConvert.SerializeObject(worlds);
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "";
            dialog.DefaultExt = ".json";
            dialog.Filter = "Json (.json) |*.json";
            var result = dialog.ShowDialog();

            if (result == true)
            {
                var fn = dialog.FileName;
                File.WriteAllText(fn, json);
            }

            Environment.Exit(0);
        }
    }
}
