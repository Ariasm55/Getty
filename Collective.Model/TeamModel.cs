using System;
using System.Collections.Generic;
using System.Linq;
using Collective.Data;
using GalaSoft.MvvmLight;

namespace Collective.Model
{
    public class TeamModel : ObservableObject
    {
        #region Properties

        private static CollectiveEntities2 _context;

        public int TeamId { get; set; }

        #region TeamLeader

        /// <summary>
        /// The <see cref="TeamLeader" /> property's name.
        /// </summary>
        public const string TeamLeaderPropertyName = "TeamLeader";

        private int _teamLeader;

        /// <summary>
        /// Sets and gets the TeamLeader property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int TeamLeader
        {
            get
            {
                return _teamLeader;
            }

            set
            {
                if (_teamLeader == value)
                {
                    return;
                }

                _teamLeader = value;
                RaisePropertyChanged(TeamLeaderPropertyName);
            }
        }

        #endregion

        #region TeamName

        /// <summary>
        /// The <see cref="TeamName" /> property's name.
        /// </summary>
        public const string TeamNamePropertyName = "TeamName";

        private string _teamName = "";

        /// <summary>
        /// Sets and gets the TeamName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TeamName
        {
            get
            {
                return _teamName;
            }

            set
            {
                if (_teamName == value)
                {
                    return;
                }

                _teamName = value;
                RaisePropertyChanged(TeamNamePropertyName);
            }
        }

        #endregion

        #region TeamManager

        /// <summary>
        /// The <see cref="TeamManager" /> property's name.
        /// </summary>
        public const string TeamManagerPropertyName = "TeamManager";

        private string _teamManager = "";

        /// <summary>
        /// Sets and gets the TeamManager property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TeamManager
        {
            get
            {
                return _teamManager;
            }

            set
            {
                if (_teamManager == value)
                {
                    return;
                }

                _teamManager = value;
                RaisePropertyChanged(TeamManagerPropertyName);
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

        public CampaignModel Campaign { get; set; }

        #endregion

        #region Public Methods

        public List<TeamModel> GetAll()
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    return (from r in _context.tbl_teams
                        join c in _context.tbl_campaigns on
                            r.campaign_id equals c.campaign_id
                        orderby r.team_name
                        select new TeamModel
                        {
                            TeamId = r.team_id,
                            TeamName = r.team_name,
                            TeamManager = r.team_manager,
                            DateCreated = r.date_created,
                            DateArchived = r.date_archived,
                            ThisSite = r.this_site,
                            Archived = r.archived,
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
                            }
                        }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public List<TeamModel> SearchByName(string argument)
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    return (from r in _context.tbl_teams
                            join c in _context.tbl_campaigns on
                                r.campaign_id equals c.campaign_id
                            where r.team_name.Contains(argument)
                            orderby r.team_name
                            select new TeamModel
                            {
                                TeamId = r.team_id,
                                TeamName = r.team_name,
                                TeamManager = r.team_manager,
                                DateCreated = r.date_created,
                                DateArchived = r.date_archived,
                                ThisSite = r.this_site,
                                Archived = r.archived,
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
                                }
                            }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }


        #endregion

        #region Private Methods
        #endregion
    }
}
