using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;
using Newtonsoft.Json;
using TimbresIP.Model;

namespace TimbresIP.Utils
{   /// <summary>
    /// Envio de correo electrónico    
    /// </summary>
    class SendMailUtils : BaseUtils
    {
        /// <summary>
        /// Campo hacia quien va dirigido el mail
        /// </summary>
        private string toMail { get; set; }
        /// <summary>
        /// Campo con el asunto del mensaje de correo
        /// </summary>
        private string subjectMail { get; set; }
        /// <summary>
        /// Cuerpo del mensaje
        /// </summary>
        private string bodyMail { get; set; }
        /// <summary>
        /// Instancia de la clase System.Net.Mail
        /// </summary>
        private MailMessage eMail { get; set; }

        /// <summary>
        /// Enviar Mail con parametros establecidos
        /// </summary>
        public bool sendMail()
        {
            FeaturesUtils featuresUtils = new FeaturesUtils();
            FeaturesModel featuresModel = new FeaturesModel();
            ConfigurationParametersModel configurationParametersModel = new ConfigurationParametersModel();
            var jsonfeaturesModel = JsonConvert.SerializeObject(featuresModel, Formatting.Indented);

            toMail = "noslendecub@gmail.com";
            subjectMail = "Nueva instalación de AdminHorarios";
            bodyMail = "Estimado usuario se ha realizado una nueva instalacion del sistema en un cliente con las siguietes características: " + jsonfeaturesModel;

            eMail = new MailMessage();
            eMail.To.Add(new MailAddress(toMail));
            eMail.From = new MailAddress("nmperez88@outlook.com");
            eMail.Subject = subjectMail;
            eMail.Body = bodyMail;
            eMail.IsBodyHtml = false;

            SmtpClient client = new SmtpClient("smtp.live.com", 587);
            using (client)
            {
                try
                {
                    client.Credentials = new System.Net.NetworkCredential("nmperez88@outlook.com", "@divinala");
                    client.EnableSsl = true;
                    client.Send(eMail);

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
