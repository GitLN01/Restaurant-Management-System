using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public static class UserSession
    {
        public static int Id { get; set; }
        public static string Name { get; private set; }
        public static string Email { get; private set; }

        public static void SetUser(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public static void ClearUser()
        {
            Id = 0;
            Name = string.Empty;
            Email = string.Empty;
        }
    }
}
