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
    /// Interaction logic for MusteringOutBenefits.xaml
    /// </summary>
    public partial class MusteringOutBenefits : Window
    {
        public List<(int Cash, string Benefit)> Benefits
        {
            get => _benefits;
            set
            {
                _benefits = value;
                Benefit1.Text = value[0].Benefit;
                Benefit2.Text = value[1].Benefit;
                Benefit3.Text = value[2].Benefit;
                Benefit4.Text = value[3].Benefit;
                Benefit5.Text = value[4].Benefit;
                Benefit6.Text = value[5].Benefit;
                Benefit7.Text = value[6].Benefit;


                Cash1.Text = value[0].Cash.ToString();
                Cash2.Text = value[1].Cash.ToString();
                Cash3.Text = value[2].Cash.ToString();
                Cash4.Text = value[3].Cash.ToString();
                Cash5.Text = value[4].Cash.ToString();
                Cash6.Text = value[5].Cash.ToString();
                Cash7.Text = value[6].Cash.ToString();
            }
        }

        private List<(int, string)> _benefits;
        public MusteringOutBenefits()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _benefits = new List<(int,string)>();

            var cashMoney = (Convert.ToInt32(Cash1.Text));
            var benefit = Benefit1.Text;
            Benefits.Add((cashMoney,benefit));
            Benefits.Add((Convert.ToInt32(Cash2.Text),Benefit2.Text));
            Benefits.Add((Convert.ToInt32(Cash3.Text),Benefit3.Text));
            Benefits.Add((Convert.ToInt32(Cash4.Text),Benefit4.Text));
            Benefits.Add((Convert.ToInt32(Cash5.Text),Benefit5.Text));
            Benefits.Add((Convert.ToInt32(Cash6.Text),Benefit6.Text));
            Benefits.Add((Convert.ToInt32(Cash7.Text),Benefit7.Text));
            DialogResult = true;
        }
    }
}
