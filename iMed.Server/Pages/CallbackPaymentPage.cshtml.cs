using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace iMed.Server.Pages
{
    public class CallbackPaymentPageModel : PageModel
    {
        public bool Successful { get; private set; }
        public void OnGet(bool successful)
        {
            Successful = successful;
        }
    }
}
