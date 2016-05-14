using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Vippen.Services
{
    public interface IRasParserService
    {
        List<string> ParsePbk();
    }
    public class RasParserService : IRasParserService 
    {
        readonly string _pbkPath;
        public RasParserService()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _pbkPath = Path.Combine(appDataPath, @"Microsoft\Network\Connections\Pbk\rasphone.pbk");
        }

        public List<string> ParsePbk()
        {
            var rx = new Regex(@"\[(.+?)\]");
            string fileAsString;
            using (var reader = new StreamReader(_pbkPath))
                fileAsString = reader.ReadToEnd();
            return rx.Matches(fileAsString)
                .Cast<Match>()
                .SelectMany(m =>
                    m.Groups.Cast<Capture>()
                        .Skip(1)
                        .Select(c => c.Value))
                        .ToList();
        }
    }
}
