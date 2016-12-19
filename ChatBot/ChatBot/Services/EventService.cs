using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ChatBot.Services
{
    public class EventService : IEventService
    {
        public delegate void DisplayChangedEventHandler(DisplayEnum displayEnum, List<object> eventArgs);
        public event DisplayChangedEventHandler DisplayChanged = null;

	    public delegate void ScrollEventHandler();
	    public event ScrollEventHandler ScrollEvent = null;

	    public delegate void MessageEventHandler(string message);

	    public event MessageEventHandler GetMessage = null;
	    public event MessageEventHandler GetResponse = null;

	    public delegate void ChangeStateEventHandler(StateEnum state);

	    public event ChangeStateEventHandler ChangeState = null;
        #region singelton
        private static EventService instance;
        private EventService()
        {
        }

        public static EventService GetInstance()
        {
            if (instance == null)
                instance = new EventService();
            return instance;
        }
        #endregion

        public void PublishDisplayChangedEvent(DisplayEnum displayEnum)
        {
            if (this.DisplayChanged != null)
                this.DisplayChanged(displayEnum, null);
        }



		public void PublishDisplayChangedEvent(DisplayEnum displayEnum, List<object> eventArgs)
		{
			if (this.DisplayChanged != null)
				this.DisplayChanged(displayEnum, eventArgs);
		}

	    public void PublishScrollEvent()
	    {
		    if (this.ScrollEvent != null)
			    this.ScrollEvent();
	    }

	    public void PublishGetMessage(string message)
	    {
		    if (this.GetMessage != null)
			    this.GetMessage(message);
	    }

	    public void PublishGetResponse(string message)
	    {
		    if (this.GetResponse != null)
			    this.GetResponse(message);
	    }

	    public void PublishChangeState(StateEnum state)
	    {
		    if (this.ChangeState != null)
			    this.ChangeState(state);
	    }
    }
}
