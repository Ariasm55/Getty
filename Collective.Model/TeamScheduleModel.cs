using System.Collections.Generic;
using System.Globalization;
using Collective.Data;
using GalaSoft.MvvmLight;
using System;
using System.Linq;


namespace Collective.Model
{
    public class TeamScheduleModel : ObservableObject
    {
        #region Properties

        private static CollectiveEntities2 _context;
        public long TeamId { get; set; }
        public long ShiftID { get; set; }

        #region "TeamDays"
        /// <summary>
        
        /// The <see cref="TeamDays" /> property's name.
        /// </summary>
        public const string TeamDaysPropertyName = "TeamDays";

        private string _teamday = "";

        /// <summary>
        /// Sets and gets the TeamDays property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TeamDays
        {
            get
            {
                return _teamday;
            }

            set
            {
                if (_teamday == value)
                {
                    return;
                }

                _teamday = value;
                RaisePropertyChanged(TeamDaysPropertyName);
            }
        }
        #endregion

        #region "TeamSchedule_TimeFrom"
        /// <summary>
	  
        /// The <see cref="TeamScheduleTimeFrom" /> property's name.
        /// </summary>
        public const string TeamScheduleTimeFromPropertyName = "TeamSchedule_TimeFrom";

        private TimeSpan _teamscheduleTimefrom;

        /// <summary>
        /// Sets and gets the TeamSchedule_TimeFrom property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan TeamScheduleTimeFrom
        {
            get
            {
                return _teamscheduleTimefrom;
            }

            set
            {
                if (_teamscheduleTimefrom == value)
                {
                    return;
                }

                _teamscheduleTimefrom = value;
                RaisePropertyChanged(TeamScheduleTimeFromPropertyName);
            }
        }   
      #endregion
        
	    #region "teamschedule_timeto"
        /// The <see cref="TeamscheduleTimeto" /> property's name.
        /// 
        public const string TeamscheduleTimetoPropertyName = "teamschedule_timeto";

        private TimeSpan _teamscheduleTimeto;

        /// <summary>
        /// Sets and gets the teamschedule_timeto property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan TeamscheduleTimeto
        {
            get
            {
                return _teamscheduleTimeto;
            }

            set
            {
                if (_teamscheduleTimeto == value)
                {
                    return;
                }

                _teamscheduleTimeto = value;
                RaisePropertyChanged(TeamscheduleTimetoPropertyName);
            }
        }
		
        #endregion.

        #region "teamschedule_datebegin"
        /// The <see cref="TeamscheduleDatebegin" /> property's name.
        
        public const string TeamscheduleDatebeginPropertyName = "teamschedule_datebegin";

        private DateTime _teamscheduleDatebegin ;

        /// <summary>
        /// Sets and gets the teamschedule_datebegin property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime TeamscheduleDatebegin
        {
            get
            {
                return _teamscheduleDatebegin;
            }

            set
            {
                if (_teamscheduleDatebegin == value)
                {
                    return;
                }

                _teamscheduleDatebegin = value;
                RaisePropertyChanged(TeamscheduleDatebeginPropertyName);
            }
        }
        #endregion
                
        #region "Graveyard"
        /// The <see cref="Graveyard" /> property's name.
        
        public const string GraveyardPropertyName = "Graveyard";

        private long _graveyard;

        /// <summary>
        /// Sets and gets the Graveyard property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long Graveyard
        {
            get
            {
                return _graveyard;
            }

            set
            {
                if (_graveyard == value)
                {
                    return;
                }

                _graveyard = value;
                RaisePropertyChanged(GraveyardPropertyName);
            }
        }
        #endregion
                
        #region "Archived"
        /// The <see cref="Archived" /> property's name.
        
        public const string ArchivedPropertyName = "Archived";

        private long _archived;

        /// <summary>
        /// Sets and gets the Archived property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long Archived
        {
            get
            {
                return _archived;
            }

            set
            {
                if (_archived == value)
                {
                    return;
                }

                _archived = value;
                RaisePropertyChanged(ArchivedPropertyName);
            }
        }
        #endregion

        #region "DateArchived"
        /// The <see cref="DateArchived" /> property's name.
        
        public const string DateArchivedPropertyName = "DateArchived";

        private DateTime _datearchived;

