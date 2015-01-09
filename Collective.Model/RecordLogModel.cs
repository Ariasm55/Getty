using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Collective.Data;
using GalaSoft.MvvmLight;

namespace Collective.Model
{
    public class RecordLogModel : ObservableObject
    {
        #region Properties
        
        private static CollectiveEntities _context;
        
        public int RecordId { get; set; }
        
        #region InitialDate
        
        /// <summary>
        /// The <see cref="InitialDate" /> property's name.
        /// </summary>
        public const string InitialDatePropertyName = "InitialDate";
        
        private DateTime _initicalDate;
        
        /// <summary>
        /// Sets and gets the InitialDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime InitialDate
        {
            get
            {
                return _initicalDate;
            }
            
            set
            {
                if (_initicalDate == value)
                {
                    return;
                }
                
                _initicalDate = value;
                RaisePropertyChanged(InitialDatePropertyName);
            }
        }
        
        #endregion
        
        #region InitialTime
        
        /// <summary>
        /// The <see cref="InitialTime" /> property's name.
        /// </summary>
        public const string InitialTimePropertyName = "InitialTime";
        
        private string _initialTime = "";
        
        /// <summary>
        /// Sets and gets the InitialTime property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string InitialTime
        {
            get
            {
                return _initialTime;
            }
            
            set
            {
                if (_initialTime == value)
                {
                    return;
                }
                
                _initialTime = value;
                RaisePropertyChanged(InitialTimePropertyName);
            }
        }
        
        #endregion
        
        #region FinalTime
        
        /// <summary>
        /// The <see cref="FinalTime" /> property's name.
        /// </summary>
        public const string FinalTimePropertyName = "FinalTime";
        
        private string _finalTime = "";
        
        /// <summary>
        /// Sets and gets the FinalTime property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FinalTime
        {
            get
            {
                return _finalTime;
            }
            
            set
            {
                if (_finalTime == value)
                {
                    return;
                }
                
                _finalTime = value;
                RaisePropertyChanged(FinalTimePropertyName);
            }
        }
        
        #endregion
        
        #region TimeSpan
        
        /// <summary>
        /// The <see cref="TimeSpan" /> property's name.
        /// </summary>
        public const string TimeSpanPropertyName = "TimeSpan";
        
        private TimeSpan _timeSpan;
        
        /// <summary>
        /// Sets and gets the TimeSpan property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan TimeSpan
        {
            get
            {
                return _timeSpan;
            }
            
            set
            {
                if (_timeSpan == value)
                {
                    return;
                }
                
                _timeSpan = value;
                RaisePropertyChanged(TimeSpanPropertyName);
            }
        }
        
        #endregion
        
        #region User
        
        /// <summary>
        /// The <see cref="User" /> property's name.
        /// </summary>
        public const string UserPropertyName = "User";
        
        private string _user = "";
        
        /// <summary>
        /// Sets and gets the User property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string User
        {
            get
            {
                return _user;
            }
            
            set
            {
                if (_user == value)
                {
                    return;
                }
                
                _user = value;
                RaisePropertyChanged(UserPropertyName);
            }
        }
        
        #endregion
        
        #region LogReason
        
        /// <summary>
        /// The <see cref="LogReason" /> property's name.
        /// </summary>
        public const string LogReasonPropertyName = "LogReason";
        
        private string _logReason = "";
        
        /// <summary>
        /// Sets and gets the LogReason property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LogReason
        {
            get
            {
                return _logReason;
            }
            
            set
            {
                if (_logReason == value)
                {
                    return;
                }
                
                _logReason = value;
                RaisePropertyChanged(LogReasonPropertyName);
            }
        }
        
        #endregion
        
        #region Campaign
        
        /// <summary>
        /// The <see cref="Campaign" /> property's name.
        /// </summary>
        public const string CampaignPropertyName = "Campaign";
        
        private string _campaign = "";
        
        /// <summary>
        /// Sets and gets the Campaign property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Campaign
        {
            get
            {
                return _campaign;
            }
            
            set
            {
                if (_campaign == value)
                {
                    return;
                }
                
                _campaign = value;
                RaisePropertyChanged(CampaignPropertyName);
            }
        }
        
        #endregion
        
        #region Status
        
        /// <summary>
        /// The <see cref="Status" /> property's name.
        /// </summary>
        public const string StatusPropertyName = "Status";
        
        private string _status = "";
        
        /// <summary>
        /// Sets and gets the Status property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Status
        {
            get
            {
                return _status;
            }
            
            set
            {
                if (_status == value)
                {
                    return;
                }
                
                _status = value;
                RaisePropertyChanged(StatusPropertyName);
            }
        }
        
        #endregion
        
        #region "Station"
        
        /// The <see cref="Station" /> property's name.
        /// 
        public const string StationPropertyName = "Station";

        private string _station = "";
        
