using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;
using con = Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using FE = Microsoft.Extensions.Configuration.FileConfigurationExtensions;
using System.IO;
using APXClient.APXFacilitator;

namespace APXClient
{
    class Program
    {
        static void Main(string[] args)
        {
            APXControler ap = new APXControler("0", "https://localhost:44348/ConnectionFacilitatorHub");
            ap.DoInit();

        }

    }
        //class Program
        //{

        //    static void Main()
        //    {
        //        Console.WriteLine("Please specify the URL of SignalR Hub");

        //    var url = "https://localhost:44348/ConnectionFacilitatorHub";

        //        //Console.WriteLine("Please specify transport type:");
        //        //Console.WriteLine("0 - default");
        //        //Console.WriteLine("1 - WebSockets");
        //        //Console.WriteLine("2 - Server-sent events");
        //        //Console.WriteLine("3 - Long polling");

        //    var transportTypeNumber = "0";

        //        con.HttpTransportType transportType;

        //        switch (transportTypeNumber)
        //        {
        //            case "0":
        //                transportType = con.HttpTransportType.None;
        //                break;
        //            case "1":
        //                transportType = con.HttpTransportType.WebSockets;
        //                break;
        //            case "2":
        //                transportType = con.HttpTransportType.ServerSentEvents;
        //                break;
        //            case "3":
        //                transportType = con.HttpTransportType.LongPolling;
        //                break;
        //            default:
        //                Console.WriteLine("Invalid transport type specified");
        //                Console.ReadKey();
        //                return;
        //        }

        //        var hubConnection = transportType == con.HttpTransportType.None ?
        //            new HubConnectionBuilder()
        //            .WithUrl(url)
        //            .Build() :
        //            new HubConnectionBuilder()
        //            .WithUrl(url, transportType)
        //            .Build();

        //        hubConnection.On<string>("ReceiveMessage", message => ReceiveMessage(message));

        //        try
        //        {
        //        var con = true;
        //        do
        //        {
        //            try
        //            {
        //                hubConnection.StartAsync().Wait();
        //                con = false;
        //                hubConnection.SendAsync("AddUserToGroup", "(ABC)").Wait();
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine("ServerNotfound");
        //            }

        //        } while (con);
        //        //hubConnection.StartAsync().Wait();
        //        Console.WriteLine("Connected...");
        //        var running = true;

        //            while (running)
        //            {
        //                var message = string.Empty;
        //                var groupName = string.Empty;

        //                Console.WriteLine("Please specify the action:");
        //                Console.WriteLine("0 - broadcast to all");
        //                Console.WriteLine("1 - send to itself");
        //                Console.WriteLine("2 - send to others");
        //                Console.WriteLine("3 - send to a group");
        //                Console.WriteLine("4 - add user to a group");
        //                Console.WriteLine("5 - remove user from a group");
        //                Console.WriteLine("exit - Exit the program");

        //                var action = Console.ReadLine();

        //                if (action == "0" || action == "1" || action == "2" || action == "3")
        //                {
        //                    Console.WriteLine("Please specify the message:");
        //                    message = Console.ReadLine();
        //                }

        //                if (action == "3" || action == "4" || action == "5")
        //                {
        //                    Console.WriteLine("Please specify the group name:");
        //                    groupName = Console.ReadLine();
        //                }

        //                switch (action)
        //                {
        //                    case "0":
        //                        hubConnection.SendAsync("BroadcastMessage", message).Wait();
        //                        break;
        //                    case "1":
        //                        hubConnection.SendAsync("SendToCaller", message).Wait();
        //                        break;
        //                    case "2":
        //                        hubConnection.SendAsync("SendToOthers", message).Wait();
        //                        break;
        //                    case "3":
        //                        hubConnection.SendAsync("SendToGroup", groupName, message).Wait();
        //                        break;
        //                    case "4":
        //                        hubConnection.SendAsync("AddUserToGroup", groupName).Wait();
        //                        break;
        //                    case "5":
        //                        hubConnection.SendAsync("RemoveUserFromGroup", groupName).Wait();
        //                        break;
        //                    case "exit":
        //                        running = false;
        //                        break;
        //                    default:
        //                        Console.WriteLine("Invalid action specified");
        //                        break;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            Console.WriteLine("Press any key to exit...");
        //            Console.ReadKey();
        //            return;
        //        }

        //        void ReceiveMessage(string message)
        //        {
        //            Console.WriteLine($"SignalR Hub Message: {message}");
        //        }
        //    }
        //}

        //}
    }
