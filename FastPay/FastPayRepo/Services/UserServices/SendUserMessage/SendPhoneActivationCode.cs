using Microsoft.Extensions.Logging;

namespace FastPayRepo.Services.UserServices.SendUserMessage
{
    public class SendPhoneActivationCode : ISendMessage
    {
        private new readonly IMailService _mailService;
        private new readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public SendPhoneActivationCode(IMailService mailService, ILogger logger, IUnitOfWork unitOfWork)
        {
            this._mailService = mailService;
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }
        public async Task<bool> SendMessage(string code, ApplicationUser applicationUser)
        {


            ActivationCode activationCodeModel = new ActivationCode()
            {
                IsPublished = true,
                CreatedOnUtc = DateTime.Now,
                Code = code,
                UserId = applicationUser.Id,
                CodeType = "phone" //mail or phone
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