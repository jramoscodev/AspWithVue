using CommonDomain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.LoginServices
{
    public interface ILoginServices
    {
        bool Login(LoginViewModel source); // TODO: esto es un ejemplo el login debe retornar otras cosas, un objeto con mas datos
    }
}
