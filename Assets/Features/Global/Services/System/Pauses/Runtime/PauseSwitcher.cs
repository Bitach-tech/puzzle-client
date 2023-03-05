using Global.Audio.Player.Runtime;
using Global.System.Updaters.Runtime.Abstract;

namespace Global.System.Pauses.Runtime
{
    public class PauseSwitcher : IPause
    {
        public PauseSwitcher(
            IUpdateSpeedSetter updateSpeedSetter,
            IVolumeSwitcher volumeSwitcher,
            SoundState state)
        {
            _updateSpeedSetter = updateSpeedSetter;
            _volumeSwitcher = volumeSwitcher;
            _state = state;
        }

        private readonly IUpdateSpeedSetter _updateSpeedSetter;
        private readonly IVolumeSwitcher _volumeSwitcher;
        private readonly SoundState _state;

        public void Pause()
        {
            _updateSpeedSetter.Pause();

            if (_state.IsMuted == false)
                _volumeSwitcher.Mute();
        }

        public void Continue()
        {
            _updateSpeedSetter.Continue();

            if (_state.IsMuted == false)
                _volumeSwitcher.Unmute();
        }
    }
}