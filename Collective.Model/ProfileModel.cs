using System;
using GalaSoft.MvvmLight;
using Collective.Data;

namespace Collective.Model
{
   public class ProfileModel : ObservableObject
   {
       #region Propiedades

       //private static CollectiveEntities2 _context;

       public int ProfileID { get; set; }

       #region Employee_ID
       /// <summary>
       /// The <see cref="EmployeeID" /> property's name.
       /// </summary>
       public const string EmployeeIDPropertyName = "EmployeeID";

       private string _employeeID ;

       /// <summary>
       /// Sets and gets the EmployeeID property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string EmployeeID
       {
           get
           {
               return _employeeID;
           }

           set
           {
               if (_employeeID == value)
               {
                   return;
               }

               _employeeID = value;
               RaisePropertyChanged(EmployeeIDPropertyName);
           }
       }
       #endregion

       #region UserName

       /// <summary>
       /// The <see cref="UserName" /> property's name.
       /// </summary>
       public const string UserNamePropertyName = "UserName";

       private string _username;

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

       #region FristName

       /// <summary>
       /// The <see cref="FristName" /> property's name.
       /// </summary>
       public const string FristNamePropertyName = "FristName";

       private string _fristName;

       /// <summary>
       /// Sets and gets the FristName property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string FristName
       {
           get
           {
               return _fristName;
           }

           set
           {
               if (_fristName == value)
               {
                   return;
               }

               _fristName = value;
               RaisePropertyChanged(FristNamePropertyName);
           }
       }

       #endregion

       #region MName

       /// <summary>
       /// The <see cref="MName" /> property's name.
       /// </summary>
       public const string MNamePropertyName = "MName";

       private string _mName;

       /// <summary>
       /// Sets and gets the MName property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string MName
       {
           get
           {
               return _mName;
           }

           set
           {
               if (_mName == value)
               {
                   return;
               }

               _mName = value;
               RaisePropertyChanged(MNamePropertyName);
           }
       }

       #endregion

       #region LastName

       /// <summary>
       /// The <see cref="LastName" /> property's name.
       /// </summary>
       public const string LastNamePropertyName = "LastName";

       private string _lastName ;

       /// <summary>
       /// Sets and gets the LastName property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string LastName
       {
           get
           {
               return _lastName;
           }

           set
           {
               if (_lastName == value)
               {
                   return;
               }

               _lastName = value;
               RaisePropertyChanged(LastNamePropertyName);
           }
       }

       #endregion

       #region BirthDate

       /// <summary>
       /// The <see cref="Birthday" /> property's name.
       /// </summary>
       public const string BirthdayPropertyName = "Birthday";

       private DateTime _birthDay;

       /// <summary>
       /// Sets and gets the Birthday property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public DateTime Birthday
       {
           get
           {
               return _birthDay;
           }

           set
           {
               if (_birthDay == value)
               {
                   return;
               }

               _birthDay = value;
               RaisePropertyChanged(BirthdayPropertyName);
           }
       }

       #endregion

       #region ContactNumber

       /// <summary>
       /// The <see cref="ContactNumber" /> property's name.
       /// </summary>
       public const string ContactNumberPropertyName = "ContactNumber";

       private string _contactNumber ;

       /// <summary>
       /// Sets and gets the ContactNumber property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string ContactNumber
       {
           get
           {
               return _contactNumber;
           }

           set
           {
               if (_contactNumber == value)
               {
                   return;
               }

               _contactNumber = value;
               RaisePropertyChanged(ContactNumberPropertyName);
           }
       }

       #endregion

       #region CivilStatus

       /// <summary>
       /// The <see cref="CivilStatus" /> property's name.
       /// </summary>
       public const string CivilStatusPropertyName = "CivilStatus";

       private string _civilStatus;

       /// <summary>
       /// Sets and gets the CivilStatus property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string CivilStatus
       {
           get
           {
               return _civilStatus;
           }

           set
           {
               if (_civilStatus == value)
               {
                   return;
               }

               _civilStatus = value;
               RaisePropertyChanged(CivilStatusPropertyName);
           }
       }

       #endregion

       #region Gender

       /// <summary>
       /// The <see cref="Gender" /> property's name.
       /// </summary>
       public const string GenderPropertyName = "Gender";

       private string _gender;

       /// <summary>
       /// Sets and gets the Gender property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string Gender
       {
           get
           {
               return _gender;
           }

           set
           {
               if (_gender == value)
               {
                   return;
               }

               _gender = value;
               RaisePropertyChanged(GenderPropertyName);
           }
       }

       #endregion

       #region Nationality

       /// <summary>
       /// The <see cref="Nationality" /> property's name.
       /// </summary>
       public const string NationalityPropertyName = "Nationality";

       private string _nationality;

       /// <summary>
       /// Sets and gets the Nationality property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string Nationality
       {
           get
           {
               return _nationality;
           }

           set
           {
               if (_nationality == value)
               {
                   return;
               }

               _nationality = value;
               RaisePropertyChanged(NationalityPropertyName);
           }
       }

       #endregion

       #region Address

       /// <summary>
       /// The <see cref="Address" /> property's name.
       /// </summary>
       public const string AddressPropertyName = "Address";

       private string _address;

       /// <summary>
       /// Sets and gets the Address property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string Address
       {
           get
           {
               return _address;
           }

           set
           {
               if (_address == value)
               {
                   return;
               }

               _address = value;
               RaisePropertyChanged(AddressPropertyName);
           }
       }

       #endregion

       #region Department

       /// <summary>
       /// The <see cref="Department" /> property's name.
       /// </summary>
       public const string DepartmentPropertyName = "Department";

       private string _department;

       /// <summary>
       /// Sets and gets the Department property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string Department
       {
           get
           {
               return _department;
           }

           set
           {
               if (_department == value)
               {
                   return;
               }

               _department = value;
               RaisePropertyChanged(DepartmentPropertyName);
           }
       }

       #endregion

       #region Position

       /// <summary>
       /// The <see cref="Position" /> property's name.
       /// </summary>
       public const string PositionPropertyName = "Position";

       private string _position = "";

       /// <summary>
       /// Sets and gets the Position property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string Position
       {
           get
           {
               return _position;
           }

           set
           {
               if (_position == value)
               {
                   return;
               }

               _position = value;
               RaisePropertyChanged(PositionPropertyName);
           }
       }

       #endregion

       #region ProfilePicture
       /// <summary>
       /// The <see cref="ProfilePicture" /> property's name.
       /// </summary>
       public const string ProfilePicturePropertyName = "ProfilePicture";

       private string _profilepicture;

       /// <summary>
       /// Sets and gets the ProfilePicture property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string ProfilePicture
       {
           get
           {
               return _profilepicture;
           }

           set
           {
               if (_profilepicture == value)
               {
                   return;
               }

               _profilepicture = value;
               RaisePropertyChanged(ProfilePicturePropertyName);
           }
       }
       #endregion



       #endregion

       #region Public Methods

       #endregion

       #region Private Methods

       #endregion
   }
}
