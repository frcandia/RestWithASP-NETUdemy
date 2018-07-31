using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Model.Base;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy.Data.VO
{
    // ReSharper disable once InconsistentNaming
    public class UserVO 
    {
        public string Login { get; set; }
        public string AccessKey { get; set; }
    }
}