        /// <summary>
        /// Sets and gets the DateArchived property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DateArchived
        {
            get
            {
                return _datearchived;
            }

            set
            {
                if (_datearchived == value)
                {
                    return;
                }

                _datearchived = value;
                RaisePropertyChanged(DateArchivedPropertyName);
            }
        }
        #endregion
                
        #region "TeamLabel"
        /// The <see cref="TeamLabel" /> property's name.
        
        public const string TeamLabelPropertyName = "TeamLabel";

        private string _teamlabel = "";

        /// <summary>
        /// Sets and gets the TeamLabel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TeamLabel
        {
            get
            {
                return _teamlabel;
            }

            set
            {
                if (_teamlabel == value)
                {
                    return;
                }

                _teamlabel = value;
                RaisePropertyChanged(TeamLabelPropertyName);
            }
        }
        #endregion
                
        #region "TeamAgents"
        /// The <see cref="TeamAgents" /> property's name.
        
        public const string TeamAgentsPropertyName = "TeamAgents";

        private string _teamagents = "";

        /// <summary>
        /// Sets and gets the TeamAgents property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TeamAgents
        {
            get
            {
                return _teamagents;
            }

            set
            {
                if (_teamagents == value)
                {
                    return;
                }

                _teamagents = value;
                RaisePropertyChanged(TeamAgentsPropertyName);
            }
        }
        #endregion
                        
        #region "DateAssigned"
        /// The <see cref="DateAssigned" /> property's name.
        
        public const string DateAssignedPropertyName = "DateAssigned";

        private DateTime _dateassigned  ;

        /// <summary>
        /// Sets and gets the DateAssigned property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DateAssigned
        {
            get
            {
                return _dateassigned;
            }

            set
            {
                if (_dateassigned == value)
                {
                    return;
                }

                _dateassigned = value;
                RaisePropertyChanged(DateAssignedPropertyName);
            }
        }
        #endregion
        
        #region "TeamScheduleRestDayLabel"
        /// The <see cref="TeamScheduleRestDayLabel" /> property's name.
        
        public const string TeamScheduleRestDayLabelPropertyName = "TeamScheduleRestDayLabel";

        private long _teamschedulerestdaylabel;

        /// <summary>
        /// Sets and gets the TeamScheduleRestDayLabel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long TeamScheduleRestDayLabel
        {
            get
            {
                return _teamschedulerestdaylabel;
            }

            set
            {
                if (_teamschedulerestdaylabel == value)
                {
                    return;
                }

                _teamschedulerestdaylabel = value;
                RaisePropertyChanged(TeamScheduleRestDayLabelPropertyName);
            }
        }
        #endregion
        
        #region "TeamSchedulePreOtFrom"
        /// The <see cref="TeamSchedulePreOtFrom" /> property's name.
        
        public const string TeamSchedulePreOtFromPropertyName = "TeamSchedulePreOtFrom";

        private string _teamschedulepreotfrom = "";

        /// <summary>
        /// Sets and gets the TeamSchedulePreOtFrom property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TeamSchedulePreOtFrom
        {
            get
            {
                return _teamschedulepreotfrom;
            }

            set
            {
                if (_teamschedulepreotfrom == value)
                {
                    return;
                }

                _teamschedulepreotfrom = value;
                RaisePropertyChanged(TeamSchedulePreOtFromPropertyName);
            }
        }
        #endregion
        
        #region "TeamSchedulePreOtTo"
        /// The <see cref="TeamSchedulePreOtTo" /> property's name.
        
        public const string TeamSchedulePreOtToPropertyName = "TeamSchedulePreOtTo";

        private string _teamschedulepreotto = "";

        /// <summary>
        /// Sets and gets the TeamSchedulePreOtTo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TeamSchedulePreOtTo
        {
            get
            {
                return _teamschedulepreotto;
            }

            set
            {
                if (_teamschedulepreotto == value)
                {
                    return;
                }

                _teamschedulepreotto = value;
                RaisePropertyChanged(TeamSchedulePreOtToPropertyName);
            }
        }
        #endregion
        
        #region "TeamSchedulePostOtFrom"
        /// The <see cref="TeamSchedulePostOtFrom" /> property's name.
        
        public const string TeamSchedulePostOtFromPropertyName = "TeamSchedulePostOtFrom";

