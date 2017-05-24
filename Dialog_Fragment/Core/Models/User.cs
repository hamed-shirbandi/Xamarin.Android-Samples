using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
   public class User : EventArgs
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public bool IsLogin { get; set; }
    }
}
