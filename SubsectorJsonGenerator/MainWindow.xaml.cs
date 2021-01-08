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
            if (Name.Text != "")
            {
                var world = GetWorld();
                AddWorldToList(world);

                ResetFields();
                AddButton.Content = $"Save Planet To Subsector list and reset ({worlds.Count})";
            }
        }

        private World GetWorld()
        {
            var name = Name.Text ?? "";
            var x = Convert.ToInt32(WorldX.Text ?? "0");
            var y = Convert.ToInt32(WorldY.Text ?? "0");

            var starportQuality = ((StarportQuality) StarportQuality.SelectedIndex+10);
            var worldSize = ((WorldSize) WorldSize.SelectedIndex);
            var atmosphere = ((WorldAtmosphere) WorldAtmosphere.SelectedIndex);
            var hydrographics = WorldHydrographics.SelectedIndex;
            var controllingGovernmentType = WorldPrimaryGov.SelectedIndex;
            var population = WorldPopulation.SelectedIndex;
            var lawLevel = WorldLawLevel.SelectedIndex;
            var techLevel = WorldTechLevel.SelectedIndex;

            var temperature = (Temperatures) WorldTemperature.SelectedIndex;
            var exactPop = PopulationExact.Text ?? "0";
            var quirk = (Quirks) WorldQuirk.SelectedIndex;
            var controllingGov = CurrentGovernment.Text ?? "0";

            var factions = GetFactions();

            var fuelDepo = HasFuelDepo.IsChecked ?? false;
            var militaryBase = HasMilitaryBase.IsChecked ?? false;
            var otherBase = HasOtherBase.IsChecked ?? false;

            var world = new World(name, x, y, starportQuality, worldSize, atmosphere,
                hydrographics, controllingGovernmentType, population, lawLevel, techLevel,
                controllingGov, quirk, temperature, factions,
                militaryBase, fuelDepo, otherBase, exactPop);

            return world;
        }

        private void AddWorldToList(World world)
        {
            if (worlds.Any(x => x.Name == world.Name))
            {
                var oldWorld = worlds.First(x => x.Name == world.Name);
                worlds.Remove(oldWorld);
                WorldsDropdown.Items.Remove(oldWorld);
            }

            worlds.Add(world);
            WorldsDropdown.Items.Add(world);
        }

        private void SetFields(World world)
        {
            Name.Text = world.Name;
            WorldX.Text = world.X.ToString();
            WorldY.Text = world.Y.ToString();

            StarportQuality.SelectedIndex = ((int) world.StarportQuality)-10;
            WorldSize.SelectedIndex = (int) world.WorldSize;
            WorldAtmosphere.SelectedIndex = (int) world.WorldAtmosphere;
            WorldHydrographics.SelectedIndex = world.WorldHydrographics;
            WorldPrimaryGov.SelectedIndex = world.GovernmentType;
            WorldLawLevel.SelectedIndex = world.LawLevel;
            WorldTechLevel.SelectedIndex = world.TechLevel;

            WorldPopulation.SelectedIndex = world.PopulationStat;
            PopulationExact.Text = world.Population;

            WorldTemperature.SelectedIndex = (int) world.Temperature;
            WorldQuirk.SelectedIndex = (int) world.Quirk;
            CurrentGovernment.SelectedIndex = 0;

            var factions = world.Factions;

            //If it has at least 1 item
            if (factions.Count > 0)
            {
                var faction = factions[0];
                HasGroup1.IsChecked = true;
                Group1Backer.SelectedIndex = 0; //Always default to backer 0 rn.
                Group1Size.SelectedIndex = (int) faction.Strength;
                Group1Type.SelectedIndex = faction.GovernmentType;
            }
            else
            {
                HasGroup1.IsChecked = false;
                Group1Backer.SelectedIndex = 0;
                Group1Size.SelectedIndex = 0;
                Group1Type.SelectedIndex = 0;
            }

            //If it has 2 factions
            if (factions.Count > 1)
            {
                var faction = factions[1];
                HasGroup2.IsChecked = true;
                Group2Backer.SelectedIndex = 0; //Always default to backer 0 rn.
                Group2Size.SelectedIndex = (int)faction.Strength;
                Group2Type.SelectedIndex = faction.GovernmentType;
            }
            else
            {
                HasGroup2.IsChecked = false;
                Group2Backer.SelectedIndex = 0;
                Group2Size.SelectedIndex = 0;
                Group2Type.SelectedIndex = 0;
            }

            //If it has 3 factions
            if (factions.Count > 2)
            {
                var faction = factions[2];
                HasGroup3.IsChecked = true;
                Group3Backer.SelectedIndex = 0; //Always default to backer 0 rn.
                Group3Size.SelectedIndex = (int)faction.Strength;
                Group3Type.SelectedIndex = faction.GovernmentType;
            }
            else
            {
                HasGroup3.IsChecked = false;
                Group3Backer.SelectedIndex = 0;
                Group3Size.SelectedIndex = 0;
                Group3Type.SelectedIndex = 0;
            }

            HasFuelDepo.IsChecked = world.GasGiant;
            HasMilitaryBase.IsChecked = world.MilitaryBase;
            HasOtherBase.IsChecked = world.OtherBase;
        }

        private void ResetFields()
        {
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

            WorldPopulation.SelectedIndex = 0;
            PopulationExact.Text = "";

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

        private List<(int govType, FactionSize govSize, string backer)> GetFactions()
        {
            var factions = new List<(int, FactionSize, string)>();

            if (HasGroup1.IsChecked ?? false)
            {
                var type = Group1Type.SelectedIndex;
                var size = (FactionSize) Group1Size.SelectedIndex;
                var backer = Group1Backer.Text;
                factions.Add((type,size,backer));
            }

            if (HasGroup2.IsChecked ?? false)
            {
                var type = Group2Type.SelectedIndex;
                var size = (FactionSize)Group2Size.SelectedIndex;
                var backer = Group2Backer.Text;
                factions.Add((type, size, backer));
            }

            if (HasGroup3.IsChecked ?? false)
            {
                var type = Group3Type.SelectedIndex;
                var size = (FactionSize)Group3Size.SelectedIndex;
                var backer = Group3Backer.Text;
                factions.Add((type, size, backer));
            }

            return factions;
        }

        private void GenreateFromButton(object sender, RoutedEventArgs e)
        {
            var UWPdialog = new FromUWPDialog();
            if (UWPdialog.ShowDialog() == true)
            {
                Name.Text = UWPdialog.Name;
                WorldX.Text = UWPdialog.X;
                WorldY.Text = UWPdialog.Y;

                StarportQuality.SelectedIndex = UWPdialog.Starport-10;
                WorldSize.SelectedIndex = UWPdialog.Size;
                WorldAtmosphere.SelectedIndex = UWPdialog.Atmo;
                WorldHydrographics.SelectedIndex = UWPdialog.Hydro;
                WorldPopulation.SelectedIndex = UWPdialog.Pop;
                WorldPrimaryGov.SelectedIndex = UWPdialog.Gov;
                WorldLawLevel.SelectedIndex = UWPdialog.Law;
                WorldTechLevel.SelectedIndex = UWPdialog.Tech;
            }
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SavedFile())
                MessageBox.Show("File Save successfully", "Saved Successfully", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
        }

        private bool SavedFile()
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "";
            dialog.DefaultExt = ".json";
            dialog.Filter = "Json (.json) |*.json";
            var result = dialog.ShowDialog();

            if (result == true)
            {
                var fn = dialog.FileName;
                var subName = dialog.SafeFileName;
                var subsector = new Subsector(subName.Remove(subName.IndexOf(".json", StringComparison.Ordinal)), worlds);

                var json = JsonConvert.SerializeObject(subsector);
                File.WriteAllText(fn, json);
                return true;
            }

            return false;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(SavedFile()) Environment.Exit(0);
        }

        private void WorldsDropdown_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Name.Text != "")
            {
                var world = GetWorld();
                if (!worlds.Contains(world))
                {
                    AddWorldToList(world);
                }
            }

            //If any of the worlds in the list have the same name as this planet, remove that planet and then add this one.
            try
            {
                if (WorldsDropdown.SelectedIndex != 0)
                {
                    var newWorld = worlds[WorldsDropdown.SelectedIndex-1];

                    //Save the current world if its been entered
                    SetFields(newWorld);
                }
                else
                {
                    ResetFields();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DeleteEntry_OnClick(object sender, RoutedEventArgs e)
        {
            if (WorldsDropdown.SelectedIndex > 0 && worlds.Count > 0)
            {
                //Wipe the fields out
                ResetFields();
                
                var index = WorldsDropdown.SelectedIndex - 1;
                worlds.RemoveAt(index);
                AddButton.Content = $"Save Planet To Subsector list and reset ({worlds.Count})";

                //This will call the change selected item thing
                WorldsDropdown.Items.RemoveAt(WorldsDropdown.SelectedIndex);
            }
        }
    }
}
