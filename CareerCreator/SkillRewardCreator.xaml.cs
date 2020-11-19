﻿using System;
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
    /// Interaction logic for SkillRewardCreator.xaml
    /// </summary>
    public partial class SkillRewardCreator : Window
    {

        public TravellerCharacterCreationSkillReward Reward;
        public SkillRewardCreator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var rewards = SkillList.Text.Split(',').ToList();
            Reward = new TravellerCharacterCreationSkillReward(rewards);
            DialogResult = true;
        }
    }
}
