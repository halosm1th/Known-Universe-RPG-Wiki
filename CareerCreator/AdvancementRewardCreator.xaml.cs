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
    /// Interaction logic for AdvancementRewardCreator.xaml
    /// </summary>
    public partial class AdvancementRewardCreator : Window
    {
        public TravellerCharacterCreationAdvancementReward Reward
        {
            get { return _reward; }
            set
            {
                _reward = value;
                CareerName.Text = Convert.ToString(_reward.AdvancementAmount);
            }
        }

        private TravellerCharacterCreationAdvancementReward _reward;
        public AdvancementRewardCreator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CareerName.Text, out var reward))
            {
                _reward = new TravellerCharacterCreationAdvancementReward(reward);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Error, Advancement value not correct. Enter a number");
            }
        }
    }
}
