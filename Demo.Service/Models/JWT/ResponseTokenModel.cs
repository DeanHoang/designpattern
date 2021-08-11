using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Models.JWT
{
    public class ResponseTokenModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Scope { get; set; }
    }
}
