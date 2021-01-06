using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SubsectorJsonGenerator
{
    /// <summary>
    /// Interaction logic for FromUWPDialog.xaml
    /// </summary>
    public partial class FromUWPDialog : Window
    {
        public string Name { get; set; }
        public string X { get; set; }
        public string Y { get; set; }

        public int Starport { get; set; }
        public int Size { get; set; }
        public int Atmo { get; set; }
        public int Hydro { get; set; }
        public int Gov { get; set; }
        public int Pop { get; set; }

        public int Law
        {
            get => _law;
            set => _law = value > 9? 9 : value;
        }

        private int _law;

        public int Tech { get; set; }
        public FromUWPDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var regex = new Regex(
                @"(\w+)\s([0-9A-F])([0-9A-F])([0-9A-F])([0-9A-F])([0-9A-F])([0-9A-F])([0-9A-F])-([0-9A-F])\s([1-8])\s(\d)+");
            if (regex.IsMatch(UPP.Text))
            {
                var parts = regex.Split(UPP.Text);
                //Start counting at one beacuse for some reason the regex counts empty space as a first valid match
                Name = parts[1];

                Starport = Int32.Parse(parts[2], NumberStyles.HexNumber);
                Size = Int32.Parse(parts[3], NumberStyles.HexNumber);
                Atmo= Int32.Parse(parts[4], NumberStyles.HexNumber);
                Hydro= Int32.Parse(parts[5], NumberStyles.HexNumber);
                Pop = Int32.Parse(parts[6], NumberStyles.HexNumber);
                Gov= Int32.Parse(parts[7], NumberStyles.HexNumber);
                Law= Int32.Parse(parts[8], NumberStyles.HexNumber);
                Tech= Int32.Parse(parts[9], NumberStyles.HexNumber);

                X = parts[10];
                Y = parts[11];
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Error UPP incorrect", "UPP Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
