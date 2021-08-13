using System.ComponentModel.DataAnnotations;

namespace Nam.Test.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}