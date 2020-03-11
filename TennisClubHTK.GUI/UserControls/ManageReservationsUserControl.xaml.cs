using System;
using System.Collections.Generic;
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
using TennisClubHTK.Entities;
using TennisClubHTK.GUI.ViewModels;

namespace TennisClubHTK.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for ManageReservationsUserControl.xaml
    /// </summary>
    public partial class ManageReservationsUserControl : UserControl
    {
        ReservationsViewModel reservationsViewModel = new ReservationsViewModel();
        public ManageReservationsUserControl()
        {
            InitializeComponent();
            DataContext = reservationsViewModel;
        }

        private void ReserveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime time = (DateTime)ReservationTimeDatePicker.Value;
            int hour = time.Hour;

            List<FieldReservation> reservationsAtTheSameTime = reservationsViewModel.FieldReservations.Where(fr => fr.ReservationTime.ToString() == time.ToString()).ToList();

            if (hour < 10 || ( hour > 13 && hour < 18 ) || hour > 20){
                MessageBox.Show("Man kan kun spille imellem 10-14 og 18-21");
            }
            else if(reservationsAtTheSameTime.Count > 0)
            {
                MessageBox.Show("Tiden er allerede optaget");
            }
            else
            {
                FieldReservation fieldReservation = new FieldReservation()
                {
                    Field = SelectFieldComboBox.SelectedItem as Field,
                    Member1 = Player1ComboBox.SelectedItem as Member,
                    Member2 = Player2ComboBox.SelectedItem as Member,
                    ReservationTime = (DateTime)ReservationTimeDatePicker.Value
                };

                reservationsViewModel.CreateFieldReservation(fieldReservation);
            }
        }

        private void SelectFieldComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            reservationsViewModel.SelectedField = SelectFieldComboBox.SelectedItem as Field;

            Player1ComboBox.IsEnabled = true;
            Player2ComboBox.IsEnabled = true;
            ReservationTimeDatePicker.IsEnabled = true;

            FieldReservationsDataGrid.ItemsSource = reservationsViewModel.FieldReservationsByFieldId;
        }
    }
}
