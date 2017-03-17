using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Naruto
{
    class Program
    {
        static void Main(string[] args)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.
            string url = "http://localhost:18080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }

    /// <summary>
    /// 保存Client識別資料的物件
    /// </summary>
    public class ClientInfo
    {
        public string ConnId { get; set; }

        public string ClientName { get; set; }
    }

    public class MyHub : Hub
    {
        /// <summary>
        /// 紀錄目前已連結的 Client 識別資料
        /// </summary>
        public static Dictionary<string, ClientInfo> CurrClients = new Dictionary<string, ClientInfo>();

        /// <summary>
        /// 提供Client 端呼叫
        /// 功能:對全體 Client 發送訊息
        /// </summary>
        /// <param name="message">發送訊息內容</param>
        public void SendMsg(string message)
        {
            string connId = Context.ConnectionId;
            lock (CurrClients)
            {
                if (CurrClients.ContainsKey(connId))
                {
                    Clients.All.ReceiveMsg(CurrClients[connId].ClientName, message);//呼叫 Client 端所提供 ReceiveMsg方法(ReceiveMsg 方法由 Client 端實作)
                }
            }
        }
        
        /// <summary>
        /// 提供 Client 端呼叫
        /// 功能:對 Server 進行身分註冊
        /// </summary>
        /// <param name="clientName">使用者稱謂</param>
        public void Register(string clientName)
        {
            string connId = Context.ConnectionId;
            lock (CurrClients)
            {
                if (!CurrClients.ContainsKey(connId))
                {
                    CurrClients.Add(connId, new ClientInfo { ConnId = connId, ClientName = clientName });
                }
            }
            Clients.All.NowUser(CurrClients);
        }

        /// <summary>
        /// Client 端離線時的動作
        /// </summary>
        /// <param name="stopCalled">true:為使用者正常關閉(離線); false: 使用者不正常關閉(離線)，如連線狀態逾時</param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            string connId = Context.ConnectionId;
            lock (CurrClients)
            {
                if (CurrClients.ContainsKey(connId))
                {
                    CurrClients.Remove(connId);
                }
            }
            Clients.All.NowUser(CurrClients);//呼叫 Client 所提供 NowUser 方法(ReceiveMsg 方法由Client 端實作)

            stopCalled = true;
            return base.OnDisconnected(stopCalled);
        }
    }
}
