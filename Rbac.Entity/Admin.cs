using System;

namespace Rbac.Entity
{
    public class Admin : BaseModel<int>
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginTime { get; set; }
    }
}
