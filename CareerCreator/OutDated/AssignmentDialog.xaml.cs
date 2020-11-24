using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravellerWiki.Data;

namespace CareerCreator
{
    /// <summary>
    /// Interaction logic for AssignmentDialog.xaml
    /// </summary>
    public partial class AssignmentDialog : Window
    {

        public TravellerAssignment Assignment
        {
            get => _assignment;
            set
            {
                _assignment = value;
                if (value != null)
                {
                    _assignmentSkills = _assignment.SkillList;
                    _ranksAndBonuses = _assignment.RanksAndBonuses;
                    AssignmentName.Text = _assignment.Name;
                    Description.Text = _assignment.Description;
                    SurvivalStat.SelectedIndex = SurvivalStat.Items.IndexOf(_assignment.Survival.SkillName);
                    AdvanceStat.SelectedIndex = AdvanceStat.Items.IndexOf(_assignment.Advancement.SkillName);
                    SurvivalValue.Text = _assignment.Survival.BeatValue.ToString();
                    AdvanceValue.Text = _assignment.Advancement.BeatValue.ToString();
                }
            }
        }
        private TravellerAssignment _assignment;
        private List<string> _assignmentSkills;
        private List<(string Title, TravellerCharacterCreationReward Perk)> _ranksAndBonuses;
        public AssignmentDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var SkillsDialog = new GetSkillsDialog();
            if (_assignmentSkills != null)
            {
                SkillsDialog.Skills = _assignmentSkills;
            }

            if (SkillsDialog.ShowDialog() == true)
            {
                _assignmentSkills = SkillsDialog.Skills;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var ranksDialog = new RanksAndBonusesDialog();
            if (_assignmentSkills != null)
            {
                ranksDialog.RanksAndBonuses = _ranksAndBonuses;
            }

            if (ranksDialog.ShowDialog() == true)
            {
                _ranksAndBonuses = ranksDialog.RanksAndBonuses;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var name = AssignmentName.Text;
            var description = Description.Text;
            var survival = new TravellerSkillCheck(SurvivalStat.Text,Convert.ToInt32(SurvivalValue.Text));
            var advance = new TravellerSkillCheck(AdvanceStat.Text,Convert.ToInt32(AdvanceValue.Text));
            Assignment = new TravellerAssignment(name,description,survival,
                advance,_assignmentSkills,_ranksAndBonuses);
            DialogResult = true;
        }
    }
}
