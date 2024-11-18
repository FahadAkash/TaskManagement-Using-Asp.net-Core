using Microsoft.AspNetCore.Identity;

namespace WEBAPITEST.src.Application.Core.Models.StudentManagementSystemModels
{
    public class User : IdentityUser
    {
        public ICollection<TaskModel> taskModels { get; set; }   

    }
}
