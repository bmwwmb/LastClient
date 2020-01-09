using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APXClient.APXFacilitator
{
    public class APXControler
    {
        SignalRBase m_handler;
        //DataTransferMonitor m_datatransferMonitor;
        string m_transportType;
        string m_sUrl;

        public void AMessageReceived(object sender, EventArgs e)
        {
            //ProcessType.Init_Message_Ak;
        }
        public APXControler(string transportType,string sUrl)
        {
            m_transportType = transportType;
            m_sUrl = sUrl;
        }
        public bool DoInit()
        {

            SignalRBase provider =  MessageTypeFactory.CreateFactory(m_transportType, "https://localhost:44348/ConnectionFacilitatorHub", this);
            //DataTransferMonitor Initialize = new DataTransferMonitor("BaggageClaimMonitor1");
            //Initialize.Subscribe(provider); 
            
            
            //provider.DoSendMessageToGroup("ABC", "Init");
            while(!provider.DoInit("(ABC)", "Init"))
            {
                ;
            }
            Console.Read();
            return true;
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
