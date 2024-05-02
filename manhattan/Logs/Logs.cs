using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace manhattan.Logs
{
    public class Logs
    {

        public static void LogSinConexion(string log)
        {
            if (Directory.Exists(Bodys.folderPatchAño))
            {

                if (File.Exists(Bodys.pathArchivoDia))
                {
                    File.AppendAllText(Bodys.pathArchivoDia, "\n" + "\t" + Convert.ToString(DateTime.Now) + "\t" + log);
                    //if (!funcionCorreo(Globals.log))
                    //{
                    //    File.AppendAllText(Globals.pathArchivoDia, "\n" + "\t" + Convert.ToString(DateTime.Now) + "\t" + "Falla en correo");
                    //}
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(Bodys.pathArchivoDia))
                    {
                        sw.WriteLine("\n" + "\t" + Convert.ToString(DateTime.Now) + "\t" + log);
                        //if (!funcionCorreo(Globals.log))
                        //{
                        //    sw.WriteLine("\n" + "\t" + Convert.ToString(DateTime.Now) + "\t" + "Falla en correo");
                        //}
                    }
                }

            }
            else
            {
                Directory.CreateDirectory(Bodys.folderPatchAño);
                using (StreamWriter sw = File.CreateText(Bodys.pathArchivoDia))
                {
                    sw.WriteLine("\n" + "\t" + Convert.ToString(DateTime.Now) + "\t" + log);
                    //if (!funcionCorreo(Globals.log))
                    //{
                    //    sw.WriteLine("\n" + "\t" + Convert.ToString(DateTime.Now) + "\t" + "Falla en correo");
                    //}
                }
            }//Fin de else principal
        }

    }
}