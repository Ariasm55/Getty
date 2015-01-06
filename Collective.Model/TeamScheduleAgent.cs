using System.Linq;
using Collective.Data;
using GalaSoft.MvvmLight;
using System;


namespace Collective.Model 
{
    public class TeamScheduleAgent : ObservableObject
    {
        #region Properties
        private static CollectiveEntities _context;
        public long Teamscheduleagentid { get; set;}
        public long TeamID { get; set; }
        
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
        
        #region "Agent"
        /// The <see cref="Agent" /> property's name.
        public const string AgentPropertyName = "Agent";

        private string _agent = "";

        /// <summary>
        /// Sets and gets the Agent property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Agent
        {
            get
            {
                return _agent;
            }

            set
            {
                if (_agent == value)
                {
                    return;
                }

                _agent = value;
                RaisePropertyChanged(AgentPropertyName);
            }
        }
        #endregion

        #region "DateAssigned"
        /// The <see cref="DateAssigned" /> property's name.
        /// </summary>
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
                
        #region "Archived"
        /// The <see cref="Archived" /> property's name.
        /// </summary>
        public const string ArchivedPropertyName = "Archived";

        private long _archived  ;

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
        /// </summary>
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
		

        #endregion

        #region Public Methods

        public static TeamScheduleModel GetSchedule2(string username)
        {
            try
            {
                using (_context = new CollectiveEntities())
                {
                    var getSchedule = (from p in _context.tbl_teamscheduleagents
                        where p.agent == username && p.date_assigned == DateTime.Now
                        select new TeamScheduleAgent
                        {
                            Agent = p.agent,
                            Archived = p.archived,
                            TeamID = p.team_id,
                            DateAssigned = p.date_assigned,
                            DateArchived = p.date_archived,
                            TeamLabel = p.team_label,
                            Teamscheduleagentid = p.teamscheduleagent_id
                        }).FirstOrDefault();
                    //if (getSchedule.DateAssigned != null) throw new Exception("You dont have a Schedule Assinged Please talk to your TL.");
                    
                    
                        var today = (from p in _context.tbl_teamschedules
                                     where p.assignedtoteam == getSchedule.Teamscheduleagentid
                                     select new TeamScheduleModel
                                     {
                                         
                                         DateAssigned = p.date_assigned,
                                         teamschedule_datebegin = p.teamschedule_datebegin,
                                         

                                     }).FirstOrDefault();
                        return today;
    
                    
                    
                    
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
