using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace iMed.Server.Pages
{
    public class IndexModel : PageModel
    {
        public string Version { get; set; } = typeof(Program).Assembly.GetName().Version.ToString();
        public void OnGet()
        {
        }
    }
}
