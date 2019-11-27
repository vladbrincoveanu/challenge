using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO.Compression;
using Exception = System.Exception;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.Directory.CreateDirectory(System.DateTime.Now.DayOfWeek.ToString());
            const string sourcePath = @"..\..\Images";
            const string path = "text.meta";
            var seed = (int) DateTime.Now.Day;
            var random = new Random(seed);

            if (Directory.Exists(sourcePath))
            {
                var files = ConfigurationManager.AppSettings.AllKeys;
                File.Delete(path);
                foreach (var key in files)
                {
                    var fileName = Path.GetFileName(ConfigurationManager.AppSettings[key]);
                    var destFile = Path.Combine(System.DateTime.Now.DayOfWeek.ToString(), fileName ?? throw new InvalidOperationException());
                    File.Copy(ConfigurationManager.AppSettings[key], destFile, true);
                    if (!File.Exists(path))
                    {
                        using (var txtFile = File.AppendText(path))
                        {
                            txtFile.WriteLine("ID        | Creation date   | Image route");
                        }
                    }
                    using (var txtFile = File.AppendText(path))
                    {
                        var dateToConvert = System.DateTime.Now;
                        var julianDate = $"{dateToConvert:yy}{dateToConvert.DayOfYear}";
                        var id = julianDate + random.Next(0, 99999).ToString("D5");
                        txtFile.WriteLine(id + "|" + dateToConvert.ToString("yyyy/MM/dd HH:MM:ss") + "|" + destFile);
                    }
                }
                File.Copy(path, Path.Combine(System.DateTime.Now.DayOfWeek.ToString(), path), true);
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

            var zipFilePath = System.DateTime.Now.ToString("yyyy_MM_dd_HH_MM_ss") + ".zip";

            if (File.Exists(zipFilePath))
            {
                File.Delete(zipFilePath);
                System.Threading.Thread.Sleep(20);
                ZipFile.CreateFromDirectory(System.DateTime.Now.DayOfWeek.ToString(), zipFilePath);
//                ZipFile.ExtractToDirectory(zipFilePath, @"ExtractedHere");
            }
            else
            {
                ZipFile.CreateFromDirectory(System.DateTime.Now.DayOfWeek.ToString(), zipFilePath);
//                ZipFile.ExtractToDirectory(zipFilePath, @"ExtractedHere");
            }
            
               
        }
    }
}
