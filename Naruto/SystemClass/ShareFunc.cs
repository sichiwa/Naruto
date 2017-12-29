using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using TWCAlib;
using NLog;
using Naruto.SystemClass;
using System.Linq.Expressions;
using System.Net;
using Naruto.DAL;
using Naruto.Models;
using System.Data.Entity.SqlServer;

namespace Naruto.SystemClass
{
    public class ShareFunc
    {
        SDContext context = new SDContext();
        SystemConfig Configer = new SystemConfig();
        public static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private string _ConnStr;

        private string _op_name;
        private string log_Info = "Info";
        private string log_Err = "Err";
        public enum MailPriority : int
        {
            Low = 0,
            Middle = 1,
            High = 2
        }

        public string getNowDateString()
        {
            //初始化系統參數
            Configer.Init();

            return DateTime.Now.ToString(Configer.SystemDateTimeFormat);
        }

        /// <summary>
        /// 將資訊記錄至Log檔中
        /// </summary>
        /// <param name="_Str">顯示資訊</param>
        /// <param name="_Mode">Err:記錄至Debug log;Info記錄至Info log:</param>
        /// <remarks>2014/03/04 黃富彥</remarks>
        public void logandshowInfo(string _Str, string _Mode)
        {
            if ((_Mode == "Err"))
            {
                logger.Error(_Str);
            }
            else
            {
                logger.Info(_Str);
            }
        }

        /// <summary>
        /// 將執行結果寫入資料庫
        /// </summary>
        /// <param name="_OPLogger">OPLoger類別</param>
        /// <remarks>2014/03/04 黃富彥</remarks>
        //public void log2DB(SystemLogs _SL,
        //                   string _MailServer,
        //                   int _MailServerPort,
        //                   string _MailSender,
        //                   List<string> _MailReceiver)
        //{
        //    SystemLogs SL = _SL;
        //    string MailServer = _MailServer;
        //    int MailServerPort = _MailServerPort;
        //    string MailSender = _MailSender;
        //    List<string> MailReceiver = _MailReceiver;
        //    string MailSubject = string.Empty;
        //    StringBuilder MailBody = new StringBuilder();
        //    string SendResult = string.Empty;

        //    try
        //    {
        //        using (CMDBContext context = new CMDBContext())
        //        {
        //            //初始化系統參數
        //            Configer.Init();

        //            StringBuilder PlainText = new StringBuilder();
        //            PlainText.Append(SL.Account + Configer.SplitSymbol);
        //            PlainText.Append(SL.Controller + Configer.SplitSymbol);
        //            PlainText.Append(SL.Action + Configer.SplitSymbol);
        //            PlainText.Append(SL.StartTime.ToString() + Configer.SplitSymbol);
        //            PlainText.Append(SL.EndTime.ToString() + Configer.SplitSymbol);
        //            PlainText.Append(SL.TotalCount.ToString() + Configer.SplitSymbol);
        //            PlainText.Append(SL.SuccessCount.ToString() + Configer.SplitSymbol);
        //            PlainText.Append(SL.FailCount.ToString() + Configer.SplitSymbol);
        //            PlainText.Append(SL.Result.ToString() + Configer.SplitSymbol);
        //            PlainText.Append(SL.Msg);

        //            //計算HASH值
        //            SL.HashValue = getHashValue(PlainText.ToString());

        //            context.SystmeLogs.Add(SL);
        //            context.SaveChanges();

