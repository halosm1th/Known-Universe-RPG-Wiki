using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for ItemRewardCreator.xaml
    /// </summary>
    public partial class ItemRewardCreator : Window
    {
        public TravellerCharacterCreationItemReward Reward;
        public ItemRewardCreator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var rewards = ItemList.Text.Split(',').ToList();
            Reward = new TravellerCharacterCreationItemReward(rewards);
            DialogResult = true;
        }
    }
}
