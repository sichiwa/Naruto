using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWCAlib;

namespace Naruto.SystemClass
{
    class SystemConfig
    {
        private string _Version;
        private string _VersionName;
        private int _Schedule;
        private int _StartHour;
        private int _StartMiniute;
        private int _Tolerance;
        private string _LDAPName;
        private string _VAVerifyURL;
        private int _NumofgridviewPage_perrows;
        private int _SelectTopN;

        private string _C_DBConnstring;
        private string _SystemHashAlg;
        private string _SystemSlat;
        private string _SystemDateTimeFormat;
        private string _SplitSymbol;
        private string _SplitSymbol2;
        private string _SplitSymbol3;

        private int _PublicRoleID;

        private string _CreateAction;
        private string _EditAction;
        private string _RemoveAction;
        private string _InsertAction;
        private string _UpdateAction;
        private string _DeleteAction;
        private string _GetAction;
        private string _VerifyAction;
        private string _SearchAction;
        private string _ReviewAction;
        private string _LoginAction;
        private string _LogoutAction;

        private string _UploadPath;
        private bool _UseLocalDB;
        private int _Sleep;

        private string _ServerIP;
        private int _ServerListenPort;

        private string _MailServer;
        private int _MailServerPort;
        private string _MailSender;
        private List<string> _MailReceiver;
        private List<string> _MailCC;
        private bool _MailUseSSL;
        private bool _MailBodyUseHTML;
        private string _MailPriority;
        private int _MailCodePage;
        private string _MailSubject;

        private string _MailBody;
        private List<string> _TextReceivers;
        private string _TextSubject;
        private string _TextBody;

        private bool _EnableDataCheck;
        private List<string> _RootDirList;
        private List<string> _IgnoreFoladerList;


        private bool _EnableLogCheck;
        private List<string> _LogFoladerList;
        private List<string> _LogKeywords;

        private string _LogListName;
        private string _DataListName;

        private bool _EnableBinaryCheck;
        private List<string> _BinaryFoladerList;

        private List<string> _NeedCheckContentHashExts;

        /// <summary>
        /// 系統版次
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        /// <summary>
        /// 程式名稱
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string VersionName
        {
            get { return _VersionName; }
            set { _VersionName = value; }
        }

        /// <summary>
        /// 系統資料庫連線字串
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string C_DBConnstring
        {
            get { return _C_DBConnstring; }
            set { _C_DBConnstring = value; }
        }

        /// <summary>
        /// 系統使用之雜湊演算法
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SystemHashAlg
        {
            get { return _SystemHashAlg; }
            set { _SystemHashAlg = value; }
        }

        /// <summary>
        /// 系統使用之Slat
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SystemSlat
        {
            get { return _SystemSlat; }
            set { _SystemSlat = value; }
        }

        /// <summary>
        /// 系統使用時間格式
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SystemDateTimeFormat
        {
            get { return _SystemDateTimeFormat; }
            set { _SystemDateTimeFormat = value; }
        }

        /// <summary>
        /// 系統使用分隔符號
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SplitSymbol
        {
            get { return _SplitSymbol; }
            set { _SplitSymbol = value; }
        }

        /// <summary>
        /// 系統使用分隔符號(2)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SplitSymbol2
        {
            get { return _SplitSymbol2; }
            set { _SplitSymbol2 = value; }
        }

        /// <summary>
        /// 系統使用分隔符號(3)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SplitSymbol3
        {
            get { return _SplitSymbol3; }
            set { _SplitSymbol3 = value; }
        }

        /// <summary>
        ///掃描頻率(單位秒)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int Schedule
        {
            get { return _Schedule; }
            set { _Schedule = value; }
        }

        /// <summary>
        ///排程執行時間:小時
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int StartHour
        {
            get { return _StartHour; }
            set { _StartHour = value; }
        }

        /// <summary>
        ///排程執行時間:分
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int StartMiniute
        {
            get { return _StartMiniute; }
            set { _StartMiniute = value; }
        }

        /// <summary>
        ///檢查時間容忍值:小時
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int Tolerance
        {
            get { return _Tolerance; }
            set { _Tolerance = value; }
        }

        /// <summary>
        /// 網域登入網址
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string LDAPName
        {
            get { return _LDAPName; }
            set { _LDAPName = value; }
        }

        /// <summary>
        /// VA驗章網址
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string VAVerifyURL
        {
            get { return _VAVerifyURL; }
            set { _VAVerifyURL = value; }
        }

