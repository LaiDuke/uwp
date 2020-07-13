using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Repository
{
    public class SoundManager
    {
        private static List<Sound> GetSounds()
        {
            return new List<Sound>()
            {
                new Sound("Cat", SoundCategory.Animals),
                new Sound("Cow", SoundCategory.Animals),
                new Sound("Cat", SoundCategory.Animals),
                new Sound("Gun", SoundCategory.Cartoon), 
                new Sound("Spring", SoundCategory.Cartoon),
                new Sound("Clock", SoundCategory.Taunts), 
                new Sound("LOL", SoundCategory.Taunts),
                new Sound("Ship", SoundCategory.Warnings),
                new Sound("Siren", SoundCategory.Warnings),

        };
        }
        public static void GetAllSounds(ObservableCollection<Sound> sounds)
        {
            var allsounds = GetSounds();
            sounds.Clear();
            allsounds.ForEach(x => sounds.Add(x));
        }
        public static void GetSoundByCategory(ObservableCollection<Sound> sounds, SoundCategory soundCategory)
        {
            var allsounds = GetSounds();
            var GetSoundCate = allsounds.Where(x => x.Category == soundCategory).ToList();
            sounds.Clear();
            allsounds.ForEach(x => sounds.Add(x));
        }
    }
}
