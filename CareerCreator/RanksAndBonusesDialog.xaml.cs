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
    /// Interaction logic for RanksAndBonusesDialog.xaml
    /// </summary>
    public partial class RanksAndBonusesDialog : Window
    {
        public List<(string Title, TravellerCharacterCreationReward Benefit)> RanksAndBonuses { get; set; }
        public RanksAndBonusesDialog()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RanksAndBonuses = new List<(string Title, TravellerCharacterCreationReward Benefit)>
            {
                (Title1.Text,Bonus1),
                (Title2.Text,Bonus2),
                (Title3.Text,Bonus3),
                (Title4.Text,Bonus4),
                (Title5.Text,Bonus5),
                (Title6.Text,Bonus6),
            };
            this.DialogResult = true;
        }

        private TravellerCharacterCreationReward Bonus1;
        private TravellerCharacterCreationReward Bonus2;
        private TravellerCharacterCreationReward Bonus3;
        private TravellerCharacterCreationReward Bonus4;
        private TravellerCharacterCreationReward Bonus5;
        private TravellerCharacterCreationReward Bonus6;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var rewardType = new CharacterCreationRewardType();
            if (rewardType.ShowDialog() == true)
            {
                Bonus1 = rewardType.Reward;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var rewardType = new CharacterCreationRewardType();
            if (rewardType.ShowDialog() == true)
            {
                Bonus2 = rewardType.Reward;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var rewardType = new CharacterCreationRewardType();
            if (rewardType.ShowDialog() == true)
            {
                Bonus3 = rewardType.Reward;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var rewardType = new CharacterCreationRewardType();
            if (rewardType.ShowDialog() == true)
            {
                Bonus4 = rewardType.Reward;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var rewardType = new CharacterCreationRewardType();
            if (rewardType.ShowDialog() == true)
            {
                Bonus5 = rewardType.Reward;
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var rewardType = new CharacterCreationRewardType();
            if (rewardType.ShowDialog() == true)
            {
                Bonus6 = rewardType.Reward;
            }
        }
    }
}