        /// <summary>
        ///GridView分頁，每頁資料筆數
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int NumofgridviewPage_perrows
        {
            get { return _NumofgridviewPage_perrows; }
            set { _NumofgridviewPage_perrows = value; }
        }

        /// <summary>
        ///顯示最近N筆監控紀錄
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int SelectTopN
        {
            get { return _SelectTopN; }
            set { _SelectTopN = value; }
        }

        /// <summary>
        /// Public角色ID
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int PublicRoleID
        {
            get { return _PublicRoleID; }
            set { _PublicRoleID = value; }
        }

        /// <summary>
        ///系統動作(建立)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string CreateAction
        {
            get { return _CreateAction; }
            set { _CreateAction = value; }
        }

        /// <summary>
        ///系統動作(編輯)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string EditAction
        {
            get { return _EditAction; }
            set { _EditAction = value; }
        }

        /// <summary>
        /// 系統動作(移除)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string RemoveAction
        {
            get { return _RemoveAction; }
            set { _RemoveAction = value; }
        }

        /// <summary>
        /// 系統動作(新增)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string InsertAction
        {
            get { return _InsertAction; }
            set { _InsertAction = value; }
        }

        /// <summary>
        /// 系統動作(修改)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string UpdateAction
        {
            get { return _UpdateAction; }
            set { _UpdateAction = value; }
        }

        /// <summary>
        /// 系統動作(刪除)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string DeleteAction
        {
            get { return _DeleteAction; }
            set { _DeleteAction = value; }
        }

        /// <summary>
        /// 系統動作(取得)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string GetAction
        {
            get { return _GetAction; }
            set { _GetAction = value; }
        }

        /// <summary>
        /// 系統動作(覆核)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string ReviewAction
        {
            get { return _ReviewAction; }
            set { _ReviewAction = value; }
        }

        /// <summary>
        /// 系統動作(驗證)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string VerifyAction
        {
            get { return _VerifyAction; }
            set { _VerifyAction = value; }
        }

        /// <summary>
        /// 系統動作(查詢)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SearchAction
        {
            get { return _SearchAction; }
            set { _SearchAction = value; }
        }

        /// <summary>
        /// 系統動作(登入)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string LoginAction
        {
            get { return _LoginAction; }
            set { _LoginAction = value; }
        }

        /// <summary>
        /// 系統動作(登出)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string LogoutAction
        {
            get { return _LogoutAction; }
            set { _LogoutAction = value; }
        }

        /// <summary>
        /// 郵件伺服器IP
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string MailServer
        {
            get { return _MailServer; }
            set { _MailServer = value; }
        }

        /// <summary>
        /// 伺服器IP
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string ServerIP
        {
            get { return _ServerIP; }
            set { _ServerIP = value; }
        }

        /// <summary>
        /// 伺服器服務Port
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int ServerListenPort
        {
            get { return _ServerListenPort; }
            set { _ServerListenPort = value; }
        }

        /// <summary>
        /// 檔案上傳路徑
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string UploadPath
        {
            get { return _UploadPath; }
            set { _UploadPath = value; }
        }

        /// <summary>
        /// 是否使用LocalDB儲存檢查資料
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool UseLocalDB
        {
            get { return _UseLocalDB; }
            set { _UseLocalDB = value; }
        }

        /// <summary>
        /// 休息間隔時間
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int Sleep
        {
            get { return _Sleep; }
            set { _Sleep = value; }
        }

        /// <summary>
        /// 郵件伺服器使用Port
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int MailServerPort
        {
            get { return _MailServerPort; }
            set { _MailServerPort = value; }
        }

        /// <summary>
        /// 寄件人
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string MailSender
        {
            get { return _MailSender; }
            set { _MailSender = value; }
        }

        /// <summary>
        /// 收件人
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> MailReceiver
        {
            get { return _MailReceiver; }
            set { _MailReceiver = value; }
        }

        /// <summary>
        /// 副本收件人
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> MailCC
        {
            get { return _MailCC; }
            set { _MailCC = value; }
        }

        /// <summary>
        /// 郵件是否使用SSL
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool MailUseSSL
        {
            get { return _MailUseSSL; }
            set { _MailUseSSL = value; }
        }

        /// <summary>
        /// 郵件內容是否使用HTML
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool MailBodyUseHTML
        {
            get { return _MailBodyUseHTML; }
            set { _MailBodyUseHTML = value; }
        }

        /// <summary>
        /// 郵件重要性
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string MailPriority
        {
            get { return _MailPriority; }
            set { _MailPriority = value; }
        }

