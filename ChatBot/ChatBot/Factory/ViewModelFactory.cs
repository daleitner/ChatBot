using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatBot.Chat;
using ChatBot.Login;
using ChatBot.Services;

namespace ChatBot.Factory
{
	public class ViewModelFactory : IViewModelFactory
	{
		private readonly IEventService eventService;
		private static ViewModelFactory factory;
		private ViewModelFactory()
		{
			this.eventService = EventService.GetInstance();
		}

		public static ViewModelFactory GetInstance()
		{
			return factory ?? (factory = new ViewModelFactory());
		}

		public LoginViewModel GetLoginViewModel()
		{
			return new LoginViewModel(this.eventService);
		}

		public ChatViewModel GetChatViewModel()
		{
			return new ChatViewModel();
		}
	}
}
