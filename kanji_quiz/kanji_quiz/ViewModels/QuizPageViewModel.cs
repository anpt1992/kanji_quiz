using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using Prism.Navigation;
using kanji_quiz.Models;
using Prism.Commands;
using kanji_quiz.Services;

namespace kanji_quiz.ViewModels
{
    public class QuizPageViewModel:BaseViewModel
    {
        public DelegateCommand ResultCommand { get; }
        public DelegateCommand BackCommand { get; }
        private readonly ApiService _apiService;
        private string _question;
        public string Question
        {
            get => _question;
            set => SetProperty(ref _question, value);
        }
        private string _answer1;
        public string Answer1
        {
            get => _answer1;
            set => SetProperty(ref _answer1, value);
        }

        private string _answer2;
        public string Answer2
        {
            get => _answer2;
            set => SetProperty(ref _answer2, value);
        }
        private string _answer3;
        public string Answer3
        {
            get => _answer3;
            set => SetProperty(ref _answer3, value);
        }


        public QuizPageViewModel(INavigationService navigationService, ApiService apiService) : base(navigationService)
        {
            ResultCommand = new DelegateCommand(Result);
            BackCommand = new DelegateCommand(Back);
            _apiService = apiService;
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
            base.OnNavigatedTo(parameters);
            var result = await RunActionAsync(() => _apiService.Quiz_Detail("1"));
            Question = result.Question;
            Answer1 = result.Answer1;
            Answer2 = result.Answer2;
            Answer3 = result.Answer3;
        }

        protected override void OnException(Exception e)
        {
            base.OnException(e);
        }        
    }

}
