using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;

namespace ChatBot.Models
{
	public class Configuration : ModelBase
	{
		public Configuration()
		{
			this.Parameter = "";
			this.Value = "";
		}

		public Configuration(List<string> itemArray)
		{
			this.Id = itemArray[0];
			this.Parameter = itemArray[1];
			this.Value = itemArray[2];
		}

		public string Parameter { get; set; }
		public string Value { get; set; }
	}
}
