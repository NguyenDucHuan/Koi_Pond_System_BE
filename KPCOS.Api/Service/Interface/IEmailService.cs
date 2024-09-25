using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPCOS.Api.Service.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body, bool isHtml = false);
    }
}