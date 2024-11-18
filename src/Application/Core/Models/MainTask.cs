using System.ComponentModel.DataAnnotations;

namespace WEBAPITEST.src.Application.Core.Models
{
    public class MainTask
    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedUserId { get; set; }
        public string Status { get; set; }
    }
}
