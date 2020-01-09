using System;
using System.Collections.Generic;
using System.Text;

namespace APXClient.APXFacilitator
{

    public class MessageHandler111111 : IObservable<PayLoad>
    {
        private List<IObserver<PayLoad>> observers;
        private List<PayLoad> messages;

        public MessageHandler111111(string TransportType,string sUrl)
        {
            switch (TransportType)
            {
                case "0":
                    m_messageClient = new SignalRSNone(sUrl);
                    break;
            }

            observers = new List<IObserver<PayLoad>>();
            messages = new List<PayLoad>();
        }

        public IDisposable Subscribe(IObserver<PayLoad> observer)
        {
            // Check whether observer is already registered. If not, add it
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                // Provide observer with existing data.
                foreach (var item in messages)
                    observer.OnNext(item);
            }
            return new Unsubscriber<PayLoad>(observers, observer);
        }


        public void Message(string message)
        {
            var info = new PayLoad(message);

            // Carousel is assigned, so add new info object to list.
            //if (//carousel > 0 && 
            //    !messages.Contains(info))
            //{
            //    messages.Add(info);
            //    foreach (var observer in observers)
            //        observer.OnNext(info);
            //}
            m_messageClient.DoSendMessageToGroup("ABC", message);
            

/*            else if (//carousel 
                0 == 0)
            {
                // Baggage claim for flight is done
                var flightsToRemove = new List<PayLoad>();
                foreach (var flight in flights)
                {
                    if (info.FlightNumber == flight.FlightNumber)
                    {
                        flightsToRemove.Add(flight);
                        foreach (var observer in observers)
                            observer.OnNext(info);
                    }
                }
                foreach (var flightToRemove in flightsToRemove)
                    flights.Remove(flightToRemove);

                flightsToRemove.Clear();
            }
            */
        }

        public void LastBaggageClaimed()
        {
            foreach (var observer in observers)
                observer.OnCompleted();

            observers.Clear();
        }







        SignalRBase m_messageClient;
        ProcessType Previous;
        ProcessType Current;
        public bool DoInit()
        {

            return m_messageClient.DoInit();


        }
        bool DoDoTryToEstablishConnection()
        {

            return true;
        }

        bool DoExitMessageReceived()
        {
            bool bIsOk = false;
            return bIsOk;
        }
        bool DoExitMessags()
        {

            return DoExitMessageReceived();
        }
        void DoProcessMessage()
        {

        }

    }
}