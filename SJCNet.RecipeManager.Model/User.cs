using SJCNet.RecipeManager.Model.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Model
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }
    }
}
