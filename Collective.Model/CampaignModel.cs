using System;
using System.Collections.Generic;
using System.Linq;
using Collective.Data;
using GalaSoft.MvvmLight;

namespace Collective.Model
{
    public class CampaignModel : ObservableObject
    {
        #region Properties

        private static CollectiveEntities2 _context;

        public int CampaignId { get; set; }

        #region  Name

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

        #region ManagerTemp

        /// <summary>
        /// The <see cref="ManagerTemp" /> property's name.
        /// </summary>
        public const string ManagerTempPropertyName = "ManagerTemp";

        private string _managerTemp = "";

        /// <summary>
        /// Sets and gets the ManagerTemp property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ManagerTemp
        {
            get
            {
                return _managerTemp;
            }

            set
            {
                if (_managerTemp == value)
                {
                    return;
                }

                _managerTemp = value;
                RaisePropertyChanged(ManagerTempPropertyName);
            }
        }

        #endregion

        #region Username

        /// <summary>
        /// The <see cref="UserName" /> property's name.
        /// </summary>
        public const string UserNamePropertyName = "UserName";

        private string _userName = "";

        /// <summary>
        /// Sets and gets the UserName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                if (_userName == value)
                {
                    return;
                }

                _userName = value;
                RaisePropertyChanged(UserNamePropertyName);
            }
        }

        #endregion

        #region AgentTemp

        /// <summary>
        /// The <see cref="AgentTemp" /> property's name.
        /// </summary>
        public const string AgentTempPropertyName = "AgentTemp";

        private int _agentTemp;

        /// <summary>
        /// Sets and gets the AgentTemp property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int AgentTemp
        {
            get
            {
                return _agentTemp;
            }

            set
            {
                if (_agentTemp == value)
                {
                    return;
                }

                _agentTemp = value;
                RaisePropertyChanged(AgentTempPropertyName);
            }
        }

        #endregion

        #region Rate

        /// <summary>
        /// The <see cref="Rate" /> property's name.
        /// </summary>
        public const string RatePropertyName = "Rate";

        private int _rate;

        /// <summary>
        /// Sets and gets the Rate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Rate
        {
            get
            {
                return _rate;
            }

            set
            {
                if (_rate == value)
                {
                    return;
                }

                _rate = value;
                RaisePropertyChanged(RatePropertyName);
            }
        }

        #endregion

        #region ActiveTemp

        /// <summary>
        /// The <see cref="ActiveTemp" /> property's name.
        /// </summary>
        public const string ActiveTempPropertyName = "ActiveTemp";

        private string _activeTemp = "";

        /// <summary>
        /// Sets and gets the ActiveTemp property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ActiveTemp
        {
            get
            {
                return _activeTemp;
            }

            set
            {
                if (_activeTemp == value)
                {
                    return;
                }

                _activeTemp = value;
                RaisePropertyChanged(ActiveTempPropertyName);
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

        #region Location
        /// <summary>
        /// The <see cref="Location" /> property's name.
        /// </summary>
        public const string LocationPropertyName = "Location";

        private string _location = "";

        /// <summary>
        /// Sets and gets the Location property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Location
        {
            get
            {
                return _location;
            }

            set
            {
                if (_location == value)
                {
                    return;
                }

                _location = value;
                RaisePropertyChanged(LocationPropertyName);
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

        #region TimeStamp

        /// <summary>
        /// The <see cref="TimeStamp" /> property's name.
        /// </summary>
        public const string TimeStampPropertyName = "TimeStamp";

        private DateTime _timeStamp;

        /// <summary>
        /// Sets and gets the TimeStamp property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime TimeStamp
        {
            get
            {
                return _timeStamp;
            }

            set
            {
                if (_timeStamp == value)
                {
                    return;
                }

                _timeStamp = value;
                RaisePropertyChanged(TimeStampPropertyName);
            }
        }

        #endregion

        #region Map

        /// <summary>
        /// The <see cref="Map" /> property's name.
        /// </summary>
        public const string MapPropertyName = "Map";

        private string _map = "";

        /// <summary>
        /// Sets and gets the Map property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Map
        {
            get
            {
                return _map;
            }

            set
            {
                if (_map == value)
                {
                    return;
                }

                _map = value;
                RaisePropertyChanged(MapPropertyName);
            }
        }

        #endregion

        #region Contingency

        /// <summary>
        /// The <see cref="Contingency" /> property's name.
        /// </summary>
        public const string ContingencyPropertyName = "Contingency";

        private int _contingency;

        /// <summary>
        /// Sets and gets the Contingency property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Contingency
        {
            get
            {
                return _contingency;
            }

            set
            {
                if (_contingency == value)
                {
                    return;
                }

                _contingency = value;
                RaisePropertyChanged(ContingencyPropertyName);
            }
        }

        #endregion

        #region Seats

        /// <summary>
        /// The <see cref="Seats" /> property's name.
        /// </summary>
        public const string SeatsPropertyName = "Seats";

        private int _seats;

        /// <summary>
        /// Sets and gets the Seats property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Seats
        {
            get
            {
                return _seats;
            }

            set
            {
                if (_seats == value)
                {
                    return;
                }

                _seats = value;
                RaisePropertyChanged(SeatsPropertyName);
            }
        }

        #endregion

        #region GracePeriod

        /// <summary>
        /// The <see cref="GracePeriod" /> property's name.
        /// </summary>
        public const string GracePeriodPropertyName = "GracePeriod";

        private int _gracePeriod;

        /// <summary>
        /// Sets and gets the GracePeriod property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int GracePeriod
        {
            get
            {
                return _gracePeriod;
            }

            set
            {
                if (_gracePeriod == value)
                {
                    return;
                }

                _gracePeriod = value;
                RaisePropertyChanged(GracePeriodPropertyName);
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

        #region OvertimeRate

        /// <summary>
        /// The <see cref="OvertimeRate" /> property's name.
        /// </summary>
        public const string OvertimeRatePropertyName = "OvertimeRate";

        private decimal? _overtimeRate;

        /// <summary>
        /// Sets and gets the OvertimeRate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? OvertimeRate
        {
            get
            {
                return _overtimeRate;
            }

            set
            {
                if (_overtimeRate == value)
                {
                    return;
                }

                _overtimeRate = value;
                RaisePropertyChanged(OvertimeRatePropertyName);
            }
        }

        #endregion

        #endregion

        #region Public Methods

        public List<CampaignModel> GetAll()
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    return (from r in _context.tbl_campaigns
                        orderby r.campaign_name
                        select new CampaignModel
                        {
                            Name = r.campaign_name,
                            ManagerTemp = r.campaign_manager_temp,
                            UserName = r.user_username,
                            AgentTemp = r.campaign_agents_temp,
                            Rate = r.campaign_rate,
                            ActiveTemp = r.active_temp,
                            Status = r.campaign_status,
                            Location = r.campaign_location,
                            DateCreated = r.campaign_datecreated,
                            TimeStamp = r.campaign_timestamp,
                            Map = r.campaign_map,
                            Contingency = r.campaign_contingency,
                            Seats = r.campaign_seats,
                            GracePeriod = r.campaign_graceperiod,
                            Archived = r.archived,
                            DateArchived = r.date_archived,
                            ThisSite = r.this_site,
                            OvertimeRate = r.ot_rate


                        }).ToList();
                }
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message,exception);
            }  
        }

        public CampaignModel GetbyAgent(string userName)
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    return (from r in _context.tbl_campaigns
                        where r.user_username == userName
                        orderby r.campaign_name
                        select new CampaignModel
                        {
                            Name = r.campaign_name,
                            ManagerTemp = r.campaign_manager_temp,
                            UserName = r.user_username,
                            AgentTemp = r.campaign_agents_temp,
                            Rate = r.campaign_rate,
                            ActiveTemp = r.active_temp,
                            Status = r.campaign_status,
                            Location = r.campaign_location,
                            DateCreated = r.campaign_datecreated,
                            TimeStamp = r.campaign_timestamp,
                            Map = r.campaign_map,
                            Contingency = r.campaign_contingency,
                            Seats = r.campaign_seats,
                            GracePeriod = r.campaign_graceperiod,
                            Archived = r.archived,
                            DateArchived = r.date_archived,
                            ThisSite = r.this_site,
                            OvertimeRate = r.ot_rate


                        }).FirstOrDefault();
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
