using System;

namespace STA.Model
{
    /// <summary>
    /// Datos de conexión para hacer llamadas.
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

        /// <summary>
        /// Constructor. Necesario para serialización.
        /// </summary>
        public ConnectionCallServerModel()
        {
        }

        internal bool isValid()
        {
            //return userName != null && !userName.Equals("") && registerName != null && !registerName.Equals("") && registerPassword != null && !registerPassword.Equals("");
            return displayName != null && !displayName.Equals("") && userName != null && !userName.Equals("") && registerName != null && !registerName.Equals("") && registerPassword != null && !registerPassword.Equals("");
        }
    }
}
