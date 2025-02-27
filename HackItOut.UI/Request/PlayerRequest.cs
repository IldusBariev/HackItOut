using System.ComponentModel.DataAnnotations;

namespace HackItOut.UI.Request
{
    public class PlayerRequest
    {
        [Required(ErrorMessage = "Это поле обязательно")]
        public string FullName {  get; set; }
        [Required(ErrorMessage = "Это поле обязательно")]
        public string PhoneNumber {  get; set; }
        [Required(ErrorMessage = "Это поле обязательно")]
        public string Email {  get; set; }
    }
}
