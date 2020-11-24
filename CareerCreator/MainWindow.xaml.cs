using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

namespace CareerCreator
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

        private List<TravellerSkillCheck> _qualifications = new List<TravellerSkillCheck>();
        private TravellerCommission commission;
        private List<string> _AdvancedEducationSkillList;
        private List<string> _personelDevelopmentSkills;
        private List<string> _serviceSkillList;
        private List<(int Cash, string Benefit)> _musteringOutBenefits;
        private List<TravellerAssignment> _assignments = new List<TravellerAssignment>();

        private List<TravellerCharacterCreationEvent> _events;
        private List<TravellerCharacterCreationEvent> _mishaps;

        private TravellerCareer _career;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var qualificationDialog = new NewQualificationDialog();
            if (qualificationDialog.ShowDialog() == true)
            {
                var qualification = qualificationDialog.NewQualification;
                PreviousQualificationDisplay.Items.Add(qualification.ToString());
                _qualifications.Add(qualification);
            }
        }

        private void HasCommission_Checked(object sender, RoutedEventArgs e)
        {
            EditCommission.IsEnabled = HasCommission.IsChecked ?? false;
        }

        private void EditCommission_Click(object sender, RoutedEventArgs e)
        {
            var commissionDialog = new NewCommissionDialog();
            if (commissionDialog.ShowDialog() == true)
            {
                commission = commissionDialog.Commission;
            }
        }

        private void HasAdvancedEducation_Checked(object sender, RoutedEventArgs e)
        {
            EditEducation.IsEnabled = HasAdvancedEducation.IsChecked ?? false;
        }

        private void EditEducation_Click(object sender, RoutedEventArgs e)
        {
            var advancedEducationSkills= new GetSkillsDialog();
            if (_AdvancedEducationSkillList != null)
            {
                advancedEducationSkills.Skills = _AdvancedEducationSkillList;
            }
            if (advancedEducationSkills.ShowDialog() == true)
            {
                _AdvancedEducationSkillList = advancedEducationSkills.Skills;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var personalDevelopmentSkills = new GetSkillsDialog();
            if (_personelDevelopmentSkills != null)
            {
                personalDevelopmentSkills.Skills = _personelDevelopmentSkills;
            }
            if (personalDevelopmentSkills.ShowDialog() == true)
            {
                _personelDevelopmentSkills = personalDevelopmentSkills.Skills;
            }
        }

        private void ServiceSkillsButton_Click(object sender, RoutedEventArgs e)
        {
            var serviceSkillsDialog = new GetSkillsDialog();
            if (_serviceSkillList != null)
            {
                serviceSkillsDialog.Skills = _serviceSkillList;
            }
            if (serviceSkillsDialog.ShowDialog() == true)
            {
                _serviceSkillList = serviceSkillsDialog.Skills;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var musterOut = new MusteringOutBenefits();
            if (_musteringOutBenefits != null)
            {
                musterOut.Benefits = _musteringOutBenefits;
            }

            if (musterOut.ShowDialog() == true)
            {
                _musteringOutBenefits = musterOut.Benefits;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var eventsDialog = new EventsDialog();
            if (_events != null)
            {
                eventsDialog.Events = _events;
            }

            if (eventsDialog.ShowDialog() == true)
            {
                _events = eventsDialog.Events;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            var eventsDialog = new MishapTable();
            if (_mishaps != null)
            {
                eventsDialog.Mishaps = _mishaps;
            }

            if (eventsDialog.ShowDialog() == true)
            {
                _mishaps = eventsDialog.Mishaps;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (AssignmentCombo.SelectedIndex != 0)
            {
                var assignment =  (TravellerAssignment) AssignmentCombo.SelectionBoxItem;
                AssignmentCombo.SelectedIndex = 0;
                AssignmentCombo.Items.Remove(assignment);
                _assignments.Remove(assignment);
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var assigmentDialog = new AssignmentDialog();
            if (AssignmentCombo.SelectedIndex != 0)
            {
                assigmentDialog.Assignment= (TravellerAssignment) AssignmentCombo.SelectedItem;
            }

            if (assigmentDialog.ShowDialog() == true)
            {
                _assignments.Add(assigmentDialog.Assignment);
                AssignmentCombo.Items.Add(assigmentDialog.Assignment);
            }
        }

        private void CreateCareer()
        {
            var name = CareerName.Text;
            if (commission != null)
            {
                if (_AdvancedEducationSkillList != null)
                {

                    _career = new TravellerCareer(careerName: name,
                        CareerDescription.Text,
                        Nationality.Text,
                        qualifications: _qualifications,commission: commission,
                        assignments: _assignments,musteringOutBenefits: _musteringOutBenefits,
                        personalDevelopmentSkillList: _personelDevelopmentSkills,_serviceSkillList,
                        _AdvancedEducationSkillList,_events,_mishaps);
                }
                else
                {
                    _career = new TravellerCareer(name, CareerDescription.Text, 
                        Nationality.Text, _qualifications, _assignments, _musteringOutBenefits,
                        _personelDevelopmentSkills, _serviceSkillList, commission, _events, _mishaps);
                }
            }
            else
            {
                if (HasAdvancedEducation.IsChecked == true)
                {

                    _career = new TravellerCareer(name, CareerDescription.Text,
                        Nationality.Text, _qualifications, _assignments, _musteringOutBenefits,
                        _personelDevelopmentSkills, _serviceSkillList, _AdvancedEducationSkillList, _events, _mishaps);
                }
                else
                {
                    _career = new TravellerCareer(name, CareerDescription.Text,
                        Nationality.Text, _qualifications, _assignments, _musteringOutBenefits,
                        _personelDevelopmentSkills, _serviceSkillList, _events, _mishaps);

                }
            }

        }

        private void SaveCareer()
        {
            if (_career != null)
            {
                var convert = new TravellerCareerJson(
                    _career.CareerName, CareerDescription.Text, 
                    _career.Nationality.NationName,_career.Qualifications,
                    _career.Commission, _career.Assignments, _career.MusteringOutBenefits,
                    _career.PersonalDevelopmentSkillList,_career.ServiceSkillsList,
                    _career.AdvancedEducationSkillList,_career.Events,_career.Mishaps);
                var json = JsonConvert.SerializeObject(convert);

                var dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.FileName = CareerName.Text;
                dialog.DefaultExt = ".json";
                dialog.Filter = "Json (.json) |*.json";
                var result = dialog.ShowDialog();

                if (result == true)
                {
                    var fn = dialog.FileName;
                    File.WriteAllText(fn, json);
                }
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

            CreateCareer();
            SaveCareer();
            Environment.Exit(0);
        }

        private void BlankEverything()
        {
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            CreateCareer();
            SaveCareer();
        }
    }
}
