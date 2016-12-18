using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Base;
using ChatBot.Factory;
using ChatBot.Login;
using ChatBot.Services;

namespace ChatBot
{
    public class MainViewModel : ViewModelBase
    {
		#region members

	    private readonly IViewModelFactory factory;
		private ViewModelBase content = null;
		private EventService eventService;
	    private bool closeHelp = false;
		#endregion

		#region ctors
		public MainViewModel()
        {
			this.eventService = EventService.GetInstance();
			this.eventService.DisplayChanged += eventService_DisplayChanged;
			this.factory = ViewModelFactory.GetInstance();
	        this.content = this.factory.GetLoginViewModel();
		}

		void eventService_DisplayChanged(DisplayEnum displayEnum, List<object> eventArgs)
		{
			switch (displayEnum)
			{
				case DisplayEnum.Chat:
					this.Content = this.factory.GetChatViewModel(eventArgs[0].ToString());
					break;
				case DisplayEnum.Cancel:
					this.CloseHelp = true;
					break;
			}
		}
		#endregion

		#region properties

		public ViewModelBase Content
	    {
		    get
		    {
			    return this.content; 
		    }
		    set
		    {
			    this.content = value;
			    OnPropertyChanged("Content");
		    }
	    }

	    public bool CloseHelp
	    {
		    get { return this.closeHelp; }
		    set
		    {
			    this.closeHelp = value;
			    OnPropertyChanged("CloseHelp");
		    }
	    }
		#endregion

		#region public methods
		#endregion

		#region private methods
		#endregion
    }
}

