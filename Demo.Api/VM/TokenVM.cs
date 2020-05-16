using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Api.VM
{
    public class TokenVM
    {
        public string token { get; set; }
        public long expires_at { get; set; }
    }
}
