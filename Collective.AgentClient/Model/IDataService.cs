
using System;
using System.Collections.Generic;
using Collective.Model;

namespace Collective.AgentClient.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);

        void Connected(Action<bool, Exception> callback);

        void Login(string userName, string password, Action<AgentModel, Exception> callback);

        void GetSchedule(string agent, DateTime date, Action<string, Exception> callback);

        void GetRecordLog(string agentname, DateTime initial, Action<List<RecordLogModel>, Exception> callback);
        
        void GetMessages(string agent, Action<List<MessageModel>, Exception> callback);

        void GetReasons(Action<List<PausesModel>, Exception> callback);

        void Dopause(string username, string pause, long camp, Action<long, Exception> callback);

        void Resume(long recId, Action<long, Exception> callback);

        //void Getschedule2(string agentname, Action<List<TeamScheduleAgent>, Exception> callback);

        void GetAgentLogPayroll(string agent, DateTime dateI, DateTime dateF, Action<IList<RecordLogModel>, Exception> callback);

        void Logout(string username, string pause, long camp, Action<long, Exception> callback);

        void GetRecordSummary(string agent, DateTime initial, DateTime final,
            Action<List<RecordReasonSummary>, Exception> callback);



    }
}
