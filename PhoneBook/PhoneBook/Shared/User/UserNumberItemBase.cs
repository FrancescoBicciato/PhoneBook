using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserPhoneNumber;

namespace PhoneBook.Shared.User
{
    public class UserNumberItemBase : ComponentBase
    {

        protected string btncontent = "⮛Show";
        private const string _hide = "⮙Hide";
        private const string _show = "⮛Show";
        protected bool collapse = true;
        protected void ToogleDetail()
        {
            btncontent = !collapse ? _show : _hide;
            collapse = !collapse;
        }
        
        [Parameter]
        public UserNumber Usernumbers { get; set;  }

    }
}
