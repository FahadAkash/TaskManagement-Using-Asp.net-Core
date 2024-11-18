using System.ComponentModel.DataAnnotations;
namespace WEBAPITEST.src.Application.Core.Models.StudentManagementSystemModels
{
    public class TaskModel
    {
        [Key]
        public int Id {  get; set; }    
        public string Title { get; set; }
        public string Description { get; set; } 
        public string AssignedUserId { get; set; }
        public User GetUser {  get; set; }
        public string Status { get; set; } = "Pending";




    }
}
