using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameMagaer
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _SFXSource;

        [SerializeField] private AudioClip _backgroundAudioClip;
        public List<AudioClip> _audioSFXClipList;

        private void Start()
        {
            _musicSource.clip = _backgroundAudioClip;
            _musicSource.Play();
        }

        public void SFXPlay(AudioClip clip)
        {
            _SFXSource.PlayOneShot(clip);
        }
    }
}
