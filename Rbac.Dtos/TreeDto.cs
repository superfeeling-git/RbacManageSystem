using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Dtos
{
    public class TreeDto
    {
        public int value { get; set; }
        public string label { get; set; }
        public List<TreeDto> children { get; set; } = new List<TreeDto>();
    }
}
