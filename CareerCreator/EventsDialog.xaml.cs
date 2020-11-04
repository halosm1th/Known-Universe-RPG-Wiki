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
    /// Interaction logic for EventsDialog.xaml
    /// </summary>
    public partial class EventsDialog : Window
    {
        public List<string> Events
        {
            get => _events;
            set
            {
                _events = value;
                Event2.Text = value[1] ?? "";
                Event3.Text = value[2] ?? "";
                Event4.Text = value[3] ?? "";
                Event5.Text = value[4] ?? "";
                Event6.Text = value[5] ?? "";

                Event7.Text = value[6] ?? "";
                Event8.Text = value[7] ?? "";
                Event9.Text = value[8] ?? "";
                Event10.Text = value[9] ?? "";
                Event11.Text = value[10] ?? "";
                Event12.Text = value[11] ?? "";
            }
        }

        private List<string> _events;

        public EventsDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _events = new List<string>();
            Events.Add(Event2.Text ?? "");
            Events.Add(Event3.Text ?? "");
            Events.Add(Event4.Text ?? "");
            Events.Add(Event5.Text ?? "");
            Events.Add(Event6.Text ?? "");

            Events.Add(Event7.Text ?? "");
            Events.Add(Event8.Text ?? "");
            Events.Add(Event9.Text ?? "");
            Events.Add(Event10.Text ?? "");
            Events.Add(Event11.Text ?? "");
            Events.Add(Event12.Text ?? "");
            DialogResult = true;
        }
    }
}
