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
		private readonly EventService eventService;
		private readonly QueryService queryService;
		private readonly CommandService commandService;
		private static ViewModelFactory factory;
		private ViewModelFactory()
		{
			this.eventService = EventService.GetInstance();
			this.queryService = new QueryService();
			this.commandService = new CommandService();
		}

		public static ViewModelFactory GetInstance()
		{
			return factory ?? (factory = new ViewModelFactory());
		}

		public LoginViewModel GetLoginViewModel()
		{
			return new LoginViewModel(this.eventService);
		}

		public ChatViewModel GetChatViewModel(string name)
		{
			return new ChatViewModel(name, this.eventService, this);
		}

		public MessageListener GetMessageListener(bool isXMode)
		{
			return new MessageListener(this.eventService, this.queryService, isXMode);
		}
	}
}
