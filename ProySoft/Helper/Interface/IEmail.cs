namespace ProySoft.Helper.Interface
{
    public interface IEmail
    {
        public Task SendEmailAsync(string email, string subject, string message);
        public Task SendEmailWithTemplateAsync(string ToEmail);
        public Task Execute(string subject, string message, string email);
    }
}
