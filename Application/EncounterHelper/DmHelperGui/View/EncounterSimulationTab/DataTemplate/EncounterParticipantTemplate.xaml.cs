using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DmHelperGui.View.EncounterSimulationTab.DataTemplate
{
    /// <summary>
    /// Interaction logic for EncounterParticipantTemplate.xaml
    /// </summary>
    public partial class EncounterParticipantTemplate : UserControl
    {
        public EncounterParticipantTemplate()
        {
            InitializeComponent();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List.
            List<string> data = new List<string>();
            data.Add("Normal");
            data.Add("Hidden");

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }
    }
}
