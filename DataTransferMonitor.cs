using System;
using System.Collections.Generic;
namespace APXClient.APXFacilitator
{

    //public class DataTransferMonitor : IObserver<PayLoad>
    //{
    //    private string m_message;
        
    //    private IDisposable m_cancellation;

    //    private ProcessType m_ProcessStatus;
    //    public DataTransferMonitor(string name)
    //    {
    //        if (String.IsNullOrEmpty(name))
    //            throw new ArgumentNullException("The observer must be assigned a name.");

    //        this.m_message = name;
    //    }

    //    public virtual void Subscribe(SignalRBase provider)
    //    {
    //        m_cancellation = provider.Subscribe(this);
    //    }

    //    public virtual void Unsubscribe()
    //    {
    //        m_cancellation.Dispose();
           
    //    }

    //    public virtual void OnInit()
    //    {
    //        m_ProcessStatus = ProcessType.InProgress;
    //    }


    //    public virtual void OnCompleted()
    //    {
    //    }
    //    public ProcessType CheckStatus()
    //    {
    //        return m_ProcessStatus;
    //    }

       

    //    // No implementation needed: Method is not called by the BaggageHandler class.
    //    public virtual void OnError(Exception e)
    //    {
    //        // No implementation.
    //    }
    //    public virtual void OnNext(PayLoad info)
    //    {
    //        // No implementation.
    //    }

    //    //// Update information.
    //    //public virtual void OnNext(PayLoad info)
    //    //{
    //    //    bool updated = false;

    //    //    // Flight has unloaded its baggage; remove from the monitor.
    //    //    if (info.Carousel == 0)
    //    //    {
    //    //        var flightsToRemove = new List<string>();
    //    //        string flightNo = String.Format("{0,5}", info.FlightNumber);

    //    //        foreach (var flightInfo in flightInfos)
    //    //        {
    //    //            if (flightInfo.Substring(21, 5).Equals(flightNo))
    //    //            {
    //    //                flightsToRemove.Add(flightInfo);
    //    //                updated = true;
    //    //            }
    //    //        }
    //    //        foreach (var flightToRemove in flightsToRemove)
    //    //            flightInfos.Remove(flightToRemove);

    //    //        flightsToRemove.Clear();
    //    //    }
    //    //    else
    //    //    {
    //    //        // Add flight if it does not exist in the collection.
    //    //        string flightInfo = String.Format(fmt, info.From, info.FlightNumber, info.Carousel);
    //    //        if (!flightInfos.Contains(flightInfo))
    //    //        {
    //    //            flightInfos.Add(flightInfo);
    //    //            updated = true;
    //    //        }
    //    //    }
    //    //    if (updated)
    //    //    {
    //    //        flightInfos.Sort();
    //    //        Console.WriteLine("Arrivals information from {0}", this.name);
    //    //        foreach (var flightInfo in flightInfos)
    //    //            Console.WriteLine(flightInfo);

    //    //        Console.WriteLine();
    //    //    }
    //    //}
    //}
}

