using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketChat.Models;

namespace WebSocketChat.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        Socket socket;
        private List<Person> _persons;
        private Person _selectedItem;
        private readonly INavigationService _navigationService;

        public List<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                RaisePropertyChanged("Persons");
            }
        }

        public Person SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    RaisePropertyChanged("SelectedItem");
                    OnSelectItem?.Execute();
                }
            }
        }

        public DelegateCommand OnSendCommand { get; private set; }
        public DelegateCommand OnSelectItem { get; private set; }


        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";
            OnSendCommand = new DelegateCommand(SendMessage);
            OnSelectItem = new DelegateCommand(SelectItem);
            this._navigationService = navigationService;
        }

        private void SelectItem()
        {
            NavigationParameters prm = new NavigationParameters();
            prm.Add("id", _selectedItem.Id);

            _navigationService.NavigateAsync("Dialog", prm);
        }

        private void SendMessage()
        {
            var jobj = new JObject();
            jobj.Add("username", "sl");
            jobj.Add("room", "bestroom");
            jobj.Add("message", "hello pidari"); ;

            socket.Emit("new_message", jobj);
        }


        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            socket = IO.Socket("http://10.0.3.2:5555/test");
            socket.Connect();

            Persons = new List<Person>
            {
                new Person{Name = "Slava"},
                new Person{Name = "Ivan"},
                new Person{Name = "Petya"}
            };
        }
    }
}
