using System;

namespace TimbresIP.Utils
{
    class FileHandlerUtils : BaseUtils
    {

        /*
         * Crear directorio vacío
         * 
         */
        public static void CreateEmptyDirectory(string fullPath)
        {
            if (!System.IO.Directory.Exists(fullPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(fullPath);
                }
                catch (Exception e)
                {
                    log.Error(e);
                }
            }
        }

        /*
         * Borrar un archivo
         * 
         */
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

        /*
         * Copiar archivo
         * 
         */
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
