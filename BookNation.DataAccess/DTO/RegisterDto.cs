using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNation.DataAccess.DTO
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string Password { get; set; }
    }
}
