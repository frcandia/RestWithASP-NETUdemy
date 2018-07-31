using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Data.Conveter;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Data.Converters
{
    public class UserConverter : IParser<User, UserVO>
    {
        public UserVO Parse(User origin)
        {
            if (origin == null)
                return new UserVO();

            return new UserVO()
            {
                Login = origin.Login,
                AccessKey = origin.AccessKey
            };
        }

        public List<UserVO> ParseList(List<User> origin)
        {
            if (origin == null)
                return new List<UserVO>();

            return origin.Select(Parse).ToList();
        }
    }
}
