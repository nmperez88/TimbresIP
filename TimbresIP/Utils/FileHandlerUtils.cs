using System;

namespace TimbresIP.Utils
{
    /// <summary>
    /// Gestionar archivos.
    /// </summary>
    class FileHandlerUtils : BaseUtils
    {

        /// <summary>
        /// Crear directorio vacío.
        /// </summary>
        /// <param name="dirPath"></param>
        public static void CreateEmptyDirectory(string dirPath)
        {
            if (!System.IO.Directory.Exists(dirPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(dirPath);
                }
                catch (Exception e)
                {
                    log.Error(e);
                }
            }
        }

        /// <summary>
        /// Borrar un archivo.
        /// </summary>
        /// <param name="fullPath"></param>
        public static void DeleteFile(string fullPath)
        {
            if (System.IO.File.Exists(fullPath))
            {
                try
                {
                    System.IO.FileInfo info = new System.IO.FileInfo(fullPath);
                    info.Attributes = System.IO.FileAttributes.Normal;
                    System.IO.File.Delete(fullPath);
                }
                catch (Exception e)
                {
                    log.Error(e);
                }

            }
        }

        /// <summary>
        /// Copiar archivo.
        /// </summary>
        /// <param name="origPath"></param>
        /// <param name="destPath"></param>
        /// <param name="overwrite"></param>
        public static void CopyFile(string origPath, string destPath, bool overwrite)
        {
            try
            {
                if (System.IO.Path.GetExtension(destPath) == "")
                {
                    destPath = System.IO.Path.Combine(destPath, System.IO.Path.GetFileName(origPath));
                }
                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(destPath)))
                {
                    CreateEmptyDirectory(System.IO.Path.GetDirectoryName(destPath));
                }
                if (!System.IO.File.Exists(destPath))
                {
                    System.IO.File.Copy(origPath, destPath, true);
                }
                else
                {
                    if (overwrite == true)
                    {
                        DeleteFile(destPath);
                        System.IO.File.Copy(origPath, destPath, true);
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }
        }


    }
}
