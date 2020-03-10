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
    public class MemberViewModel : INotifyPropertyChanged
    {
        private Member selectedMember;
        private List<Member> members;

        public Member SelectedMember
        {
            get { return selectedMember; }
            set
            {
                selectedMember = value;
                OnPropertyChanged(nameof(SelectedMember));
            }
        }

        public List<Member> Members
        {
            get { return new MemberRepository().GetAllMembers(); }
            set
            {
                members = value;
                OnPropertyChanged(nameof(Members));
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
