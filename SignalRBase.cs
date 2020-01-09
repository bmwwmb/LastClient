using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR.Client;
using con = Microsoft.AspNetCore.Http.Connections;
namespace APXClient.APXFacilitator
{
    public abstract class SignalRBase //: IObservable<PayLoad>
    {
        public List<IObserver<PayLoad>> m_observers;
        public List<PayLoad> m_messages;
        public event EventHandler AMessageReceived;

        protected con.HttpTransportType m_transportType { get; set; }

        protected HubConnection m_hubConnection { get; set; }

        protected string m_sUrl { get; set; }

        public SignalRBase(string sUrl)//, APXControler apx)
        {
           m_sUrl = sUrl;
           // m_APXControler = apx;
            m_observers = new List<IObserver<PayLoad>>();
            m_messages = new List<PayLoad>();
        }


        protected virtual void OnThresholdReached(EventArgs e)
        {
            EventHandler handler = AMessageReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        //public IDisposable Subscribe(IObserver<PayLoad> observer)
        //{
        //    // Check whether observer is already registered. If not, add it
        //    if (!m_observers.Contains(observer))
        //    {
        //        m_observers.Add(observer);
        //        // Provide observer with existing data.
        //        foreach (var item in m_messages)
        //            observer.OnNext(item);
        //    }
        //    return new Unsubscriber<PayLoad>(m_observers, observer);
        //}

        public abstract bool DoCreateGroup(string groupName);
        public abstract bool DoSendMessageToGroup(string groupName, string message);
        public abstract bool DoSendMessageToSelf(string message);



        public abstract bool DoSubscribe(string GroupName);

        public abstract bool DoInit(string groupName, string message);
        //public abstract bool DoReceiveMessages();
        public abstract ProcessType ReceiveMessage(string message, ProcessType previous);
        public abstract ProcessType SendMessage(string message, ProcessType current);

    }
}
