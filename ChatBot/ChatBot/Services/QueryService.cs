using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatBot.Models;
using DataBaseInitializer;
using SQLDatabase;

namespace ChatBot.Services
{
	public class QueryService
	{
		private readonly DataBaseConnection connection;
		private readonly ORDictionary mapping;
		private readonly Random rnd;
		public QueryService()
		{
			this.connection = DataBaseManager.GetInstance().DataBaseConnection;
			this.mapping = DataBaseManager.GetInstance().Mapping;
			this.rnd = new Random();
		}

		public string GetResponse(string request)
		{
			var table = this.mapping.GetTableByObject(typeof(Message));
			var condition = new Condition().Add(new PropertyExpression(table.Columns["Request"], CompareEnum.Equals, request));
			var query = new DataBaseQuery(table, condition);
			var res = this.connection.ExecuteQuery(query).FirstOrDefault();
			if (res == null)
				return "";
			var message = new Message(res);
			var responses = message.Response.Split('|');
			var rand = this.rnd.Next(responses.Length);
			return responses[rand];
		}
	}
}
