using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimbresIP.Model
{
    /// <summary>
    /// Archivo de sonido utilizado en los tonos de llamada del horario.
    /// </summary>
    class SoundFileModel
    {
        /// <summary>
        /// Nombre.
        /// </summary>
        public String name { get; set; }

        /// <summary>

        /// Identificador
        /// Nombre de archivo en el directorio destino.
        /// </summary>
        /// <remarks>
        /// Valor: horary.randomId+"t"+pos(En: CallServerList)+".extensionDeArchivo(Ej: .mp3, .wav)". 
        /// Ej: h1t1.mp3.
        /// </remarks>

        public String randomId { get; set; }

        /// <summary>
        /// Ruta origen o fuente.
        /// </summary>
        public String sourcePath { get; set; }

        /// <summary>
        /// Ruta destino.
        /// </summary>
        public String targetPath { get; set; }


        /// <summary>
        /// Ruta a directorio origen o fuente.
        /// </summary>
        public String sourceDirPath { get; set; }

        /// <summary>
        /// Ruta a directorio destino.
        /// </summary>
        public String targetDirPath { get; set; }
    }
}
