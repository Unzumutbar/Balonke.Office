using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using Unzumutbar.Extensions;
using Unzumutbar.Utilities;

namespace Balonek.Office.Utils
{
    public class BalonekSoundPlayer
    {
        private BackgroundWorker musicPlayer;
        [DllImport("winmm.dll", SetLastError = true)]
        private static extern bool PlaySound(string pszSound, IntPtr hmod, int fdwSound);

        public BalonekSoundPlayer()
        {
            musicPlayer = new BackgroundWorker();
            musicPlayer.DoWork += new DoWorkEventHandler(playsecretSong_DoWork);
        }


        public void PlaySecretMusic()
        {
            musicPlayer.RunWorkerAsync();
        }

        private void playsecretSong_DoWork(object sender, DoWorkEventArgs e)
        {
            var tempDir = DirectoryExtension.CreateTempDirectory("ZosiasOffice");
            var sound = Path.Combine(tempDir, "secret.wav");
            ResourceUtilities.ExtractEmbeddedResource(sound, Properties.Resources.secret);
            PlaySound(sound, IntPtr.Zero, 0);
        }
    }
}
