using System;
using System.Collections.Generic;
using System.Linq;
using Collective.Data;
using GalaSoft.MvvmLight;

namespace Collective.Model
{
    public class AgentModel : ObservableObject
    {
        #region Properties

        private static CollectiveEntities _context;

        public int AgentId { get; set; }

        #region Name

        /// <summary>
        /// The <see cref="Name" /> property's name.
        /// </summary>
        public const string NamePropertyName = "Name";

        private string _name = "";

        /// <summary>
        /// Sets and gets the Name property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name == value)
                {
                    return;
                }

                _name = value;
                RaisePropertyChanged(NamePropertyName);
            }
        }

        #endregion

        #region DateAssign

        /// <summary>
        /// The <see cref="DateAssign" /> property's name.
        /// </summary>
        public const string DateAssignPropertyName = "DateAssign";

        private DateTime _dateAssign;

        /// <summary>
        /// Sets and gets the DateAssign property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DateAssign
        {
            get
            {
                return _dateAssign;
            }

            set
            {
                if (_dateAssign == value)
                {
                    return;
                }

                _dateAssign = value;
                RaisePropertyChanged(DateAssignPropertyName);
            }
        }

        #endregion

        #region DateCreated

        /// <summary>
        /// The <see cref="DateCreated" /> property's name.
        /// </summary>
        public const string DateCreatedPropertyName = "DateCreated";

        private DateTime _dateCreated;

        /// <summary>
        /// Sets and gets the DateCreated property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DateCreated
        {
            get
            {
                return _dateCreated;
            }

            set
            {
                if (_dateCreated == value)
                {
                    return;
                }

                _dateCreated = value;
                RaisePropertyChanged(DateCreatedPropertyName);
            }
        }

        #endregion

        #region Archived

        /// <summary>
        /// The <see cref="Archived" /> property's name.
        /// </summary>
        public const string ArchivedPropertyName = "Archived";

        private int _archived;

        /// <summary>
        /// Sets and gets the Archived property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Archived
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

        #region DateArchived

        /// <summary>
        /// The <see cref="DateArchived" /> property's name.
        /// </summary>
        public const string DateArchivedPropertyName = "DateArchived";

        private DateTime _dateArchived;

        /// <summary>
        /// Sets and gets the DateArchived property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DateArchived
        {
            get
            {
                return _dateArchived;
            }

            set
            {
                if (_dateArchived == value)
                {
                    return;
                }

                _dateArchived = value;
                RaisePropertyChanged(DateArchivedPropertyName);
            }
        }

        #endregion

        #region ThisSite

        /// <summary>
        /// The <see cref="ThisSite" /> property's name.
        /// </summary>
        public const string ThisSitePropertyName = "ThisSite";

        private string _thisSite = "";

        /// <summary>
        /// Sets and gets the ThisSite property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ThisSite
        {
            get
            {
                return _thisSite;
            }

            set
            {
                if (_thisSite == value)
                {
                    return;
                }

                _thisSite = value;
                RaisePropertyChanged(ThisSitePropertyName);
            }
        }

        #endregion

        #region AssignedToTeam

        /// <summary>
        /// The <see cref="AssignedToTeam" /> property's name.
        /// </summary>
        public const string AssignedToTeamPropertyName = "AssignedToTeam";

        private long _assignedToTeam;

        /// <summary>
        /// Sets and gets the AssignedToTeam property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long AssignedToTeam
        {
            get
            {
                return _assignedToTeam;
            }

            set
            {
                if (_assignedToTeam == value)
                {
                    return;
                }

                _assignedToTeam = value;
                RaisePropertyChanged(AssignedToTeamPropertyName);
            }
        }

        #endregion

        #region AssignedToTeamDate

        /// <summary>
        /// The <see cref="AssignedToTeamDate" /> property's name.
        /// </summary>
        public const string AssignedToTeamDatePropertyName = "AssignedToTeamDate";

        private DateTime _assignedToTeamDate;

        /// <summary>
        /// Sets and gets the AssignedToTeamDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime AssignedToTeamDate
        {
            get
            {
                return _assignedToTeamDate;
            }

            set
            {
                if (_assignedToTeamDate == value)
                {
                    return;
                }

                _assignedToTeamDate = value;
                RaisePropertyChanged(AssignedToTeamDatePropertyName);
            }
        }

        #endregion

        #region LogId

        /// <summary>
        /// The <see cref="LogId" /> property's name.
        /// </summary>
        public const string LogIdPropertyName = "LogId";

        private int _logId;

        /// <summary>
        /// Sets and gets the LogId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int LogId
        {
            get
            {
                return _logId;
            }

            set
            {
                if (_logId == value)
                {
                    return;
                }

                _logId = value;
                RaisePropertyChanged(LogIdPropertyName);
            }
        }

        #endregion

        public CampaignModel Campaign { get; set; }

        public TeamModel Team { get; set; }

        public ProfileModel Profile { get; set; }

        public RecordLogModel Record { get; set; }

        public TeamScheduleAgent TeamAgent { get; set; }

        public TeamScheduleModel TeamSchedule { get; set; }

        #endregion

        #region Public Methods

        public List<AgentModel> GetAll()
        {
            try
            {
                using (_context = new CollectiveEntities())
                {
                    return (from r in _context.tbl_agents
                        join c in _context.tbl_campaigns on r.campaign_id equals c.campaign_id
                        join t in _context.tbl_teams on r.team_id equals t.team_id
                        orderby r.team_id
                        select new AgentModel
                        {
                            Name = r.agent,
                            DateAssign = r.date_assigned,
                            DateCreated = r.datecreated,
                            Archived = r.archived,
                            ThisSite = r.this_site,
                            AssignedToTeam = r.assignedtoteam,
                            AssignedToTeamDate = r.assignedtoteamdate,
                            Campaign = new CampaignModel
                            {
                                CampaignId = c.campaign_id,
                                ActiveTemp = c.active_temp,
                                AgentTemp = c.campaign_agents_temp,
                                Archived = c.archived,
                                Contingency = c.campaign_contingency,
                                DateArchived = c.date_archived,
                                DateCreated = c.campaign_datecreated,
                                GracePeriod = c.campaign_graceperiod,
                                Location = c.campaign_location,
                                ManagerTemp = c.campaign_manager_temp,
                                Map = c.campaign_map,
                                Name = c.campaign_name,
                                OvertimeRate = c.ot_rate,
                                Rate = c.campaign_rate,
                                Seats = c.campaign_seats,
                                Status = c.campaign_status,
                                ThisSite = c.this_site,
                                TimeStamp = c.campaign_timestamp,
                                UserName = c.user_username
                            },
                            Team = new TeamModel
                            {
                                TeamId = t.team_id,
                                TeamName = t.team_name,
                                TeamManager = t.team_manager,
                                DateCreated = t.date_created,
                                DateArchived = t.date_archived,
                                ThisSite = t.this_site,
                                Archived = t.archived, 
                            }


                        }).ToList();
                }
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message, exception
                    );
            }
        }

        public List<AgentModel> GetAgent(string searchargument)
        {
            try
            {
                using (_context = new CollectiveEntities())
                {
                    return (from r in _context.tbl_agents
                            join c in _context.tbl_campaigns on r.campaign_id equals c.campaign_id
                            join t in _context.tbl_teams on r.team_id equals t.team_id
                            where r.agent.Contains(searchargument)
                            orderby r.team_id
                            select new AgentModel
                            {
                                Name = r.agent,
                                DateAssign = r.date_assigned,
                                DateCreated = r.datecreated,
                                Archived = r.archived,
                                ThisSite = r.this_site,
                                AssignedToTeam = r.assignedtoteam,
                                AssignedToTeamDate = r.assignedtoteamdate,
                                Campaign = new CampaignModel
                                {
                                    CampaignId = c.campaign_id,
                                    ActiveTemp = c.active_temp,
                                    AgentTemp = c.campaign_agents_temp,
                                    Archived = c.archived,
                                    Contingency = c.campaign_contingency,
                                    DateArchived = c.date_archived,
                                    DateCreated = c.campaign_datecreated,
                                    GracePeriod = c.campaign_graceperiod,
                                    Location = c.campaign_location,
                                    ManagerTemp = c.campaign_manager_temp,
                                    Map = c.campaign_map,
                                    Name = c.campaign_name,
                                    OvertimeRate = c.ot_rate,
                                    Rate = c.campaign_rate,
                                    Seats = c.campaign_seats,
                                    Status = c.campaign_status,
                                    ThisSite = c.this_site,
                                    TimeStamp = c.campaign_timestamp,
                                    UserName = c.user_username
                                },
                                Team = new TeamModel
                                {
                                    TeamId = t.team_id,
                                    TeamName = t.team_name,
                                    TeamManager = t.team_manager,
                                    DateCreated = t.date_created,
                                    DateArchived = t.date_archived,
                                    ThisSite = t.this_site,
                                    Archived = t.archived,
                                }


                            }).ToList();
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception
                    );
            }
        }

        #endregion

        #region Private Methods
        #endregion

        
    }
}
