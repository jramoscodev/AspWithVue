using CommonDomain.ViewModels;
using DbEmployees.Entities;
using DbEmployees.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.LoginServices
{
    public class LoginServicesImpl : ILoginServices
    {
        private readonly IUserRepository _userRepository;

        public LoginServicesImpl()
        {
            _userRepository = new UserRepositoryImpl();
        }
        /*
         TODO:
          Este metodo solo es para explicar como usar el filtro del repositorio, 
          en el contructor de la clase se instancia la interface con la implementacion de esta
          esto corresponde al principio de Liskov(SOLID principles) esto permite reutilizar el codigo y ser agiles con la 
         creacion de querys
         */
        public bool Login(LoginViewModel source)
        {

            var resul = _userRepository.GetBy(x => x.UserName.ToLower() == source.UserName.ToLower() && x.Password == source.Password);

            if (resul == null) return false;

            return true;

        }
    }
}
