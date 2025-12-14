using Avalonia.Media.Imaging;

namespace AvaloniaGuideApp.Models
{
    public class PageModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Bitmap Icon { get; set; }
        public PagesEnum Page { get; set; }
       
    }
}
