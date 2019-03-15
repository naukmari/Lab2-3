using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using CharpZavertailo2.Annotations;
using CharpZavertailo2.Tools;
using CharpZavertailo2.Tools.Managers;

namespace CharpZavertailo2.ViewModels
{
    class MainWindowViewModel : ILoaderOwner
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;


        public Visibility LoaderVisibility
        {
            get => _loaderVisibility;
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsControlEnabled
        {
            get => _isControlEnabled;
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        internal MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
 }
