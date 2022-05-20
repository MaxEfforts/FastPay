using FastPayDB.Models.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPayRepo.Services.UserServices.SendUserMessage
{
    public class SendMailActivationCode : ISendMessage
    {
        private new readonly IMailService _mailService;
        private new readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public SendMailActivationCode(IMailService mailService, ILogger logger, IUnitOfWork unitOfWork)
        {
            this._mailService = mailService;
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }
        public async Task<bool> SendMessage(string code, ApplicationUser applicationUser)
        {
            //try
            //{
            //    await _mailService.SendEmailAsync(new MailRequest()
            //    {
            //        Subject = "Email Activation",
            //        Body = "Please use this code " + code + " to active your account.",
            //        ToEmail = applicationUser.Email!
            //    }).ConfigureAwait(false);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    _logger.LogError(e, "{Repo} Register send email error", typeof(UserServices));
            //}

            ActivationCode activationCodeModel = new ActivationCode()
            {
                IsPublished = true,
                CreatedOnUtc = DateTime.Now,
                Code = code,
                UserId = applicationUser.Id,
                CodeType = "email" //mail or phone
            };
            await _unitOfWork.ActivationCodeRepository.SaveActivationCode(activationCodeModel);
            int iCount = await _unitOfWork.CompleteAsync();
            if (iCount != 1)
            {
                return false;
            }
            return true;

        }
    }
}