        /// <summary>
        /// 郵件內容編碼
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int MailCodePage
        {
            get { return _MailCodePage; }
            set { _MailCodePage = value; }
        }

        /// <summary>
        /// 郵件主旨
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string MailSubject
        {
            get { return _MailSubject; }
            set { _MailSubject = value; }
        }

        /// <summary>
        /// 郵件內容
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string MailBody
        {
            get { return _MailBody; }
            set { _MailBody = value; }
        }

        /// <summary>
        /// 簡訊收件人
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> TextReceivers
        {
            get { return _TextReceivers; }
            set { _TextReceivers = value; }
        }

        /// <summary>
        /// 簡訊主旨
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string TextSubject
        {
            get { return _TextSubject; }
            set { _TextSubject = value; }
        }

        /// <summary>
        /// 簡訊內容
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string TextBody
        {
            get { return _TextBody; }
            set { _TextBody = value; }
        }

        

        /// <summary>
        /// 是否啟用資料檢查
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool EnableDataCheck
        {
            get { return _EnableDataCheck; }
            set { _EnableDataCheck = value; }
        }

        /// <summary>
        /// 根目錄清單
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> RootDirList
        {
            get { return _RootDirList; }
            set { _RootDirList = value; }
        }

        /// <summary>
        /// 資料檢查忽略清單
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> IgnoreFoladerList
        {
            get { return _IgnoreFoladerList; }
            set { _IgnoreFoladerList = value; }
        }

        /// <summary>
        /// 是否啟用Log檢查
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool EnableLogCheck
        {
            get { return _EnableLogCheck; }
            set { _EnableLogCheck = value; }
        }

        /// <summary>
        /// Log目錄清單
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> LogFoladerList
        {
            get { return _LogFoladerList; }
            set { _LogFoladerList = value; }
        }

        /// <summary>
        /// Log關鍵字清單
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> LogKeywords
        {
            get { return _LogKeywords; }
            set { _LogKeywords = value; }
        }

        /// <summary>
        /// Log清單名稱
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string LogListName
        {
            get { return _LogListName; }
            set { _LogListName = value; }
        }

        /// <summary>
        /// 資料清單名稱
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string DataListName
        {
            get { return _DataListName; }
            set { _DataListName = value; }
        }

        /// <summary>
        /// Log關鍵字清單
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> NeedCheckContentHashExts
        {
            get { return _NeedCheckContentHashExts; }
            set { _NeedCheckContentHashExts = value; }
        }

        /// <summary>
        /// 是否啟用非文字或靜態資料檔案檢查
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool EnableBinaryCheck
        {
            get { return _EnableBinaryCheck; }
            set { _EnableBinaryCheck = value; }
        }

        /// <summary>
        /// 非文字或靜態資料檔案目錄清單
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> BinaryFoladerList
        {
            get { return _BinaryFoladerList; }
            set { _BinaryFoladerList = value; }
        }

        public void Init(string Version, string VersionName, int Schedule, int NumofgridviewPage_perrows, int SelectTopN, string C_DBConnstring,
        string SystemHashAlg, string SystemSlat, string SystemDateTimeFormat, string SplitSymbol, string SplitSymbol2, string SplitSymbol3,
        int PublicRoleID,
        string CreateAction, string EditAction, string RemoveAction, string InsertAction, string UpdateAction, string DeleteAction, string GetAction, string ReviewAction, string VerifyAction, string SearchAction, string LoginAction, string LogoutAction,
        string UploadPath,bool UseLocalDB,int Sleep,
        string MailServer, int MailServerPort, string MailSender, List<string> MailReceiver, List<string> MailCC, bool MailUseSSL, bool MailBodyUseHTML, string MailPriority, int MailCodePage, string MailSubject, string MailBody,
        List<string> TextReceivers,
        string TextSubject, string TextBody)
        {
            Char[] splitsymbol = { ',' };

            this.Version = Version;
            this.VersionName = VersionName;
            this.Schedule = Schedule;

            this.NumofgridviewPage_perrows = NumofgridviewPage_perrows;
            this.SelectTopN = Convert.ToInt16(SelectTopN);

            //this.C_DBConnstring = SecurityProcessor.TurnBase642String(C_DBConnstring);
            this.SystemHashAlg = SystemHashAlg;
            this.SystemSlat = SystemSlat;
            this.SystemDateTimeFormat = SystemDateTimeFormat;
            this.SplitSymbol = SplitSymbol;
            this.SplitSymbol2 = SplitSymbol2;
            this.SplitSymbol3 = SplitSymbol3;

            this.PublicRoleID = PublicRoleID;
            this.CreateAction = CreateAction;
            this.EditAction = EditAction;
            this.RemoveAction = RemoveAction;
            this.InsertAction = InsertAction;
            this.UpdateAction = UpdateAction;
            this.DeleteAction = DeleteAction;
            this.GetAction = GetAction;
            this.ReviewAction = ReviewAction;
            this.VerifyAction = VerifyAction;
            this.SearchAction = SearchAction;
            this.LoginAction = LoginAction;
            this.LogoutAction = LogoutAction;

            this.UploadPath = UploadPath;
            this.UseLocalDB = UseLocalDB;
            this.Sleep = Sleep;

            this.MailServer = MailServer;
            this.MailServerPort = Convert.ToInt16(MailServerPort);
            this.MailSender = MailSender;
            this.MailReceiver = MailReceiver;
            this.MailCC = MailCC;
            this.MailUseSSL = MailUseSSL;
            this.MailBodyUseHTML = MailBodyUseHTML;
            this.MailPriority = MailPriority;
            this.MailCodePage = MailCodePage;
            this.MailSubject = MailSubject;
            this.MailBody = MailBody;

            this.TextReceivers = TextReceivers;
            this.TextSubject = TextSubject;
            this.TextBody = TextBody;
        }


