using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Collective.Data;
using Collective.Library;
using Collective.Model.Properties;
using GalaSoft.MvvmLight;

namespace Collective.Model
{
   public class PausesModel : ObservableObject
   {
       #region Properties

       private static CollectiveEntities2 _context;

       public long PauseId { get; set; }

       #region Reason

       /// <summary>
       /// The <see cref="Reason" /> property's name.
       /// </summary>
       public const string ReasonPropertyName = "Reason";

       private string _reason = "";

       /// <summary>
       /// Sets and gets the Reason property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string Reason
       {
           get
           {
               return _reason;
           }

           set
           {
               if (_reason == value)
               {
                   return;
               }

               _reason = value;
               RaisePropertyChanged(ReasonPropertyName);
           }
       }
       #endregion

       #region Desc

       /// <summary>
       /// The <see cref="Desc" /> property's name.
       /// </summary>
       public const string DescPropertyName = "Desc";

       private string _desc = "";

       /// <summary>
       /// Sets and gets the Desc property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string Desc
       {
           get
           {
               return _desc;
           }

           set
           {
               if (_desc == value)
               {
                   return;
               }

               _desc = value;
               RaisePropertyChanged(DescPropertyName);
           }
       }

       #endregion
       
       #region "RecId"
       /// The <see cref="RecId" /> property's name.
       
       public const string RecIdPropertyName = "RecId";

       private long _recId ;

       /// <summary>
       /// Sets and gets the RecId property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public long RecId
       {
           get
           {
               return _recId;
           }

           set
           {
               if (_recId == value)
               {
                   return;
               }

               _recId = value;
               RaisePropertyChanged(RecIdPropertyName);
           }
       }
       #endregion
		
		
		


       #endregion

       #region Public Methods

       public static List<PausesModel> GetAll()
       {
           try
           {
               using (_context = new CollectiveEntities2())
               {
                   var lista = from p in _context.tbl_pauses
                       orderby p.pause_reason
                       select p;
              var retorno = lista.Select(item => new PausesModel
                   {
                       PauseId = item.pause_id, Reason = item.pause_reason, Desc = item.pause_description
                   }).ToList();
                   _context.Database.Connection.Close();
                   _context.Database.Connection.Dispose();
                   return retorno;
               }
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message, exception);
           }
       }

      