        /// <summary>
        /// Sets and gets the Station property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Station
        {
            get
            {
                return _station;
            }
            
            set
            {
                if (_station == value)
                {
                    return;
                }
                
                _station = value;
                RaisePropertyChanged(StationPropertyName);
            }
        }

        #endregion
        
        #region "IP"
        
        /// The <see cref="Ip" /> property's name.
        /// 
        public const string IpPropertyName = "IP";
        
        private string _ip = "";
        
        /// <summary>
        /// Sets and gets the IP property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Ip
        {
            get
            {
                return _ip;
            }
                
            set
            {
                if (_ip == value)
                {
                    return;
                }
            
                _ip = value;
                RaisePropertyChanged(IpPropertyName);
            }
        }
        
        #endregion
        
        #region "DateStamp"

        /// The <see cref="DateStamp" /> property's name.
        /// 
        public const string DateStampPropertyName = "DateStamp";
        
        private string _datestamp = "";
        
        /// <summary>
        /// Sets and gets the DateStamp property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DateStamp
        {
            get
            {
                return _datestamp;
            }
                
            set
            {
                if (_datestamp == value)
                {
                    return;
                }
        
                _datestamp = value;
                RaisePropertyChanged(DateStampPropertyName);
            }
        }
        
        #endregion
        
        #region "Site"
        
        /// The <see cref="Site" /> property's name.
        /// 
        public const string SitePropertyName = "Site";
        
        private string _site = "";
        
        /// <summary>
        /// Sets and gets the Site property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Site
        {
            get
            {
                return _site;
            }
                    
            set
            {
                if (_site == value)
                {
                    return;
                }

                _site = value;
                RaisePropertyChanged(SitePropertyName);
            }
        }
        
        #endregion
        
        #endregion
            
        #region Public Methods
                