        private string _teamschedulepostotfrom = "";

        /// <summary>
        /// Sets and gets the TeamSchedulePostOtFrom property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TeamSchedulePostOtFrom
        {
            get
            {
                return _teamschedulepostotfrom;
            }

            set
            {
                if (_teamschedulepostotfrom == value)
                {
                    return;
                }

                _teamschedulepostotfrom = value;
                RaisePropertyChanged(TeamSchedulePostOtFromPropertyName);
            }
        }
        #endregion
        
        #region "TeamSchedulePostOtTo"
        /// The <see cref="TeamSchedulePostOtTo" /> property's name.
        
        public const string TeamSchedulePostOtToPropertyName = "TeamSchedulePostOtTo";

        private string _teamschedulepostotto = "";

        /// <summary>
        /// Sets and gets the TeamSchedulePostOtTo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TeamSchedulePostOtTo
        {
            get
            {
                return _teamschedulepostotto;
            }

            set
            {
                if (_teamschedulepostotto == value)
                {
                    return;
                }

                _teamschedulepostotto = value;
                RaisePropertyChanged(TeamSchedulePostOtToPropertyName);
            }
        }
        #endregion
        
        #region "TeamSchedulePreOtMax"
        /// The <see cref="TeamSchedulePreOtMax" /> property's name.
        
        public const string TeamSchedulePreOtMaxPropertyName = "TeamSchedulePreOtMax";

        private long _teamschedulepreotmax   ;

        /// <summary>
        /// Sets and gets the TeamSchedulePreOtMax property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long TeamSchedulePreOtMax
        {
            get
            {
                return _teamschedulepreotmax;
            }

            set
            {
                if (_teamschedulepreotmax == value)
                {
                    return;
                }

                _teamschedulepreotmax = value;
                RaisePropertyChanged(TeamSchedulePreOtMaxPropertyName);
            }
        }
        #endregion
                
        #region "TeamSchedulePostOtMax"
        /// The <see cref="TeamSchedulePostOtMax" /> property's name.
        
        public const string TeamSchedulePostOtMaxPropertyName = "TeamSchedulePostOtMax";

        private long _teamschedulepostotmax ;

        /// <summary>
        /// Sets and gets the TeamSchedulePostOtMax property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long TeamSchedulePostOtMax
        {
            get
            {
                return _teamschedulepostotmax;
            }

            set
            {
                if (_teamschedulepostotmax == value)
                {
                    return;
                }

                _teamschedulepostotmax = value;
                RaisePropertyChanged(TeamSchedulePostOtMaxPropertyName);
            }
        }
        #endregion
                
        #region "ScheduleIsVerified"
        /// The <see cref="ScheduleIsVerified" /> property's name.
        
        public const string ScheduleIsVerifiedPropertyName = "ScheduleIsVerified";

        private long _scheduleisverified ;

        /// <summary>
        /// Sets and gets the ScheduleIsVerified property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long ScheduleIsVerified
        {
            get
            {
                return _scheduleisverified;
            }

            set
            {
                if (_scheduleisverified == value)
                {
                    return;
                }

                _scheduleisverified = value;
                RaisePropertyChanged(ScheduleIsVerifiedPropertyName);
            }
        }
        #endregion
        
        #region "SchedRate"
        /// The <see cref="SchedRate" /> property's name.
        
        public const string SchedRatePropertyName = "SchedRate";

        private decimal _schedrate  ;

        /// <summary>
        /// Sets and gets the SchedRate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal SchedRate
        {
            get
            {
                return _schedrate;
            }

            set
            {
                if (_schedrate == value)
                {
                    return;
                }

                _schedrate = value;
                RaisePropertyChanged(SchedRatePropertyName);
            }
        }
        #endregion
        
        #region "SchedOtRate"
        /// The <see cref="SchedOtRate" /> property's name.
        
        public const string SchedOtRatePropertyName = "SchedOtRate";

        private decimal _schedotrate;

        /// <summary>
        /// Sets and gets the SchedOtRate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal SchedOtRate
        {
            get
            {
                return _schedotrate;
            }

            set
            {
                if (_schedotrate == value)
                {
                    return;
                }

                _schedotrate = value;
                RaisePropertyChanged(SchedOtRatePropertyName);
            }
        }
        #endregion
               
