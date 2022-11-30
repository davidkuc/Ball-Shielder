using UnityEngine;
using UnityEngine.Audio;

namespace BallShielder
{
    public class AudioManager : Debuggable
    {
        [SerializeField] private AudioMixer audioMixer;
        private AudioSource gameMusic;
        private AudioSource sfx_AudioSource;
        private bool soundActivated;

        public bool SoundActivated => soundActivated;

        public AudioSource SFX_AudioSource => sfx_AudioSource;

        private void Awake()
        {
            gameMusic = transform.Find("music").GetComponent<AudioSource>();
            sfx_AudioSource = transform.Find("sfx").GetComponent<AudioSource>();
        }

        private void Start() => gameMusic.Play();
    }
}
