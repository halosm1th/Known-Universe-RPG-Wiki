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

namespace CareerCreator
{
    /// <summary>
    /// Interaction logic for CharacterCreationRewardType.xaml
    /// </summary>
    /// 

    public enum CharacterCreationRewardTypes
    {
        Skill, Item, Career, Benefit, Advancement, Commission, None
    }

    public partial class CharacterCreationRewardType : Window
    {


        public CharacterCreationRewardTypes CreateRewardType;
        public CharacterCreationRewardType()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateRewardType = CharacterCreationRewardTypes.Skill;
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateRewardType = CharacterCreationRewardTypes.Item;
            DialogResult = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CreateRewardType = CharacterCreationRewardTypes.Career;
            DialogResult = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CreateRewardType = CharacterCreationRewardTypes.Benefit;
            DialogResult = true;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CreateRewardType = CharacterCreationRewardTypes.Advancement;
            DialogResult = true;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            CreateRewardType = CharacterCreationRewardTypes.Commission;
            DialogResult = true;
        }
    }
}
