using System.Collections.Generic;
using System.Windows.Input;
using Base;
using ChatBot.Services;

namespace ChatBot.Login
{
	public class LoginViewModel : ViewModelBase
	{
		#region members
		private RelayCommand loginCommand = null;
		private RelayCommand cancelCommand = null;
		private string userName = "";
		private string password = "";
		private readonly IEventService eventService;
		#endregion

		#region ctors
		public LoginViewModel(IEventService eventService)
		{
			this.UserName = "Jarvis";
			this.Password = "Ironman";
			this.eventService = eventService;
		}
		#endregion

		#region properties
		public ICommand LoginCommand
		{
			get
			{
				if (this.loginCommand == null)
				{
					this.loginCommand = new RelayCommand(
						param => Login()
					);
				}
				return this.loginCommand;
			}
		}
		public ICommand CancelCommand
		{
			get
			{
				if (this.cancelCommand == null)
				{
					this.cancelCommand = new RelayCommand(
						param => Cancel()
					);
				}
				return this.cancelCommand;
			}
		}
		public string UserName
		{
			get
			{
				return this.userName;
			}
			set
			{
				this.userName = value;
				OnPropertyChanged("UserName");
			}
		}
		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				this.password = value;
				OnPropertyChanged("Password");
			}
		}
		#endregion

		#region private methods
		private void Login()
		{
			if((this.UserName == "Jarvis" && this.Password == "Ironman" )||( this.UserName == "Foxy" && this.Password == "Meli"))
			this.eventService.PublishDisplayChangedEvent(DisplayEnum.Chat, new List<object>() {this.UserName, this.Password});
		}

		private void Cancel()
		{
			this.eventService.PublishDisplayChangedEvent(DisplayEnum.Cancel, null);
		}

		#endregion

		#region public methods
		#endregion
	}
}
