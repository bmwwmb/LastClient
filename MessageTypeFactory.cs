using System;
using System.Collections.Generic;
using System.Text;

namespace APXClient.APXFacilitator
{
    public static class MessageTypeFactory
    {
        public static SignalRBase CreateFactory(string TransportType,string sUrl, APXControler apx)
        {
            SignalRBase s = null;
            switch (TransportType)
            {
                case "0":
                    s=  new SignalRSNone(sUrl,apx);
                    break;
                    
            }
            return s;
        }
    }
}
