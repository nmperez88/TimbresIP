﻿using System;

namespace TimbresIP.Model
{
    /*
     * Llamada al servidor para horario
     */
    class CallServer
    {
        /*
         * Número en la lista
         * 
         */
        private String number;

        /*
         * Hora de inicio
         * 
         */
        private String startAt;

        /*
         * Tiempo que debe durar la llamada
         * 
         */
        private String callTime;

        /*
         * Archivo de sonido
         * 
         */
        private SoundFile soundFile;

        /*
         * Habilitado
         * 
         */
        private Boolean enabled;

        /*
         * Extensión a llamar. Generalmente es la extensión telefónica. numberToDial
         * 
         */
        private String registerName;

        /*
         * Observaciones
         * 
         */
        private String observations;

    }
}
