using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using Prism.Navigation;
using kanji_quiz.Models;
using Prism.Commands;

namespace kanji_quiz.ViewModels
{
    public class QuizPageViewModel:BaseViewModel
    {
        public DelegateCommand ResultCommand { get; }
        public DelegateCommand BackCommand { get; }

        public QuizPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ResultCommand = new DelegateCommand(Result);
            BackCommand = new DelegateCommand(Back);
        }

        private async void Result()
        {
            await NavigationService.NavigateAsync("Result");
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