        public static List<RecordLogModel> GetRecordLog(int campaignId, DateTime initial, DateTime final)
        {
            try
            {
                using (_context = new CollectiveEntities())
                {
                    var result = new List<RecordLogModel>();
                    var id = campaignId.ToString(CultureInfo.InvariantCulture).Trim();
                    var lista = from r in _context.tbl_record_logs
                                where r.campaign == id &&
                                      r.dt_stamp >= initial && r.dt_stamp <= final
                                select r;
                    foreach (var log in lista)
                    {
                        var endDate = log.dt_stamp_end;
                        var end = String.Format("{0}:{1}:{2}",
                            log.dt_stamp_end.Hour.ToString("00"),
                            log.dt_stamp_end.Minute.ToString("00"),
                            log.dt_stamp_end.Second.ToString("00"));
                                
                        if (end == "00:00:00")
                        {
                            endDate = DateTime.Now;
                            end = String.Format("{0}:{1}:{2}",
                                endDate.Hour.ToString("00"),
                                endDate.Minute.ToString("00"),
                                endDate.Second.ToString("00"));
                        }
                                
                        result.Add(new RecordLogModel
                        {
                            InitialDate = new DateTime(log.dt_stamp.Year, log.dt_stamp.Month, log.dt_stamp.Day),
                            InitialTime = String.Format("{0}:{1}:{2}",
                                log.dt_stamp.Hour.ToString("00"),
                                log.dt_stamp.Minute.ToString("00"),
                                log.dt_stamp.Second.ToString("00")),
                            Campaign = log.campaign,
                            FinalTime = end,
                            TimeSpan = endDate - log.dt_stamp,
                            User = log.username,
                            Status = log.status,
                            LogReason = log.log_reason
                        });
                    }
                    return result;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
                
        public static List<RecordLogModel> GetAgentRecordLog(string agentName, DateTime date)
        {
            try
            {
                using (_context = new CollectiveEntities())
                {
                    var initial = new DateTime(date.Year,date.Month,date.Day,0,0,0);
                    var final = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
                    var result = new List<RecordLogModel>();
                    var lista = from r in _context.tbl_record_logs
                                where r.username == agentName &&
                                      r.dt_stamp >= initial && r.dt_stamp <= final
                                select r;
                    foreach (var log in lista)
                    {
                        var endDate = log.dt_stamp_end;
                        var end = String.Format("{0}:{1}:{2}",
                            log.dt_stamp_end.Hour.ToString("00"),
                            log.dt_stamp_end.Minute.ToString("00"),
                            log.dt_stamp_end.Second.ToString("00"));
                                
                        if (end == "00:00:00")
                        {
                            endDate = DateTime.Now;
                            end = String.Format("{0}:{1}:{2}",
                                endDate.Hour.ToString("00"),
                                endDate.Minute.ToString("00"),
                                endDate.Second.ToString("00"));
                        }
                                
                        result.Add(new RecordLogModel
                        {
                            InitialDate = new DateTime(log.dt_stamp.Year, log.dt_stamp.Month, log.dt_stamp.Day),
                            InitialTime = String.Format("{0}:{1}:{2}",
                                log.dt_stamp.Hour.ToString("00"),
                                log.dt_stamp.Minute.ToString("00"),
                                log.dt_stamp.Second.ToString("00")),
                            Campaign = log.campaign,
                            FinalTime = end,
                            TimeSpan = endDate - log.dt_stamp,
                            User = log.username,
                            Status = log.status,
                            LogReason = log.log_reason
                        });
                    }
                    return result;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
                
        public static List<RecordLogModel> GetPayrollAssistance(string agentName, DateTime dateI, DateTime dateF)
        {
            try
            {
                using (_context = new CollectiveEntities())
                {
                    var initial = new DateTime(dateI.Year, dateI.Month, dateI.Day, 0, 0, 0);
                    var final = new DateTime(dateF.Year, dateF.Month, dateF.Day, 23, 59, 59);
                    var result = new List<RecordLogModel>();
                    var lista = from r in _context.tbl_record_logs
                                where r.username == agentName &&
                                      r.dt_stamp >= initial && r.dt_stamp <= final
                                select r;
                    foreach (var log in lista)
                    {
                        var endDate = log.dt_stamp_end;
                        var end = String.Format("{0}:{1}:{2}",
                            log.dt_stamp_end.Hour.ToString("00"),
                            log.dt_stamp_end.Minute.ToString("00"),
                            log.dt_stamp_end.Second.ToString("00"));
                                
                        if (end == "00:00:00")
                        {
                            endDate = DateTime.Now;
                            end = String.Format("{0}:{1}:{2}",
                                endDate.Hour.ToString("00"),
                                endDate.Minute.ToString("00"),
                                endDate.Second.ToString("00"));
                        }
                                
                        result.Add(new RecordLogModel
                        {
                            InitialDate = new DateTime(log.dt_stamp.Year, log.dt_stamp.Month, log.dt_stamp.Day),
                            InitialTime = String.Format("{0}:{1}:{2}",
                                log.dt_stamp.Hour.ToString("00"),
                                log.dt_stamp.Minute.ToString("00"),
                                log.dt_stamp.Second.ToString("00")),
                            Campaign = log.campaign,
                            FinalTime = end,
                            TimeSpan = endDate - log.dt_stamp,
                            User = log.username,
                            Status = log.status,
                            LogReason = log.log_reason
                        });
                    }
                    return result;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
                
        public static List<RecordReasonSummary> GetPayrollAssistance2(string agentName, DateTime dateI, DateTime dateF)
        {
            try
            {
                using (_context = new CollectiveEntities())
                {
                    var initial = new DateTime(dateI.Year, dateI.Month, dateI.Day, 0, 0, 0);
                    var final = new DateTime(dateF.Year, dateF.Month, dateF.Day, 23, 59, 59);
                    var lista = (from r in _context.tbl_record_logs
                                 where r.username == agentName &&
                                       r.dt_stamp >= initial && r.dt_stamp <= final
                                 orderby r.username,r.log_reason
                                 select r).ToList();
                    var motives = (from m in _context.tbl_pauses
                                   orderby m.pause_reason
                                   select new { m.pause_id, m.pause_reason }).ToList();
                    var summary = new List<RecordReasonSummary>();
                    foreach (var motive in motives)
                    {
                        var time = new TimeSpan();
                        DateTime tick = new DateTime();
                        /*foreach (var Date in lista)
                        {
                            DateTime search = Date.dt_stamp.Date;
                            time = lista.Where(item => item.log_reason == motive.pause_reason)
                               .Aggregate(time, (current, item) => current + (item.dt_stamp_end - item.dt_stamp));
                        }*/
                        time = lista.Where(item => item.log_reason == motive.pause_reason)
                               .Aggregate(time, (current, item) => current + ( item.dt_stamp_end - item.dt_stamp));

                        
                        summary.Add(new RecordReasonSummary
                        {
                            //InitialDate = new DateTime(.dt_stamp.Year, .dt_stamp.Month, .dt_stamp.Day),
                            Reason = motive.pause_reason,
                            Time = time
                        });
                    }
                    return summary;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
                
        public static long InsertLogin(string username, RecordLogModel rec)
        {
            try
            {
                using (_context = new CollectiveEntities())
                {
                    var login = new tbl_record_log
                    {
                        dt_stamp = DateTime.Now,
                        username = username,
                        campaign = rec.Campaign,
                        station = Environment.MachineName,
                        ip = Library.NetworkIp.LocalIPAddress(),
                        status = "logged",
                        dt_stamp_day = DateTime.Today.Day.ToString(CultureInfo.InvariantCulture),
                        this_site = "Honduras"
                    };
                    _context.tbl_record_logs.Add(login);
                    _context.SaveChanges();
                    return login.rec_id;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        #endregion

        #region Private

        #endregion
    }
}