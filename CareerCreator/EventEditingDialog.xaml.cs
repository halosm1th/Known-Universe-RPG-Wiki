using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for EventEditingDialog.xaml
    /// </summary>
    public partial class EventEditingDialog : Window
    {

        public TravellerCharacterCreationEvent CharacterCreationEvent
        {
            get { return characterCreationEvent; }
            set
            {
                characterCreationEvent = value;
                EventText.Text = value.EventText;

                if (value.GetType() == typeof(TravellerCharacterCreationTextEventWithReward))
                {
                    HasReward.IsChecked = true;
                    reward = ((TravellerCharacterCreationTextEventWithReward) value).Reward;
                }

                if (value.GetType() == typeof(TravellerCharacterCreationTextEventWithSkillCheck))
                {
                    onSuccess = ((TravellerCharacterCreationTextEventWithSkillCheck) value).OnSuccess;
                    onFailure = ((TravellerCharacterCreationTextEventWithSkillCheck) value).OnFailure;
                    var skill = ((TravellerCharacterCreationTextEventWithSkillCheck) value).SkillCheck;
                    SkillName.Text = skill.SkillName;
                    SkillValue.Text = Convert.ToString(skill.BeatValue);

                }
            }
        }

        private TravellerCharacterCreationEvent characterCreationEvent;

        private TravellerCharacterCreationReward onSuccess;
        private TravellerCharacterCreationReward onFailure;
        private TravellerCharacterCreationReward reward;
        
        public EventEditingDialog()
        {
            InitializeComponent();
        }

        private TravellerCharacterCreationReward GetReward()
        {
            var characterCreationRewardType = new CharacterCreationRewardType();
            TravellerCharacterCreationReward reward = null;
            if (characterCreationRewardType.ShowDialog() == true)
            {
                var rewardType = characterCreationRewardType.CreateRewardType;
                switch (rewardType)
                {
                    case CharacterCreationRewardTypes.Skill:
                        var skillcreator = new SkillRewardCreator();
                        if (skillcreator.ShowDialog() == true)
                        {
                            reward = skillcreator.Reward;
                        }
                        break;
                    case CharacterCreationRewardTypes.Item:
                        var itemCreator = new ItemRewardCreator();
                        if(itemCreator.ShowDialog() == true)
                        {
                            reward = itemCreator.Reward;
                        }
                        break;
                    case CharacterCreationRewardTypes.Career:
                        var job = new CareerRewardCreator();
                        if (job.ShowDialog() == true)
                        {
                            reward = job.Reward;
                        }
                        break;
                    case CharacterCreationRewardTypes.Benefit:
                        var benefit = new BenefitRewardCreator();
                        if (benefit.ShowDialog() == true)
                        {
                            reward = benefit.Reward;
                        }
                        break;
                    case CharacterCreationRewardTypes.Advancement:
                        var advancement= new AdvancementRewardCreator();
                        if (advancement.ShowDialog() == true)
                        {
                            reward = advancement.Reward;
                        }
                        break;
                    case CharacterCreationRewardTypes.Commission:
                        var commission = new CommissionRewardCreator();
                        if (commission.ShowDialog() == true)
                        {
                            reward = commission.Reward;
                        }
                        break;
                    case CharacterCreationRewardTypes.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return reward;
        }

        public void RewardClicked(object sender, RoutedEventArgs e)
        {
            RewardText.IsEnabled = HasReward.IsChecked ?? false;
        }

        public void SkillsClicked(object sender, RoutedEventArgs e)
        {
            //Textboxes
            SkillName.IsReadOnly = !HasReward.IsChecked ?? true;
            SkillValue.IsReadOnly = !HasReward.IsChecked ?? true;
            //Buttons
            EditSuccess.IsEnabled= HasReward.IsChecked ?? false;
            EditFailure.IsEnabled= HasReward.IsChecked ?? false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var eventText = EventText.Text;
            if (HasSkillCheck.IsChecked ?? false)
            {
                if (onSuccess == null || onFailure == null)
                {
                    MessageBox.Show("Error, no success or failure result!");
                }
                else
                {
                    CharacterCreationEvent =
                        new TravellerCharacterCreationTextEventWithSkillCheck(eventText,
                            new TravellerSkillCheck(SkillName.Text, Convert.ToInt32(SkillValue.Text)),
                        onSuccess,onFailure);
                   DialogResult = true;
                }
            }
            else if (HasReward.IsChecked ?? false)
            {
                CharacterCreationEvent = 
                    new TravellerCharacterCreationTextEventWithReward(eventText, reward);
            DialogResult = true;
            }
            else
            {
                CharacterCreationEvent = new TravellerCharacterCreationTextEvent(eventText);
            DialogResult = true;
            }

        }

        private void RewardText_Click(object sender, RoutedEventArgs e)
        {
            reward= GetReward();
        }

        private void EditSuccess_Click(object sender, RoutedEventArgs e)
        {
            onSuccess = GetReward();
        }

        private void EditFailure_Click(object sender, RoutedEventArgs e)
        {
            onFailure = GetReward();
        }
    }
}
