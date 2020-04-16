using GiaSuSystem.Models.Subjects;
using GiaSuSystem.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.MMTables
{
    public class UserModelRequestSubject
    {
        [MaxLength(450), Required]
        public string UserId { get; set; }
        public UserModel User { get; set; }

        public int RequestId { get; set; }
        public RequestSubject Request { get; set; }
    }
}
