using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCartaBEPrj.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCartaBE.Services
{
    public interface IUserService
    {
        bool IsValidUserCredentials(string userName, string password, BDeCarta context);
        bool IsValidEmpleadoUserCredentials(string userName, string password, BDeCarta context);
        bool IsValidUserCredentialsEmpleados(string userName, string password, BDeCarta context);
    }

    public class UserService : IUserService
    {

        public UserService()
        {
        }

        public bool IsValidUserCredentials(string userName, string password, BDeCarta context)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            Dictionary<string, string> keyValuePairs = context.Encargados
                .Select(t => new { t.Dni, t.Pass })
                .ToDictionary(t => t.Dni, t => t.Pass);

            return keyValuePairs.TryGetValue(userName, out var p) && BCrypt.Net.BCrypt.Verify(password,p);

        }
        public bool IsValidUserCredentialsEmpleados(string userName, string password, BDeCarta context)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            Dictionary<string, string> keyValuePairs = context.Empleados
                .Select(t => new { t.Dni, t.Pass })
                .ToDictionary(t => t.Dni, t => t.Pass);

            return keyValuePairs.TryGetValue(userName, out var p) && BCrypt.Net.BCrypt.Verify(password, p);

        }
        public bool IsValidEmpleadoUserCredentials(string userName, string password, BDeCarta context)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            Dictionary<string, string> keyValuePairs = context.Empleados
                .Select(t => new { t.Dni, t.Pass })
                .ToDictionary(t => t.Dni, t => t.Pass);

            return keyValuePairs.TryGetValue(userName, out var p) && BCrypt.Net.BCrypt.Verify(password,p);

        }

    }

}
