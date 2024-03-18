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

        [SerializeField] private AudioClip _backgroundAudioClip;

        private void Start()
        {
            _musicSource.clip = _backgroundAudioClip;
            _musicSource.Play();
        }
    }
}
