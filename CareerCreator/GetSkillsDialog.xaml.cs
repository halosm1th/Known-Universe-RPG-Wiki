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
    /// Interaction logic for GetSkillsDialog.xaml
    /// </summary>
    public partial class GetSkillsDialog : Window
    {
        public List<string> Skills
        {
            get => _skills;
            set
            {
                _skills = value;
                Skill1.Text = value[0] ?? "";
                Skill2.Text = value[1] ?? "";
                Skill3.Text = value[2] ?? "";
                Skill4.Text = value[3] ?? "";
                Skill5.Text = value[4] ?? "";
                Skill6.Text = value[5] ?? "";
            }
        }

        private List<string> _skills;

        public GetSkillsDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _skills = new List<string>();
            Skills.Add(Skill1.Text);
            Skills.Add(Skill2.Text);
            Skills.Add(Skill3.Text);
            Skills.Add(Skill4.Text);
            Skills.Add(Skill5.Text);
            Skills.Add(Skill6.Text);
            DialogResult = true;
        }
    }
}