        public void InitFromJson(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jSystemConfig = jObject["SystemConfig"];
            Char[] splitsymbol = { ',' };

            this.Version = (string)jSystemConfig["Version"];
            this.VersionName = (string)jSystemConfig["VersionName"];
            this.Schedule = (Int32)jSystemConfig["Schedule"];
            this.StartHour = (Int16)jSystemConfig["StartHour"];
            this.StartMiniute = (Int16)jSystemConfig["StartMiniute"];
            this.Tolerance = (Int16)jSystemConfig["Tolerance"];

            //this.ADauth = (bool)jSystemConfig["Schedule"];
            this.LDAPName = (string)jSystemConfig["LDAPName"];
            this.NumofgridviewPage_perrows = (Int16)jSystemConfig["NumofgridviewPage_perrows"];//Convert.ToInt16();
            this.SelectTopN = (Int16)jSystemConfig["SelectTopN"];// Convert.ToInt16(WebConfigurationManager.AppSettings["SelectTopN"]);

            this.C_DBConnstring = SecurityProcessor.TurnBase642String((string)jSystemConfig["C_DBConnstring"]);
            this.SystemHashAlg = (string)jSystemConfig["SystemHashAlg"];
            this.SystemSlat = (string)jSystemConfig["SystemSlat"];
            this.SystemDateTimeFormat = (string)jSystemConfig["SystemDateTimeFormat"];
            this.SplitSymbol = (string)jSystemConfig["SplitSymbol"];
            this.SplitSymbol2 = (string)jSystemConfig["SplitSymbol2"];
            this.SplitSymbol3 = (string)jSystemConfig["SplitSymbol3"];

            this.PublicRoleID = (Int16)jSystemConfig["PublicRoleID"];//Convert.ToInt16(WebConfigurationManager.AppSettings["PublicRoleID"]);

            this.CreateAction = (string)jSystemConfig["CreateAction"];//WebConfigurationManager.AppSettings["CreateAction"];
            this.EditAction = (string)jSystemConfig["EditAction"];//WebConfigurationManager.AppSettings["EditAction"];
            this.RemoveAction = (string)jSystemConfig["RemoveAction"];// WebConfigurationManager.AppSettings["RemoveAction"];
            this.InsertAction = (string)jSystemConfig["InsertAction"];//WebConfigurationManager.AppSettings["InsertAction"];
            this.UpdateAction = (string)jSystemConfig["UpdateAction"];//WebConfigurationManager.AppSettings["UpdateAction"];
            this.DeleteAction = (string)jSystemConfig["DeleteAction"];//WebConfigurationManager.AppSettings["DeleteAction"];
            this.GetAction = (string)jSystemConfig["GetAction"];//WebConfigurationManager.AppSettings["GetAction"];
            this.ReviewAction = (string)jSystemConfig["ReviewAction"];//WebConfigurationManager.AppSettings["ReviewAction"];
            this.VerifyAction = (string)jSystemConfig["VerifyAction"];//WebConfigurationManager.AppSettings["VerifyAction"];
            this.SearchAction = (string)jSystemConfig["SearchAction"];//WebConfigurationManager.AppSettings["SearchAction"];
            this.LoginAction = (string)jSystemConfig["LoginAction"];//WebConfigurationManager.AppSettings["LoginAction"];
            this.LogoutAction = (string)jSystemConfig["LogoutAction"];//WebConfigurationManager.AppSettings["LogoutAction"];

            this.UploadPath = (string)jSystemConfig["UploadPath"];//WebConfigurationManager.AppSettings["UploadPath"];
            this.UseLocalDB = (bool)jSystemConfig["UseLocalDB"];
            this.Sleep = (Int16)jSystemConfig["Sleep"];//Convert.ToInt16(WebConfigurationManager.AppSettings

            this.ServerIP = (string)jSystemConfig["ServerIP"];
            this.ServerListenPort = (Int32)jSystemConfig["ServerListenPort"];//Convert.ToInt16(WebConfigurationManager.AppSettings["MailServerPort"]);
            
            this.MailServer = (string)jSystemConfig["MailServer"];//WebConfigurationManager.AppSettings["MailServer"];
            this.MailServerPort = (Int16)jSystemConfig["MailServerPort"];//Convert.ToInt16(WebConfigurationManager.AppSettings["MailServerPort"]);
            this.MailSender = (string)jSystemConfig["MailSender"];//WebConfigurationManager.AppSettings["MailSender"];
            this.MailReceiver = StringProcessor.SplitString2Array((string)jSystemConfig["MailReceiver"], splitsymbol);
            this.MailCC = StringProcessor.SplitString2Array((string)jSystemConfig["MailCC"], splitsymbol);
            this.MailUseSSL = (bool)jSystemConfig["MailUseSSL"];//Convert.ToBoolean(WebConfigurationManager.AppSettings["MailUseSSL"]);
            this.MailBodyUseHTML = (bool)jSystemConfig["MailBodyUseHTML"];//Convert.ToBoolean(WebConfigurationManager.AppSettings["MailBodyUseHTML"]);
            this.MailPriority = (string)jSystemConfig["MailPriority"];//WebConfigurationManager.AppSettings["MailPriority"];
            this.MailCodePage =(Int32)jSystemConfig["MailCodePage"];//Convert.ToInt32(WebConfigurationManager.AppSettings["MailCodePage"]);
            this.MailSubject = (string)jSystemConfig["MailSubject"];//WebConfigurationManager.AppSettings["MailSubject"];
            this.MailBody = (string)jSystemConfig["MailBody"];// WebConfigurationManager.AppSettings["MailBody"];

            this.TextReceivers = StringProcessor.SplitString2Array((string)jSystemConfig["TextReceivers"], splitsymbol);
            this.TextSubject = (string)jSystemConfig["TextSubject"];//WebConfigurationManager.AppSettings["TextSubject"];
            this.TextBody = (string)jSystemConfig["TextBody"];//WebConfigurationManager.AppSettings["TextBody"];

            this.RootDirList = StringProcessor.SplitString2Array((string)jSystemConfig["RootDirList"], splitsymbol);
            this.IgnoreFoladerList = StringProcessor.SplitString2Array((string)jSystemConfig["IgnoreFoladerList"], splitsymbol);
            this.BinaryFoladerList = StringProcessor.SplitString2Array((string)jSystemConfig["BinaryFoladerList"], splitsymbol);

            this.EnableDataCheck = (bool)jSystemConfig["EnableDataCheck"];//Convert.ToBoolean(WebConfigurationManager.AppSettings["MailUseSSL"]);
            this.EnableLogCheck = (bool)jSystemConfig["EnableLogCheck"];//Convert.ToBoolean(WebConfigurationManager.AppSettings["MailUseSSL"]);
            this.EnableBinaryCheck = (bool)jSystemConfig["EnableBinaryCheck"];

            this.LogFoladerList = StringProcessor.SplitString2Array((string)jSystemConfig["LogFoladerList"], splitsymbol);
            this.LogKeywords = StringProcessor.SplitString2Array((string)jSystemConfig["LogKeywords"], splitsymbol);

            this.LogListName = (string)jSystemConfig["LogListName"];//WebConfigurationManager.AppSettings["MailSubject"];
            this.DataListName = (string)jSystemConfig["DataListName"];//WebConfigurationManager.AppSettings["MailSubject"];
            this.NeedCheckContentHashExts = StringProcessor.SplitString2Array((string)jSystemConfig["NeedCheckContentHashExts"], splitsymbol);
        }

