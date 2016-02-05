using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Controller;
using ViewModel.Participant;

namespace DmHelperGui.View
{
    /// <summary>
    /// Interaction logic for EncounterSimulation.xaml
    /// </summary>
    public partial class EncounterSimulation : UserControl
    {
        public EncounterSimulation()
        {
            InitializeComponent();
        }

        readonly ObservableCollection<EncounterParticipantViewModel> participants = new ObservableCollection<EncounterParticipantViewModel>();


        private void btnGenerateEncounter_Click(object sender, RoutedEventArgs e)
        {
            // Reset the Items Collection
            participants.Clear();

            var encounterInfo = EncounterController.Instance.StartEncounter();
            var list = encounterInfo.ParticipantsList;

            for (int index = 0; index < list.Count; index++)
            {
                var participant = list[index];
                participants.Add(participant);
            }

            // Bind the items Collection to the List Box
            peopleListBox.ItemsSource = participants;
        }


    }
}
