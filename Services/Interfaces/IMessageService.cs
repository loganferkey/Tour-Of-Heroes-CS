namespace TOHFerkey.Services.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<string> Messages { get; }
        void Add(string message);
        void Clear();
    }
}
