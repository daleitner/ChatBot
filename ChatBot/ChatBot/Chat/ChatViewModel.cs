using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Base;
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
		private readonly IEventService eventService;
		#endregion

		#region ctors
		public ChatViewModel(string name, IEventService eventService)
		{
			this.name = name;
			this.eventService = eventService;
			this.status = "Online";
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
			this.Messages.Add(new MessageViewModel(this.Message, false, this.xMode));
			this.Message = "";
			this.eventService.PublishScrollEvent();
		}

		#endregion

		#region public methods
		#endregion
	}
}
