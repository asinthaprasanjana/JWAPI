using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public  class ApplicationUserVM
    {

        public int UserID { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public int Branch { get; set; }
        public int BranchID { get; set; }
        public string newPassword { get; set; }
        public string currentPassword { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NicNo { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime expirationDate { get; set; }
        public int MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DuplicateLogIn { get; set; }
        public string Token { get; set; }
        public IEnumerable< ApplicationPageVM> applicationPageVM { get; set; }
        public IEnumerable<MenuModel> menuModel { get; set; }




    }
}
