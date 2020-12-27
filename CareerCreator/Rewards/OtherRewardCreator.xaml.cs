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

namespace CareerCreator.Rewards
{
    /// <summary>
    /// Interaction logic for OtherRewardCreator.xaml
    /// </summary>
    public partial class OtherRewardCreator : Window
    {
        public TravellerOtherReward Reward { get; set; }
        public OtherRewardCreator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reward = new TravellerOtherReward(OtherText.Text);
            DialogResult = true;
        }
    }
}
