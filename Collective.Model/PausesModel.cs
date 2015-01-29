using System.Globalization;
using Collective.Data;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;


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
                   var retorno = new List<PausesModel>();
                   var lista = from p in _context.tbl_pauses
                       orderby p.pause_reason
                       select p;
                   foreach (var item in lista)
                   {
                       retorno.Add(new PausesModel
                       {
                           PauseId = item.pause_id,
                           Reason = item.pause_reason,
                           Desc = item.pause_description

                       });
                   }
                   return retorno;
               }
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message, exception);
           }
       }

       public static long Logout(long id, RecordLogModel log)
       {
           try
           {
               using (_context = new CollectiveEntities2())
               {
                   var lista = from r in _context.tbl_record_logs
                               where r.rec_id == id
                               select r;
                   foreach (var rec in lista)
                   {
                       rec.dt_stamp_end = DateTime.Today;
                       rec.log_reason = "Logout";

                   }
                   _context.SaveChanges();

               }
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return 0;
       }

       public static long InsertPause(string username, string pausename, long camp)
       {
           try
           {
               using (_context = new CollectiveEntities2())
               {

                   var login = new tbl_record_log
                   {
                       dt_stamp = DateTime.Now,
                       username = username,
                       campaign = camp.ToString(CultureInfo.InvariantCulture),
                       station = Environment.MachineName,
                       ip = Library.NetworkIp.LocalIPAddress(),
                       status = "paused",
                       dt_stamp_day = DateTime.Now.DayOfWeek.ToString(),
                       this_site = "Honduras",
                       log_reason = pausename
                   };
                   _context.tbl_record_logs.Add(login);
                   _context.SaveChanges();
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
               using (_context = new CollectiveEntities2())
               {
                   var lista = from r in _context.tbl_record_logs
                               where r.rec_id == id
                               select r;
                   foreach (var rec in lista)
                   {
                       rec.dt_stamp_end = DateTime.Now;
                   }
                   _context.SaveChanges();

               }
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return 0;
       }
       
       public static int LogOff(long id)
       {
           try
           {
               using (_context = new CollectiveEntities2())
               {
                   var lista = from r in _context.tbl_record_logs
                               where r.rec_id == id
                               select r;
                   foreach (var rec in lista)
                   {
                       rec.dt_stamp_end = DateTime.Now;
                       rec.log_reason = "Staffed Time";
                   }
                   _context.SaveChanges();

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
                   string today = DateTime.Today.ToString("yyyy/MM/dd");
                   DateTime today2 = DateTime.Parse(today);
                   
                   var checklogin = (from p in _context.tbl_record_logs
                                     where  p.status == "Loged" &&
                                            p.username == username &&
                                            p.dt_stamp.Year == today2.Year &&
                                            p.dt_stamp.Month == today2.Month &&
                                            p.dt_stamp.Day == today2.Day &&
                                            p.log_reason != "Staffed Time"
                                     select p).FirstOrDefault();
                   if (checklogin == null)
                   {
                       var site = Properties.Settings.Default.ThisSite;
                       DateTime time = new DateTime();
                       var login = new tbl_record_log
                       {
                           dt_stamp = DateTime.Now,
                           username = username,
                           campaign = camp.ToString(CultureInfo.InvariantCulture),
                           station = Environment.MachineName,
                           ip = Library.NetworkIp.LocalIPAddress(),
                           status = "Loged",
                           dt_stamp_day = DateTime.Now.DayOfWeek.ToString(),
                           this_site = site, 
                           log_reason = "Current Staffed Time",
                           dt_stamp_end = time
                       };
                       _context.tbl_record_logs.Add(login);
                       _context.SaveChanges();
                       Library.GlobalVariables.GlobalsLib.CheckLogin = true;
                       return login.rec_id;
                   }
                   else
                   {
                       Library.GlobalVariables.GlobalsLib.CheckLogin = false;
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
                   var logout = (from p in _context.tbl_record_logs
                       where p.username == username &&
                             p.rec_id == recordLogin
                       select p).FirstOrDefault();
                   if (logout != null)
                   {
                       logout.log_reason = "Staffed Time";
                       logout.dt_stamp_end = DateTime.Now;
                       _context.SaveChanges();
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

                   var login = new tbl_record_log
                   {
                       dt_stamp = DateTime.Now,
                       username = username,
                       campaign = camp.ToString(CultureInfo.InvariantCulture),
                       station = Environment.MachineName,
                       ip = Library.NetworkIp.LocalIPAddress(),
                       status = "paused",
                       dt_stamp_day = DateTime.Now.DayOfWeek.ToString(),
                       this_site = "Honduras",
                       log_reason = "Automatic Pause"
                   };
                   _context.tbl_record_logs.Add(login);
                   _context.SaveChanges();
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
