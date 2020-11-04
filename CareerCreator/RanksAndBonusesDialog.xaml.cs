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
    /// Interaction logic for RanksAndBonusesDialog.xaml
    /// </summary>
    public partial class RanksAndBonusesDialog : Window
    {
        public List<(string Title, string Benefit)> RanksAndBonuses { get; set; }
        public RanksAndBonusesDialog()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RanksAndBonuses = new List<(string, string)>();

            RanksAndBonuses.Add((Title1.Text ?? "", Skill1.Text ?? ""));
            RanksAndBonuses.Add((Title2.Text ?? "", Skill2.Text ?? ""));
            RanksAndBonuses.Add((Title3.Text ?? "", Skill3.Text ?? ""));
            RanksAndBonuses.Add((Title4.Text ?? "", Skill4.Text ?? ""));
            RanksAndBonuses.Add((Title5.Text ?? "", Skill5.Text ?? ""));
            RanksAndBonuses.Add((Title6.Text ?? "", Skill6.Text ?? ""));
            this.DialogResult = true;
        }
    }
}
