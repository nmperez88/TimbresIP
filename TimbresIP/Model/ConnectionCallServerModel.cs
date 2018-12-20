using System;

namespace TimbresIP.Model
{
    /// <summary>
    /// Llamada al servidor.
    /// </summary>
    class ConnectionCallServerModel
    {

        /// <summary>
        /// Nombre a mostrar. Generalmente es la extensión telefónica.
        /// </summary>
        public String displayName { get; set; }

        /// <summary>
        /// Nombre de usuario. Generalmente es la extensión telefónica.
        /// </summary>
        public String userName { get; set; }

        ///<summary>
        ///Extensión a llamar(authenticationId).
        ///</summary>
        public String registerName { get; set; }

        /// <summary>
        /// Clave, contraseña.
        /// </summary>
        public String registerPassword { get; set; }

    }
}