        #region "SchedGracePeriod"
        /// The <see cref="SchedGracePeriod" /> property's name.
        
        public const string SchedGracePeriodPropertyName = "SchedGracePeriod";

        private long _schedgraceperiod;

        /// <summary>
        /// Sets and gets the SchedGracePeriod property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long SchedGracePeriod
        {
            get
            {
                return _schedgraceperiod;
            }

            set
            {
                if (_schedgraceperiod == value)
                {
                    return;
                }

                _schedgraceperiod = value;
                RaisePropertyChanged(SchedGracePeriodPropertyName);
            }
        }
        #endregion
        
        #region "ScheduleLeave"
        /// The <see cref="ScheduleLeave" /> property's name.
        
        public const string ScheduleLeavePropertyName = "ScheduleLeave";

        private long _scheduleleave  ;

        /// <summary>
        /// Sets and gets the ScheduleLeave property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long ScheduleLeave
        {
            get
            {
                return _scheduleleave;
            }

            set
            {
                if (_scheduleleave == value)
                {
                    return;
                }

                _scheduleleave = value;
                RaisePropertyChanged(ScheduleLeavePropertyName);
            }
        }
        #endregion
                
        #region "DoubleShift"
        /// The <see cref="DoubleShift" /> property's name.
        
        public const string DoubleShiftPropertyName = "DoubleShift";

        private long _doubleshift ;

        /// <summary>
        /// Sets and gets the DoubleShift property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long DoubleShift
        {
            get
            {
                return _doubleshift;
            }

            set
            {
                if (_doubleshift == value)
                {
                    return;
                }

                _doubleshift = value;
                RaisePropertyChanged(DoubleShiftPropertyName);
            }
        }
        #endregion
        
        #region "IsUnderTime"
        /// The <see cref="IsUnderTime" /> property's name.
        
        public const string IsUnderTimePropertyName = "IsUnderTime";

        private long _isundertime ;

        /// <summary>
        /// Sets and gets the IsUnderTime property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long IsUnderTime
        {
            get
            {
                return _isundertime;
            }

            set
            {
                if (_isundertime == value)
                {
                    return;
                }

                _isundertime = value;
                RaisePropertyChanged(IsUnderTimePropertyName);
            }
        }
        #endregion
        
        #region "AssignedToTeam"
        /// The <see cref="AssignedToTeam" /> property's name.
        
        public const string AssignedToTeamPropertyName = "AssignedToTeam";

        private long _assignedtoteam;

        /// <summary>
        /// Sets and gets the AssignedToTeam property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long AssignedToTeam
        {
            get
            {
                return _assignedtoteam;
            }

            set
            {
                if (_assignedtoteam == value)
                {
                    return;
                }

                _assignedtoteam = value;
                RaisePropertyChanged(AssignedToTeamPropertyName);
            }
        }
        #endregion

        #region TimeSpanString
        /// <summary>
        /// The <see cref="TimeSpanString" /> property's name.
        /// </summary>
        public const string TimeSpanStringPropertyName = "TimeSpanString";

        private string _timespanstring = "";

        /// <summary>
        /// Sets and gets the TimeSpanString property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TimeSpanString
        {
            get
            {
                return _timespanstring;
            }

            set
            {
                if (_timespanstring == value)
                {
                    return;
                }

                _timespanstring = value;
                RaisePropertyChanged(TimeSpanStringPropertyName);
            }
        }
        #endregion

        #region TimeFrom
        /// <summary>
        /// The <see cref="TimeFrom" /> property's name.
        /// </summary>
        public const string TimeFromPropertyName = "TimeFrom";

        private string _timefrom = "";

        /// <summary>
        /// Sets and gets the TimeFrom property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TimeFrom
        {
            get
            {
                return _timefrom;
            }

            set
            {
                if (_timefrom == value)
                {
                    return;
                }

                _timefrom = value;
                RaisePropertyChanged(TimeFromPropertyName);
            }
        }
        #endregion

        #region TimeTo

        /// <summary>
        /// The <see cref="TimeTo" /> property's name.
        /// </summary>
        public const string TimeToPropertyName = "TimeTo";

        private string _timeto = "";

