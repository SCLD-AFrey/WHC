using System.ComponentModel.DataAnnotations;

namespace WHC.CommonLibrary.Models.UserInfo
{
    public class Role
    {
        public int Oid { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}