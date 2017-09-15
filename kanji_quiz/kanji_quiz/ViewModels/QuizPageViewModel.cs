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
    public class QuizPageViewModel : BaseViewModel
    {
        private int _index = 0;
        private int _score = 0;
        public DelegateCommand BackCommand { get; }
        public DelegateCommand Answer1Command { get; }
        public DelegateCommand Answer2Command { get; }
        public DelegateCommand Answer3Command { get; }
        private readonly ApiService _apiService;
        private string _question;
        List<Question> question_set;
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
        private int _correctAnswer = 0;
        public int CorrectAnswer
        {
            get { return this._correctAnswer; }
            set
            {
                this._correctAnswer = value;
            }
        }

        public QuizPageViewModel(INavigationService navigationService, ApiService apiService) : base(navigationService)
        {
            BackCommand = new DelegateCommand(Back);
            Answer1Command = new DelegateCommand(Answer1_cmd);
            Answer2Command = new DelegateCommand(Answer2_cmd);
            Answer3Command = new DelegateCommand(Answer3_cmd);
            _apiService = apiService;
        }

        private async void Back()
        {
            await NavigationService.GoBackAsync();
        }

        private void Answer1_cmd()
        {
            _score += CheckIfCorrect(1) ? 1 : 0;

            DoAnswer();
        }
        private void Answer2_cmd()
        {
            _score += CheckIfCorrect(2) ? 1 : 0;
            DoAnswer();
        }
        private void Answer3_cmd()
        {
            _score += CheckIfCorrect(3) ? 1 : 0;
            DoAnswer();
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var result = await RunActionAsync(() => _apiService.GetQuestionSet());
            question_set = result.Data.Questions;
            ChooseNewQuestion();

        }

        private void DoAnswer()
        {
            if (_index < question_set.Count)
            {
                ChooseNewQuestion();
            }
            else
            {
                NavigationService.NavigateAsync("Result", new NavigationParameters()
                {
                    {"score", _score}
                });
            }
        }

        public void ChooseNewQuestion()
        {
            //   IsLoading = true;  
            Question q = question_set[_index];
            Question = q.Content;
            Answer1 = q.Answer1;
            Answer2 = q.Answer2;
            Answer3 = q.Answer3;
            CorrectAnswer = q.CorrectAnswer;
            _index++;
            //CorrectAnswer = selectedItem.CorrectAnswer;

            // IsLoading = false;
        }

        private void NavigateToEndPage()
        {
            //  Application.Current.MainPage = new ThanksForPlaying();
        }

        protected override void OnException(Exception e)
        {
            base.OnException(e);
        }
        public bool CheckIfCorrect(int correct)
        {
            if (CorrectAnswer == correct)
            {
                return true;
            }
            return false;
        }
    }

}
