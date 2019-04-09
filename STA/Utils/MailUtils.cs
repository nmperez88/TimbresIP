using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using STA.Model;

namespace STA.Utils
{   /// <summary>
    /// Envio de correo electrónico    
    /// </summary>
    class MailUtils : BaseUtils
    {

        /// <summary>
        /// Correo para enviar notificaciones
        /// </summary>
        //private static String emailFrom = "nmperez88@outlook.com";
        private static String emailFrom = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("Yml0ZGF0YS5zZW5kZXJAZ21haWwuY29t"));

        /// <summary>
        /// Clave del correo para enviar notificaciones
        /// </summary>
        //private static String emailPass = "@Divinala1";
        private static String emailPass = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("VGVhbUJpdGRhdGFTZW5kZXI="));

        /// <summary>
        /// Origen del correo.
        /// </summary>
        //private MailAddress from = new MailAddress("nmperez88@outlook.com");
        private MailAddress from = new MailAddress(emailFrom);

        /// <summary>
        /// Destino(s) del correo.
        /// </summary>
        private List<MailAddress> toCollection { get; set; } = new List<MailAddress>() { new MailAddress("bitdata.ec@gmail.com"), new MailAddress("bitdata.uy@gmail.com") };

        /// <summary>
        /// Campo con el asunto del mensaje de correo
        /// </summary>
        private string subject { get; set; } = "Nueva instalación de STA";

        /// <summary>
        /// Cuerpo del mensaje.
        /// </summary>
        private string body { get; set; } = "Estimado usuario se ha realizado una nueva instalacion del sistema en un cliente con las siguietes características: ";

        /// <summary>
        /// Instancia de la clase System.Net.Mail
        /// </summary>
        private MailMessage mailMessage { get; set; } = new MailMessage();

        /// <summary>
        /// 
        /// </summary>
        private FeaturesUtils featuresUtils = new FeaturesUtils();

        /// <summary>
        /// 
        /// </summary>
        private FeaturesModel featuresModel = new FeaturesModel();

        /// <summary>
        /// 
        /// </summary>
        private ConfigurationParametersModel configurationParametersModel = new ConfigurationParametersModel();

        /// <summary>
        /// SMTP Client.
        /// </summary>
        //private SmtpClient smtpClient = new SmtpClient("smtp.live.com", 587);
        //private SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 465);
        private SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

        /// <summary>
        /// Enviar Mail con parametros establecidos
        /// </summary>
        public bool send()
        {
            mailMessage.To.Clear();
            toCollection.ForEach(mailMessage.To.Add);
            mailMessage.From = from;
            mailMessage.Subject = subject;
            mailMessage.Body = String.Format(body + " {0}", JsonConvert.SerializeObject(featuresModel, Formatting.Indented));
            mailMessage.IsBodyHtml = false;

            using (smtpClient)
            {
                try
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential(emailFrom, emailPass);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mailMessage);

                    configurationParametersModel.sendedEMail = true;
                    return true;
                }
                catch (Exception e)
                {
                    BaseUtils.log.Error(e);
                    return false;
                }
            }
        }

    }
}
