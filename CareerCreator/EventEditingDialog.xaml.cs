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
            }
        }

        private TravellerCharacterCreationEvent characterCreationEvent;

        private List<TravellerCharacterCreationReward> onSuccess;
        private List<TravellerCharacterCreationReward> onFailure;

        private List<TravellerCharacterCreationEventSkillChoice> skillChoices = new List<TravellerCharacterCreationEventSkillChoice>();
        public EventEditingDialog()
        {
            InitializeComponent();
        }

        //Add things to the event
        //Types of thigns to add:
        //1) Skill Check (str 8+, onSuccessReward, onFailReward)
        //2) Reward


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var skill = new SkillCheckChoice();
            if (skill.ShowDialog() == true)
            {
                skillChoices.Add(skill.Reward);
                EventChoices.Items.Add(skill.Reward);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            characterCreationEvent = 
                new TravellerCharacterCreationEvent(
                    EventText.Text,skillChoices,reward);
            DialogResult = true;
        }

        private TravellerCharacterCreationReward reward;

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var eventReward = new CharacterCreationRewardType();
            if (eventReward.ShowDialog() == true)
            {
                reward = eventReward.Reward;
            }

        }


    }
}
