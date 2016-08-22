using System.IO;
using Unzumutbar.Extensions;
using Unzumutbar.OggPlayer;
using Unzumutbar.Utilities;

namespace Balonek.Office.Utils
{
    public class BalonekSoundPlayer
    {
        OggPlayer _player;
        public BalonekSoundPlayer()
        {
            _player = new OggPlayer();
        }

        public void PlaySecretMusic()
        {
            var tempDir = DirectoryExtension.CreateTempDirectory("ZosiasOffice");
            var sound = Path.Combine(tempDir, "secret.ogg");
            ResourceUtilities.ExtractEmbeddedResource(sound, Properties.Resources.secret);
            _player.Play(sound);
        }
    }
}
