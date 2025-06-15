using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppApuntesCamilySolorzano.Models
{
    internal class About
    {
        public string Title => "Camily Solorzano";
        public string Version => AppInfo.VersionString;
        public string MoreInfoUrl => "https://aka.ms/maui";
        public string Message => "Me llamo Camily y me gustan los gatos";
        public string Image => "imagenrepresentativa.jpeg";
    }
}
