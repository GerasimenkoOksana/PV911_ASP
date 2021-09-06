using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAjax.Data.Entities
{
    // Добавление к сущности пользователь новых полей и связей
    public class ProjectUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Анатациями (атрибутами) выставляю параметры
        public string Avatar { get; set; }
    }
}
