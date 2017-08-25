using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;
using DryIoc;

namespace kanji_quiz.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        protected IPageDialogService DialogService { get; }
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (SetProperty(ref _isBusy, value))
                {
                    RaisePropertyChanged(nameof(IsNotBusy));
                }
            }
        }
        public bool IsNotBusy => !IsBusy;
        protected BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            DialogService = ((App)Application.Current).Container.Resolve<IPageDialogService>();
        }
        protected INavigationService NavigationService { get; }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
        }
        protected virtual async void OnException(Exception e)
        {
            await DialogService.DisplayAlertAsync("Error", e.Message, "OK");
        }
    }
}
