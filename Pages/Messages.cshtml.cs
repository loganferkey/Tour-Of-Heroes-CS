using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TOHFerkey.Services.Interfaces;

namespace TOHFerkey.Pages
{
    public class MessagesModel : PageModel
    {
        private readonly IMessageService _messageService;
        public MessagesModel(IMessageService messageService)
        {
            this._messageService = messageService;
        }

        public List<string> Messages { get; set; } = new List<string>();

        public void OnGet(string? clear)
        {
            if (clear == "true")
                _messageService.Clear();
            this.Messages = _messageService.Messages.ToList();
        }
    }
}
