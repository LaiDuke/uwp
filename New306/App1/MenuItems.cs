using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class MenuItems
    {

        public MenuItems(string iconFile, SoundCategory category)
        {
            this.IconFile = iconFile;
            this.Category = category;
        }

        public string IconFile { get; set; }
        public SoundCategory Category { get; set; }
    }
}
