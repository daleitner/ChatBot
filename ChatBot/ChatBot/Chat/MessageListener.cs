using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatBot.Services;

namespace ChatBot.Chat
{
	public class MessageListener
	{
		private bool isXMode = false;
		private string response = "";
		private readonly MessageQueue queue;
		private readonly BackgroundWorker worker = new BackgroundWorker();
		private readonly EventService eventService;
		private readonly QueryService queryService;
		public MessageListener(EventService eventService, QueryService queryService, bool isXMode)
		{
			this.IsBusy = false;
			this.isXMode = isXMode;
			this.queryService = queryService;
			this.eventService = eventService;
			this.eventService.GetMessage += EventService_GetMessage;
			this.queue = MessageQueue.GetInstance(eventService);
			this.worker.DoWork += worker_DoWork;
			this.worker.RunWorkerCompleted += worker_RunWorkerCompleted;
		}

		private void EventService_GetMessage(string message)
		{
			if (!this.IsBusy)
				Start();
		}

		private void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			do
			{
				var message = this.queue.GetNextMessage();
				System.Threading.Thread.Sleep(1000);
				this.eventService.PublishChangeState(StateEnum.Writing);
				this.response = this.queryService.GetResponse(message);
				if (string.IsNullOrEmpty(this.response))
					this.response = "Tut mir leid, das verstehe ich nicht.";
				System.Threading.Thread.Sleep(1000);
				this.queue.Remove();
			} while (!this.queue.IsEmpty());
			
		}

		private void worker_RunWorkerCompleted(object sender,
											   RunWorkerCompletedEventArgs e)
		{
			this.eventService.PublishGetResponse(this.response);
			this.IsBusy = false;
		}

		public void Start()
		{
			this.worker.RunWorkerAsync();
			this.IsBusy = true;
		}

		public bool IsBusy { get; set; }
	}
}