        //            //寫入文字檔Log
        //            logandshowInfo("[" + SL.Account + "]執行[寫入資料庫紀錄作業]成功", log_Info);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //異常
        //        //寫入文字檔Log
        //        logandshowInfo("[" + SL.Account + "]執行[寫入資料庫紀錄作業]發生未預期的異常,請查詢Debug Log得到詳細資訊", log_Info);
        //        logandshowInfo("[" + SL.Account + "]執行[寫入資料庫紀錄作業]發生未預期的異常,詳細資訊如下", log_Err);
        //        logandshowInfo("執行人:[" + SL.Account + "]", log_Err);
        //        logandshowInfo("執行模組名稱:[" + SL.Controller + "]", log_Err);
        //        logandshowInfo("執行作業名稱:[" + SL.Action + "]", log_Err);
        //        logandshowInfo("處理結果:[" + SL.Result.ToString() + "]", log_Err);
        //        logandshowInfo("起始時間:[" + SL.StartTime.ToString() + "]", log_Err);
        //        logandshowInfo("結束時間:[" + SL.EndTime.ToString() + "]", log_Err);
        //        logandshowInfo("處理總筆數:[" + SL.TotalCount.ToString() + "]", log_Err);
        //        logandshowInfo("處理成功筆數:[" + SL.SuccessCount.ToString() + "]", log_Err);
        //        logandshowInfo("處理失敗筆數:[" + SL.FailCount.ToString() + "]", log_Err);
        //        logandshowInfo("作業訊息:[" + SL.Msg + "]", log_Err);
        //        logandshowInfo("錯誤訊息:[" + ex.ToString() + "]", log_Err);

        //        //通知系統管理人員
        //        MailSubject = "[異常]組態管理系統-執行[寫入資料庫紀錄作業]失敗";
        //        MailBody.Append("<table>");
        //        MailBody.Append("<tr><td>");
        //        MailBody.Append("執行人:[" + SL.Account + "]");
        //        MailBody.Append("</td></tr>");
        //        MailBody.Append("<tr><td>");
        //        MailBody.Append("執行模組名稱:[" + SL.Controller + "]");
        //        MailBody.Append("</td></tr>");
        //        MailBody.Append("<tr><td>");
        //        MailBody.Append("執行作業名稱:[" + SL.Action + "]");
        //        MailBody.Append("</td></tr>");
        //        MailBody.Append("<tr><td>");
        //        MailBody.Append("處理結果:[" + SL.Result.ToString() + "]");
        //        MailBody.Append("</td></tr>");
        //        MailBody.Append("<tr><td>");
        //        MailBody.Append("起始時間:[" + SL.StartTime.ToString() + "]");
        //        MailBody.Append("</td></tr>");
        //        MailBody.Append("<tr><td>");
        //        MailBody.Append("結束時間:[" + SL.EndTime.ToString() + "]");
        //        MailBody.Append("</td></tr>");
        //        MailBody.Append("<tr><td>");
        //        MailBody.Append("處理總筆數:[" + SL.TotalCount.ToString() + "]");
        //        MailBody.Append("</td></tr>");
        //        MailBody.Append("<tr><td>");
        //        MailBody.Append("處理成功筆數:[" + SL.SuccessCount.ToString() + "]");
        //        MailBody.Append("</td></tr>");
        //        MailBody.Append("<tr><td>");
        //        MailBody.Append("處理失敗筆數:[" + SL.FailCount.ToString() + "]");
        //        MailBody.Append("</td></tr>");
        //        MailBody.Append("<tr><td>");
        //        MailBody.Append("作業訊息:[" + SL.Msg + "]");
        //        MailBody.Append("</td></tr>");
        //        MailBody.Append("<tr><td>");
        //        MailBody.Append("錯誤訊息:[" + ex.ToString() + "]");
        //        MailBody.Append("</td></tr>");
        //        MailBody.Append("</table>");

        //        EmailNotify2Sys(MailServer, MailServerPort, MailSender, MailReceiver, false, MailSubject, MailBody.ToString());
        //    }

        //}

        /// <summary>
        /// 寄送郵件
        /// </summary>
        /// <param name="_MailServer">郵件主機位置</param>
        /// <param name="_MailServerPort">郵件主機服務Port</param>
        /// <param name="_MailSender">寄件者</param>
        /// <param name="_MailReceivers">收件者清單</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SendEmail(string _MailServer, int _MailServerPort, string _MailSender, List<string> _MailReceivers, string _Subject, string _Body)
        {
            string SendResult = null;
            MailProcessor MailP = new MailProcessor();
            string MailServer = _MailServer;
            int MailServerPort = _MailServerPort;
            string MailSender = _MailSender;
            List<string> MailReceivers = _MailReceivers;
            string MailSubject = _Subject;
            string SendBody = _Body;
            List<System.Net.Mail.Attachment> MailA = new List<System.Net.Mail.Attachment>();
            List<string> MailCC = new List<string>();

            MailP.setMailProcossor(MailSender, MailReceivers, MailCC, MailSubject, SendBody, MailA, MailServer, MailServerPort, false, true,
            MailPriority.High.ToString(), 65001);

            SendResult = MailP.Send();

            return SendResult;
        }

