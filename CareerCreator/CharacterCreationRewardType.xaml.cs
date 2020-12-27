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
using CareerCreator.Rewards;
using TravellerWiki.Data;

namespace CareerCreator
{
    /// <summary>
    /// Interaction logic for CharacterCreationRewardType.xaml
    /// </summary>
    /// 

    public partial class CharacterCreationRewardType : Window
    {
        public TravellerCharacterCreationReward Reward;

        public CharacterCreationRewardType()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var skillReward=  new SkillRewardCreator();
            if (skillReward.ShowDialog() == true)
            {
                Reward = skillReward.Reward;
            }
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var skillReward = new ItemRewardCreator();
            if (skillReward.ShowDialog() == true)
            {
                Reward = skillReward.Reward;
            }
            DialogResult = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var skillReward = new CareerRewardCreator();
            if (skillReward.ShowDialog() == true)
            {
                Reward = skillReward.Reward;
            }
            DialogResult = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var skillReward = new BenefitRewardCreator();
            if (skillReward.ShowDialog() == true)
            {
                Reward = skillReward.Reward;
            }
            DialogResult = true;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var skillReward = new AdvancementRewardCreator();
            if (skillReward.ShowDialog() == true)
            {
                Reward = skillReward.Reward;
            }
            DialogResult = true;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var skillReward = new CommissionRewardCreator();
            if (skillReward.ShowDialog() == true)
            {
                Reward = skillReward.Reward;
            }
            DialogResult = true;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Reward = new TravellerLifeEventReward();
            DialogResult = true;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var skillReward = new ContactsRewardCreator();
            if (skillReward.ShowDialog() == true)
            {
                Reward = skillReward.Reward;
            }
            DialogResult = true;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            var skillReward = new OtherRewardCreator();
            if (skillReward.ShowDialog() == true)
            {
                Reward = skillReward.Reward;
            }
            DialogResult = true;
        }
    }
}
