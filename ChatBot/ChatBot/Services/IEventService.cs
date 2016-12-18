using System.Collections.Generic;

namespace ChatBot.Services
{
    public interface IEventService
    {
        void PublishDisplayChangedEvent(DisplayEnum displayEnum);
		void PublishDisplayChangedEvent(DisplayEnum displayEnum, List<object> eventArgs);
    }
}
