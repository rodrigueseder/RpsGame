
namespace RpsGame.Api.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class SinglePlayerMatchRequest
    {
        [Required]
        public string Player1Name { get; set; }
        
        [Required]
        public string Player1Weapon { get; set; }
    }
}