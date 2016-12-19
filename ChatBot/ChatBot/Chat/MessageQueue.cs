using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatBot.Services;

namespace ChatBot.Chat
{
	public class MessageQueue
	{
		private static MessageQueue queue = null;
		private List<string> messages = null;
		private readonly IEventService eventService;
		private MessageQueue(IEventService eventService)
		{
			this.eventService = eventService;
			this.messages = new List<string>();
		}

		public static MessageQueue GetInstance(IEventService eventService)
		{
			return queue ?? (queue = new MessageQueue(eventService));
		}

		public void Add(string message)
		{
			this.messages.Add(message);
			this.eventService.PublishGetMessage(message);
		}

		public void Remove()
		{
			if(this.messages.Count > 0)
				this.messages.RemoveAt(0);
		}

		public bool IsEmpty()
		{
			return this.messages.Count == 0;
		}

		public string GetNextMessage()
		{
			return this.messages.FirstOrDefault();
		}
	}
}
