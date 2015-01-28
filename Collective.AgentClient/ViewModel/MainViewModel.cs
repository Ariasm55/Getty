using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Collective.AgentClient.Messages;
using Collective.AgentClient.View;
using Collective.Model;
using GalaSoft.MvvmLight;
using Collective.AgentClient.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Collective.AgentClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        private static IDataService _dataService;

        #region Title

        /// <summary>
        /// The <see cref="Title" /> property's name.
        /// </summary>
        public const string TitlePropertyName = "Title";

        private string _title;

        /// <summary>
        /// Sets and gets the Title property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (_title == value)
                {
                    return;
                }

                _title = value;
                RaisePropertyChanged(TitlePropertyName);
            }
        }

        #endregion

        #region Agent

        /// <summary>
        /// The <see cref="Agent" /> property's name.
        /// </summary>
        public const string AgentPropertyName = "Agent";

        private AgentModel _agente;

        /// <summary>
        /// Sets and gets the Agent property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public AgentModel Agent
        {
            get
            {
                return _agente;
            }

            set
            {
                if (_agente == value)
                {
                    return;
                }

                _agente = value;
                RaisePropertyChanged(AgentPropertyName);
            }
        }

        #endregion

        #region Date

        /// <summary>
        /// The <see cref="Date" /> property's name.
        /// </summary>
        public const string DatePropertyName = "Date";

        private string _date;

        /// <summary>
        /// Sets and gets the Date property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Date
        {
            get
            {
                return _date;
            }

            set
            {
                if (_date == value)
                {
                    return;
                }

                _date = value;
                RaisePropertyChanged(DatePropertyName);
            }
        }

        #endregion

        #region Schedule

        /// <summary>
        /// The <see cref="Schedule" /> property's name.
        /// </summary>
        public const string SchedulePropertyName = "Schedule";

        private string _schedule = "";

        /// <summary>
        /// Sets and gets the Schedule property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Schedule
        {
            get
            {
                return _schedule;
            }

            set
            {
                if (_schedule == value)
                {
                    return;
                }

                _schedule = value;
                RaisePropertyChanged(SchedulePropertyName);
            }
        }

        #endregion

        #region SelectedLog

        /// <summary>
        /// The <see cref="SelectedLog" /> property's name.
        /// </summary>
        public const string SelectedLogPropertyName = "SelectedLog";

        private RecordLogModel _selectedLog;

        /// <summary>
        /// Sets and gets the SelectedLog property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public RecordLogModel SelectedLog
        {
            get
            {
                return _selectedLog;
            }

            set
            {
                if (_selectedLog == value)
                {
                    return;
                }

                _selectedLog = value;
                RaisePropertyChanged(SelectedLogPropertyName);
            }
        }

        #endregion

        #region LogList

        /// <summary>
        /// The <see cref="LogList" /> property's name.
        /// </summary>
        public const string LogListPropertyName = "LogList";

        private ObservableCollection<RecordLogModel> _logList;

        /// <summary>
        /// Sets and gets the LogList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<RecordLogModel> LogList
        {
            get
            {
                return _logList;
            }

            set
            {
                if (_logList == value)
                {
                    return;
                }

                _logList = value;
                RaisePropertyChanged(LogListPropertyName);
            }
        }

        #endregion

        #region Messages

        /// <summary>
        /// The <see cref="Messages" /> property's name.
        /// </summary>
        public const string MessagesPropertyName = "Messages";

        private ObservableCollection<MessageModel> _messages;

        /// <summary>
        /// Sets and gets the Messages property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MessageModel> Messages
        {
            get
            {
                return _messages;
            }

            set
            {
                if (_messages == value)
                {
                    return;
                }

                _messages = value;
                RaisePropertyChanged(MessagesPropertyName);
            }
        }

        #endregion

        #region SelectedMessage

        /// <summary>
        /// The <see cref="SelectedMessage" /> property's name.
        /// </summary>
        public const string SelectedMessagePropertyName = "SelectedMessage";

        private MessageModel _selectedMessage;

        /// <summary>
        /// Sets and gets the SelectedMessage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public MessageModel SelectedMessage
        {
            get
            {
                return _selectedMessage;
            }

            set
            {
                if (_selectedMessage == value)
                {
                    return;
                }

                _selectedMessage = value;
                RaisePropertyChanged(SelectedMessagePropertyName);
            }
        }

        #endregion

        #region ConnectionStatus

        /// <summary>
        /// The <see cref="ConnectionStatus" /> property's name.
        /// </summary>
        public const string ConnectionStatusPropertyName = "ConnectionStatus";

        private string _connectionStatus = "";

        /// <summary>
        /// Sets and gets the ConnectionStatus property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ConnectionStatus
        {
            get
            {
                return _connectionStatus;
            }

            set
            {
                if (_connectionStatus == value)
                {
                    return;
                }

                _connectionStatus = value;
                RaisePropertyChanged(ConnectionStatusPropertyName);
            }
        }

        #endregion

        #region ConnectionColor

        /// <summary>
        /// The <see cref="ConnectionColor" /> property's name.
        /// </summary>
        public const string ConnectionColorPropertyName = "ConnectionColor";

        private SolidColorBrush _connectionColor;

        /// <summary>
        /// Sets and gets the ConnectionColor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SolidColorBrush ConnectionColor
        {
            get
            {
                return _connectionColor;
            }

            set
            {
                if (Equals(_connectionColor, value))
                {
                    return;
                }

                _connectionColor = value;
                RaisePropertyChanged(ConnectionColorPropertyName);
            }
        }

        #endregion

        #region Light

        /// <summary>
        /// The <see cref="Light" /> property's name.
        /// </summary>
        public const string LightPropertyName = "Light";

        private BitmapImage _light;

        /// <summary>
        /// Sets and gets the Light property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public BitmapImage Light
        {
            get
            {
                return _light;
            }

            set
            {
                if (Equals(_light, value))
                {
                    return;
                }

                _light = value;
                RaisePropertyChanged(LightPropertyName);
            }
        }

        #endregion

        #region "ProfilePicture"
        /// The <see cref="ProfilePicture" /> property's name.
        
        public const string ProfilePicturePropertyName = "ProfilePicture";

        private BitmapImage _profilepicture  ;

        /// <summary>
        /// Sets and gets the ProfilePicture property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public BitmapImage ProfilePicture
        {
            get
            {
                return _profilepicture;
            }

            set
            {
                if (_profilepicture == value)
                {
                    return;
                }

                _profilepicture = value;
                RaisePropertyChanged(ProfilePicturePropertyName);
            }
        }
        #endregion
        
        #region "GetLogAgents"
        /// The <see cref="GetLogAgents" /> property's name.
        
        public const string GetLogAgentsPropertyName = "GetLogAgents";

        private ObservableCollection<RecordLogModel> _getlogAgent  ;

        /// <summary>
        /// Sets and gets the GetLogAgents property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<RecordLogModel> GetLogAgents
        {
            get
            {
                return _getlogAgent;
            }

            set
            {
                if (_getlogAgent == value)
                {
                    return;
                }

                _getlogAgent = value;
                RaisePropertyChanged(GetLogAgentsPropertyName);
            }
        }
        #endregion

        #region WeeklySchedule
        /// <summary>
        /// The <see cref="Weekly" /> property's name.
        /// </summary>
        public const string WeeklyPropertyName = "Weekly";

        private ObservableCollection<TeamScheduleModel> _weekly;

        /// <summary>
        /// Sets and gets the Weekly property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<TeamScheduleModel> Weekly
        {
            get
            {
                return _weekly;
            }

            set
            {
                if (_weekly == value)
                {
                    return;
                }

                _weekly = value;
                RaisePropertyChanged(WeeklyPropertyName);
            }
        }
        #endregion
        
        #region PauseView
        /// <summary>
        /// The <see cref="PauseViewOption" /> property's name.
        /// </summary>
        public const string PauseViewOptionPropertyName = "PauseViewOption";

        private PauseView _pauseViewOptionView ;

        /// <summary>
        /// Sets and gets the PauseViewOption property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PauseView PauseViewOption
        {
            get
            {
                return _pauseViewOptionView;
            }

            set
            {
                if (_pauseViewOptionView == value)
                {
                    return;
                }

                _pauseViewOptionView = value;
                RaisePropertyChanged(PauseViewOptionPropertyName);
            }
        }
        #endregion

        #region News
        /// <summary>
        /// The <see cref="NewsFeed" /> property's name.
        /// </summary>
        public const string NewsFeedPropertyName = "NewsFeed";

        private ObservableCollection<NewsModel> _newsFeed;

        /// <summary>
        /// Sets and gets the NewsFeed property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<NewsModel> NewsFeed
        {
            get
            {
                return _newsFeed;
            }

            set
            {
                if (_newsFeed == value)
                {
                    return;
                }

                _newsFeed = value;
                RaisePropertyChanged(NewsFeedPropertyName);
            }
        }
        #endregion

        #region SelectedNews
        /// <summary>
        /// The <see cref="SelectedNews" /> property's name.
        /// </summary>
        public const string SelectedNewsPropertyName = "SelectedNews";

        private NewsModel _selectedNews;

        /// <summary>
        /// Sets and gets the SelectedNews property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public NewsModel SelectedNews
        {
            get
            {
                return _selectedNews;
            }

            set
            {
                if (_selectedNews == value)
                {
                    return;
                }

                _selectedNews = value;
                RaisePropertyChanged(SelectedNewsPropertyName);
            }
        }
        #endregion

        #region NewsImage
        /// <summary>
        /// The <see cref="NewsImage" /> property's name.
        /// </summary>
        public const string NewsImagePropertyName = "NewsImage";

        private string _newsImage = "";

        /// <summary>
        /// Sets and gets the NewsImage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string NewsImage
        {
            get
            {
                return _newsImage;
            }

            set
            {
                if (_newsImage == value)
                {
                    return;
                }

                _newsImage = value;
                RaisePropertyChanged(NewsImagePropertyName);
            }
        }
        #endregion

        #region NewsURL
        /// <summary>
        /// The <see cref="NewsUrl" /> property's name.
        /// </summary>
        public const string NewsUrlPropertyName = "NewsURL";

        private string _newsUrl = "";

        /// <summary>
        /// Sets and gets the NewsURL property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string NewsUrl
        {
            get
            {
                return _newsUrl;
            }

            set
            {
                if (_newsUrl == value)
                {
                    return;
                }

                _newsUrl = value;
                RaisePropertyChanged(NewsUrlPropertyName);
            }
        }
        #endregion

        public static class Globals
        {
            public static int GlobalInt { get; set; }
            public static bool IsPaused { get; set; }
            public static long Recordpause { get; set; }

            public static string AgentGlobal { get; set; }
            public static int CampidGlobal { get; set; }

            
        }




        #endregion

        #region Commands
        public RelayCommand PauseLogoutCommand { get; set; }
        public RelayCommand PayrollAdvisorCommand { get; set; }
        public RelayCommand ShowMsgCommand { get; set; }
        public RelayCommand OpenNews { get; set; }
        #endregion

        #region Constructor

        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            

            Messenger.Default.Register<LoginMessage>(this,
                message =>
                {
                    Agent = message.Agent;
                    //GetSchedule();
                    LoadLog();
                    //GetMsg();
                    GetweeklySchedule();
                    //GetNewsfeed();
                    Globals.GlobalInt = 1;


                });

            RegisterCommand();

            if (!IsInDesignMode)
            {
                Login();
            }
            else
            {
                //LoadLog();
            }
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0,0,0,45);
            dispatcherTimer.Start();
            Globals.AgentGlobal = Agent.Name;
            Globals.CampidGlobal = Agent.Campaign.CampaignId;


        }

        //public string AgentGlobal { get; set; }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (Globals.GlobalInt == 1)
            {
                MessageBox.Show("1 Minute has passed loading new Data!");
                GetweeklySchedule();
                LoadLog();
            }
        }
        

        #endregion

        #region Private Methods

        private void OpenLinks()
        {
            try
            {
                System.Diagnostics.Process.Start(_selectedNews.Link);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
        }
        private void RegisterCommand()
        {
            PauseLogoutCommand = new RelayCommand(PauseLogout);
            PayrollAdvisorCommand = new RelayCommand(PayrollAdvisor);
            ShowMsgCommand = new RelayCommand(OpenMsg);
            OpenNews = new RelayCommand(OpenLinks);
        }
        
        private void Login()
        {
            var vm = new LoginViewModel(_dataService);
            var login = new LoginView {DataContext = vm};
            vm.OnRequesteClose += (s, e) => login.Close();
            login.ShowDialog();
        }

        private void GetNewsfeed()
        {
            if (Agent != null)
            {
                _dataService.GetNews(
                    (news, error) =>
                    {
                        if (error != null)
                        {
                            MessageBox.Show(error.Message);
                        }
                        NewsFeed = new ObservableCollection<NewsModel>(news);
                        if (NewsFeed != null) SelectedNews = NewsFeed.FirstOrDefault();

                    }); 
            }
        }
        private void OpenMsg()
        {
            if (Agent != null)
            {
                MessageViewModel vm;
                vm = IsInDesignModeStatic
                    ? new MessageViewModel(new DesignDataService())
                    : new MessageViewModel(new DataService());
                vm.MessageID = SelectedMessage.Recepiant.MessageID;
                vm.FromUser = SelectedMessage.UserName.UserName;
                vm.Date = SelectedMessage.TimeStamp;
                vm.MessageContent = SelectedMessage.MessageContent;
                vm.Tittle = SelectedMessage.MessageTitle;
                vm.MsgRead = SelectedMessage.Recepiant.ReadMessage;
                var msg = new MessagesView {DataContext = vm};
                msg.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error: NO Agent Login");
            }
        }

        private void PauseLogout()
        {
            if (Agent != null)
            {
                //var vm = new PauseViewModel(_dataService);
                //var pause = new PauseView {DataContext = vm};
                //vm = IsInDesignModeStatic
                //   ? new PauseViewModel(new DesignDataService())
                //    : new PauseViewModel(new DataService());
                //vm.CampaignId = Agent.Campaign.CampaignId;
                //vm.UserName = Agent.Name;
                
                PauseViewModel vm;
                vm = IsInDesignModeStatic
                    ? new PauseViewModel(new DesignDataService())
                    : new PauseViewModel(new DataService());

                vm.CampaignId = Agent.Campaign.CampaignId;
                vm.UserName = Agent.Name;
                //var pause = new PauseView();
                var pause = new PauseView {DataContext = vm};
                pause.ShowDialog();
                vm.OnRequesteClose += (s, e) => pause.Close();
                pause.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error: No Agent Login");
            }
        }

        private void GetSchedule()
        {
             _dataService.GetSchedule(Agent.Name,DateTime.Now,
                 (response, error) =>
                 {
                     if (error != null)
                     {
                         MessageBox.Show(error.Message);
                         return;
                     }
                     Schedule = response;
                 });
        }

        /*private void Timer()
        {
            while (true)
            {
                IsConnected();
                LoadMessages();
                var now = DateTime.Now;
                Date = string.Format("{0}:{1}", now.Hour.ToString("00"), now.Minute.ToString("00"));
                Thread.Sleep(120000);
            }
            // ReSharper disable once FunctionNeverReturns
        }*/

        private void IsConnected()
        {
            _dataService.Connected(
                (conn, error) =>
                {
                    if (error != null)
                    {
                        ConnectionStatus = "Not Connected";
                        ConnectionColor = new SolidColorBrush(Colors.Red);
                        return;
                    }
                    if (conn)
                    {
                        ConnectionStatus = "Connected";
                        ConnectionColor = new SolidColorBrush(Colors.Green);
                    }
                    else
                    {
                        ConnectionStatus = "Not Connected";
                        ConnectionColor = new SolidColorBrush(Colors.Red);
                    }
                });
        }

        
        
        private void LoadLog()
        {
            _dataService.GetRecordLog(Agent.Name, DateTime.Now,
                (log, error) =>
                {
                    if (error != null)
                    {
                        MessageBox.Show(error.Message);
                        return;
                    }
                    LogList = new ObservableCollection<RecordLogModel>(log);
                    if (LogList != null) SelectedLog = LogList.FirstOrDefault();
                });
            //LogList = new ObservableCollection<RecordLogModel>(Lista());
        }

        private void GetMsg()
        {
            _dataService.GetMessages(Agent.Name,
                (msg, error) =>
                {
                    if (error != null)
                    {
                        MessageBox.Show(error.Message);
                        return;
                    }
                    Messages = new ObservableCollection<MessageModel>(msg);
                    if (Messages != null) SelectedMessage = Messages.FirstOrDefault();
                });
        }

        private void GetweeklySchedule()
        {
            _dataService.GetWeeklySchedule(Agent.Name,DateTime.Now,
                (weekly, error) =>
                {
                    if (error != null)
                    {
                        MessageBox.Show(error.Message);
                        return;
                    }
                    Weekly = new ObservableCollection<TeamScheduleModel>(weekly);
                });
        }


       /* private List<RecordLogModel> Lista()
        {
           /* var logs = new List<RecordLogModel>();
            for (var i = 1; i < 26; i++)
            {
                logs.Add(new RecordLogModel
                {
                    RecordId = i,
                    Campaign = string.Format("Campaña {0}", i.ToString("000")),
                    InitialDate = DateTime.Today,
                    InitialTime = string.Format("{0}:00:00", (6 + i).ToString("00")),
                    FinalTime = string.Format("{0}:15:00", (6 + i).ToString("00")),
                    LogReason = string.Format("Reason No. {0}", i.ToString("00")),
                    Status = "Open",
                    TimeSpan = new TimeSpan(0, 15, 0),
                    User = string.Format("user_{0}", i.ToString("000"))
                });
            }
            return logs;
           _dataService.GetRecordLog(Agent.Name,DateTime.Now,
                (log, error) =>
                {
                    if (error != null)
                    {
                        MessageBox.Show(error.Message);
                        return;
                    }
                    LogList = new ObservableCollection<RecordLogModel>(log);
                    if (LogList != null) SelectedLog = LogList.FirstOrDefault();
                });
             return null;
        }*/
        

        private void PayrollAdvisor()
        {
            if (Agent != null)
            {
                PayrollAdvisorModel vm;
                vm = IsInDesignModeStatic
                    ? new PayrollAdvisorModel(new DesignDataService())
                    : new PayrollAdvisorModel(new DataService());

                vm.Agent = Agent.Name;
                var payroll = new PayrollAdvisor();
                payroll.DataContext = vm;
                payroll.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error: No Agent Login");
            }
        }

        

        #endregion

        #region public

        public static long UserlockPause()
        {
            var agent = Globals.AgentGlobal;
            var camp = Globals.CampidGlobal;

            _dataService.Lockpause(agent, camp,
                (pause, error) =>
                {
                    if (error != null)
                    {
                        MessageBox.Show(error.Message);
                        return;
                    }
                    Globals.Recordpause=pause ;
                });
            return Globals.Recordpause;
        }
        
        public static void UserlockUnPause()
        {
            long recordid = Globals.Recordpause;
            _dataService.Resume(recordid,
                (resumeBreak, error) =>
                {
                    if (error != null)
                    {
                        MessageBox.Show(error.Message);
                        return;
                    }
                    recordid = resumeBreak;
                    recordid = 0;

                });
        }
        #endregion

        public int CampidGlobal { get; set; }
    }
}