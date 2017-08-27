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
        public DelegateCommand FinishCommand { get; }
        public ResultPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            FinishCommand = new DelegateCommand(Finish);
        }
        private async void Finish()
        {
            await NavigationService.NavigateAsync("ChooseMode");
        }
    }
}
