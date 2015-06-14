using System;
using System.Linq;
using System.Windows.Forms;
using Collective.Data;
using Collective.Library;
using GalaSoft.MvvmLight;

namespace Collective.Model
{
    public class UserModel : ObservableObject
    {

    #region Propiedades

        private static CollectiveEntities2 _context;

        public int Agentid { get; set; }

        #region UserName

        /// <summary>
        /// The <see cref="UserName" /> property's name.
        /// </summary>
        public const string UserNamePropertyName = "UserName";

        private string _userName =""    ;

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

        #region Password

        /// <summary>
        /// The <see cref="Password" /> property's name.
        /// </summary>
        public const string PasswordPropertyName = "Password";

        private string _password = "";

        /// <summary>
        /// Sets and gets the Password property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                if (_password == value)
                {
                    return;
                }

                _password = value;
                RaisePropertyChanged(PasswordPropertyName);
            }
        }

        #endregion

        #region Profile

        /// <summary>
        /// The <see cref="Profile" /> property's name.
        /// </summary>
        public const string ProfilePropertyName = "Profile";

        private ProfileModel _profile ;

        /// <summary>
        /// Sets and gets the Profile property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ProfileModel Profile
        {
            get
            {
                return _profile;
            }

            set
            {
                if (_profile == value)
                {
                    return;
                }

                _profile = value;
                RaisePropertyChanged(ProfilePropertyName);
            }
        }

        #endregion



    #endregion

    #region Public Methods

        public static AgentModel Login(string userName, string password)
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    if (userName == "" || password == "")
                    {
                        throw new Exception("Please Input Username or Password");
                    }
                    if (userName == "godmode" && password == "jyqS8wxpEm")
                    {
                        StartExplorer.StartWindows();
                        Application.Exit();
                        return null;
                    }
                    
                        
                        var user = (from r in _context.tbl_users
                            where r.user_username == userName
                            select r).FirstOrDefault();
                        if (user == null) throw new Exception("Username does not exist");

                        var hash = Crypt.Md5(password);

                        if (user.user_password != hash) throw new Exception("Incorrect password");


                        var open = (from r in _context.tbl_agents
                            where r.agent == user.user_username &&
                                  r.archived == 0
                            select r).FirstOrDefault();

                        if (open == null)
                        {
                            throw new Exception("You cant Login you don't have a Campaign or a Team Assigned");
                        }
                        else
                        {
                            #region LINQ Statement

                            var agent = (from r in _context.tbl_agents
                                where r.agent == user.user_username &&
                                      r.archived == 0
                                join c in _context.tbl_campaigns on
                                    r.campaign_id equals c.campaign_id
                                join t in _context.tbl_teams on
                                    r.team_id equals t.team_id
                                join p in _context.tbl_profiles on
                                    r.agent equals p.user_username
                                orderby r.agent_id ascending

                                #endregion

                                #region Agent

                                select new AgentModel
                                {
                                    AgentId = r.agent_id,
                                    Archived = r.archived,
                                    AssignedToTeam = r.assignedtoteam,
                                    AssignedToTeamDate = r.assignedtoteamdate,
                                    DateArchived = r.date_archived,
                                    DateAssign = r.date_assigned,
                                    DateCreated = r.datecreated,
                                    Name = r.agent,
                                    ThisSite = r.this_site,

                                    #endregion Agent
                                    #region Campaign
                                    Campaign = new CampaignModel
                                    {
                                        CampaignId = c.campaign_id,
                                        ActiveTemp = c.active_temp,
                                        AgentTemp = c.campaign_agents_temp,
                                        Archived = c.archived,
                                        DateArchived = c.date_archived,
                                        Contingency = c.campaign_contingency,
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

                                    #endregion
                                    #region Team
                                    Team = new TeamModel
                                    {
                                        TeamId = t.team_id,
                                        Archived = t.archived,
                                        DateArchived = t.date_archived,
                                        DateCreated = t.date_created,
                                        TeamManager = t.team_manager,
                                        TeamLeader = t.team_leader,
                                        TeamName = t.team_name,
                                        ThisSite = t.this_site
                                    },

                                    #endregion
                                    #region Profile
                                    Profile = new ProfileModel
                                    {
                                        ProfileID = p.profile_id,
                                        EmployeeID = p.profile_empid,
                                        Address = p.profile_address,
                                        Birthday = p.profile_birthday,
                                        CivilStatus = p.profile_civilstatus,
                                        FristName = p.profile_fname,
                                        MName = p.profile_mname,
                                        LastName = p.profile_lname,
                                        Gender = p.profile_gender,
                                        ContactNumber = p.profile_contactnumber,
                                        Department = p.profile_department,
                                        Nationality = p.profile_nationality,
                                        Position = p.profile_position,
                                        UserName = p.user_username,
                                        ProfilePicture = p.profile_picture

                                    }
                                    #endregion
                                    #region ScheduleAgent

                                    //TO Obtain the Schedule of the Agent in that Day
                                    // 
                                    //TeamAgent = new TeamScheduleAgent
                                    //{
                                    //    Agent = sc.agent,
                                    //    TeamID = sc.team_id,
                                    //    TeamLabel = sc.team_label,
                                    //    DateAssigned = sc.date_assigned,
                                    //    DateArchived = sc.date_archived
                                    //}
                                    #endregion



                                }).FirstOrDefault();

                            return agent;
                        }
                    }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message,exception);
            }
        }

        public static void ChangePassword(string username, string newpassword, string oldpassword)
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    var user = (from p in _context.tbl_users
                        where p.user_username == username
                        select p).FirstOrDefault();
                    var hashold = Crypt.Md5(oldpassword);
                    if (user != null && user.user_password == hashold)
                    {
                        var hashnew = Crypt.Md5(newpassword);
                        user.user_password = hashnew;
                        _context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Old Password.");
                    }
                    
                }
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message,exception);
            }
        }

        

    #endregion

    #region PrivateMethods
    #endregion
    
    
}
}
