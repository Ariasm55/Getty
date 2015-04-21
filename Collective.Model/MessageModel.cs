using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Collective.Data;
using GalaSoft.MvvmLight;

namespace Collective.Model
{
    public class MessageModel : ObservableObject
    {
       
        #region Properties
        private static CollectiveEntities2 _context;

        public long ID { get; set; }
        
        #region "MessageTitle"
        /// The <see cref="MessageTitle" /> property's name.
        /// </summary>
        public const string MessageTitlePropertyName = "MessageTitle";

        private string _messagetitle = "";

        /// <summary>
        /// Sets and gets the MessageTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MessageTitle
        {
            get
            {
                return _messagetitle;
            }

            set
            {
                if (_messagetitle == value)
                {
                    return;
                }

                _messagetitle = value;
                RaisePropertyChanged(MessageTitlePropertyName);
            }
        }
        #endregion
        
        #region "MessageContent"
        /// The <see cref="MessageContent" /> property's name.
        /// </summary>
        public const string MessageContentPropertyName = "MessageContent";

        private string _messagecontent = "";

        /// <summary>
        /// Sets and gets the MessageContent property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MessageContent
        {
            get
            {
                return _messagecontent;
            }

            set
            {
                if (_messagecontent == value)
                {
                    return;
                }

                _messagecontent = value;
                RaisePropertyChanged(MessageContentPropertyName);
            }
        }
        #endregion
        
        #region "MessageAttachment"
        /// The <see cref="MessageAttachment" /> property's name.
        /// </summary>
        public const string MessageAttachmentPropertyName = "MessageAttachment";

        private string _messageattachment = "";

        /// <summary>
        /// Sets and gets the MessageAttachment property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MessageAttachment
        {
            get
            {
                return _messageattachment;
            }

            set
            {
                if (_messageattachment == value)
                {
                    return;
                }

                _messageattachment = value;
                RaisePropertyChanged(MessageAttachmentPropertyName);
            }
        }
        #endregion
        
        #region "DateCreated"
        /// The <see cref="DateCreated" /> property's name.
        /// </summary>
        public const string DateCreatedPropertyName = "DateCreated";

        private DateTime _dateCreated  ;

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
                
        #region "TimeStamp"
        /// The <see cref="TimeStamp" /> property's name.
        /// </summary>
        public const string TimeStampPropertyName = "TimeStamp";

        private DateTime _timestamp  ;

        /// <summary>
        /// Sets and gets the TimeStamp property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime TimeStamp
        {
            get
            {
                return _timestamp;
            }

            set
            {
                if (_timestamp == value)
                {
                    return;
                }

                _timestamp = value;
                RaisePropertyChanged(TimeStampPropertyName);
            }
        }
        #endregion

        #region User

        /// <summary>
        /// The <see cref="User" /> property's name.
        /// </summary>
        public const string UserPropertyName = "User";

        private UserModel _user;

        /// <summary>
        /// Sets and gets the User property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public UserModel User
        {
            get
            {
                return _user;
            }

            set
            {
                if (_user == value)
                {
                    return;
                }

                _user = value;
                RaisePropertyChanged(UserPropertyName);
            }
        }

        #endregion
    
        #region "MessagesTo"
        /// The <see cref="MessagesTo" /> property's name.
        /// </summary>
        public const string MessagesToPropertyName = "MessagesTo";

        private string _messagesto = "";

        /// <summary>
        /// Sets and gets the MessagesTo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MessagesTo
        {
            get
            {
                return _messagesto;
            }

            set
            {
                if (_messagesto == value)
                {
                    return;
                }

                _messagesto = value;
                RaisePropertyChanged(MessagesToPropertyName);
            }
        }
        #endregion
        
        #region "MessagesendTo"
        /// The <see cref="MessagesendTo" /> property's name.
        /// </summary>
        public const string MessagesendToPropertyName = "MessagesendTo";

        private string _messagesendto = "";

        /// <summary>
        /// Sets and gets the MessagesendTo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MessagesendTo
        {
            get
            {
                return _messagesendto;
            }

            set
            {
                if (_messagesendto == value)
                {
                    return;
                }

                _messagesendto = value;
                RaisePropertyChanged(MessagesendToPropertyName);
            }
        }
        #endregion
        
        #region "Priority"
        /// The <see cref="Priority" /> property's name.
        /// </summary>
        public const string PriorityPropertyName = "Priority";

        private long _priority ;

        /// <summary>
        /// Sets and gets the Priority property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long Priority
        {
            get
            {
                return _priority;
            }

            set
            {
                if (_priority == value)
                {
                    return;
                }

                _priority = value;
                RaisePropertyChanged(PriorityPropertyName);
            }
        }
        #endregion
        
        #region "MessageRead"
        /// The <see cref="MessageRead" /> property's name.
        /// </summary>
        public const string MessageReadPropertyName = "MessageRead";

        private string _messageread = "";

        /// <summary>
        /// Sets and gets the MessageRead property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MessageRead
        {
            get
            {
                return _messageread;
            }

            set
            {
                if (_messageread == value)
                {
                    return;
                }

                _messageread = value;
                RaisePropertyChanged(MessageReadPropertyName);
            }
        }
        #endregion
        
        #region "ThisSite"
        /// The <see cref="ThisSite" /> property's name.
        /// </summary>
        public const string ThisSitePropertyName = "ThisSite";

        private string _thissite = "";

        /// <summary>
        /// Sets and gets the ThisSite property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ThisSite
        {
            get
            {
                return _thissite;
            }

            set
            {
                if (_thissite == value)
                {
                    return;
                }

                _thissite = value;
                RaisePropertyChanged(ThisSitePropertyName);
            }
        }
        #endregion

        public UserModel UserName { get; set; }
        public RecipientModel Recepiant { get; set; }

		
        #endregion

        #region Public Methods
            
        public static List<MessageModel> GetMSGuser(string username)
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    var Result = new List<MessageModel>();
                    var lista = (from r in _context.tbl_messages
                                 where r.messages_sendto == username
                                 orderby r.message_id ascending 
                                select r);

                    foreach (var log in lista)
                    {
                        Result.Add(new MessageModel
                        {
                            MessageTitle = log.message_title,
                            MessageContent = log.message_content,
                            MessageAttachment = log.message_attachment,
                            DateCreated = log.message_datecreated,
                            TimeStamp = log.message_timestamp,
                            MessagesendTo = log.message_sendto,
                            Priority = log.message_priority,
                            MessageRead = log.messages_sendto,
                            ThisSite = log.this_site


                        });
                    }
                    
                    return Result;
                }
            }
            catch (Exception excetion)
            {
                
                throw new Exception(excetion.Message);
            }
        }

        public static void GetMsg()
        {
            
        }
         
        #endregion

        #region Private Methods

       

        #endregion

    }
}
