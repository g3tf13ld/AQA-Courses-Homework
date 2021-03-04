using System;
using System.IO;
using System.Reflection;

namespace Homework5.Utils
{
    public class JsonReader
    {
        private readonly string _filename = "appsettings.json";
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /*
            public JsonReader(string filename)
            {
                this.filename = filename;
            }
        */

        public string ReadFile()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPathToFile = $"{basePath}{Path.DirectorySeparatorChar}{_filename}";

            try
            {
                var streamReader = new StreamReader(fullPathToFile);
                _logger.Info($"The file {fullPathToFile} read successfully.");
                return streamReader.ReadToEnd();
            }
            catch (DirectoryNotFoundException ex)
            {
                _logger.Error($"The Directory doesn't exist: {ex}");
                throw;
            }
            catch (FileNotFoundException ex)
            {
                _logger.Error($"The File doesn't exist: {ex}");
                throw;
            }
            catch (IOException ex)
            {
                _logger.Error($"The File can't be opened: {ex}");
                throw;
            }
        }
    }
}