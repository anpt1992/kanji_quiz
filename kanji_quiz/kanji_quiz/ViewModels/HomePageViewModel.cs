using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kanji_quiz.Models;
using kanji_quiz.Services;
using Prism.Commands;
using Prism.Navigation;

namespace kanji_quiz.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public DelegateCommand StartCommand { get; }
        public DelegateCommand OptionsCommand { get; }
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            StartCommand = new DelegateCommand(Login);
            OptionsCommand = new DelegateCommand(Options);
        }

        private async void Login()
        {        
            await NavigationService.NavigateAsync("ChooseMode");              
        }

        private async void Options()
        {
            await NavigationService.NavigateAsync("Options");
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
