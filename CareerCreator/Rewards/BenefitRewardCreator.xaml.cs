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
    /// Interaction logic for BenefitRewardCreator.xaml
    /// </summary>
    public partial class BenefitRewardCreator : Window
    {
        public TravellerCharacterCreationBenefitIncreaseReward Reward;
        public BenefitRewardCreator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var rewardAmount = Convert.ToInt32(CareerName.Text);
            Reward = new TravellerCharacterCreationBenefitIncreaseReward(rewardAmount);
            DialogResult = true;

        }
    }
}
