/* =============================================================================
 * Class file `Convenience'
 * =============================================================================
 * 
 * Class author: Niji System
 * 
 * This class file exists for convenience.
 * To use this class file, place this class file inside of 
 *   $PROJECT/Niji.Conveniece/
 * and then add `using Niji.Convenience;` to your list of imported libraries, 
 * and then add `var convenience = new Convenience();` to your object declara-
 * tions.
 * 
 */

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Niji.Convenience {
    class Convenience {
        public string CreateFile(string projectNamespace, string filename, string extension) {
            // Determine directory separator depending on OS
            char separator = '\u3000';
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                separator = '\\';
            } else {
                separator = '/';
            }
            // Retrieve appdata directory
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // Create data directory
            string systemUser = Environment.UserName;
            string userDataDirectory = $@".{systemUser}.data";
            Directory.CreateDirectory($@"{appData}{separator}{userDataDirectory}");
            string dataDirectory = $@"{userDataDirectory}{separator}{projectNamespace}";
            Directory.CreateDirectory($@"{appData}{separator}{dataDirectory}");
            // Create the file
            var dateTime = new Convenience();
            string fileDateTime = dateTime.CurrentDateTime();
            string file = $@"{filename}_{fileDateTime}.{extension}";
            string generalTimeDate = dateTime.CurrentTimeDate();
            string header = $"\t\tFILE CREATED {generalTimeDate}\n\n";
            string path = $@"{appData}{separator}{dataDirectory}{separator}{file}";
            File.AppendAllText(path, header);
            return path;
        }
        public string CurrentDateTime(string timezone) {
            DateTime time = DateTime.Now;
            string format = "yyyyMMdd-HHmmss{timezone}";
            string currentTime = time.ToString(format);
            return currentTime;
        }
        public string CurrentTimeDate(string timezone) {
            DateTime time = DateTime.Now;
            string format = $"HH:mm:ss {timezone} yyyy/MM/dd";
            string currentTime = time.ToString(format);
            return currentTime;
        }
        public bool InputBoolean() {
            bool booleanState = Convert.ToBoolean(Console.ReadLine());
            return booleanState;
        }
        public char InputCharacter() {
            char character = Convert.ToChar(Console.ReadLine());
            return character;
        }
        public double InputDouble() {
            double doubleFloat = Convert.ToDouble(Console.ReadLine());
            return doubleFloat;
        }
        public int Input32BitInteger() {
            int int32 = Convert.ToInt32(Console.ReadLine());
            return int32;
        }
        public long Input64BitInteger() {
            long int64 = Convert.ToInt64(Console.ReadLine());
            return int64;
        }
    }
}
