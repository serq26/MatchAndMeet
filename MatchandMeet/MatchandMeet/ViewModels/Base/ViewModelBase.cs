using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MatchandMeet.Services.Navigation;

namespace MatchandMeet.ViewModels.Base
{
    public abstract class BaseViewModelBase : INotifyPropertyChanged
    {
        protected readonly INavigationService NavigationService;

        public object Parameter { get; internal set; }

        public BaseViewModelBase()
        {
            NavigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
        }
        public virtual void OnAppearing(object navigationContext)
        {
        }

        public virtual void OnDisappearing()
        {
        }
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
