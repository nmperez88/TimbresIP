using System;

namespace TimbresIP.Model
{
    /// <summary>
    /// Llamada al servidor para horario.
    /// </summary>
    class CallServerModel
    {
        /// <summary>
        /// Número en la lista.
        /// </summary>
        public String number { get; set; }

        /// <summary>
        /// Hora de inicio.
        /// </summary>
        public String startAt { get; set; }

        /// <summary>
        /// Tiempo que debe durar la llamada.
        /// </summary>
        private String callTime { get; set; }

        /// <summary>
        /// Archivo de sonido.
        /// </summary>
        public SoundFileModel soundFile { get; set; }

        /// <summary>
        /// Habilitado.
        /// </summary>
        public Boolean enabled { get; set; }

        /// <summary>
        /// Extensión a llamar. Generalmente es la extensión telefónica. numberToDial.
        /// </summary>
        public String registerName { get; set; }

        /// <summary>
        /// Observaciones.
        /// </summary>
        public String observations { get; set; }

    }
}
