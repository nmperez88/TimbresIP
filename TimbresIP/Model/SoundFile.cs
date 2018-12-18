using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimbresIP.Model
{
    /**
     * Archivo de sonido utilizado en los tonos de llamada del horario
     */
    class SoundFile
    {
        private String name;
        private String randomId;//nombre de archivo en el directorio destino. Valor: horary.randomId+"t"+pos(En: CallServerList)+".extensionDeArchivo(Ej: .mp3, .wav)". Ej: h1t1.mp3
        private String sourcePath;
        private String targetPath;
    }
}
