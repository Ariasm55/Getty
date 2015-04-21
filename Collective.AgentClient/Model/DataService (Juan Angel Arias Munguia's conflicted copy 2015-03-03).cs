using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Collective.Model;

namespace Collective.AgentClient.Model
{
    public class DataService : IDataService
    {
        public void Connected(Action<bool, Exception> callback)
        {
            try
            {
                var ip = Properties.Settings.Default.ConnectionTest;
                
                var ping = new Ping();
                var result = ping.Send(ip);
                if (result != null && result.Status.ToString() == "Success")
                {
                    callback(true, null);
                }
                else
                {
                    callback(false, new Exception("Server not found"));
                }
            }
            catch (Exception exception)
            {
                callback(false, exception);
            }
        }

        public void Login(string userName, string password, Action<AgentModel, Exception> callback)
        {
            try
            {
                var agent = UserModel.Login(userName, password);
                
                if (agent != null)
                {
                    PausesModel.RegisterLogin(userName, agent.Campaign.CampaignId);
                    callback(agent, null);
                    
                }
                
                callback(null,new Exception("Invalid username or password"));
            }
            catch (Exception exception)
            {
                callback(null, exception);
            }
        }

        public void GetSchedule(string agent, DateTime date, Action<string, Exception> callback)
        {
            try
            {
                var response = TeamScheduleModel.GetSchedule(agent, date);
                callback(response, null);
            }
            catch (Exception exception)
            {
                callback(null, exception);
            }
        }

        public void GetRecordLog(string agentname, DateTime initial, Action<List<RecordLogModel>, Exception> callback)
        {
            try
            {
                var lista = RecordLogModel.GetAgentRecordLog(agentname, initial);
                
                callback(lista, null);
            }
            catch (Exception exception)
            {
                callback(null, exception);
            }
        }

        public void GetMessages(string agent, Action<List<MessageModel>, Exception> callback)
        {
            try
            {
                var msg = RecipientModel.GetAllUserMessagesID(agent);
                callback(msg, null);
            }
            catch (Exception exception)
            {
                
                callback(null,exception);
            }
        }

        public void GetReasons(Action<List<PausesModel>, Exception> callback)
        {
            try
            {
                var lista = PausesModel.GetAll();
                callback(lista, null);
            }
            catch (Exception exception)
            {
                callback(null, exception);
            }
        }

        public void Dopause(string username, string pause, long camp, Action<long, Exception> callback)
        {
            try
            {
                var  pauses = PausesModel.InsertPause(username, pause, camp);
                callback(pauses, null);
            }
            catch (Exception exception)
            {
                callback(0, exception);
                throw;
            } 
        }
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }

        public void Resume(long recId, Action<long, Exception> callback)
        {
            try
            {
                var pauses = PausesModel.UpdatePause(recId);
               callback(pauses,null);

            }
            catch (Exception exception)
            {
                callback(0, exception);
                throw;
            }
        }

        //public void Getschedule2(string agentname, Action<List<TeamScheduleAgent>, Exception> callback)
        //{
        //    try
        //    {
        //        var getschedule = TeamScheduleAgent.GetSchedule2(agentname);
        //        callback(getschedule, null);
                
        //    }
        //    catch (Exception exception)
        //    {
                
        //        callback(null, exception);
        //    }
        //}

        public void GetAgentLogPayroll(string agent, DateTime dateI, DateTime DateF, Action<IList<RecordLogModel>, Exception> callback)
        {
            try
            {
                var lista = RecordLogModel.GetPayrollAssistance(agent, dateI, DateF);

                callback(lista, null);
            }
            catch (Exception exception)
            {
                callback(null, exception);
            }
        }

        public void Logout(string username, string pause, long camp, Action<long, Exception> callback)
        {

        }

        public void GetRecordSummary(string agent, DateTime initial, DateTime final, Action<List<RecordReasonSummary>, Exception> callback)
        {
            try
            {
                var summary = RecordLogModel.GetPayrollAssistance2(agent, initial, final);
                callback(summary, null);
            }
            catch (Exception exception)
            {
                callback(null, exception);
            }
        }

        public void GetWeeklySchedule(string agent, DateTime daytime, Action<List<TeamScheduleModel>, Exception> callback)
        {
            try
            {
                var weeklySchedule = TeamScheduleModel.GetWeeklySchedule(agent, daytime);
                callback(weeklySchedule, null);
            }
            catch (Exception exception)
            {
                
                callback(null, exception);
            }
        }

        public void Logout(string username, long recordID, Action< bool,Exception> callback)
        {
            try
            {
                PausesModel.Logout(username, recordID);
                callback(true, null);

            }
            catch (Exception exception)
            {
                
                callback(false,exception);
            }
        }
    }
}