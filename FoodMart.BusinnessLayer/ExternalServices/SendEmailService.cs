using FoodMart.DataAccessLayer.ExternalProcess;
using FoodMart.DtoLayer.Dtos.MailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.BusinnessLayer.ExternalServices
{
    public class SendEmailService
    {
        public async Task<string> SendEmailAsync(CreateSendEmailDto createSendEmailDto)
        {
            var sendEmailProcess = new SendEmailProcess();
            var values = await sendEmailProcess.SendEmailAsync(createSendEmailDto);
            return values;
        }
    }
}
