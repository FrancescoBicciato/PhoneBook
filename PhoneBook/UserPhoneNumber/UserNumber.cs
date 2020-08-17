using System;

namespace UserPhoneNumber
{
    public class UserNumber
    {
        internal int userID  = 0;
        public UserNumber()
        {        
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MobileNumber { get; set; }
        public string InternalNumber { get; set; }

        public string  Department { get; set; }

        public string  FullName { get =>  Name + " " + Surname; }




    }
}