        /// <summary>
        /// Sets and gets the TimeTo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TimeTo
        {
            get
            {
                return _timeto;
            }

            set
            {
                if (_timeto == value)
                {
                    return;
                }

                _timeto = value;
                RaisePropertyChanged(TimeToPropertyName);
            }
        }
        #endregion

        #region TimeIn
        /// <summary>
        /// The <see cref="TimeIn" /> property's name.
        /// </summary>
        public const string TimeInPropertyName = "TimeIn";

        private DateTime _timeIn;

        /// <summary>
        /// Sets and gets the TimeIn property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime TimeIn
        {
            get
            {
                return _timeIn;
            }

            set
            {
                if (_timeIn == value)
                {
                    return;
                }

                _timeIn = value;
                RaisePropertyChanged(TimeInPropertyName);
            }
        }
        #endregion

        #region TimeOff
        /// <summary>
        /// The <see cref="TimeOff" /> property's name.
        /// </summary>
        public const string TimeOffPropertyName = "TimeOff";

        private DateTime _dateoff;

        /// <summary>
        /// Sets and gets the TimeOff property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime TimeOff
        {
            get
            {
                return _dateoff;
            }

            set
            {
                if (_dateoff == value)
                {
                    return;
                }

                _dateoff = value;
                RaisePropertyChanged(TimeOffPropertyName);
            }
        }
        #endregion


        #endregion

        #region Public Methods

        public static string GetSchedule(string agentName, DateTime date, bool checklate)
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    var today = DateTime.Now;
                    var today2 = new DateTime(today.Year, today.Month, today.Day);
                    var teamLabel = (from r in _context.tbl_teamscheduleagents
                        where r.agent == agentName && r.date_assigned == today2
                        select r.team_label).FirstOrDefault();
                    if (teamLabel == null) 
                        throw  new Exception("There is no Schedule for Today please contact your TL");
                    //var dateBegin = new DateTime(date.Year, date.Month, date.Day);
                    var schedule = (from r in _context.tbl_teamschedules
                        where r.team_label == teamLabel &&
                              r.teamschedule_datebegin == today2
                        select r).FirstOrDefault();
                    if (schedule == null)
                        throw new Exception("Error: There is no Schedule for Today please contact your TL");
                    DateTime timeIn = DateTime.Today.Add(schedule.teamschedule_timefrom);
                    DateTime timeOut = DateTime.Today.Add(schedule.teamschedule_timeto);
                    var response = string.Format("{0} To: {1}",
                    timeIn.ToString("hh:mm tt", CultureInfo.InvariantCulture),
                    timeOut.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                    DateTime t1 = DateTime.Parse(timeIn.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                    DateTime t2 = DateTime.Parse(today.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                    checklate = true;
                    if (checklate == true)
                    {
                        //Late
                        if (t1.TimeOfDay < t2.TimeOfDay)
                        {
                            ToastModel.RegisterToast(agentName,1);
                        }
                        //Early
                        else if (t1.TimeOfDay > t2.TimeOfDay)
                        {
                            ToastModel.RegisterToast(agentName, 2);
                        }
                    }
                    return response;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public static List<TeamScheduleModel> GetWeeklySchedule(string agent, DateTime datetoday)
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
                    DateTime endofweek = startOfWeek.AddDays(7);
                    var result = new List<TeamScheduleModel>();
                    var weekly = (from p in _context.tbl_teamschedules
                        join tsa in _context.tbl_teamscheduleagents on
                            p.team_label equals tsa.team_label
                                  where tsa.agent == agent &&
                                  p.teamschedule_datebegin >= startOfWeek &&
                                  p.teamschedule_datebegin <= endofweek &&
                                  p.archived == 0 && tsa.archived == 0

                        select p);
                    foreach (var record in weekly)
                    {
                        var timeIn = DateTime.Today.Add(record.teamschedule_timefrom);
                        var timeOut = DateTime.Today.Add(record.teamschedule_timeto);
                        var today = DateTime.Now.Date.DayOfWeek.ToString();
                        if (record.team_days == today)
                        {
                            record.team_days = "TODAY";
                        }
                        result.Add(new TeamScheduleModel
                        {
                            TimeIn = timeIn,
                            TimeOff = timeOut,
                            DateAssigned = record.date_assigned,
                            TeamDays = record.team_days
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
		 
	    #endregion
        
        #region Private Methods
        
        #endregion
    }
}
