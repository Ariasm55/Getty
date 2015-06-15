using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Collective.Data;
using Collective.Library;
using GalaSoft.MvvmLight;


// ReSharper disable FunctionComplexityOverflow

// ReSharper disable RedundantAssignment

namespace Collective.Model
{

    // This Class is to make a File for every days Logs to check and see any problems with the DB
    // It will create on File Per Day
    // Inside the File you will find each pause in and out,Log in and out of  Agent.
    // Juan Angel Arias
    //May 10th 2015
    public class HistoryFile : ObservableObject
    {
        #region Properties
        private static CollectiveEntities2 _context;
        public static class Variables
        {
            public static string FileName;
            public static string PauseId;
        }
        #endregion

       
        #region Constructor

        public static void CreateFileforToday2(tbl_record_log login, DateTime timenow)
        {
            var conver = TimeConversion.TimetoEst(DateTime.Now);
            var day = conver.Day;
            var month = conver.Month;
            var year = conver.Year;
            var fileName = day + "_" + month + "_" + year + "_" + login.username + ".csv";
            var fileName2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), fileName);
            Variables.FileName = fileName2;
            var file = new StreamWriter(fileName2, true);
            
            file.Close();
        }

        public static void CreateFileforToday(tbl_record_log login, DateTime timenow)
        {
            var conver = TimeConversion.TimetoEst(DateTime.Now);
            var day = conver.Day;
            var month = conver.Month;
            var year = conver.Year;
            var fileName = day + "_" + month + "_" + year + "_" + login.username + ".csv";
            var fileName2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), fileName);
           
                
            Variables.FileName = fileName2;
            var file = new StreamWriter(fileName2, true);

            

            file.Write(
                "rec_id,dt_stamp,dt_stamp_end,username,campaign,station,IP,status,dt_stamp_day,this_site,log_reason\r\n");
            file.Write(login.rec_id + "," + login.dt_stamp + "," + login.dt_stamp_end + "," + login.username + "," +
                       login.campaign + "," +
                       login.station + "," + login.ip + "," + login.status + "," + login.dt_stamp_day + "," +
                       login.this_site + "," +
                       login.log_reason + "\r\n");

            file.Close();

        }


        public static void MakePause(tbl_record_log login, DateTime esttime)
        {
            var fileName = Variables.FileName;
            var file = new StreamWriter(fileName,true);
            

            file.Write(login.rec_id + "," + esttime + "," + login.dt_stamp_end + "," + login.username + "," +
                       login.campaign + "," + login.station + "," + login.ip + "," + login.status + "," + 
                       login.dt_stamp_day + "," + login.this_site + "," + login.log_reason + "\r\n");
            file.Close();

        }

        public static void UpdatePause(string time,long id)
        {
            try
            {
                var fileName = Variables.FileName;
                var search = id.ToString();
                var  text = File.ReadAllText(fileName);
                text = text.Replace(search,"78,");
                File.WriteAllText("test.txt",text);


                var lookupid = id.ToString();
                const string delimiter = ",";
                const bool firstLineContainsHeaders = true;
                var tempPath = Path.GetTempFileName();
                var lineNumber = 0;

                var splitExpression = new Regex(@"(" + delimiter + @")(?=(?:[^""]|""[^""]*"")*$)");

                using (var writer = new StreamWriter(tempPath,true))
                using (var reader = new StreamReader(fileName,true))
                {
                    string line = null;
                    string[] headers = null;
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (firstLineContainsHeaders)
                    {
                        line = reader.ReadLine();
                        lineNumber++;

                        if (string.IsNullOrEmpty(line)) return; // file is empty;

                        headers = splitExpression.Split(line).Where(s => s != delimiter).ToArray();
                        
                        writer.WriteLine(line); // write the original header to the temp file.
                    }

                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;

                        var columns = splitExpression.Split(line).Where(s => s != delimiter).ToArray();

                        // if there are no headers,do a simple sanity check to make sure you always have the same number of columns in a line
                        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                        // ReSharper disable once HeuristicUnreachableCode
                        if (headers == null) headers = new string[columns.Length];

                        if (columns.Length != headers.Length) throw new InvalidOperationException(string.Format("Line {0} is missing one or more columns.",lineNumber));

                        // TODO: search and replace in columns
                        // example: replace 'v' in the first column with '\/': if (columns[0].Contains("v")) columns[0] = columns[0].Replace("v",@"\/");

                        if (columns[0].Contains(lookupid))
                        {
                            
                            if (columns[7].Contains("logged"))
                                
                            {
                                columns[2] = columns[2].Replace("1/1/0001 12:00:00 AM", time.ToString());
                                columns[10] = columns[10].Replace("Current Staffed Time", "Staffed Time");

                            }
                            else
                            {
                                columns[2] = columns[2].Replace("1/1/0001 12:00:00 AM", time.ToString());
                            }
                           
                        }
                            
                        writer.WriteLine(string.Join(delimiter,columns));
                    }
                    reader.Close();
                    writer.Close();
                    File.Delete(fileName);
                    File.Move(tempPath,fileName);
                }

                

            }
            catch (Exception exception)
            {
                
                MessageBox.Show(exception.Message);
            }
            

            
        }

        public static void UpdateDb()
        {
            var change = false;
            try
            {
                var fileName = Variables.FileName;
                const string delimiter = ",";
                const bool firstLineContainsHeaders = true;
                var tempPath = Path.GetTempFileName();
                var lineNumber = 0;
                var splitExpression = new Regex(@"(" + delimiter + @")(?=(?:[^""]|""[^""]*"")*$)");

                using (var writer = new StreamWriter(tempPath, true))
                using (var reader = new StreamReader(fileName, true))
                {
                    string line = null;
                    string[] headers = null;
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (firstLineContainsHeaders)
                    {
                        line = reader.ReadLine();
                        lineNumber++;

                        if (string.IsNullOrEmpty(line)) return; // file is empty;

                        headers = splitExpression.Split(line).Where(s => s != delimiter).ToArray();

                        writer.WriteLine(line); // write the original header to the temp file.
                    }

                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;

                        var columns = splitExpression.Split(line).Where(s => s != delimiter).ToArray();

                        // if there are no headers,do a simple sanity check to make sure you always have the same number of columns in a line
                        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                        // ReSharper disable once HeuristicUnreachableCode
                        if (headers == null) headers = new string[columns.Length];

                        if (columns.Length != headers.Length) throw new InvalidOperationException(string.Format("Line {0} is missing one or more columns.", lineNumber));

                        // TODO: search and replace in columns
                        // example: replace 'v' in the first column with '\/': if (columns[0].Contains("v")) columns[0] = columns[0].Replace("v",@"\/");

                        if (columns[7].Contains("logged") && columns[10].Contains("Current Staffed Time"))
                        {
                            
                            var dateIn = Convert.ToDateTime(columns[1]);
                            var dateOut = Convert.ToDateTime(columns[2]);
                            var username = columns[3];
                            var station = columns[5];
                            var status = columns[7];
                            var datestamp = columns[8];
                            var logreason = columns[10];
                            var campaign = columns[4];
                            var ip = columns[6];
                            string today = dateIn.ToString("yyyy/MM/dd");
                            DateTime today2 = DateTime.Parse(today);
                            try
                            {
                                using (_context = new CollectiveEntities2())
                                {
                                    var check = (from p in _context.tbl_record_logs
                                                 where
                                                 p.dt_stamp.Day == today2.Day &&
                                                 p.dt_stamp.Month == today2.Month &&
                                                 p.dt_stamp.Year == today2.Year &&
                                                 p.dt_stamp.Hour == dateIn.Hour &&
                                                 p.dt_stamp.Minute == dateIn.Minute &&
                                                 p.dt_stamp_day == datestamp &&
                                                 p.username == username &&
                                                 p.station == station &&
                                                 p.status == status &&
                                                 p.log_reason == logreason &&
                                                 p.ip == ip &&
                                                 p.campaign == campaign
                                                 
                                                 select p).FirstOrDefault();
                                    if (check == null)
                                    {
                                        var insertlostdata = new tbl_record_log
                                        {
                                            dt_stamp = dateIn,
                                            dt_stamp_end = dateOut,
                                            username = columns[3],
                                            campaign = columns[4],
                                            station = columns[5],
                                            ip = columns[6],
                                            status = columns[7],
                                            dt_stamp_day = columns[8],
                                            this_site = columns[9],
                                            log_reason = columns[10]
                                        };
                                        change = true;
                                        _context.tbl_record_logs.Add(insertlostdata);
                                        _context.SaveChanges();

                                        var newid = (from p in _context.tbl_record_logs
                                                     where p.dt_stamp == dateIn &&
                                                           p.dt_stamp_day == datestamp &&
                                                           p.username == username &&
                                                           p.station == station &&
                                                           p.status == status &&
                                                           p.log_reason == logreason &&
                                                           p.ip == ip &&
                                                           p.campaign == campaign
                                                     select p).FirstOrDefault();

                                        if (newid != null) GlobalVariables.GlobalsLib.RecordIdLogout = newid.rec_id;


                                        _context.Database.Connection.Close();
                                        _context.Database.Connection.Dispose();


                                    }
                                }
                            }
                            catch (Exception exception)
                            {

                                // ReSharper disable once RedundantToStringCall
                                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                exception.Message.ToString();
                            }
                            writer.WriteLine(string.Join(delimiter, columns));
                            
                        }
                        if (columns[7].Contains("pause"))
                        {
                            
                            var dateIn = Convert.ToDateTime(columns[1]);
                            var dateOut = Convert.ToDateTime(columns[2]);
                            var username = columns[3];
                            var station = columns[5];
                            var status = columns[7];
                            var datestamp = columns[8];
                            var logreason = columns[10];
                            var campaign = columns[4];
                            var ip = columns[6];
                            string today = dateIn.ToString("yyyy/MM/dd");
                            DateTime today2 = DateTime.Parse(today);
                            try
                            {
                                using (_context = new CollectiveEntities2())
                                {
                                    var check = (from p in _context.tbl_record_logs
                                                 where
                                                 p.dt_stamp.Day == today2.Day &&
                                                 p.dt_stamp.Month == today2.Month &&
                                                 p.dt_stamp.Year == today2.Year &&
                                                 p.dt_stamp.Hour == dateIn.Hour &&
                                                 p.dt_stamp.Minute == dateIn.Minute &&
                                                 p.dt_stamp_day == datestamp &&
                                                 p.username == username &&
                                                 p.station == station &&
                                                 p.status == status &&
                                                 p.log_reason == logreason &&
                                                 p.ip == ip &&
                                                 p.campaign == campaign
                                                 select p).FirstOrDefault();
                                    if (check == null)
                                    {
                                        var insertlostdata = new tbl_record_log
                                        {
                                            dt_stamp = dateIn,
                                            dt_stamp_end = dateOut,
                                            username = columns[3],
                                            campaign = columns[4],
                                            station = columns[5],
                                            ip = columns[6],
                                            status = columns[7],
                                            dt_stamp_day = columns[8],
                                            this_site = columns[9],
                                            log_reason = columns[10]
                                        };
                                        change = true;
                                        _context.tbl_record_logs.Add(insertlostdata);
                                        _context.SaveChanges();
                                        var newid = (from p in _context.tbl_record_logs
                                            where p.dt_stamp == dateIn &&
                                                  p.dt_stamp_day == datestamp &&
                                                  p.username == username &&
                                                  p.station == station &&
                                                  p.status == status &&
                                                  p.log_reason == logreason &&
                                                  p.ip == ip &&
                                                  p.campaign == campaign
                                            select p).FirstOrDefault();

                                        if (newid != null) GlobalVariables.GlobalsLib.RecordIdPause = newid.rec_id;


                                        _context.Database.Connection.Close();
                                        _context.Database.Connection.Dispose();


                                    }
                                }
                            }
                            catch (Exception exception)
                            {

                                // ReSharper disable once RedundantToStringCall
                                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                                exception.Message.ToString();
                            }

                        }
                       
                        
                    }
                    if (change)
                    {
                        reader.Close();
                        writer.Close();
                        
                    }
                    else
                    {
                        reader.Close();
                        writer.Close();
                    }
                    
                    
                }



            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            

         
            

        }
    }

    #endregion
}

