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
    /// Interaction logic for SkillCheckChoice.xaml
    /// </summary>
    public partial class SkillCheckChoice : Window
    {
        public TravellerCharacterCreationEventSkillChoice Reward;
        public SkillCheckChoice()
        {
            InitializeComponent();
        }

        private TravellerSkillCheck _skillCheck;

        private TravellerCharacterCreationReward onSuccess;
        private TravellerCharacterCreationReward onFailure;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var skilLDialog = new NewQualificationDialog();
            if (skilLDialog.ShowDialog() == true)
            {
                _skillCheck = skilLDialog.NewQualification;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var checkText = CheckText.Text ?? "";
            var failureText = FailureText.Text ?? "";
            var successText = SuccessText.Text ?? "";
            if (checkText != null)
            {
                Reward = new TravellerCharacterCreationEventSkillChoice(
                    _skillCheck, checkText, onSuccess, successText,
                    onFailure, failureText);
                DialogResult = true;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var success = new CharacterCreationRewardType();
            if (success.ShowDialog() == true)
            {
                onSuccess = success.Reward;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var failure = new CharacterCreationRewardType();
            if (failure.ShowDialog() == true)
            {
                onFailure = failure.Reward;
            }
        }
    }
}