        public void Init()
        {
            //Char[] splitsymbol = { ',' };

            //this.Version = WebConfigurationManager.AppSettings["Version"];
            //this.VersionName = WebConfigurationManager.AppSettings["VersionName"];
            //this.Schedule = Convert.ToInt16(WebConfigurationManager.AppSettings["Schedule"]);

            //this.ADauth = Convert.ToBoolean(WebConfigurationManager.AppSettings["ADauth"]);
            //this.LDAPName = WebConfigurationManager.AppSettings["LDAPName"];
            //this.NumofgridviewPage_perrows = Convert.ToInt16(WebConfigurationManager.AppSettings["NumofgridviewPage_perrows"]);
            //this.SelectTopN = Convert.ToInt16(WebConfigurationManager.AppSettings["SelectTopN"]);

            ////this.C_DBConnstring = WebConfigurationManager.ConnectionStrings["C_DBConnstring"].ToString();//SecurityProcessor.TurnBase642String(WebConfigurationManager.ConnectionStrings["C_DBConnstring"].ToString());
            //this.SystemHashAlg = WebConfigurationManager.AppSettings["SystemHashAlg"];
            //this.SystemSlat = WebConfigurationManager.AppSettings["SystemSlat"];
            //this.SystemDateTimeFormat = WebConfigurationManager.AppSettings["SystemDateTimeFormat"];
            //this.SplitSymbol = WebConfigurationManager.AppSettings["SplitSymbol"];
            //this.SplitSymbol2 = WebConfigurationManager.AppSettings["SplitSymbol2"];
            //this.SplitSymbol3 = WebConfigurationManager.AppSettings["SplitSymbol3"];

            //this.PublicRoleID = Convert.ToInt16(WebConfigurationManager.AppSettings["PublicRoleID"]);

            //this.CreateAction = WebConfigurationManager.AppSettings["CreateAction"];
            //this.EditAction = WebConfigurationManager.AppSettings["EditAction"];
            //this.RemoveAction = WebConfigurationManager.AppSettings["RemoveAction"];
            //this.InsertAction = WebConfigurationManager.AppSettings["InsertAction"];
            //this.UpdateAction = WebConfigurationManager.AppSettings["UpdateAction"];
            //this.DeleteAction = WebConfigurationManager.AppSettings["DeleteAction"];
            //this.GetAction = WebConfigurationManager.AppSettings["GetAction"];
            //this.ReviewAction = WebConfigurationManager.AppSettings["ReviewAction"];
            //this.VerifyAction = WebConfigurationManager.AppSettings["VerifyAction"];
            //this.SearchAction = WebConfigurationManager.AppSettings["SearchAction"];
            //this.LoginAction = WebConfigurationManager.AppSettings["LoginAction"];
            //this.LogoutAction = WebConfigurationManager.AppSettings["LogoutAction"];

            //this.UploadPath = WebConfigurationManager.AppSettings["UploadPath"];

            //this.MailServer = WebConfigurationManager.AppSettings["MailServer"];
            //this.MailServerPort = Convert.ToInt16(WebConfigurationManager.AppSettings["MailServerPort"]);
            //this.MailSender = WebConfigurationManager.AppSettings["MailSender"];
            //this.MailReceiver = StringProcessor.SplitString2Array(WebConfigurationManager.AppSettings["MailReceiver"], splitsymbol);
            //this.MailCC = StringProcessor.SplitString2Array(WebConfigurationManager.AppSettings["MailCC"], splitsymbol);
            //this.MailUseSSL = Convert.ToBoolean(WebConfigurationManager.AppSettings["MailUseSSL"]);
            //this.MailBodyUseHTML = Convert.ToBoolean(WebConfigurationManager.AppSettings["MailBodyUseHTML"]);
            //this.MailPriority = WebConfigurationManager.AppSettings["MailPriority"];
            //this.MailCodePage = Convert.ToInt32(WebConfigurationManager.AppSettings["MailCodePage"]);
            //this.MailSubject = WebConfigurationManager.AppSettings["MailSubject"];
            //this.MailBody = WebConfigurationManager.AppSettings["MailBody"];

            //this.TextReceivers = StringProcessor.SplitString2Array(WebConfigurationManager.AppSettings["TextReceivers"], splitsymbol);
            //this.TextSubject = WebConfigurationManager.AppSettings["TextSubject"];
            //this.TextBody = WebConfigurationManager.AppSettings["TextBody"];
        }
    }
}
