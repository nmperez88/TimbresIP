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
        /// Origen del correo.
        /// </summary>
        private MailAddress from = new MailAddress("nmperez88@outlook.com");

        /// <summary>
        /// Destino(s) del correo.
        /// </summary>
        private List<MailAddress> toCollection { get; set; } = new List<MailAddress>() { new MailAddress("noslendecub@gmail.com"), new MailAddress("rolypompa@emailn.de") };

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
        private SmtpClient smtpClient = new SmtpClient("smtp.live.com", 587);

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
                    smtpClient.Credentials = new System.Net.NetworkCredential("nmperez88@outlook.com", "@divinala");
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
