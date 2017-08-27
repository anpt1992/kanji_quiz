using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;

namespace kanji_quiz.ViewModels
{
    class ChooseModePageViewModel : BaseViewModel
    {
        public DelegateCommand SeiOnCommand { get; }
        public DelegateCommand BackCommand { get; }
        public ChooseModePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            SeiOnCommand = new DelegateCommand(SeiOn);
            BackCommand = new DelegateCommand(Back);
        }

        private async void SeiOn()
        {
            await NavigationService.NavigateAsync("Quiz");
        }
        private async void Back()
        {
            await NavigationService.GoBackAsync();
        }
        public override async void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        protected override void OnException(Exception e)
        {
            base.OnException(e);
        }

    }
}
