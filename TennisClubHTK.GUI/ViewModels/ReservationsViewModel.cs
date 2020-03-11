using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisClubHTK.DAL;
using TennisClubHTK.Entities;

namespace TennisClubHTK.GUI.ViewModels
{
    public class ReservationsViewModel : INotifyPropertyChanged
    {
        private Field selectedField;
        private List<Field> fields;
        private List<FieldReservation> fieldReservations;
        private List<FieldReservation> fieldReservationsByFieldId;
        private List<Member> members;

        public void CreateFieldReservation(FieldReservation fieldReservation)
        {
            new FieldReservationRepository().CreateFieldReservation(fieldReservation);
        }


        public List<Field> Fields
        {
            get { return new FieldRepository().GetAllFields(); }
            set { fields = value; }
        }

        public Field SelectedField
        {
            get { return selectedField; }
            set
            {
                selectedField = value;
                OnPropertyChanged(nameof(SelectedField));
            }
        }

        public List<FieldReservation> FieldReservationsByFieldId
        {
            get { return new FieldReservationRepository().GetAllFieldReservationsByFieldId(selectedField.Id); }
            set
            {
                fieldReservationsByFieldId = value;
            }
        }
        
        public List<FieldReservation> FieldReservations
        {
            get { return new FieldReservationRepository().GetAllFieldReservations(); }
            set { 
                fieldReservations = value; 
            }
        }

        public List<Member> Members
        {
            get => new MemberRepository().GetAllMembers();
        }

        



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
