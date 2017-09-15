using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Commands;

namespace kanji_quiz.ViewModels
{
    public class ResultPageViewModel:BaseViewModel
    {
        private int _score;
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public DelegateCommand FinishCommand { get; }
        public ResultPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            FinishCommand = new DelegateCommand(Finish);
        }
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            _score = Convert.ToInt32(parameters["score"]);           
            Title = "Your score:" + _score ;
        }
        private async void Finish()
        {
            await NavigationService.NavigateAsync("ChooseMode");
        }
    }
}
