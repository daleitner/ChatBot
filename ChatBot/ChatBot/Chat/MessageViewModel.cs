using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Base;

namespace ChatBot.Chat
{
	public class MessageViewModel : ViewModelBase
	{
		private string message = "";
		private HorizontalAlignment align;
		private Brush backgroundColor;
		public MessageViewModel(string message, bool isUserMessage, bool isXMode)
		{
			this.message = message;
			if (isUserMessage)
			{
				this.align = HorizontalAlignment.Right;
				this.backgroundColor = new SolidColorBrush(Colors.LightBlue);
			}
			else
			{
				this.align = HorizontalAlignment.Left;
				if (!isXMode)
					this.backgroundColor = new SolidColorBrush(Colors.LightSeaGreen);
				else
					this.backgroundColor = new SolidColorBrush(Colors.IndianRed);
			}
		}

		public string Message
		{
			get { return this.message; }
			set
			{
				this.message = value;
				OnPropertyChanged("Message");
			}
		}

		public HorizontalAlignment Align
		{
			get { return this.align; }
			set
			{
				this.align = value;
				OnPropertyChanged("Align");
			}
		}

		public Brush BackgroundColor
		{
			get { return this.backgroundColor; }
			set
			{
				this.backgroundColor = value;
				OnPropertyChanged("BackgroundColor");
			}
		}
	}
}
