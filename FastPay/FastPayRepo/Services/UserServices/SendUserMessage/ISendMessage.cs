using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPayRepo.Services.UserServices.SendUserMessage
{
    public interface ISendMessage
    {
        Task<bool> SendMessage(string code, ApplicationUser applicationUser);
    }
}
