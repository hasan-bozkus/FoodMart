using AutoMapper.Internal;
using FoodMart.DtoLayer.Dtos.MailDtos;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.DataAccessLayer.ExternalProcess
{
    public class SendEmailProcess
    {
        public async Task<string> SendEmailAsync(CreateSendEmailDto createSendEmailDto)
        {
            if(string.IsNullOrWhiteSpace(createSendEmailDto.ReceiverEmail))
            {
                return "ReceiverMail, E-posta adresi boş olamaz.";
            }

            var mimeMessage = new MimeMessage();

            var mailBoxAddressFrom = new MailboxAddress("Food Mart Admin", "denememardin0147@gmail.com");
            mimeMessage.From.Add(mailBoxAddressFrom);

            var mailBoxAddressTo = new MailboxAddress(createSendEmailDto.Name ?? "", createSendEmailDto.ReceiverEmail);
            mimeMessage.To.Add(mailBoxAddressTo);

            mimeMessage.Subject = "Tebrikler! %25 İndirim Kodu Kazandınız";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $@"
				<div style='font-family: Verdana, Geneva, Tahoma, sans-serif; line-height: 1.5; color: #333;'>
					<h1 style='color: #28a745;'>Tebrikler, {createSendEmailDto.Name}!</h1>
					<p>Size özel <strong>%25 indirim kuponu</strong> kazandınız!</p>
					<p>Bu fırsatı ilk siparişinizde kullanarak büyük avantaj sağlayabilirsiniz:</p>
					<div style='padding: 12px; background-color: #e9ecef; border-radius: 5px; display: inline-block;'>
						<strong style='font-size: 22px; letter-spacing: 2px;'>INDIRIM25</strong>
					</div>
					<p>Hemen alışverişe başlamak için web sitemizi ziyaret edin</a>.</p>
					<p>Keyifli alışverişler dileriz!<br><strong>FoodMart Ekibi</strong></p>
				</div>"

            };

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync("smtp.gmail.com", 587, false);
            await smtpClient.AuthenticateAsync("denememardin0147@gmail.com", "apmetyokiyxtdvwm");
            await smtpClient.SendAsync(mimeMessage);
            await smtpClient.DisconnectAsync(true);

            return "Mail başarıyla gönderildi.";
        }
    }
}
