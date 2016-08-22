using System.ComponentModel;
using System.IO;
using System.Media;
using Unzumutbar.OggPlayer.OggDecoder;

namespace Unzumutbar.OggPlayer
{
    public class OggPlayer
    {
        private BackgroundWorker _soundWorker;
        private string _audioFile;

        public OggPlayer()
        {
            _soundWorker = new BackgroundWorker();
            _soundWorker.DoWork += new DoWorkEventHandler(playSong_DoWork);
        }
        public void Play(string audiofile)
        {
            _audioFile = audiofile;
            if (string.IsNullOrEmpty(_audioFile))
                return;

            _soundWorker.RunWorkerAsync();
        }

        private void playSong_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var file = new FileStream(_audioFile, FileMode.Open, FileAccess.Read))
            {
                var player = new SoundPlayer(new OggDecodeStream(file));
                player.PlaySync();
            }
        }
    }
}
