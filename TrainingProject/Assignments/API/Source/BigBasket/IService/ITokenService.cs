using BigBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBasket.IService
{
    public interface ITokenService
    {
        string CreateToken(User user); //JWT are simply a String
        string CreateToken(Admin user);
    }
}

