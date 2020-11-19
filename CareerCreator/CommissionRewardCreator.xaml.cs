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
    /// Interaction logic for CommissionRewardCreator.xaml
    /// </summary>
    public partial class CommissionRewardCreator : Window
    {

        public TravellerCharacterCreationCommissionReward Reward;
        public CommissionRewardCreator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var rewardAmount = Convert.ToInt32(CareerName.Text);
            Reward = new TravellerCharacterCreationCommissionReward(rewardAmount);
            DialogResult = true;
        }
    }
}
