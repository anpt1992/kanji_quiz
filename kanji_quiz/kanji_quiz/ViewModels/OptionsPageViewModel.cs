using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Commands;

namespace kanji_quiz.ViewModels
{
    public class OptionsPageViewModel:BaseViewModel
    {
        public DelegateCommand BackCommand { get; }
        public OptionsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            BackCommand = new DelegateCommand(Back);
        }
        private async void Back()
        {
            await NavigationService.GoBackAsync();
        }
    }
}
