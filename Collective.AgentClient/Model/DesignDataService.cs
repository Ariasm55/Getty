using System;
using System.Collections.Generic;
using Collective.Model;

namespace Collective.AgentClient.Model
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void Connected(Action<bool, Exception> callback)
        {
            /*  try
              {
                  var ip = Properties.Settings.Default.ConnectionTest;
                  var ping = new Ping();
                  var result = ping.Send(ip);
                  //MessageBox.Show(result.Status.ToString());
                  if (result != null && result.Status.ToString() == "Success")
                  {
                      callback(true, null);
                  }
                  callback(false, new Exception("Server not found"));
              }
              catch (Exception exception)
              {
                  callback(false, exception);
              }*/
        }

        public void Login(string userName, string password, Action<AgentModel, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetSchedule(string agent, DateTime date, Action<string, Exception> callback)
        {
           // callback("From: 07:00 To: 17:00", null);
            throw new NotImplementedException();
        }

        public void GetRecordLog(string agent, DateTime date, Action<List<RecordLogModel>, Exception> callback)
        {

             var logs = new List<RecordLogModel>();
             for (var i = 1; i < 6; i++)
             {
                 logs.Add(new RecordLogModel
                 {
                     RecordId = i,
                     Campaign = string.Format("Campaña {0}",i.ToString("000")),
                     InitialDate = DateTime.Today,
                     InitialTime = string.Format("{0}:00:00", (6 + i).ToString("00")),
                     FinalTime = string.Format("{0}:15:00", (6 + i).ToString("00")),
                     LogReason = string.Format("Reason No. {0}",i.ToString("00")),
                     Status = "Open",
                     TimeSpan = new TimeSpan(0,15,0),
                     User = string.Format("user_{0}",i.ToString("000"))
                 });
             }
             callback(logs, null);
        }

        public void GetMessages(string agent, Action<List<MessageModel>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetReasons(Action<List<PausesModel>, Exception> callback)
        {
            var lista = new List<PausesModel>();
            for (var i = 1; i < 20; i++)
            {
                lista.Add(new PausesModel
                {
                    PauseId = i,
                    Reason = "Reason No. " + i.ToString("000"),
                    Desc = "Reason description No. " + i.ToString("000")
                });
            }
            callback(lista, null);
        }

        public void Dopause(string username, string pause, long camp, Action<long, Exception> callback)
        {
            throw new NotImplementedException();
        }

        /* public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }*/


        public void Resume(long recId, Action<long, Exception> callback)
        {
            throw new NotImplementedException();
        }

        /*  public void Getschedule2(string agentname, Action<List<TeamScheduleAgent>, Exception> callback)
          {
              throw new NotImplementedException();
          }*/

        public void GetAgentLogPayroll(string agent, DateTime dateI, DateTime dateF, Action<IList<RecordLogModel>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void Logout(string username, string pause, long camp, Action<long, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetRecordSummary(string agent, DateTime initial, DateTime final, Action<List<RecordReasonSummary>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetWeeklySchedule(string agent, DateTime daytime, Action<List<TeamScheduleModel>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void Logout(string username, long recordID, Action<bool,Exception> callback)
        {
            throw new NotImplementedException();
        }
    }
}