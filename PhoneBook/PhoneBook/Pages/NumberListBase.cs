using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UserPhoneNumber;
namespace PhoneBook.Pages
{
    public class NumberListBase : ComponentBase
    {
        protected bool hideLoading, noNumber = false;
        public IEnumerable<UserNumber> Usernumbers { get; set; }
        
        private static readonly string constr = "server = .\\SQLEXPRESS2019; database='PHONE BOOK';uid=sa;password=0000;";

        public UserAction useraction = new UserAction(constr);
        protected override async Task OnInitializedAsync()
        {
            await LoadData();

        }
        private async Task LoadData()
        {
            Usernumbers = await useraction.LoadUserList();
            hideLoading = useraction.RequestState == IstructionState.Success;
            noNumber = Usernumbers.Count() == 0;
        }


        public void FindUser()
        {
            string Filter = "";/*textbox for resarch*/
            if (string.IsNullOrWhiteSpace(Filter))
            {
                IEnumerable<UserNumber> FilteredUser = from user in Usernumbers
                                                       where user.FullName.Contains(Filter)
                                                       select user;

                Usernumbers = FilteredUser;
            }
            hideLoading = true;
            noNumber = Usernumbers.Count() == 0;
            //implment the resarch
        }
        public async Task ClearSearchBar()
        {
            hideLoading = false;
            await LoadData();
        }



    }
}
