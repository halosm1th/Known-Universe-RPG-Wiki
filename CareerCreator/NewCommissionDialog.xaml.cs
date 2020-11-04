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
    /// Interaction logic for NewCommissionDialog.xaml
    /// </summary>
    public partial class NewCommissionDialog : Window
    {
        private List<string> CommissionSkillList { get; set; }
        private List<(string Title, string Perk)> CommissionRanksAndSkills { get; set; }

        public TravellerCommission Commission { get; set; }

        public NewCommissionDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var skills = new CommissionSkillsDialog();
            if (skills.ShowDialog() == true)
            {
                CommissionSkillList = skills.CommissionSkillList;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var skills = new CommissionRankandSkilllist();
            if (skills.ShowDialog() == true)
            {
                CommissionRanksAndSkills = skills.CommissionSkillsAndRanks;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var commissionSkill = CommissionSkillName.SelectionBoxItem.ToString();
            var commissionValue = Convert.ToInt32(CommissionValue.Text);
            var commissionSkillCheck = new TravellerSkillCheck(commissionSkill,commissionValue);
            Commission = new TravellerCommission(true,CommissionSkillList,CommissionRanksAndSkills, commissionSkillCheck);
            DialogResult = true;
        }
    }
}
