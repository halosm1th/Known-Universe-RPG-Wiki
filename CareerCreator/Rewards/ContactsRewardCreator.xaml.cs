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
    /// Interaction logic for ContactsRewardCreator.xaml
    /// </summary>
    public partial class ContactsRewardCreator : Window
    {
        public TravellerContactReward Reward { get; private set; }
        public ContactsRewardCreator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reward = new TravellerContactReward(ContactNumber.Text,ContactType.Text);
            DialogResult = true;
        }
    }
}
