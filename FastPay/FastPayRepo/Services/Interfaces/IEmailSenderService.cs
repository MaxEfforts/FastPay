using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPayRepo.Services.Interfaces
{
    public interface IEmailSenderService
    {
        void SendEmail(List<string> to, string subject, string body, string hostname = null);
        void SendEmail(string to, string subject, string body, string hostname = null);

        Task<Result> SendEmailAsync(string email, string subject, string body);
    }
}
