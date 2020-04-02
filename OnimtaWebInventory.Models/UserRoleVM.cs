using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public class UserRoleVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string pageNameList { get; set; }
        public int CompanyId { get; set; }
        public string UserRoleName { get; set; }
        public string pageIdList { get; set; }
        public int CreatedUserId { get; set; }
        public string  PrivilegesId { get; set; }
        public int LastCreatedUserId { get; set; }
        //public IEnumerable<UserRoleVm> userRoles { get; set; }
    }

    public class ModuleVM
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public int Module { get; set; }
        public IEnumerable<ModuleVM> Actions { get; set; }
        public Boolean Allow { get; set; }
    }

    public class UserRoleVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModuleId { get; set; }
        public bool Allow { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedUser { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int LastModifiedUserId { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public IEnumerable<ModuleVM> Permissions { get; set; }

    }
}
