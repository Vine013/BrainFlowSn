using System.Net;
using System.Net.Mail;

namespace BrainFlow.UI.Web.Helpers
{
    public class EmailSender
    {
        #region Repositorios
        private readonly IConfiguration _configuration;
        #endregion

        #region Construtor
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region SendEmailAsync
        /// <summary>
        /// Envia um e-mail de forma assíncrona usando as configurações do appsettings.json
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<bool> SendEmailAsync(string toEmail, string subject, string message)
        {
            try
            {
                // Obter as configurações do appsettings.json
                var senderEmail = _configuration.GetSection("EmailSettings:SenderEmail").Value;
                var senderPassword = _configuration.GetSection("EmailSettings:SenderPassword").Value;
                var smtpServer = _configuration.GetSection("EmailSettings:SmtpServer").Value;
                var smtpPort = _configuration.GetSection("EmailSettings:SmtpPort").Value;

                var fromAddress = new MailAddress(senderEmail);
                var toAddress = new MailAddress(toEmail);

                var smtp = new SmtpClient
                {
                    Host = smtpServer,
                    Port = int.Parse(smtpPort),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, senderPassword)
                };

                using (var msg = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                })
                {
                    await smtp.SendMailAsync(msg);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
                return false;
            }
        }
        #endregion
    }
}
