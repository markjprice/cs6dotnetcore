using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch16_QuizWebApp.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
