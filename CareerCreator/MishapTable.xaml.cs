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
    /// Interaction logic for MishapTable.xaml
    /// </summary>
    public partial class MishapTable : Window
    {
        public List<string> Mishaps
        {
            get => _mishaps;
            set
            {
                _mishaps = value;
                Mishap1.Text = value[0] ?? "";
                Mishap2.Text = value[1] ?? "";
                Mishap3.Text = value[2] ?? "";
                Mishap4.Text = value[3] ?? "";
                Mishap5.Text = value[4] ?? "";
                Mishap6.Text = value[5] ?? "";
            }
        }

        private List<string> _mishaps;

        public MishapTable()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mishaps = new List<string>();
            Mishaps.Add(Mishap1.Text);
            Mishaps.Add(Mishap2.Text);
            Mishaps.Add(Mishap3.Text);
            Mishaps.Add(Mishap4.Text);
            Mishaps.Add(Mishap5.Text);
            Mishaps.Add(Mishap6.Text);
            DialogResult = true;
        }
    }
}
