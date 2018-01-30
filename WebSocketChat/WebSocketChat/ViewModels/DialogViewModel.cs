using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Navigation;
using WebSocketChat.Models;

namespace WebSocketChat.ViewModels
{
    public class DialogViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private string _currentId;
        private ObservableCollection<Message> _messageList;

        ObservableCollection<Message> MessageList
        {
            get { return _messageList; }
            set
            {
                _messageList = value;
                RaisePropertyChanged();
            }
        }

        public DialogViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            this._navigationService = navigationService;
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            if (parameters.TryGetValue<string>("id",  out string id))
                _currentId = id;
        }

        
    }
}
