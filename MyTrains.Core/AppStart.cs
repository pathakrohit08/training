using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.ViewModel;
using MyTrains.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrains.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public async void Start(object hint = null)
        {
            //hardcoded login for this demo
            var userService = Mvx.Resolve<IUserDataService>();
            await userService.Login("gillcleeren", "123456");

            ShowViewModel<SplashViewModel>();
        }
    }
}
