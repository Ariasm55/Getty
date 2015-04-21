using System;
using System.Collections.Generic;
using System.Linq;
using Collective.Data;
using GalaSoft.MvvmLight;

namespace Collective.Model
{
    public class ToastModel : ObservableObject
    {
        private static CollectiveEntities2 _context;

        #region Propertys
        public long ToastId { get; set; }

        #region Username
        /// <summary>
        /// The <see cref="Username" /> property's name.
        /// </summary>
        public const string UsernamePropertyName = "Username";

        private string _username = "";

        /// <summary>
        /// Sets and gets the Username property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                if (_username == value)
                {
                    return;
                }

                _username = value;
                RaisePropertyChanged(UsernamePropertyName);
            }
        }
        #endregion

        #region DateCreated
        /// <summary>
        /// The <see cref="DateTimeCreated" /> property's name.
        /// </summary>
        public const string DateTimeCreatedPropertyName = "DateTimeCreated";

        private DateTime _datetimecreate;

        /// <summary>
        /// Sets and gets the DateTimeCreated property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DateTimeCreated
        {
            get
            {
                return _datetimecreate;
            }

            set
            {
                if (_datetimecreate == value)
                {
                    return;
                }

                _datetimecreate = value;
                RaisePropertyChanged(DateTimeCreatedPropertyName);
            }
        }
        #endregion

        #region Message
        /// <summary>
        /// The <see cref="Message" /> property's name.
        /// </summary>
        public const string MessagePropertyName = "Message";

        private string _message;

        /// <summary>
        /// Sets and gets the Message property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                if (_message == value)
                {
                    return;
                }

                _message = value;
                RaisePropertyChanged(MessagePropertyName);
            }
        }
        #endregion

        #region Read
        /// <summary>
        /// The <see cref="ReadMessage" /> property's name.
        /// </summary>
        public const string ReadMessagePropertyName = "ReadMessage";

        private bool _readmessage;

        /// <summary>
        /// Sets and gets the ReadMessage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ReadMessage
        {
            get
            {
                return _readmessage;
            }

            set
            {
                if (_readmessage == value)
                {
                    return;
                }

                _readmessage = value;
                RaisePropertyChanged(ReadMessagePropertyName);
            }
        }
        #endregion

        #region ReadDate
        /// <summary>
        /// The <see cref="ReadDate" /> property's name.
        /// </summary>
        public const string ReadDatePropertyName = "ReadDate";

        private DateTime _readdate;

        /// <summary>
        /// Sets and gets the ReadDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime ReadDate
        {
            get
            {
                return _readdate;
            }

            set
            {
                if (_readdate == value)
                {
                    return;
                }

                _readdate = value;
                RaisePropertyChanged(ReadDatePropertyName);
            }
        }
        #endregion

        #region MessageType
        /// <summary>
        /// The <see cref="MessageType" /> property's name.
        /// </summary>
        public const string MessageTypePropertyName = "MessageType";

        private int _messagetype;

        /// <summary>
        /// Sets and gets the MessageType property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int MessageType
        {
            get
            {
                return _messagetype;
            }

            set
            {
                if (_messagetype == value)
                {
                    return;
                }

                _messagetype = value;
                RaisePropertyChanged(MessageTypePropertyName);
            }
        }

        #endregion

        #region Color
        /// <summary>
        /// The <see cref="Color" /> property's name.
        /// </summary>
        public const string ColorPropertyName = "Color";

        private string _color;

        /// <summary>
        /// Sets and gets the Color property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Color
        {
            get
            {
                return _color;
            }

            set
            {
                if (_color == value)
                {
                    return;
                }

                _color = value;
                RaisePropertyChanged(ColorPropertyName);
            }
        }
        #endregion

        #endregion

        #region Public Methods

        public static List<ToastModel> GetToast(string username)
        {
            try
            {
                using (_context =new CollectiveEntities2())
                {
                    var toast = (from p in _context.tbl_toasts
                        where p.toast_username == username && p.toast_read != true
                        select p);
                    return toast.Select(toasty => new ToastModel
                    {
                        Message = toasty.toast_message, MessageType = toasty.toast_type
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
        }

        public static void RegisterToast(string username, int typeoftoast)
        {
            try
            {
                var startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
                var endofweek = startOfWeek.AddDays(7);
                var today1 = DateTime.Today.Date;
                using (_context =new CollectiveEntities2())
                {
                    var checktoast = (from p in _context.tbl_toasts
                        where p.toast_username == username
                              && p.toast_datetime == today1
                        select p).FirstOrDefault();
                    if (checktoast == null)
                    {
                        #region SWITCH

                        var today = DateTime.Today;
                        switch (typeoftoast)
                        {
                            case 1:
                            {
                                var checklate = (from p in _context.tbl_toasts
                                    where p.toast_username == username
                                          && p.toast_datetime >= startOfWeek
                                          && p.toast_datetime <= endofweek
                                          && p.toast_type == 1
                                          && p.toast_type == 2
                                    select p.toast_type).Count();
                                if (checklate <= 2)
                                {
                                    var toast1 = new tbl_toast
                                    {

                                        toast_username = username,
                                        toast_datetime = DateTime.Now,
                                        toast_read = false,
                                        toast_message = "You are Late Today",
                                        toast_type = 1

                                    };
                                    _context.tbl_toasts.Add(toast1);
                                    _context.SaveChanges();
                                }
                                else if (checklate >= 3)
                                {
                                    var toast1 = new tbl_toast
                                    {

                                        toast_username = username,
                                        toast_datetime = DateTime.Now,
                                        toast_read = false,
                                        toast_message = "You have been late for the last few day's.",
                                        toast_type = 3

                                    };
                                    _context.tbl_toasts.Add(toast1);
                                    _context.SaveChanges();
                                }

                            }
                                break;
                            case 2:
                                var checklate2 = (from p in _context.tbl_toasts
                                    where p.toast_username == username
                                          && p.toast_datetime >= startOfWeek
                                          && p.toast_datetime <= endofweek
                                          && p.toast_type == 1
                                          && p.toast_type == 2
                                    select p.toast_type).Count();
                                if (checklate2 >= 2)
                                {
                                    var toast1 = new tbl_toast
                                    {

                                        toast_username = username,
                                        toast_datetime = DateTime.Now,
                                        toast_read = false,
                                        toast_message = "Right on Schedule.",
                                        toast_type = 5

                                    };
                                    _context.tbl_toasts.Add(toast1);
                                    _context.SaveChanges();


                                }
                                else if (checklate2 <= 3)
                                {
                                    var toast1 = new tbl_toast
                                    {

                                        toast_username = username,
                                        toast_datetime = DateTime.Now,
                                        toast_read = false,
                                        toast_message = "Congratulation's you are on Time Today.",
                                        toast_type = 4

                                    };
                                    _context.tbl_toasts.Add(toast1);
                                    _context.SaveChanges();
                                }

                                break;
                        }

                        #endregion

                    }
                }
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            } 
        }

        public static void ClearToast(long toastId)
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    var updatetoast = (from p in _context.tbl_toasts
                        where p.toast_id == toastId
                        select p).FirstOrDefault();
                    if (updatetoast != null)
                    {
                        updatetoast.toast_read = true;
                        updatetoast.toast_read_date = DateTime.Today;
                        _context.SaveChanges();
                    }

                    _context.Database.Connection.Close();
                    _context.Dispose();
                }
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
