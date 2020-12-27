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
    /// Interaction logic for EventsDialog.xaml
    /// </summary>
    public partial class EventsDialog : Window
    {
        public List<TravellerCharacterCreationEvent> Events
        {
            get => characterCreationEvents.ToList();
            set => characterCreationEvents = value.ToArray();
        }

        private TravellerCharacterCreationEvent[] characterCreationEvents = new TravellerCharacterCreationEvent[11]
        {
            new TravellerCharacterCreationEvent
            {
                EventText = "Disaster! Roll on the Mishap Table, but you are not ejected from this career."
            }, 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent("Life Event. Roll on the Life Events Table. "),
            new TravellerCharacterCreationEvent(),
            new TravellerCharacterCreationEvent(),
            new TravellerCharacterCreationEvent(),
            new TravellerCharacterCreationEvent(),
            new TravellerCharacterCreationEvent(),
        };
        public EventsDialog()
        {
            InitializeComponent();
            
        }


        private void EditEvent(int eventID)
        {
            if (characterCreationEvents[eventID] != null)
            {
                var dialog = new EventEditingDialog {CharacterCreationEvent = characterCreationEvents[eventID]};
                if (dialog.ShowDialog() == true)
                {
                    characterCreationEvents[eventID] = dialog.CharacterCreationEvent;
                }
            }
            else
            {
                var dialog = new EventEditingDialog();
                if (dialog.ShowDialog() == true)
                {
                    characterCreationEvents[eventID] = dialog.CharacterCreationEvent;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Event3_Click(object sender, RoutedEventArgs e)
        {
            EditEvent(1);
        }

        private void Event4_Click(object sender, RoutedEventArgs e)
        {
            EditEvent(2);

        }

        private void Event5_Click(object sender, RoutedEventArgs e)
        {
            EditEvent(3);
        }

        private void Event6_Click(object sender, RoutedEventArgs e)
        {
            EditEvent(4);
        }

        private void Event8_Click(object sender, RoutedEventArgs e)
        {
            EditEvent(6);
        }

        private void Event9_Click(object sender, RoutedEventArgs e)
        {
            EditEvent(7);
        }
        private void Event10_Click(object sender, RoutedEventArgs e)
        {
            EditEvent(8);
        }

        private void Event11_Click(object sender, RoutedEventArgs e)
        {
            EditEvent(9);
        }
        private void Event12_Click(object sender, RoutedEventArgs e)
        {
            EditEvent(10);
        }

    }
}
