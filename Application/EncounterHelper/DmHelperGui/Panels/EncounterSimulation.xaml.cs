using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DmHelperGui.ModelView;
using DmHelperGui.ViewLogic;

namespace DmHelperGui.Panels
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

        readonly ObservableCollection<EncounterParticipant> participants = new ObservableCollection<EncounterParticipant>();


        private void btnGenerateEncounter_Click(object sender, RoutedEventArgs e)
        {
            // Reset the Items Collection
            participants.Clear();

            var encounterInfo = EncounterManager.Instance.GetSimulation();
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
