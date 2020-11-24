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
    /// Interaction logic for NewQualificationDialog.xaml
    /// </summary>
    public partial class NewQualificationDialog : Window
    {
        public TravellerSkillCheck NewQualification { get;  set; }
        public NewQualificationDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var stat =QualificationName.SelectionBoxItem;
            if(!int.TryParse(QualificationValue.Text,out var qualificationNumber))
            {
                MessageBox.Show("Error, you need a number to beat!", "Qualification number error");
            }
            NewQualification = new TravellerSkillCheck(stat.ToString(),qualificationNumber);
            this.DialogResult = true;
        }
    }
}
