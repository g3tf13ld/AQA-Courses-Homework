using System;
using System.IO;
using System.Reflection;

namespace Homework5.Utils
{
    public class JsonReader
    {
        public readonly string _Filename = "appsettings.json";
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /*
            public JsonReader(string filename)
            {
                this.filename = filename;
            }
        */
        
        
        public string ReadFile()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPathToFile = $"{basePath}{Path.DirectorySeparatorChar}{_Filename}";

            try
            {
                var streamReader = new StreamReader(fullPathToFile);
                return streamReader.ReadToEnd();
            }
            catch (DirectoryNotFoundException ex)
            {
                Logger.Error($"The Directory doesn't exist: {ex}");
                throw;
            }
            catch (FileNotFoundException ex)
            {
                Logger.Error($"The File doesn't exist: {ex}");
                throw;
            }
            catch (IOException ex)
            {
                Logger.Error($"The File can't be opened: {ex}");
                throw;
            }
        }
    }
}