using Collective.Data;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Collective.Model
{
    public class RecipientModel : ObservableObject
    {

        #region Properties
        private static CollectiveEntities2 _context;

        public long ID { get; set; }

        #region MessageID
        /// <summary>
        /// The <see cref="MessageID" /> property's name.
        /// </summary>
        public const string MessageIDPropertyName = "MessageID";

        private long _messageID ;

        /// <summary>
        /// Sets and gets the MessageID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long MessageID
        {
            get
            {
                return _messageID;
            }

            set
            {
                if (_messageID == value)
                {
                    return;
                }

                _messageID = value;
                RaisePropertyChanged(MessageIDPropertyName);
            }
        }
        #endregion

        #region Username
        /// <summary>
        /// The <see cref="UserName" /> property's name.
        /// </summary>
        public const string UserNamePropertyName = "UserName";

        private string _username ;

        /// <summary>
        /// Sets and gets the UserName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserName
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
                RaisePropertyChanged(UserNamePropertyName);
            }
        }
        #endregion

        #region Read
        /// <summary>
        /// The <see cref="ReadMessage" /> property's name.
        /// </summary>
        public const string ReadMessagePropertyName = "ReadMessage";

        private long _readMessage ;

        /// <summary>
        /// Sets and gets the ReadMessage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long ReadMessage
        {
            get
            {
                return _readMessage;
            }

            set
            {
                if (_readMessage == value)
                {
                    return;
                }

                _readMessage = value;
                RaisePropertyChanged(ReadMessagePropertyName);
            }
        }

        #endregion

        #endregion

        #region Public Methods

        public static void ReadMsg(long id, string agent)
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    var cheackread = (_context.tbl_recipients.Where(p => p.messages_id == id && p.user_username == agent)).FirstOrDefault();

                    if (cheackread == null || cheackread.recipient_read != 0) return;
                    cheackread.recipient_read = 1;
                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
        }
        public static List<MessageModel> GetAllUserMessagesID(string username)
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    var msgs = (from r in _context.tbl_recipients
                        join m in _context.tbl_messages
                            on r.messages_id equals m.message_id
                        join user in _context.tbl_users
                            on m.user_id equals user.user_id
                        where r.user_username == username
                        select new MessageModel
                        {
                            MessageTitle = m.message_title,
                            MessageContent = m.message_content,
                            MessageAttachment = m.message_attachment,
                            TimeStamp = m.message_timestamp,
                            UserName = new UserModel
                            {
                                UserName = user.user_username
                            },
                            Recepiant = new RecipientModel
                            {
                                UserName = r.user_username,
                                MessageID = r.messages_id,
                                ReadMessage = r.recipient_read
                                
                            }

                        }).ToList();

                    
                    return msgs;
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
