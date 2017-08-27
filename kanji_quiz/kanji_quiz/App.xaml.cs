using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DryIoc;
using kanji_quiz.Models;
using kanji_quiz.Services;
using kanji_quiz.Views;
using Prism.DryIoc;
using Xamarin.Forms;

namespace kanji_quiz
{
    public partial class App
    {
        public static Configuration Configuration { get; set; }
        public App()
        {
           
        }
        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            await NavigationService.NavigateAsync("Home");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>("Navigation");
            Container.RegisterTypeForNavigation<HomePage>("Home");
            Container.RegisterTypeForNavigation<ChooseModePage>("ChooseMode");
            Container.RegisterTypeForNavigation<OptionsPage>("Options");
            Container.RegisterTypeForNavigation<QuizPage>("Quiz");
            Container.RegisterTypeForNavigation<ResultPage>("Result");
            /*Container.Register<ApiService>(Reuse.Singleton);
            Container.Register<TokenService>(Reuse.Singleton);
            Container.Register<StarBucksService>(Reuse.Singleton);

            
            
            Container.RegisterTypeForNavigation<SearchPage>("Search");
            Container.RegisterTypeForNavigation<MoviePage>("Movie");*/
        }
    }
}