        /// <summary>
        /// Email通知系統管理人員
        /// </summary>
        /// <param name="_WitreDB">是否要將通知結果寫入資料庫</param>
        /// <param name="_MailSubject">郵件主旨</param>
        /// <param name="_MailBody">郵件內容</param>
        /// <remarks></remarks>
        public void EmailNotify2Sys(string _MailServer, int _MailServerPort, string _MailSender, List<string> _MailReceiver, bool _WitreDB, string _MailSubject, string _MailBody)
        {
            //SystemLogs SL = new SystemLogs();
            //SL.Account = "System";
            //SL.Action = "通知系統管理人員作業";
            //SL.StartTime = DateTime.Now;
            //SL.TotalCount = 1;

            bool WitreDB = _WitreDB;

            string MailServer = _MailServer;
            int MailServerPort = _MailServerPort;
            string MailSender = _MailSender;
            List<string> MailReceiver = _MailReceiver;
            string MailSubject = _MailSubject;
            string MailBody = _MailBody;
            string SendResult = string.Empty;

            //寄送通知信給系統管理人員
            SendResult = SendEmail(MailServer, MailServerPort, MailSender, MailReceiver, MailSubject, MailBody.ToString());
            //SL.EndTime = DateTime.Now;

            if (SendResult == "success")
            {
                //寫入文字檔Log
                logandshowInfo("執行[寄送報表]成功", log_Info);

                //SL.SuccessCount = 1;
                //SL.Result = true;
            }
            else
            {
                //寫入文字檔Log
                logandshowInfo("執行[寄送報表]失敗,請查詢Debug Log得到詳細資訊", log_Info);
                logandshowInfo("執行[寄送報表]失敗,詳細資訊如下", log_Err);
                logandshowInfo("錯誤訊息:[" + SendResult + "]", log_Err);

                //SL.FailCount = 1;
                //SL.Msg = SendResult;
            }

            if (WitreDB == true)
            {
                //寫入DB Log
                //OPLoger.SetOPLog(this.op_name, op_action, op_stime, op_etime, op_a_count, op_s_count, op_f_count, op_msg, op_result);
                //log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
            }
        }

       
        /// <summary>
        /// 計算HASH值
        /// </summary>
        /// <param name="PlainText">明文</param>
        /// <returns>BASE64編碼的HASH值或null</returns>
        public string getHashValue(string PlainText)
        {
            //初始化系統參數
            Configer.Init();

            string ResultStr = string.Empty;

            byte[] SaltBytes = Encoding.UTF8.GetBytes(Configer.SystemSlat);

            if (SaltBytes.Length > 0)
            {
                ResultStr = SecurityProcessor.SHAEncodebyUTF8(PlainText, Configer.SystemHashAlg, true, SaltBytes).ToString();
                ResultStr = SecurityProcessor.TurnStrig2Base64byUTF8(ResultStr);

                return ResultStr;
            }
            else
            {
                return null;
            }
        }

        public void addCheckReportItem(string Name,string IP,DateTime CheckDate,string CheckMsg)
        {
            //新增檢查明細
            using (var db= new SDContext())
            {
                CheckReportItems R = new CheckReportItems();
                R.ServerName = Name;
                R.ServerIP = IP;
                R.CheckMsg = CheckMsg;
                R.insertTime = DateTime.Now;
                R.CheckDate = CheckDate;
                db.CheckReportItems.Add(R);

                db.SaveChanges();
            }
        }
    }
}