using System;
using System.Threading.Tasks;
using MatchandMeet.ViewModels.Base;

namespace MatchandMeet.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModelBase;

        Task NavigateToAsync(Type viewModelType);

        Task NavigateBackAsync();
    }
}
