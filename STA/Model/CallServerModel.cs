﻿using System;
using System.Collections.Generic;

namespace STA.Model
{
    /// <summary>
    /// Llamada al servidor para horario.
    /// </summary>
    class CallServerModel : BaseModel
    {

        /// <summary>
        /// Identificador para el grupo para llamadas al servidor.
        /// </summary>
        private String idGroup { get; set; } = "cs";

        /// <summary>
        /// Identificador.
        /// </summary>
        /// <remarks>
        /// Sintaxis: "cs"+startId. A startId debe autoincrementarse previamente.
        /// </remarks>
        public String randomId { get; set; }

        /// <summary>
        /// Número.
        /// </summary>
        public int no { get; set; }

        /// <summary>
        /// Hora de inicio.
        /// </summary>
        public String startAt { get; set; }

        /// <summary>
        /// Tiempo que debe durar la llamada. En segundos.
        /// </summary>
        public int callTime { get; set; }

        /// <summary>
        /// Archivo de sonido.
        /// </summary>
        public SoundFileModel soundFile { get; set; }

        /// <summary>
        /// Habilitado.
        /// </summary>
        public Boolean enabled { get; set; }

        /// <summary>
        /// Extensión a llamar. numberToDial.
        /// </summary>
        public String registerName { get; set; }

        /// <summary>
        /// Observaciones.
        /// </summary>
        public String observations { get; set; }

        /// <summary>
        /// Modo de ejecución. Por defecto llamada softphone
        /// </summary>
        public ModeModel mode { get; set; } = new ModeModel("Llamada", "softphone");

        /// <summary>
        /// Constructor. Necesario para serialización.
        /// </summary>
        public CallServerModel()
        {
            this.randomId = idGroup + getStartId();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="no"></param>
        public CallServerModel(int no)
        {
            this.no = no;
            this.randomId = idGroup + getStartId();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="no"></param>
        /// <param name="startAt"></param>
        /// <param name="callTime"></param>
        /// <param name="soundFile"></param>
        /// <param name="enabled"></param>
        /// <param name="registerName"></param>
        /// <param name="observations"></param>
        public CallServerModel(int no, string startAt, int callTime, SoundFileModel soundFile, bool enabled, string registerName, string observations)
        {
            this.no = no;
            this.randomId = idGroup + getStartId();
            this.startAt = startAt;
            this.callTime = callTime;
            this.soundFile = soundFile;
            this.enabled = enabled;
            this.registerName = registerName;
            this.observations = observations;
        }
    }
}
