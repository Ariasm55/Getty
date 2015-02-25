using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Collective.Data;
using GalaSoft.MvvmLight;

namespace Collective.Model
{
    public class ForgotPasswordModel : ObservableObject
    {
        #region Property

        private static CollectiveEntities2 _context;
        public int Fpid { get; set; }

        #region UserID
        
        
        /// <summary>
        /// The <see cref="User_id" /> property's name.
        /// </summary>
        public const string User_idPropertyName = "User_id";

        private int _userid;

        /// <summary>
        /// Sets and gets the User_id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int User_id
        {
            get
            {
                return _userid;
            }

            set
            {
                if (_userid == value)
                {
                    return;
                }

                _userid = value;
                RaisePropertyChanged(User_idPropertyName);
            }
        }
        #endregion

        #region Question

        /// <summary>
        /// The <see cref="Question" /> property's name.
        /// </summary>
        public const string QuestionPropertyName = "Question";

        private string _question = "";

        /// <summary>
        /// Sets and gets the Question property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Question
        {
            get
            {
                return _question;
            }

            set
            {
                if (_question == value)
                {
                    return;
                }

                _question = value;
                RaisePropertyChanged(QuestionPropertyName);
            }
        }

        #endregion

        #region Answer

        /// <summary>
        /// The <see cref="Answer" /> property's name.
        /// </summary>
        public const string AnswerPropertyName = "Answer";

        private string _answer = "";

        /// <summary>
        /// Sets and gets the Answer property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Answer
        {
            get
            {
                return _answer;
            }

            set
            {
                if (_answer == value)
                {
                    return;
                }

                _answer = value;
                RaisePropertyChanged(AnswerPropertyName);
            }
        }

        #endregion

        #endregion

        #region Public Methods

        public static List<ForgotPasswordModel> GetQuestion()
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    var retorno = new List<ForgotPasswordModel>();
                    var lista = from p in _context.tbl_info_respas
                                group p by p.question into g
                                select new { QuestionName = g.Key, Questions = g.ToList() };

                    foreach (var item in lista)
                    {
                        retorno.Add(new ForgotPasswordModel
                        {
                            Question = item.QuestionName
                        });
                    }
                    return retorno;
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
