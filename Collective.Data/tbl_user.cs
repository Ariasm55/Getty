//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Collective.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_user
    {
        public int user_id { get; set; }
        public string user_username { get; set; }
        public string user_password { get; set; }
        public Nullable<int> user_privileges { get; set; }
        public string user_email { get; set; }
        public System.DateTime user_timestamp { get; set; }
        public System.DateTime user_datecreated { get; set; }
        public int archived { get; set; }
        public System.DateTime date_archived { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
        public string Data4 { get; set; }
        public string Data5 { get; set; }
        public string this_site { get; set; }
    }
}
