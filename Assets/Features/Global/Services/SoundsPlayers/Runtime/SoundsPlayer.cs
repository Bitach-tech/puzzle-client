using UnityEngine;

namespace Global.Services.SoundsPlayers.Runtime
{
    [DisallowMultipleComponent]
    public class SoundsPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _musicSource;

        [SerializeField] private AudioSource[] _soundSources;

        public void SetVolume(float music, float sound)
        {
            _musicSource.volume = music;

            foreach (var source in _soundSources)
                source.volume = sound;
        }

        public void PlaySound(AudioClip clip)
        {
            foreach (var source in _soundSources)
            {
                if (source.isPlaying == true)
                    continue;

                source.clip = clip;
                source.Play();
            }

            _soundSources[0].clip = clip;
            _soundSources[0].Play();
        }

        public void PlayLoopMusic(AudioClip clip)
        {
            _musicSource.loop = true;
            _musicSource.clip = clip;
            _musicSource.Play();
        }
    }
}