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

namespace CareerCreator
{
    /// <summary>
    /// Interaction logic for CommissionRankandSkilllist.xaml
    /// </summary>
    public partial class CommissionRankandSkilllist : Window
    {

        public List<(string Title, string Benefit)> CommissionSkillsAndRanks { get; set; }
        public CommissionRankandSkilllist()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommissionSkillsAndRanks = new List<(string, string)>();

            CommissionSkillsAndRanks.Add((Title1.Text,Skill1.Text));
            CommissionSkillsAndRanks.Add((Title2.Text, Skill2.Text));
            CommissionSkillsAndRanks.Add((Title3.Text, Skill3.Text));
            CommissionSkillsAndRanks.Add((Title4.Text, Skill4.Text));
            CommissionSkillsAndRanks.Add((Title5.Text, Skill5.Text));
            CommissionSkillsAndRanks.Add((Title6.Text, Skill6.Text));
            this.DialogResult = true;
        }
    }
}
