using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace _10_03_20_Homework_BlogLesson_54
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        private ObservableCollection<Person> _personsCollectionForListBox = new ObservableCollection<Person>();
        public ObservableCollection<Person> PersonsCollectionForListBox
        {
            get => _personsCollectionForListBox;
            set
            {
                if (_personsCollectionForListBox == value) return;
                _personsCollectionForListBox = value;
                OnPropertyChanged();
            }
        }
        private string _personName = "Name";
        public string PersonName
        {
            get => _personName;
            set
            {
                if (String.Equals(_personName, value)) return;
                _personName = value;
                OnPropertyChanged();
            }
        }
        private int _personAgeNum;
        private string _personAge = "Age";
        public string PersonAge
        {
            get => _personAge;
            set
            {
                if (String.Equals(_personAge, value)) return;
                _personAge = value;
                OnPropertyChanged();
            }
        }
        private int _personHeightNum;
        private string _personHeight = "Height";
        public string PersonHeight
        {
            get => _personHeight;
            set
            {
                if (String.Equals(_personHeight, value)) return;
                _personHeight = value;
                OnPropertyChanged();
            }
        }
        private bool _isPersonSmoker = false;
        public bool IsPersonSmoker
        {
            get => _isPersonSmoker;
            set
            {
                if (_isPersonSmoker == value) return;
                _isPersonSmoker = value;
                OnPropertyChanged();
            }
        }
        private int _listBoxCollectionSelectedIndex;
        public int ListBoxCollectionSelectedIndex
        {
            get => _listBoxCollectionSelectedIndex;
            set
            {
                if (_listBoxCollectionSelectedIndex == value) return;
                _listBoxCollectionSelectedIndex = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand AddANewPerson_buttonClick_delegComm { get; set; }
        private void AddANewPerson_OnButtonClick()
        {
            Person person = new Person(PersonName, _personAgeNum, _personHeightNum, IsPersonSmoker);
            person.CallBackEvent += (object sender, GlobalEventArgs e) =>
            {
                if(e.Name != null) PersonName = e.Name;
                if(e.Age != null) PersonAge = e.Age;
                if(e.Height != null) PersonHeight = e.Height;
                IsPersonSmoker = e.IsSmoke;
            };
            PersonsCollectionForListBox.Add(person);            
        }
        private bool AddANewPerson_CanExecute()
        {            
            if (!Int32.TryParse(PersonAge, out _personAgeNum)) return false;
            if (!Int32.TryParse(PersonHeight, out _personHeightNum)) return false;

            return true;
        }
        public DelegateCommand UpdatePerson_buttonClick_delegComm { get; set; }
        private void UpdatePerson_OnButtonClick()
        {
            Person person = new Person(PersonName, _personAgeNum, _personHeightNum, IsPersonSmoker);
            person.CallBackEvent += (object sender, GlobalEventArgs e) => 
            {
                if (e.Name != null) PersonName = e.Name;
                if (e.Age != null) PersonAge = e.Age;
                if (e.Height != null) PersonHeight = e.Height;
                IsPersonSmoker = e.IsSmoke;
            };
            if (ListBoxCollectionSelectedIndex != -1 && PersonsCollectionForListBox.Count > 0)
            {
                person.Name = PersonName;
                person.Age = int.Parse(PersonAge);
                person.Height = int.Parse(PersonHeight);
                person.IsSmoking = IsPersonSmoker;                
                PersonsCollectionForListBox[ListBoxCollectionSelectedIndex] = person;                
            }
        }
        private bool UpdatePerson_CanExecute()
        {
            return true;
        }

        public ViewModel()
        {
            

            AddANewPerson_buttonClick_delegComm = new DelegateCommand(AddANewPerson_OnButtonClick, AddANewPerson_CanExecute);
            UpdatePerson_buttonClick_delegComm = new DelegateCommand(UpdatePerson_OnButtonClick, UpdatePerson_CanExecute);
            Task.Run(() =>
            {
                while (true)
                {
                    AddANewPerson_buttonClick_delegComm.RaiseCanExecuteChanged();
                    UpdatePerson_buttonClick_delegComm.RaiseCanExecuteChanged();
                    Thread.Sleep(100);
                }
            });
        }


        


    }
}
