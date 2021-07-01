
using Domain.Models;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
