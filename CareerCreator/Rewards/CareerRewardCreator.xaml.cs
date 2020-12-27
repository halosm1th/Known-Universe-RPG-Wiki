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
    /// Interaction logic for CareerRewardCreator.xaml
    /// </summary>
    public partial class CareerRewardCreator : Window
    {
        public TravellerCharacterCreationJobChangeReward Reward;
        public CareerRewardCreator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var reward = CareerName.Text;
            Reward = new TravellerCharacterCreationJobChangeReward(reward);
            DialogResult = true;
        }
    }
}
