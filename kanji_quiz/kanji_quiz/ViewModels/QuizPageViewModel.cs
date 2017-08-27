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
        private int _correctAnswer = 0;
        public int CorrectAnswer
        {
            get { return this._correctAnswer; }
            set
            {
                this._correctAnswer = value;
       //         PropertyChanged(this,new PropertyChangedEventArgs("CorrectAnswer"));
            }
        }
        private string _question;
        public string Question
        {
            get { return this._question; }
            set
            {
                this._question = value;
       //         PropertyChanged(this,new PropertyChangedEventArgs("Question"));
            }
        }

        private string _answer1;
        public string Answer1
        {
            get { return this._answer1; }
            set
            {
                this._answer1 = value;
        //        PropertyChanged(this,new PropertyChangedEventArgs("Answer1"));
            }
        }

        private bool _answer1Enabled;
        public bool Answer1Enabled
        {
            get { return this._answer1Enabled; }
            set
            {
                this._answer1Enabled = value;
             //   PropertyChanged(this,new PropertyChangedEventArgs("Answer1Enabled"));
            }
        }

        private string _answer2;
        public string Answer2
        {
            get { return this._answer2; }
            set
            {
                this._answer2 = value;
            //    PropertyChanged(this,new PropertyChangedEventArgs("Answer2"));
            }
        }

        private bool _answer2Enabled;
        public bool Answer2Enabled
        {
            get { return this._answer2Enabled; }
            set
            {
                this._answer2Enabled = value;
          //      PropertyChanged(this,new PropertyChangedEventArgs("Answer2Enabled"));
            }
        }

        private string _answer3;
        public string Answer3
        {
            get { return this._answer3; }
            set
            {
                this._answer3 = value;
         //       PropertyChanged(this,new PropertyChangedEventArgs("Answer3"));
            }
        }

        private bool _answer3Enabled;
        public bool Answer3Enabled
        {
            get { return this._answer3Enabled; }
            set
            {
                this._answer3Enabled = value;
      //          PropertyChanged(this,new PropertyChangedEventArgs("Answer3Enabled"));
            }
        }
        private bool _isLoading;
        public bool IsLoading
        {
            get { return this._isLoading; }
            set
            {
                this._isLoading = value;
              //  PropertyChanged(this,new PropertyChangedEventArgs("IsLoading"));
            }
        }
        public QuizPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ResultCommand = new DelegateCommand(Result);
            BackCommand = new DelegateCommand(Back);
            ChooseNewQuestion();
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

        public async Task LoadQuestions()
        {
            IsLoading = true;
           // MobileServiceClient client = AppSettings.MobileService;

       //     IMobileServiceTable<XamarinQuiz> xamarinQuizTable = client.GetTable<XamarinQuiz>();

            try
            {
          //      QuestionList = await xamarinQuizTable.ToListAsync();
            }
            catch (Exception exc)
            {
            }


            IsLoading = false;
            ChooseNewQuestion();
        }

        public void ChooseNewQuestion()
        {
            IsLoading = true;

        //    int questionNumber = rnd.Next(0, QuestionList.Count);
            Quiz selectedItem = new Quiz();
            selectedItem.Id = "1";
            selectedItem.Question = "dddddddd?";
            selectedItem.CorrectAnswer = 1;
            selectedItem.Answer1 = "1";
            selectedItem.Answer2 = "2";
            selectedItem.Answer3 = "3";
            

            Answer1Enabled = true;
            Answer2Enabled = true;
            Answer3Enabled = true;

            Question = selectedItem.Question;
            Answer1 = selectedItem.Answer1;
            Answer2 = selectedItem.Answer2;
            Answer3 = selectedItem.Answer3;

            CorrectAnswer = selectedItem.CorrectAnswer;

            IsLoading = false;
        }
    }

}
