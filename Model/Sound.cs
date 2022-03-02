using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Model
{
   public class Sound
    {
        public enum SoundCategory
        {
            Animals,
            Cartoons,
            Taunts,
            Warnings
        }
        public string Name { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }
        public SoundCategory Category { get; set; }

        public Sound(string name, SoundCategory category)
        {
            Name = Name;
            Category = category;
            AudioFile = $"/Assets/Audio/{category}/{name}.wav";
            ImageFile = $"/Assets/Images/{category}/{name}.png";
        }

    }
}
