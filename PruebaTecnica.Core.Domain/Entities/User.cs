using PruebaTecnica.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Domain.Entities
{
    public class User : EntityBase<int>
    {
        public string UserName { get; set; }
        public byte[] PasswordHast { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
