using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JonsApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand ShowAlertCommand { get; set; }

        private readonly IPageDialogService _pageDialogService;

        public MainPageViewModel(INavigationService navigationService,
                                IPageDialogService pageDialogService)
            : base(navigationService)
        {
            Title = "Main Page";
            ShowAlertCommand = new DelegateCommand(OnShowAlertTapped);
            _pageDialogService = pageDialogService;
        }

        private async void OnShowAlertTapped()
        {
            await _pageDialogService.DisplayAlertAsync("Alert!", "You've tapped the show alert button.", "ok");
        }
    }
}
