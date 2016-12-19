using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseInitializer;
using SQLDatabase;

namespace ChatBot.Services
{
	public class CommandService
	{
		private DataBaseManager dbManager;
		private ORDictionary mapping;
		private DataBaseConnection connection;

		public CommandService()
		{
			this.dbManager = DataBaseManager.GetInstance();
			if (this.dbManager != null)
			{
				this.mapping = this.dbManager.Mapping;
				this.connection = this.dbManager.DataBaseConnection;
			}
		}
	}
}
