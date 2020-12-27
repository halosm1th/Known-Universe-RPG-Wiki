using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using TravellerWiki.Data;

namespace CareerCreator
{
    /// <summary>
    /// Interaction logic for CareerCreatorMainWindow.xaml
    /// </summary>
    public partial class CareerCreatorMainWindow : Window
    {
        public CareerCreatorMainWindow()
        {
            InitializeComponent();
        }


        private List<TravellerSkillCheck> _qualifications = new List<TravellerSkillCheck>();
        private TravellerSkillCheck _commissionCheck;
        private List<TravellerAssignment> assignments = new List<TravellerAssignment>()
        {
            new TravellerAssignment("","", new TravellerSkillCheck("Str",8), new TravellerSkillCheck("Str",8),
                new List<string>(),new List<(string,TravellerCharacterCreationReward)>()),
            new TravellerAssignment("","", new TravellerSkillCheck("Str",8), new TravellerSkillCheck("Str",8),
                new List<string>(),new List<(string,TravellerCharacterCreationReward)>()),
            new TravellerAssignment("","", new TravellerSkillCheck("Str",8), new TravellerSkillCheck("Str",8),
                new List<string>(),new List<(string,TravellerCharacterCreationReward)>()),
        };

        private List<(string, TravellerCharacterCreationReward)> _commissionRanksAndBonuses = new List<(string, TravellerCharacterCreationReward)>();
        private TravellerCharacterCreationReward[] _benefits = new TravellerCharacterCreationReward[7];

        private TravellerCharacterCreationEvent[] events = new TravellerCharacterCreationEvent[12]
        {
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent("Life Event. Roll on the Life Events Table."),
            new TravellerCharacterCreationEvent(),
            new TravellerCharacterCreationEvent(),
            new TravellerCharacterCreationEvent(),
            new TravellerCharacterCreationEvent(),
            new TravellerCharacterCreationEvent(),
            new TravellerCharacterCreationEvent()
        };
        private TravellerCharacterCreationEvent[] mishaps = new TravellerCharacterCreationEvent[]
        {
            new TravellerCharacterCreationEvent("Severely injured (this is the same as a result of 2 on the Injury Table). Alternatively, roll twice on the Injury Table and take the lower result."),
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent("Injured. Roll on the Injury Table.")
        };

        private int previousIndex = 0;

        private void Qualification_Click(object sender, RoutedEventArgs e)
        {
            var qualificationDialog = new NewQualificationDialog();
            if (qualificationDialog.ShowDialog() == true)
            {
                var qualification = qualificationDialog.NewQualification;
                PreviousQualificationDisplay.Items.Add(qualification.ToString());
                _qualifications.Add(qualification);
            }
        }

        private TravellerSkillCheck GetTravellerSkillCheck()
        {
            var quaDialog = new NewQualificationDialog();
            if (quaDialog.ShowDialog() == true)
            {
                return quaDialog.NewQualification;
            }

            return null;
        }

