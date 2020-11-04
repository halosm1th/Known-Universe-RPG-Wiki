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
    /// Interaction logic for CommissionSkillsDialog.xaml
    /// </summary>
    public partial class CommissionSkillsDialog : Window
    {
        public List<string> CommissionSkillList = new List<string>();
        public CommissionSkillsDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommissionSkillList.Add(Skill1.Text);
            CommissionSkillList.Add(Skill2.Text);
            CommissionSkillList.Add(Skill3.Text);
            CommissionSkillList.Add(Skill4.Text);
            CommissionSkillList.Add(Skill5.Text);
            CommissionSkillList.Add(Skill6.Text);
            this.DialogResult = true;
        }
    }
}
