using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;

namespace ChatBot.Models
{
	public class Message : ModelBase
	{
		public Message()
		{
			this.Request = "";
			this.Response = "";
			this.IsXMode = false;
		}

		public Message(List<string> itemArray)
		{
			this.Id = itemArray[0];
			this.Request = itemArray[1];
			this.Response = itemArray[2];
			this.IsXMode = Boolean.Parse(itemArray[3]);
		}

		public string Request { get; set; }
		public string Response { get; set; }
		public bool IsXMode { get; set; }
	}
}
