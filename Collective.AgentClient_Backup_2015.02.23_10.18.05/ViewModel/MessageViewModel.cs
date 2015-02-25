using System;
using Collective.AgentClient.Model;
using Collective.Library;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Collective.AgentClient.ViewModel
{

    public class MessageViewModel : ViewModelBase
    {
        #region Properties

        private readonly IDataService _dataService;

        #region MessageID
        /// <summary>
        /// The <see cref="MessageID" /> property's name.
        /// </summary>
        public const string MessageIDPropertyName = "MessageID";

        private long _messageID;

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

        #region From

        /// <summary>
        /// The <see cref="UserFrom" /> property's name.
        /// </summary>
        public const string UserFromPropertyName = "UserFrom";

        private string _userFrom ;

        /// <summary>
        /// Sets and gets the UserFrom property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserFrom
        {
            get
            {
                return _userFrom;
            }

            set
            {
                if (_userFrom == value)
                {
                    return;
                }

                _userFrom = value;
                RaisePropertyChanged(UserFromPropertyName);
            }
        }
        #endregion

        #region To
        /// <summary>
        /// The <see cref="FromUser" /> property's name.
        /// </summary>
        public const string FromUserPropertyName = "FromUser";

        private string _fromUser ;

        /// <summary>
        /// Sets and gets the FromUser property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FromUser
        {
            get
            {
                return _fromUser;
            }

            set
            {
                if (_fromUser == value)
                {
                    return;
                }

                _fromUser = value;
                RaisePropertyChanged(FromUserPropertyName);
            }
        }
        #endregion

        #region Title
        /// <summary>
        /// The <see cref="Tittle" /> property's name.
        /// </summary>
        public const string TittlePropertyName = "Tittle";

        private string _title = "";

        /// <summary>
        /// Sets and gets the Tittle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Tittle
        {
            get
            {
                return _title;
            }

            set
            {
                if (_title == value)
                {
                    return;
                }

                _title = value;
                RaisePropertyChanged(TittlePropertyName);
            }
        }
        #endregion

        #region Message Content
        /// <summary>
        /// The <see cref="MessageContent" /> property's name.
        /// </summary>
        public const string MessageContentPropertyName = "MessageContent";

        private string _messageContent ;

        /// <summary>
        /// Sets and gets the MessageContent property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MessageContent
        {
            get
            {
                return _messageContent;
            }

            set
            {
                if (_messageContent == value)
                {
                    return;
                }

                _messageContent = value;
                RaisePropertyChanged(MessageContentPropertyName);
            }
        }
        #endregion

        #region Date
        /// <summary>
        /// The <see cref="Date" /> property's name.
        /// </summary>
        public const string DatePropertyName = "Date";

        private DateTime _date;

        /// <summary>
        /// Sets and gets the Date property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                if (_date == value)
                {
                    return;
                }

                _date = value;
                RaisePropertyChanged(DatePropertyName);
            }
        }
        #endregion 

        #region MSGRead
        /// <summary>
        /// The <see cref="MsgRead" /> property's name.
        /// </summary>
        public const string MSGReadPropertyName = "MSGRead";

        private long _msgRead;

        /// <summary>
        /// Sets and gets the MSGRead property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long MsgRead
        {
            get
            {
                return _msgRead;
            }

            set
            {
                if (_msgRead == value)
                {
                    return;
                }

                _msgRead = value;
                RaisePropertyChanged(MSGReadPropertyName);
            }
        }
        #endregion

        public RelayCommand CloseMessage { get; set; }

        #endregion

        #region Construtor

        public MessageViewModel(IDataService dataService)
        {
            _dataService = dataService;
            RegisterCommand();

        }

        #endregion

        #region Private Methods
        public RelayCommand CanCloseCommand { get; set; }
        private void RegisterCommand()
        {
            CanCloseCommand = new RelayCommand(CanClose);
        }

        #endregion

        private void LoadMSG()
        {
            
        }

        private void CanClose()
        {
            
            
        }

    }
}