using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using System.Collections.Generic;
using System.Threading.Tasks;
using Naruto.SystemClass;
using Naruto.Models;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Data.Entity;
using Naruto.DAL;
using System.Linq;
using TWCAlib;
using System.Threading;
using System.Text;

namespace Naruto
{
    class Program
    {
        private static SystemConfig configer = new SystemConfig();
        private static ShareFunc SF = new ShareFunc();
        private static string log_Info = "Info";
        private static string log_Err = "Err";
        static void Main(string[] args)
        {
            string CurrentDir = System.Environment.CurrentDirectory;
            string SystemConfigFileName = "SystemConfig.json";

            SF.logandshowInfo("讀取設定檔", log_Info);
            SF.logandshowInfo("設定檔路徑:"+ CurrentDir + @"\" + SystemConfigFileName, log_Err);
            string Json = File.ReadAllText(CurrentDir + @"\" + SystemConfigFileName);
            SF.logandshowInfo("讀取設定檔完成", log_Info);

            //初始化
            Console.WriteLine("Server  initializaing");
            Console.WriteLine("Loading config");
            SF.logandshowInfo("初始化Configer", log_Info);
            SF.logandshowInfo("Config json:"+ Json, log_Err);
            configer.InitFromJson(Json);
           
            if (configer != null)
            {
                Console.WriteLine("Loading complete");
                SF.logandshowInfo("初始化Configer完成", log_Info);

                Console.WriteLine("CheckClientWorkSate start");
                SF.logandshowInfo("確認client狀態", log_Info);
                CheckClientWorkSate();
                SF.logandshowInfo("確認client狀態完成", log_Info);
                Console.WriteLine("CheckClientWorkSate complete");

                Console.WriteLine("GenReport and Send start");
                SF.logandshowInfo("產製報表", log_Info);
                GenReport();
                SF.logandshowInfo("產製報表完成", log_Info);
                Console.WriteLine("GenReport and Send complete");
            }
            else
            {
                Console.WriteLine("Config load error");
                SF.logandshowInfo("初始化Configer異常", log_Info);
            }
          

            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.

            //計算距離排程時間(秒)
            //DateTime CheckTime = Convert.ToDateTime(configer.StartHour.ToString() + configer.SplitSymbol2 + configer.StartMiniute);
            //double DiffTime = Convert.ToDouble(OtherProcesser.TimeDiff( DateTime.Now, CheckTime, "Seconds"));

            //啟動http服務
            //Console.WriteLine("Starting http Service");
            //string url = "http://"+configer.ServerIP+configer.SplitSymbol2+configer.ServerListenPort.ToString();
            //using (WebApp.Start(url))
            //{
            //    Console.WriteLine("Starting http Service complete");
            //    Console.WriteLine("Server running on {0}", url);

            //    //啟動排程
            //    Console.WriteLine("The check job will start in {0} seconds latter", DiffTime);
            //    Timer t = new Timer(TimerCallback, null,  Convert.ToInt16(DiffTime) * 1000,configer.Schedule * 1000);
            //    Console.ReadLine();
            //}
        }

        //
        //private static void TimerCallback(Object o)
        //{
        //    //請所有線上的Client 進行檢查
        //    IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        //    hubContext.Clients.All.addMessage("Check");
        //    GC.Collect();
        //}

        /// <summary>
        /// 確認主機是否有被記錄
        /// </summary>
        /// <param name="ServerName">主機名稱</param>
        /// <returns></returns>
        public bool isExistServer(string ServerName)
        {
            bool Exist = true;

            using (var db = new SDContext())
            {
                int ServerCount = db.CheckServers
                    .Where(b => b.Name == ServerName)
                    .Count();

                if (ServerCount > 0)
                {

                }
                else
                {
                    Exist = false;
                }
            }
            return Exist;
        }

        /// <summary>
        /// 新增主機資訊
        /// </summary>
        /// <param name="clientName">主機名稱</param>
        /// <param name="clientIP">主機IP</param>
        public void AddServer(string clientName, string clientIP)
        {
            using (var db = new SDContext())
            {
                CheckServers S = new CheckServers();
                S.Name = clientName;
                S.IP = clientIP;
                S.Enable = true;
                //S.DoChcek = true;
                S.DirListTime = Convert.ToDateTime("1911-01-01");
                S.DataListTime = Convert.ToDateTime("1911-01-01");
                S.LogDirListTime = Convert.ToDateTime("1911-01-01");
                S.UpdateTime = DateTime.Now;

                db.CheckServers.Add(S);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// /確認Client回報時間
        /// </summary>
        private static void CheckClientWorkSate()
        {
            bool WorkSate = true;
            DateTime CheckDate = DateTime.Now.Date;
            string CheckMsg = string.Empty;
            using (var db= new SDContext())
            {
                SF.logandshowInfo("開始確認client回報時間", log_Info);
                //挑出所有有效的client
                SF.logandshowInfo("開始從資料庫找出有效client",log_Err);
                var query = db.CheckServers
                    .Where(b => b.Enable == true);
                    //.Where(b=>b.EnableDataCheck==true);
                SF.logandshowInfo("從資料庫找出有效client完成", log_Err);
                SF.logandshowInfo("有效client共:"+ query.Count().ToString(), log_Err);

                if (query.Count() > 0)
                {
                    foreach (var item in query.ToList())
                    {
                        DateTime LastCheckTime = item.CheckStartTime;
                        SF.logandshowInfo("client:" + item.Name + "最後一次檢查時間:"+ LastCheckTime.ToString(configer.SystemDateTimeFormat), log_Err);

                        if (LastCheckTime > DateTime.Now)
                        {
                            //最後一次檢查時間超過目前時間，代表有問題
                            WorkSate = false;
                            CheckMsg= "最後一次檢查時間超過目前時間";
                            SF.logandshowInfo("client:" + item.Name + CheckMsg, log_Err);
                        }
                        else
                        {
                            SF.logandshowInfo("開始計算本次時間與上次檢查時間差異", log_Err);
                            Double DiffHour = Convert.ToDouble(OtherProcesser.TimeDiff(LastCheckTime, DateTime.Now, "Hours"));
                            SF.logandshowInfo("計算本次時間與上次檢查時間差異完成", log_Err);
                            SF.logandshowInfo("差異時間(小時):"+ DiffHour.ToString(), log_Err);
                            if (DiffHour > configer.Tolerance)
                            {
                                //檢查間隔超過設定的容許值，代表有問題
                                WorkSate = false;
                                CheckMsg = "檢查程式未正常執行";
                                SF.logandshowInfo("client:" + item.Name + CheckMsg, log_Err);
                            }
                        }

                        if (!WorkSate)
                        {
                            //新增檢查明細
                            SF.logandshowInfo("開始新增client:" + item.Name + "檢查明細", log_Info);
                            SF.logandshowInfo("client:" + item.Name + "檢查明細:" + CheckMsg, log_Err);
                            SF.addCheckReportItem(item.Name, item.IP, CheckDate, CheckMsg);
                            SF.logandshowInfo("新增client:" + item.Name + "檢查明細完成", log_Info);
                        }
                        else
                        {
                            SF.logandshowInfo("client:" + item.Name + "最後一次檢查時間正常", log_Info);
                        }

                        ////若有啟用資料檢查，要讀取資料基板時間檢查
                        //if (item.EnableDataCheck)
                        //{
                        //    SF.logandshowInfo("client:" + item.Name + "有啟用資料檢查", log_Info);
                        //    DateTime LastDataListTime = item.DataListTime;
                        //    SF.logandshowInfo("client:" + item.Name + "資料基板最後異動時間:" + LastDataListTime.ToString(configer.SystemDateTimeFormat), log_Err);

                        //    if (LastDataListTime > DateTime.Now)
                        //    {
                        //        //最後一次檢查時間超過目前時間，代表有問題
                        //        WorkSate = false;
                        //        CheckMsg = "最後一次資料基板時間超過目前時間";
                        //        SF.logandshowInfo("client:" + item.Name + CheckMsg, log_Err);
                        //    }
                        //    else
                        //    {
                        //        int DiffHour = Convert.ToInt16(OtherProcesser.TimeDiff(LastDataListTime, DateTime.Now, "Hours"));
                        //        if (DiffHour > configer.Tolerance)
                        //        {
                        //            //檢查間隔超過設定的容許值，代表有問題
                        //            WorkSate = false;
                        //            CheckMsg = "資料基板時間未更新";
                        //            SF.logandshowInfo("client:" + item.Name + CheckMsg, log_Err);
                        //        }
                        //    }

                        //    if (!WorkSate)
                        //    {
                        //        //新增檢查明細
                        //        SF.logandshowInfo("開始新增client:" + item.Name + "檢查明細", log_Info);
                        //        SF.logandshowInfo("client:" + item.Name + ",檢查明細:" + CheckMsg, log_Err);
                        //        SF.addCheckReportItem(item.Name, item.IP, CheckDate, CheckMsg);
                        //        SF.logandshowInfo("新增client:" + item.Name + "檢查明細完成", log_Info);
                        //    }
                        //    else
                        //    {
                        //        SF.logandshowInfo("client:" + item.Name + "資料基板時間正常", log_Info);
                        //    }
                        //}
                        //else
                        //{
                        //    SF.logandshowInfo("client:" + item.Name + "未啟用資料檢查", log_Info);
                        //}

                        ////若有啟用Log檢查，要讀取Log基板時間檢查
                        //if (item.EnableLogCheck)
                        //{
                        //    //SF.logandshowInfo("client:" + item.Name + "有啟用Log檢查", log_Info);
                        //    //DateTime LastLogDirTime = item.LogDirListTime;
                        //    //SF.logandshowInfo("client:" + item.Name + "Log基板最後異動時間:" + LastLogDirTime.ToString(configer.SystemDateTimeFormat), log_Err);

                        //    //if (LastLogDirTime > DateTime.Now)
                        //    //{
                        //    //    //最後一次檢查時間超過目前時間，代表有問題
                        //    //    WorkSate = false;
                        //    //    CheckMsg = "最後一次Log基板時間超過目前時間";
                        //    //    SF.logandshowInfo("client:" + item.Name + CheckMsg, log_Err);
                        //    //}
                        //    //else
                        //    //{
                        //    //    int DiffHour = Convert.ToInt16(OtherProcesser.TimeDiff(LastLogDirTime, DateTime.Now, "Hours"));
                        //    //    if (DiffHour > configer.Tolerance)
                        //    //    {
                        //    //        //檢查間隔超過設定的容許值，代表有問題
                        //    //        WorkSate = false;
                        //    //        CheckMsg = "Log基板時間未更新";
                        //    //        SF.logandshowInfo("client:" + item.Name + CheckMsg, log_Err);
                        //    //    }
                        //    //}

                        //    //if (!WorkSate)
                        //    //{
                        //    //    //新增檢查明細
                        //    //    SF.logandshowInfo("開始新增client:" + item.Name + "檢查明細", log_Info);
                        //    //    SF.logandshowInfo("client:" + item.Name + ",檢查明細:" + CheckMsg, log_Err);
                        //    //    SF.addCheckReportItem(item.Name, item.IP, CheckDate, CheckMsg);
                        //    //    SF.logandshowInfo("新增client:" + item.Name + "檢查明細完成", log_Info);
                        //    //}
                        //    //else
                        //    //{
                        //    //    SF.logandshowInfo("client:" + item.Name + "Log基板時間正常", log_Info);
                        //    //}
                        //}
                        //else
                        //{
                        //    SF.logandshowInfo("client:" + item.Name + "未啟用Log檢查", log_Info);
                        //}

                        if (!WorkSate)
                        {
                            if (db.CheckReportSummaries.Any(b => b.ServerName == item.Name))
                            {
                                SF.logandshowInfo("有client:" + item.Name + "彙總資料", log_Info);
                                SF.logandshowInfo("開始從資料庫找出client:" + item.Name + "彙總資料", log_Info);
                                CheckReportSummaries RS = db.CheckReportSummaries
                                           .Where(b => b.ServerName == item.Name)
                                           //.Where(b => b.ServerIP == item.IP)
                                           .First();
                                SF.logandshowInfo("從資料庫找出client:" + item.Name + "彙總資料完成", log_Info);

                                SF.logandshowInfo("修改彙總資料的檢查結果:false", log_Info);
                                RS.CheckResult = false;
                                RS.UpdateTime = DateTime.Now;
                                SF.logandshowInfo("修改資料庫Entity:CheckReportSummaries", log_Info);
                                db.Entry(RS).State = EntityState.Modified;
                            }
                            else
                            {
                                //新增彙總報表
                                CheckReportSummaries RS = new CheckReportSummaries();
                                SF.logandshowInfo("沒有client:" + item.Name + "彙總資料", log_Info);
                                SF.logandshowInfo("開始新增client:" + item.Name + "彙總資料", log_Info);
                                SF.logandshowInfo("設定檢查結果:false", log_Info);
                                RS.ServerName = item.Name;
                                RS.ServerIP = item.IP;
                                RS.CheckResult = false;
                                RS.DataCount = 0;
                                RS.DirCount = 0;
                                RS.LogCount = 0;
                                RS.UpdateTime = DateTime.Now;
                                SF.logandshowInfo("新增資料庫Entity:CheckReportSummaries", log_Info);
                                db.CheckReportSummaries.Add(RS);
                            }
                            SF.logandshowInfo("開始實際資料庫異動", log_Info);
                            db.SaveChanges();
                            SF.logandshowInfo("實際資料庫異動完成", log_Info);
                        }
                    }
                    SF.logandshowInfo("確認Client回報時間完成", log_Info);
                }
                else
                {
                    //沒有任何有效client
                    SF.logandshowInfo("沒有任何有效Client", log_Info);
                    SF.logandshowInfo("確認client回報時間完成", log_Info);
                }
            }
        }

        /// <summary>
        /// 產生報表並且寄送
        /// </summary>
        private static void GenReport()
        {
            string MailSubject = configer.MailSubject;
            string MailBody = string.Empty;

            using (var db= new SDContext())
            {
                SF.logandshowInfo("開始產製報表", log_Info);
                DateTime CheckDate = DateTime.Now.Date;
                bool ReplaceResult = false;

                //挑出所有有效的client
                SF.logandshowInfo("開始從資料庫找出有效client", log_Err);

                var query = db.CheckServers
                    .Where(b => b.Enable == true)
                    .Where(b => b.EnableDataCheck == true);
                SF.logandshowInfo("從資料庫找出有效client完成", log_Err);
                SF.logandshowInfo("有效client共:" + query.Count().ToString(), log_Err);

                if (query.Count() > 0)
                {
                    string Table = "<table border=1><tr><td>主機名稱</td><td>是否完成檢查</td><td>檢查結果</td><td>檢查訊息</td><td>檢查開始時間</td><td>檢查結束時間</td><td>檢查花費時間(毫秒)</td>";

                    foreach (var item in query.ToList())
                    {

                        CheckDate = item.CheckStartTime;

                        if (db.CheckReportSummaries
                            .Any(b => b.ServerName == item.Name))
                        {
                            SF.logandshowInfo("有client:" + item.Name + "彙總資料", log_Info);
                            SF.logandshowInfo("開始從資料庫找出client:" + item.Name + "彙總資料", log_Info);
                            CheckReportSummaries RS = db.CheckReportSummaries
                                .Where(b => b.ServerName == item.Name)
                                //.Where(b => b.ServerIP == item.IP)
                                .First();
                            SF.logandshowInfo("從資料庫找出client:" + item.Name + "彙總資料完成", log_Info);

                            StringBuilder Rows = new StringBuilder();
                            Rows.Append("<tr>");
                            Rows.Append("<td>" + RS.ServerName + "</td>");

                            if (item.Finish)
                            {
                                Rows.Append("<td>完成</td>");
                            }
                            else
                            {
                                Rows.Append("<td bgcolor='#FF3333'>未完成</td>");
                            }

                            if (RS.CheckResult)
                            {
                                Rows.Append("<td>正常</td>");
                            }
                            else
                            {
                                Rows.Append("<td bgcolor='#FF3333'>異常</td>");
                                if (!ReplaceResult)
                                {
                                    ReplaceResult = true;
                                }
                            }
                            //取得回報訊息
                            SF.logandshowInfo("開始取得client:" + item.Name + "回報訊息", log_Info);
                            string CheckMsg = getCheckMsg(RS.ServerName, RS.ServerIP, CheckDate);
                            SF.logandshowInfo("client:" + item.Name + "回報訊息:" + CheckMsg, log_Info);
                            SF.logandshowInfo("取得client:" + item.Name + "回報訊息完成", log_Info);

                            if (CheckMsg != "")
                            {
                                Rows.Append("<td>" + CheckMsg + "</td>");
                            }
                            else
                            {
                                Rows.Append("<td></td>");
                            }

                            Rows.Append("<td>" + item.CheckStartTime.ToString(configer.SystemDateTimeFormat) + "</td>");
                            Rows.Append("<td>" + item.CheckEndTime.ToString(configer.SystemDateTimeFormat) + "</td>");
                            Rows.Append("<td>" + item.CheckCost + "</td>");

                            Rows.Append("</tr>");
                            Table = Table + Rows.ToString() + "</table>";

                            MailBody = Table;
                        }
                        else
                        {
                            //沒有彙總資訊
                            MailBody = "<h2>沒有回報資料</h2>";
                        }
                    }
                }
                else
                {
                    //沒有任何client
                    MailBody = "<h2>無有效主機資料</h2>";
                }
                MailSubject = MailSubject.Replace("#ReportDate", DateTime.Now.ToShortDateString());

                SF.logandshowInfo("MailBody len:" + MailBody.Length.ToString(), log_Info);

                if (ReplaceResult)
                {
                  MailSubject= MailSubject.Replace("#CheckResult", "異常");
                }
                else
                {
                    MailSubject = MailSubject.Replace("#CheckResult", "正常");
                }

                SF.logandshowInfo("檢查日期:" + CheckDate.ToString(), log_Info);
                SF.logandshowInfo("報表主旨:" + MailSubject , log_Info);
                SF.logandshowInfo("報表內容:" + MailBody, log_Info);

                //寄送報表
                SF.logandshowInfo("開始寄送報表", log_Info);
                SF.EmailNotify2Sys(configer.MailServer, configer.MailServerPort, configer.MailSender, configer.MailReceiver, false, MailSubject, MailBody);
                SF.logandshowInfo("寄送報表完成", log_Info);
            }
        }

        /// <summary>
        /// 取得回報訊息
        /// </summary>
        /// <param name="Name">主機名稱</param>
        /// <param name="IP">主機IP</param>
        /// <param name="CheckDate">檢查日期</param>
        /// <returns></returns>
        private static string getCheckMsg(string Name, string IP, DateTime CheckDate)
        {
            using (var db= new SDContext())
            {
                var q = db.CheckReportItems
                    .Where(b => b.ServerName == Name)
                    //.Where(b => b.ServerIP == IP)
                    .Where(b => b.CheckDate == CheckDate);

                StringBuilder CheckMsg = new StringBuilder();

                if (q.Count() > 0)
                {
                    foreach (var item in q.ToList())
                    {
                        CheckMsg.Append(item.CheckMsg +"</br>" );
                    }

                    return CheckMsg.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
    }

    //class Startup
    //{
    //    public void Configuration(IAppBuilder app)
    //    {
    //        app.UseCors(CorsOptions.AllowAll);
    //        app.MapSignalR();
    //    }
    //}

    ///// <summary>
    ///// 保存Client識別資料的物件
    ///// </summary>
    //public class ClientInfo
    //{
    //    public string ConnId { get; set; }

    //    public string ClientName { get; set; }

    //    public string clientIP { get; set; }
    //}

    //public class MyHub : Hub
    //{
    //    /// <summary>
    //    /// 紀錄目前已連結的 Client 識別資料
    //    /// </summary>
    //    public static Dictionary<string, ClientInfo> CurrClients = new Dictionary<string, ClientInfo>();

    //    /// <summary>
    //    /// client端回報檢查結果
    //    /// </summary>
    //    /// <param name="R">檢查結果物件</param>
    //    //public void ReportCheckResult(CheckReportSummaries R)
    //    //{
    //    //    string connId = Context.ConnectionId;
    //    //    lock (CurrClients)
    //    //    {
    //    //        //if (CurrClients.ContainsKey(connId))
    //    //        //{
    //    //        //    Clients.All.ReceiveMsg(CurrClients[connId].ClientName, message);//呼叫 Client 端所提供 ReceiveMsg方法(ReceiveMsg 方法由 Client 端實作)
    //    //        //}
    //    //    }
    //    //}

    //    /// <summary>
    //    /// /client端回報基板檔案時間
    //    /// </summary>
    //    /// <param name="clientName">使用者稱謂</param>
    //    /// <param name="Type">基板類型</param>
    //    /// <param name="BaseFileTime">基板最後異動時間</param>
    //    //public void ReportBaseFileTime(string clientName,string Type,DateTime BaseFileTime)
    //    //{
    //    //    string connId = Context.ConnectionId;
    //    //    lock (CurrClients)
    //    //    {
    //    //        if (CurrClients.ContainsKey(connId))
    //    //        {
    //    //            //檢查基板時間
    //    //            if (CheckBaseFileTime(clientName, Type, BaseFileTime))
    //    //            {
    //    //                // 檢查正常，do nothing
    //    //            }
    //    //            else
    //    //            {
    //    //                using (var db = new SDContext())
    //    //                {
    //    //                    CheckServers C = db.CheckServers.Where(b => b.Name == clientName).First();

    //    //                    if (C !=null)
    //    //                    {
    //    //                        C.DoChcek = false;
    //    //                        db.Entry(C).State = EntityState.Modified;
    //    //                    }

    //    //                    int ReportItemCount = db.CheckReportItems.Where(b=>b.ServerName== clientName).Count();

    //    //                    CheckReportItems R = db.CheckReportItems.Where(b => b.ServerName == clientName).First();

    //    //                    if (R != null)
    //    //                    {
    //    //                        R.CheckResult = false;
    //    //                        R.DataCount = 0;
    //    //                        R.DirCount = 0;
    //    //                        R.LogCount = 0;
    //    //                        R.UpdateTime = DateTime.Now;
    //    //                        R.CheckMsg = "基板檔案時間異常，請檢查";
    //    //                        db.Entry(R).State = EntityState.Modified;
    //    //                    }
    //    //                    else
    //    //                    {
    //    //                        //寫入報表
    //    //                        //CheckReportItems R = new CheckReportItems();
    //    //                        R.ServerName = C.Name;
    //    //                        R.ServerIP = C.IP;
    //    //                        R.CheckResult = false;
    //    //                        R.DataCount = 0;
    //    //                        R.DirCount = 0;
    //    //                        R.LogCount = 0;
    //    //                        R.UpdateTime = DateTime.Now;
    //    //                        R.CheckMsg = "基板檔案時間異常，請檢查";
    //    //                        db.CheckReportItems.Add(R);
    //    //                    }
    //    //                    db.SaveChanges();

    //    //                    //請client離線
    //    //                    Clients.Client(connId).addMesage("disconnect");
    //    //                }
    //    //            }
    //    //        }
    //    //    }
    //    //}

    //    /// <summary>
    //    /// /檢查基板最後異動時間是否正常
    //    /// </summary>
    //    /// <param name="clientName">使用者稱謂</param>
    //    /// <param name="Type">基板類型</param>
    //    /// <param name="BaseFileTime">基板最後異動時間</param>
    //    /// <returns></returns>
    //    //public bool CheckBaseFileTime(string clientName, string Type, DateTime BaseFileTime)
    //    //{
    //    //    bool CheckResult = true;
    //    //    DateTime nowBaseFileTime=new DateTime();

    //    //    using (var db= new SDContext())
    //    //    {
    //    //        switch (Type)
    //    //        {
    //    //            case "Dir":
    //    //                nowBaseFileTime = db.CheckServers.Where(b => b.Name == clientName).First().LogDirListTime;
    //    //                break;
    //    //            case "Data":
    //    //                nowBaseFileTime = db.CheckServers.Where(b => b.Name == clientName).First().DataListTime;
    //    //                break;
    //    //            case "LogDir":
    //    //                nowBaseFileTime = db.CheckServers.Where(b => b.Name == clientName).First().LogDirListTime;
    //    //                break;
    //    //            default:
    //    //                break;
    //    //        }

    //    //        if (nowBaseFileTime != null)
    //    //        {
    //    //            if (nowBaseFileTime > DateTime.Now)
    //    //            {
    //    //                CheckResult = false;
    //    //            }
    //    //            else
    //    //            {
    //    //                if (Convert.ToInt16(OtherProcesser.TimeDiff(nowBaseFileTime, DateTime.Now, "Days"))>=2)
    //    //                {
    //    //                    CheckResult = false;
    //    //                }
    //    //            }
    //    //        }
    //    //        else
    //    //        {
    //    //            CheckResult = false;
    //    //        }
    //    //    }

    //    //    return CheckResult;
    //    //}

    //    /// <summary>
    //    /// 提供Client 端呼叫
    //    /// 功能:對全體 Client 發送訊息
    //    /// </summary>
    //    /// <param name="message">發送訊息內容</param>
    //    //public void SendMsg(string message)
    //    //{
    //    //    string connId = Context.ConnectionId;
    //    //    lock (CurrClients)
    //    //    {
    //    //        if (CurrClients.ContainsKey(connId))
    //    //        {
    //    //            Clients.All.ReceiveMsg(CurrClients[connId].ClientName, message);//呼叫 Client 端所提供 ReceiveMsg方法(ReceiveMsg 方法由 Client 端實作)
    //    //        }
    //    //    }
    //    //}
        
    //    /// <summary>
    //    /// 提供 Client 端呼叫
    //    /// 功能:對 Server 進行身分註冊
    //    /// </summary>
    //    /// <param name="clientName">使用者稱謂</param>
    //    //public void Register(string clientName,string clientIP)
    //    //{
    //    //    string connId = Context.ConnectionId;
    //    //    lock (CurrClients)
    //    //    {
    //    //        //新Client
    //    //        if (!CurrClients.ContainsKey(connId))
    //    //        {
    //    //            CurrClients.Add(connId, new ClientInfo { ConnId = connId, ClientName = clientName ,clientIP=clientIP});
    //    //            //確認主機是否有被記錄
    //    //            if (! isExistServer(clientName))
    //    //            {
    //    //                //新增主機資訊
    //    //                AddServer(clientName, clientIP);
    //    //            }

    //    //            //請client端回報基板最後異動時間
    //    //            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
    //    //            hubContext.Clients.Client(connId).addMesage("getBaseFileTime");
    //    //        }
    //    //    }
    //    //    Clients.All.NowUser(CurrClients);
    //    //}

    //    /// <summary>
    //    /// Client 端離線時的動作
    //    /// </summary>
    //    /// <param name="stopCalled">true:為使用者正常關閉(離線); false: 使用者不正常關閉(離線)，如連線狀態逾時</param>
    //    /// <returns></returns>
    //    //public override Task OnDisconnected(bool stopCalled)
    //    //{
    //    //    string connId = Context.ConnectionId;
    //    //    lock (CurrClients)
    //    //    {
    //    //        if (CurrClients.ContainsKey(connId))
    //    //        {
    //    //            CurrClients.Remove(connId);
    //    //        }
    //    //    }
    //    //    Clients.All.NowUser(CurrClients);//呼叫 Client 所提供 NowUser 方法(ReceiveMsg 方法由Client 端實作)

    //    //    stopCalled = true;
    //    //    return base.OnDisconnected(stopCalled);
    //    //}

       
    //}
}