       public static long InsertPause(string username, string pausename, long camp)
       {
           try
           {
               using (_context = new CollectiveEntities2())
               {
                   var timeest = TimeConversion.TimetoEst(DateTime.Now);
                   var site = Settings.Default.ThisSite;
                   var conver2 = new DateTime(timeest.Year, timeest.Month, timeest.Day, Convert.ToInt16(timeest.Hour), Convert.ToInt16(timeest.Minute), 0);
                   var login = new tbl_record_log
                   {
                       dt_stamp = conver2,
                       username = username,
                       campaign = camp.ToString(CultureInfo.InvariantCulture),
                       station = Environment.MachineName,
                       ip = NetworkIp.LocalIPAddress(),
                       status = "pause",
                       dt_stamp_day = timeest.DayOfWeek.ToString(),
                       this_site = site,
                       log_reason = pausename
                   };
                   _context.tbl_record_logs.Add(login);
                   _context.SaveChanges();
                   HistoryFile.MakePause(login, conver2);
                   _context.Database.Connection.Close();
                   _context.Database.Connection.Dispose();
                   
                   return login.rec_id;
               }
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
       }

       public static int UpdatePause(long id)
       {
           try
           {
               var time = DateTime.Now;
               var timeest = TimeConversion.TimetoEst(time);
               var conver2 = new DateTime(timeest.Year, timeest.Month, timeest.Day, Convert.ToInt16(timeest.Hour), Convert.ToInt16(timeest.Minute),0);
               HistoryFile.UpdatePause(conver2.ToString(CultureInfo.InvariantCulture), id);

               using (_context = new CollectiveEntities2())
               {
                   var lista = from r in _context.tbl_record_logs
                               where r.rec_id == id
                               select r;
                   foreach (var rec in lista)
                   {
                       rec.dt_stamp_end = conver2;
                   }
                   _context.SaveChanges();
                   _context.Database.Connection.Close();
                   _context.Database.Connection.Dispose();

               }
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return 0;
       }
       
       

      public static long RegisterLogin(string username, long camp)
       {
           try
           {
               using (_context = new CollectiveEntities2())
               {
                   DateTime time = new DateTime(); // null time for DT_STAMP_END
                   var timenow = DateTime.Now;
                   var conver = TimeConversion.TimetoEst(timenow);
                   string today = conver.ToString("yyyy/MM/dd");
                   DateTime today2 = DateTime.Parse(today);
                   GlobalVariables.GlobalsLib.Timing = conver;
                   var conver2 = new DateTime(today2.Year, today2.Month, today2.Day, Convert.ToInt16(conver.Hour), Convert.ToInt16(conver.Minute),0);
                   
                   var checklogin = (from p in _context.tbl_record_logs
                                     where p.status == "logged" &&
                                            p.username == username &&
                                            p.dt_stamp.Year == today2.Year &&
                                            p.dt_stamp.Month == today2.Month &&
                                            p.dt_stamp.Day == today2.Day &&
                                            p.log_reason != "Staffed Time"
                                     select p).FirstOrDefault();
                   if (checklogin == null)
                   {
                       
                       var site = Settings.Default.ThisSite;
                       var login = new tbl_record_log
                       {
                           dt_stamp = conver2,
                           username = username,
                           campaign = camp.ToString(CultureInfo.InvariantCulture),
                           station = Environment.MachineName,
                           ip = NetworkIp.LocalIPAddress(),
                           status = "logged",
                           dt_stamp_day = conver.DayOfWeek.ToString(),
                           this_site = site, 
                           log_reason = "Current Staffed Time",
                           dt_stamp_end = time
                       };
                       _context.tbl_record_logs.Add(login);
                       _context.SaveChanges();
                       HistoryFile.CreateFileforToday(login, GlobalVariables.GlobalsLib.Timing);
                       GlobalVariables.GlobalsLib.CheckLogin = true;
                       GlobalVariables.GlobalsLib.RecordIdLogout = login.rec_id;
                       
                       return login.rec_id;
                   }
                   else
                   {
                       GlobalVariables.GlobalsLib.CheckLogin = false;
                       GlobalVariables.GlobalsLib.RecordIdLogout = checklogin.rec_id;
                       GlobalVariables.GlobalsLib.CanClose = true;
                       HistoryFile.CreateFileforToday2(checklogin, checklogin.dt_stamp);
                       return checklogin.rec_id;
                   }
               }
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
       }

       public static bool Logout(string username, long recordLogin)
       {
           try
           {
               using (_context = new CollectiveEntities2())
               {
                   
                   var time = DateTime.Now;
                   var timeest = TimeConversion.TimetoEst(time);
                   var conver2 = new DateTime(timeest.Year, timeest.Month, timeest.Day, Convert.ToInt16(timeest.Hour), Convert.ToInt16(timeest.Minute), 0);
                   var logout = (from p in _context.tbl_record_logs
                       where p.username == username &&
                             p.rec_id == recordLogin
                       select p).FirstOrDefault();
                   if (logout != null)
                   {
                       logout.log_reason = "Staffed Time";
                       logout.dt_stamp_end = conver2;
                       _context.SaveChanges();
                       HistoryFile.UpdatePause(conver2.ToString(CultureInfo.InvariantCulture), recordLogin);
                       return true;
                   }
                   else
                   {
                       return false;
                       
                   }
               }
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           } 
       }

       public static long InsertLockPause(string username, long camp)
       {
           try
           {
               using (_context = new CollectiveEntities2())
               {
                   var time = DateTime.Now;
                   var timeest = TimeConversion.TimetoEst(time);
                   var site = Settings.Default.ThisSite;
                   var login = new tbl_record_log
                   {
                       dt_stamp = timeest,
                       username = username,
                       campaign = camp.ToString(CultureInfo.InvariantCulture),
                       station = Environment.MachineName,
                       ip = NetworkIp.LocalIPAddress(),
                       status = "pause",
                       dt_stamp_day = DateTime.Now.DayOfWeek.ToString(),
                       this_site = site,
                       log_reason = "Automatic Pause"
                   };
                   _context.tbl_record_logs.Add(login);
                   _context.SaveChanges();
                   HistoryFile.MakePause(login,timeest);
                   _context.Database.Connection.Close();
                   _context.Database.Connection.Dispose();
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
