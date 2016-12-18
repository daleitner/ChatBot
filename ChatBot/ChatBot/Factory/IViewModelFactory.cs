using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatBot.Chat;
using ChatBot.Login;

namespace ChatBot.Factory
{
	public interface IViewModelFactory
	{
		LoginViewModel GetLoginViewModel();
		ChatViewModel GetChatViewModel(string name);
	}

}
