using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using CharpZavertailo2.Annotations;
using CharpZavertailo2.Tools;
using CharpZavertailo2.Tools.Managers;
using CharpZavertailo2.Tools.Navigation;

namespace CharpZavertailo2.ViewModels.Authentication
{
    class PersonFillInfoViewModel : INotifyPropertyChanged
    {

        private DateTime _date = DateTime.Today;
        private string _name;
        private string _surname;
        private string _email;

        private RelayCommand<object> _getInfoCommand;


        public PersonFillInfoViewModel()
        {
        }

        public DateTime Date
        {
            get => _date;

            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;

            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => _surname;

            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;

            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<Object> GetInfo
        {
            get
            {
                return _getInfoCommand ?? (_getInfoCommand = new RelayCommand<object>(
                           ProceedImpl, o => IsOk()));
            }
        }

        private bool IsOk()
        {
            return  !string.IsNullOrWhiteSpace(_email) && !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_surname);
        }

        private async void ProceedImpl(object o)
        {
            LoaderManager.Instance.ShowLoader();
            Person person = null;
            try
            {
                await Task.Run(() => { person = new Person(_name, _surname, _email, _date); }
                );
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            if (person != null)
            {
                if (person.IsBirthday)
                {
                    MessageBox.Show(
                        $"Happy B-Day to you, Happy B-Day to you, Happy B-Day dear {_name}, Happy B-Day to you!");
                }

                StationManager.CurrentPerson = person;
                LoaderManager.Instance.HideLoader();
                NavigationManager.Instance.Navigate(ViewType.Main);
                LoaderManager.Instance.HideLoader();

            }
            else
            {
                LoaderManager.Instance.HideLoader();

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
