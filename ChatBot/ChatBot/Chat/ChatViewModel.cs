using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Base;
using ChatBot.Factory;
using ChatBot.Services;

namespace ChatBot.Chat
{
	public class ChatViewModel : ViewModelBase
	{
		#region members
		private RelayCommand sendCommand = null;
		private ObservableCollection<MessageViewModel> messages = null;
		private Uri path;
		private BitmapImage imageSource = null;
		private string name = "";
		private string status = "";
		private string message = "";
		private bool xMode = false;
		private readonly EventService eventService;
		private readonly MessageQueue queue;
		private readonly MessageListener listener;
		#endregion

		#region ctors
		public ChatViewModel(string name, EventService eventService, IViewModelFactory factory)
		{
			this.queue = MessageQueue.GetInstance(eventService);
			this.name = name;
			this.eventService = eventService;
			this.eventService.GetResponse += EventService_GetResponse;
			this.eventService.ChangeState += EventService_ChangeState;
			EventService_ChangeState(StateEnum.Online);
			this.path = new Uri(Path.GetFullPath("images"));
			if (this.Name == "Foxy")
			{
				this.xMode = true;
				if (File.Exists(new Uri(this.path, ".\\images\\Foxy.jpg").LocalPath))
				{
					this.imageSource = new BitmapImage(new Uri(this.path, ".\\images\\Foxy.jpg"));
				}
			}
			else
			{
				if (File.Exists(new Uri(this.path, ".\\images\\jarvis.jpg").LocalPath))
				{
					this.imageSource = new BitmapImage(new Uri(this.path, ".\\images\\jarvis.jpg"));
				}
			}
			this.messages = new ObservableCollection<MessageViewModel>();
			this.listener = factory.GetMessageListener(this.xMode);
		}

		private void EventService_ChangeState(StateEnum state)
		{
			switch (state)
			{
				case StateEnum.Online:
					this.Status = "Online";
					break;
					case StateEnum.Writing:
					this.Status = "Schreibt...";
					break;
			}
		}

		private void EventService_GetResponse(string response)
		{
			this.Messages.Add(new MessageViewModel(response, false, this.xMode));
			EventService_ChangeState(StateEnum.Online);
			this.eventService.PublishScrollEvent();
		}
		#endregion

		#region properties
		public ICommand SendCommand
		{
			get
			{
				if (this.sendCommand == null)
				{
					this.sendCommand = new RelayCommand(
						param => Send()
					);
				}
				return this.sendCommand;
			}
		}
		public ObservableCollection<MessageViewModel> Messages
		{
			get
			{
				return this.messages;
			}
			set
			{
				this.messages = value;
				OnPropertyChanged("Messages");
			}
		}
		public BitmapImage ImageSource
		{
			get
			{
				return this.imageSource;
			}
			set
			{
				this.imageSource = value;
				OnPropertyChanged("ImageSource");
			}
		}
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
				OnPropertyChanged("Name");
			}
		}
		public string Status
		{
			get
			{
				return this.status;
			}
			set
			{
				this.status = value;
				OnPropertyChanged("Status");
			}
		}
		public string Message
		{
			get
			{
				return this.message;
			}
			set
			{
				this.message = value;
				OnPropertyChanged("Message");
			}
		}
		#endregion

		#region private methods
		private void Send()
		{
			this.Messages.Add(new MessageViewModel(this.Message, true, false));
			this.queue.Add(this.Message);
			this.Message = "";
			this.eventService.PublishScrollEvent();
		}

		#endregion

		#region public methods
		#endregion
	}
}
