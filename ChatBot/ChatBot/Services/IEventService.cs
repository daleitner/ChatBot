﻿using System.Collections.Generic;

namespace ChatBot.Services
{
    public interface IEventService
    {
        void PublishDisplayChangedEvent(DisplayEnum displayEnum);
		void PublishDisplayChangedEvent(DisplayEnum displayEnum, List<object> eventArgs);
	    void PublishScrollEvent();
	    void PublishGetMessage(string message);
	    void PublishGetResponse(string message);
	    void PublishChangeState(StateEnum state);
    }
}
