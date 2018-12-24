using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ozeki.Media;
using Ozeki.VoIP;

namespace TimbresIP.Utils
{
    /// <summary>
    /// Gestionar conexión con el servidor.
    /// </summary>
    class SoftPhoneUtils
    {
        /// <summary>
        /// 
        /// </summary>
        static ISoftPhone softphone;
        static IPhoneLine phoneLine;
        static IPhoneCall call;
        static MediaConnector connector;
        static PhoneCallAudioSender mediaSender;
        static MP3StreamPlayback mp3Player;
    }
}
