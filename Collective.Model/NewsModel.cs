using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using Collective.Data;
using GalaSoft.MvvmLight;

namespace Collective.Model
{
    public class NewsModel : ObservableObject
    {
        #region Properties
        private static CollectiveEntities2 _context;

        public int NewsId { get; set; }

        #region Name

        /// <summary>
        /// The <see cref="NewsName" /> property's name.
        /// </summary>
        public const string NewsNamePropertyName = "NewsName";

        private string _newsName = "";

        /// <summary>
        /// Sets and gets the NewsName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string NewsName
        {
            get
            {
                return _newsName;
            }

            set
            {
                if (_newsName == value)
                {
                    return;
                }

                _newsName = value;
                RaisePropertyChanged(NewsNamePropertyName);
            }
        }
        #endregion

        #region Date
        /// <summary>
        /// The <see cref="NewsDate" /> property's name.
        /// </summary>
        public const string NewsDatePropertyName = "NewsDate";

        private DateTime _newsDate;

        /// <summary>
        /// Sets and gets the NewsDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime NewsDate
        {
            get
            {
                return _newsDate;
            }

            set
            {
                if (_newsDate == value)
                {
                    return;
                }

                _newsDate = value;
                RaisePropertyChanged(NewsDatePropertyName);
            }
        }
       
        #endregion

        #region PictureLocation

        /// <summary>
        /// The <see cref="PictureLocation" /> property's name.
        /// </summary>
        public const string PictureLocationPropertyName = "PictureLocation";

        private string _pictureLocation = "";

        /// <summary>
        /// Sets and gets the PictureLocation property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string PictureLocation
        {
            get
            {
                return _pictureLocation;
            }

            set
            {
                if (_pictureLocation == value)
                {
                    return;
                }

                _pictureLocation = value;
                RaisePropertyChanged(PictureLocationPropertyName);
            }
        }
        #endregion

        #region Active/Disable
        /// <summary>
        /// The <see cref="Active" /> property's name.
        /// </summary>
        public const string ActivePropertyName = "Active";

        private bool _active = false;

        /// <summary>
        /// Sets and gets the Active property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool Active
        {
            get
            {
                return _active;
            }

            set
            {
                if (_active == value)
                {
                    return;
                }

                _active = value;
                RaisePropertyChanged(ActivePropertyName);
            }
        }
        #endregion

        #region Link
        /// <summary>
        /// The <see cref="Link" /> property's name.
        /// </summary>
        public const string LinkPropertyName = "Link";

        private string _link = "";

        /// <summary>
        /// Sets and gets the Link property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Link
        {
            get
            {
                return _link;
            }

            set
            {
                if (_link == value)
                {
                    return;
                }

                _link = value;
                RaisePropertyChanged(LinkPropertyName);
            }
        }
        #endregion

        #region bitmapURI
        /// <summary>
        /// The <see cref="BitMap" /> property's name.
        /// </summary>
        public const string BitMapPropertyName = "BitMap";

        private BitmapImage _bitmap;

        /// <summary>
        /// Sets and gets the BitMap property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public BitmapImage BitMap
        {
            get
            {
                return _bitmap;
            }

            set
            {
                if (_bitmap == value)
                {
                    return;
                }

                _bitmap = value;
                RaisePropertyChanged(BitMapPropertyName);
            }
        }
        #endregion



        #endregion

        #region Public Methods

        public static List<NewsModel> GetAll()
        {
            try
            {
                using (_context = new CollectiveEntities2())
                {
                    var result = new List<NewsModel>();
                    var list = (from p in _context.tbl_news
                        where p.news_active != false
                        select p);

                    foreach (var picture in list)
                    {
                        var uriAddress = new Uri(picture.news_PictureLocation);
                        var image = new BitmapImage(uriAddress);
                        result.Add( new NewsModel
                        {
                            BitMap = image,
                            PictureLocation = picture.news_PictureLocation,
                            Link = picture.news_Link
                            
                            
                        });
                        
                    }
                    return result;
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
