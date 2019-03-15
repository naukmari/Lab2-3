using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CharpZavertailo2.Annotations;
using CharpZavertailo2.Tools;
using CharpZavertailo2.Tools.Managers;
using CharpZavertailo2.Tools.Navigation;

namespace CharpZavertailo2.ViewModels.Authentication
{
    class MainViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _email;
        private string _bDay;
        private string _isAdult;
        private string _chineseSign;
        private string _sunSign;
        private string _isBirthday;


        private RelayCommand<object> _tryAgainCommand;


        public MainViewModel()
        {
            FillInfo();
        }

        public string BDay
        {
            get => _bDay;

            private set
            {
                _bDay = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;

            private set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => _surname;

            private set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;

            private set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string ChineseSign
        {
            get => _chineseSign;

            private set
            {
                _chineseSign = value;
                OnPropertyChanged();
            }
        }

        public string SunSign
        {
            get => _sunSign;

            private set
            {
                _sunSign = value;
                OnPropertyChanged();
            }
        }

        public string IsAdult
        {
            get => _isAdult;

            private set
            {
                _isAdult = value;
                OnPropertyChanged();
            }
        }

        public string IsBirthday
        {
            get => _isBirthday;

            private set
            {
                _isBirthday = value;
                OnPropertyChanged();
            }
        }

        private async void FillInfo()
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                BDay = StationManager.CurrentPerson.BDate.ToShortDateString();
                Name = StationManager.CurrentPerson.Name;
                Surname =StationManager.CurrentPerson.Surname;
                Email = StationManager.CurrentPerson.Email;
                IsAdult = StationManager.CurrentPerson.IsAdult ? "Yes" : "No";
                ChineseSign = StationManager.CurrentPerson.ChineseSign;
                SunSign =  StationManager.CurrentPerson.SunSign;
                IsBirthday = StationManager.CurrentPerson.IsBirthday ? "Yes" : "No";
            });
            LoaderManager.Instance.HideLoader();
        }

        public RelayCommand<Object> TryAgain
        {
            get
            {
                return _tryAgainCommand ?? (_tryAgainCommand = new RelayCommand<object>(
                           o => { NavigationManager.Instance.Navigate(ViewType.PersonFillInfo); }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
