using MvvmCross.Core.ViewModels;
using MyTrains.Core.Contracts.ViewModel;
using MyTrains.Core.Model;
using MyTrains.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrains.Core.ViewModels
{
    public class SplashViewModel : MvxViewModel, ISplashViewModel
    {
        public MvxCommand<User> NavigateToMainView
        {
            get
            {
                return new MvxCommand<User>(selectedJourney =>
                {
                    ShowViewModel<MainViewModel>();
                });
            }
        }
    }
}
