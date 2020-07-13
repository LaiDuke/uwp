using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class Sound
    {
        public string Name { get; set; }
        public SoundCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }
        public Sound()
        {

        }
        public Sound(string name, SoundCategory category)
        {
            Name = name;
            Category = category;
            AudioFile = string.Format($"ms-appx:///Assets/Audio/{category}/{name}.wav");
            ImageFile = string.Format($"ms-appx:///Assets/Images/{category}/{name}.png");
        }
    }
}
