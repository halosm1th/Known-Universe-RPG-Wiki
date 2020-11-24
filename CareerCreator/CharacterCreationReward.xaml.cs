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
    /// Interaction logic for CharacterCreationReward.xaml
    /// </summary>
    public partial class CharacterCreationReward : Window
    {
        public CharacterCreationReward()
        {
            InitializeComponent();
        }

        public List<TravellerCharacterCreationReward> Rewards { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RewardList.SelectedIndex != 0)
            {
                var reward = new CharacterCreationRewardType();
                if (reward.ShowDialog() == true)
                {
                    Rewards.Add(reward.Reward);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
