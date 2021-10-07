using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Entity;
using Rbac.Dtos.Role;
using Rbac.Dtos.Admin;
using Rbac.Dtos.AdminRole;

namespace Rbac.WebAPI
{
    public class RbacProfile: Profile
    {
        public RbacProfile()
        {
            CreateMap<AdminDto, Admin>().ReverseMap();
            CreateMap<AdminRoleDto, AdminRole>().ReverseMap();
        }
    }
}
