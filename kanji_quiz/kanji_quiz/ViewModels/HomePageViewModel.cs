using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kanji_quiz.Models;
using kanji_quiz.Services;
using Prism.Navigation;

namespace kanji_quiz.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            
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
