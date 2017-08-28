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
        public async Task<T> RunActionAsync<T>(Func<Task<T>> func)
        {
            try
            {
                if (IsBusy == true)
                    return default(T);

                IsBusy = true;

                return await func.Invoke();
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                OnException(e);
            }
            finally
            {
                IsBusy = false;
            }
            return default(T);
        }
    }
}