        #region FirstAssignment
        private void ChosenAssignment_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FirstAssignmentName != null)
            {
                //Save the old Assignment
                assignments[previousIndex].Name = FirstAssignmentName.Text ?? "";
                assignments[previousIndex].Description = FirstAssignmentDescription.Text ?? "";

                previousIndex = ChosenAssignment.SelectedIndex;

                //Show the new one!
                FirstAssignmentName.Text = assignments[previousIndex].Name;
                FirstAssignmentDescription.Text = assignments[previousIndex].Description;
            }
        }

        private void FirstSurvival_Click(object sender, RoutedEventArgs e)
        {
            assignments[ChosenAssignment.SelectedIndex].Survival = GetTravellerSkillCheck();
        }

        private void FirstAdvance_Click(object sender, RoutedEventArgs e)
        {
            assignments[ChosenAssignment.SelectedIndex].Advancement = GetTravellerSkillCheck();
        }
        
        private void FirstSkillList_Click(object sender, RoutedEventArgs e)
        {

            var SkillsDialog = new GetSkillsDialog();
            if (assignments[ChosenAssignment.SelectedIndex].SkillList != null)
            {
                SkillsDialog.Skills = assignments[ChosenAssignment.SelectedIndex].SkillList;
            }

            if (SkillsDialog.ShowDialog() == true)
            {
                assignments[ChosenAssignment.SelectedIndex].SkillList = SkillsDialog.Skills;
            }
        }

        private void FirstRankAndBonus_Click_1(object sender, RoutedEventArgs e)
        {
            var ranksDialog = new RanksAndBonusesDialog();
            if (assignments[ChosenAssignment.SelectedIndex].RanksAndBonuses != null)
            {
                ranksDialog.RanksAndBonuses = assignments[ChosenAssignment.SelectedIndex].RanksAndBonuses;
            }

            if (ranksDialog.ShowDialog() == true)
            {
                assignments[ChosenAssignment.SelectedIndex].RanksAndBonuses = ranksDialog.RanksAndBonuses;
            }
        }
        #endregion

        private void Commission_Click(object sender, RoutedEventArgs e)
        {
            CommissionSkill1.IsReadOnly = !CommissionCheck.IsChecked ?? true;
            CommissionSkill2.IsReadOnly = !CommissionCheck.IsChecked ?? true;
            CommissionSkill3.IsReadOnly = !CommissionCheck.IsChecked ?? true;
            CommissionSkill4.IsReadOnly = !CommissionCheck.IsChecked ?? true;
            CommissionSkill5.IsReadOnly = !CommissionCheck.IsChecked ?? true;
            CommissionSkill6.IsReadOnly = !CommissionCheck.IsChecked ?? true;

            CommissionQualification.IsEnabled = CommissionCheck.IsChecked ?? false;
            CommissionRanks.IsEnabled = CommissionCheck.IsChecked ?? false;
        }

        private void AdvancedEducation_Click(object sender, RoutedEventArgs e)
        {
            AdvancedEducationSkill1.IsReadOnly = !EducationCheck.IsChecked ?? true;
            AdvancedEducationSkill2.IsReadOnly = !EducationCheck.IsChecked ?? true;
            AdvancedEducationSkill3.IsReadOnly = !EducationCheck.IsChecked ?? true;
            AdvancedEducationSkill4.IsReadOnly = !EducationCheck.IsChecked ?? true;
            AdvancedEducationSkill5.IsReadOnly = !EducationCheck.IsChecked ?? true;
            AdvancedEducationSkill6.IsReadOnly = !EducationCheck.IsChecked ?? true;
        }

        private void CommissionQualification_Click(object sender, RoutedEventArgs e)
        {
            _commissionCheck = GetTravellerSkillCheck();
        }

        private void CommissionRanks_Click(object sender, RoutedEventArgs e)
        {
            var ranksDialog = new RanksAndBonusesDialog();
            if (_commissionRanksAndBonuses != null)
            {
                ranksDialog.RanksAndBonuses = _commissionRanksAndBonuses;
            }

            if (ranksDialog.ShowDialog() == true)
            {
                _commissionRanksAndBonuses = ranksDialog.RanksAndBonuses;
            }
        }

        private void EditEvent(int index)
        {
            var creationEvent = new EventEditingDialog();
            if (events[index] != null)
            {
                creationEvent.CharacterCreationEvent = events[index];
            }
            if (creationEvent.ShowDialog() == true)
            {
                events[index] = creationEvent.CharacterCreationEvent;
            }
        }


        private void EditMishap(int index)
        {
            var creationEvent = new EventEditingDialog();
            if (mishaps[index] != null)
            {
                creationEvent.CharacterCreationEvent = mishaps[index];
            }
            if (creationEvent.ShowDialog() == true)
            {
                mishaps[index] = creationEvent.CharacterCreationEvent;
            }
        }

        private void GetBenefit(int index)
        {
            var rewardDialog = new CharacterCreationRewardType();
            if (_benefits[index] != null)
            {
                rewardDialog.Reward = _benefits[index];
            }

            if (rewardDialog.ShowDialog() == true)
            {
                _benefits[index] = rewardDialog.Reward;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetBenefit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GetBenefit(1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GetBenefit(2);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GetBenefit(3);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            GetBenefit(4);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            GetBenefit(5);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            GetBenefit(6);
        }


        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            EditEvent(0);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            EditEvent(1);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            EditEvent(2);

        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            EditEvent(3);

        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            EditEvent(4);

        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            EditEvent(6);

        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            EditEvent(7);

        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            EditEvent(8);

        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            EditEvent(9);

        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            EditEvent(10);

        }

        private void Mishap2_Click(object sender, RoutedEventArgs e)
        {
            EditMishap(1);
        }

        private void Mishap3_Click(object sender, RoutedEventArgs e)
        {
            EditMishap(2);

        }

        private void Mishap4_Click(object sender, RoutedEventArgs e)
        {
            EditMishap(3);

        }

        private void Mishap5_Click(object sender, RoutedEventArgs e)
        {
            EditMishap(4);

        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            var commission = new TravellerCommission();
            GetCommission(commission);

            assignments = assignments.Select(assignment =>
            {
                assignment.RanksAndBonuses = assignment.RanksAndBonuses.Select(rab =>
                {
                    if (rab.title == null)
                    {
                        rab.title = "";
                    }

                    if (rab.TravellerCharacterCreationReward == null)
                    {
                        rab.TravellerCharacterCreationReward = new TravellerOtherReward("");
                    }

                    return rab;
                }).ToList();

                return assignment;
            }).ToList();

            var travCareer = new TravellerCareerJson(
                CareerName.Text,CareerDescription.Text,((string) Nationality.SelectionBoxItem),
                _qualifications, commission,
                assignments,GetBenefts(),
                GetPersonalSkills(),GetServiceSkills(),GetAdvanceEducationSkills(),events.ToList(),mishaps.ToList());

            var json = JsonConvert.SerializeObject(travCareer);

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

            Environment.Exit(0);
        }

        private List<string> GetPersonalSkills()
        {
            var skills = new List<string>();
            skills.Add(PersonalDevelopmentSkill1.Text);
            skills.Add(PersonalDevelopmentSkill2.Text);
            skills.Add(PersonalDevelopmentSkill3.Text);
            skills.Add(PersonalDevelopmentSkill4.Text);
            skills.Add(PersonalDevelopmentSkill5.Text);
            skills.Add(PersonalDevelopmentSkill6.Text);

            return skills;
        }


        private List<string> GetAdvanceEducationSkills()
        {
            var skills = new List<string>();
            if (EducationCheck.IsChecked == true)
            {
                skills.Add(AdvancedEducationSkill1.Text);
                skills.Add(AdvancedEducationSkill2.Text);
                skills.Add(AdvancedEducationSkill3.Text);
                skills.Add(AdvancedEducationSkill4.Text);
                skills.Add(AdvancedEducationSkill5.Text);
                skills.Add(AdvancedEducationSkill6.Text);
            }

            return skills;
        }

        private List<string> GetServiceSkills()
        {
            var skills = new List<string>();
            skills.Add(ServiceSkill1.Text);
            skills.Add(ServiceSkill2.Text);
            skills.Add(ServiceSkill3.Text);
            skills.Add(ServiceSkill4.Text);
            skills.Add(ServiceSkill5.Text);
            skills.Add(ServiceSkill6.Text);

            return skills;

        }

        private List<(int cash, 
            TravellerCharacterCreationReward reward)> GetBenefts()
        {
            var benefits = new List<(int cash, TravellerCharacterCreationReward reward)>();

            benefits.Add((Convert.ToInt32(Cash1.Text),_benefits[0]));
            benefits.Add((Convert.ToInt32(Cash2.Text),_benefits[1]));
            benefits.Add((Convert.ToInt32(Cash3.Text),_benefits[2]));
            benefits.Add((Convert.ToInt32(Cash4.Text),_benefits[3]));
            benefits.Add((Convert.ToInt32(Cash5.Text),_benefits[4]));
            benefits.Add((Convert.ToInt32(Cash6.Text),_benefits[5]));
            benefits.Add((Convert.ToInt32(Cash7.Text),_benefits[6]));

            return benefits;
        }

        private void GetCommission(TravellerCommission commission)
        {
            if (CommissionCheck.IsChecked == true)
            {
                commission.RanksAndBonuses = _commissionRanksAndBonuses;
                commission.CommissionSkillList = new List<string>()
                {
                    CommissionSkill1.Text,
                    CommissionSkill2.Text,
                    CommissionSkill3.Text,
                    CommissionSkill4.Text,
                    CommissionSkill5.Text,
                    CommissionSkill6.Text,
                };
                commission.CommmsionCheck = _commissionCheck;
                commission.HasCommision = true;
            }
            else
            {
                commission.HasCommision = false;
            }
        }
    }
}
