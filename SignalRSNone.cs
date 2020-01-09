using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;
using con = Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using FE = Microsoft.Extensions.Configuration.FileConfigurationExtensions;
using System.IO;


namespace APXClient.APXFacilitator
{
    public class SignalRSNone:SignalRBase
    {
        public SignalRSNone(string sUrl, APXControler apx) :base(sUrl)//,apx)
        {
            
            base.m_transportType = con.HttpTransportType.None;
            base.m_hubConnection = new HubConnectionBuilder().WithUrl(sUrl).Build();

        }

        public override  bool DoCreateGroup(string groupName)
        {

            try
            {

                base.m_hubConnection.SendAsync("AddUserToGroup", groupName).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        private bool DoDeleteUserGroup(string groupName)
        {

            try
            {

                base.m_hubConnection.SendAsync("RemoveUserFromGroup", groupName).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public   bool DoSendToOthers(string message)
        {

            try
            {

                base.m_hubConnection.SendAsync("SendToOthers", message).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public override  bool DoSendMessageToGroup(string groupName, string message)
        {

            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public override bool DoSendMessageToSelf(string message)
        {

            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }



        public override  bool DoSubscribe(string GroupName)
        {
            try
            {
                base.m_hubConnection.SendAsync("AddUserToGroup", GroupName).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public override bool DoInit(string groupName , string message)
        {
            base.m_hubConnection.On<string>("ReceiveMessage", message => ReceiveMessage(message));
            try
            {
                var t = Task.Run(async delegate
                {
                    await Task.Delay(2000);
                    return 42;
                });

                base.m_hubConnection.StartAsync().Wait();
                base.m_hubConnection.SendAsync("AddUserToGroup", groupName).Wait();
                t.Wait();
                base.m_hubConnection.SendAsync("SendToGroup", groupName, message).Wait();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;

        }

        
         private void ReceiveMessage(string message)
        {
            //foreach(var observer in base.m_observers)
            //{
            //    observer.OnCompleted();
            //}

            //m_APXControler.AMessageReceived += m_APXControler.AMessageReceived;
            if (message.Length > 4)
            {
                if (message.Substring(0, 4) == "User")
                {
                    var t = Task.Run(async delegate
                    {
                        await Task.Delay(2000);
                        return 42;
                    });
                    string UserId = message.Substring(5, 22);
                    string GoupId = string.Format("({0})", message.Split('(', ')')[1]);
                    //_connectionFacilitatorHub.AddUserToGroup(GoupId);
                    //_connectionFacilitatorHub.SendToGroup(GoupId, "A test Message");
                    base.m_hubConnection.SendAsync("SendToGroup", GoupId, "Client Detected").Wait();
                    t.Wait();
                    base.m_hubConnection.SendAsync("SendToCaller", "Server Detected").Wait();
                }

            }
            Console.WriteLine("-------->       "+ message);
            OnThresholdReached(EventArgs.Empty);
        }

        public override ProcessType ReceiveMessage(string message, ProcessType previous)
        {

            ProcessType processType;
            try
            {
                switch(message)
                {
                    case "InitEntry":
                        processType = ProcessType.Init_Message_Ak;
                        break;
                    case "RegEntry":
                        processType = ProcessType.Registry_Ak;
                        break;
                    case "OutEntry":
                        processType = ProcessType.Out_Ak;
                        break;
                    case "AppEntry":
                        processType = ProcessType.App_Ak;
                        break;
                    case "ConnetEntry":
                        processType = ProcessType.Connection_Ak;
                        break;
                    case "ProcessEntry":
                        processType = ProcessType.Process_Ak;
                        break;

                    default:
                        //if(message.Substring(0,5) == "Error")
                        //{
                        //    processType = ProcessType.Error_Ak;
                        //}

                        //processType = ProcessType.Dummy_Ak;
                        processType = ProcessType.Other_Ak;
                        
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                processType = ProcessType.Error_Ak;
                return processType;
            }
            return processType;
        }



        public override ProcessType SendMessage(string message, ProcessType current)
        {

            ProcessType processType = ProcessType.Other_Ak;
            try
            {
                switch (current)
                {
                    case ProcessType.Init_Message_Ak:
                        
                        break;
                    case ProcessType.Registry_Ak:
                        ;
                        break;
                    case ProcessType.Out_Ak:
                        ;
                        break;
                    case ProcessType.App_Ak:
                        
                        break;
                    case ProcessType.Connection_Ak:
                        
                        break;
                    case ProcessType.Process_Ak:
                        
                        break;
                    default:
                        //if(message.Substring(0,5) == "Error")
                        //{
                        //    processType = ProcessType.Error_Ak;
                        //}

                        //processType = ProcessType.Dummy_Ak;
                        processType = ProcessType.Other_Ak;

                        break;
                }
                return processType;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                processType = ProcessType.Error_Ak;
                return processType;
            }
            
        }



    }
}
