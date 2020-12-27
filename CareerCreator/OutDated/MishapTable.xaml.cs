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
    /// Interaction logic for MishapTable.xaml
    /// </summary>
    public partial class MishapTable : Window
    {
        public List<TravellerCharacterCreationEvent> Mishaps
        {
            get => _mishaps.ToList();
            set
            {
                _mishaps = value.ToArray();
                Mishap1.Text = value[0].EventText ?? "";
                Mishap6.Text = value[5].EventText ?? "";
            }
        }

        private TravellerCharacterCreationEvent[] _mishaps = new TravellerCharacterCreationEvent[]
        {
            new TravellerCharacterCreationEvent("Severely injured (this is the same as a result of 2 on the Injury Table). Alternatively, roll twice on the Injury Table  and take the lower result"), 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent(), 
            new TravellerCharacterCreationEvent(),
            new TravellerCharacterCreationEvent("Injured. Roll on the Injury Table."), 
        };

        public MishapTable()
        {
            InitializeComponent();
        }

        private void EditEvent(int eventID)
        {
            if (_mishaps[eventID] != null)
            {
                var dialog = new EventEditingDialog { CharacterCreationEvent = _mishaps[eventID] };
                if (dialog.ShowDialog() == true)
                {
                    _mishaps[eventID] = dialog.CharacterCreationEvent;
                }
            }
            else
            {
                var dialog = new EventEditingDialog();
                if (dialog.ShowDialog() == true)
                {
                    _mishaps[eventID] = dialog.CharacterCreationEvent;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Mishap2_Click(object sender, RoutedEventArgs e)
        {
            EditEvent(1);
        }

        private void Mishap3_Click(object sender, RoutedEventArgs e)
        {
            EditEvent(2);

        }

        private void Mishap4_Click(object sender, RoutedEventArgs e)
        {
            EditEvent(3);

        }

        private void Mishap5_Click(object sender, RoutedEventArgs e)
        {
            EditEvent(4);

        }
    }
}
