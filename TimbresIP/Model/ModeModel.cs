using System;

namespace TimbresIP.Model
{
    /// <summary>
    /// Modo de ejecución. Llamada o jack audio 3.5
    /// </summary>
    class ModeModel : BaseModel
    {
        /// <summary>
        /// Nombre para mostrar.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Valor.
        /// </summary>
        public String value { get; set; }

        public ModeModel(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
