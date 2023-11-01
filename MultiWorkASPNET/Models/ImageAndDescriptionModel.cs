using Microsoft.AspNetCore.Http;

namespace MultiWorkASPNET.Models
{
    public class ImageAndDescriptionModel
    {
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public byte[] ImageData { get; set; }
    }
}
