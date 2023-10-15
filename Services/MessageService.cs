using TOHFerkey.Services.Interfaces;

namespace TOHFerkey.Services
{
    public class MessageService : IMessageService
    {
        private List<string> messages = new List<string>();
        public IEnumerable<string> Messages { get { return messages; } }
        public void Add(string message) { messages.Add(message); }
        public void Clear() { messages.Clear(); }
    }
}
