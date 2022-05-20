using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPayRepo.Services.UserServices.SendUserMessage
{
    public class Notification
    {
        private ISendMessage _sendMessage;
        public Notification(ISendMessage sendMessage)
        {
            _sendMessage = sendMessage;
        }

        public async Task<bool> SendActivationCode(string code, ApplicationUser applicationUser)
        {
            return await _sendMessage.SendMessage(code, applicationUser);
        }
    }
}
