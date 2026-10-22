using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace KDH.Scripts.Sounds
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instace;
        
        [SerializeField] private AudioSource sfxSource, bgmSource;
        [field: SerializeField] public BGMSoundDataSO BGM { get; private set; }

        void Awake()
        {
            Instace = this;
        }

        void Start()
        {
            PlayBGM(BGM);
        }
        
        public void PlaySound(SFXDataSO type)
        {
            if (sfxSource == null) return;

            sfxSource.pitch = 1;
            
            if (type.randomPitch)
                sfxSource.pitch = Random.Range(type.minPitch, type.maxPitch);

            sfxSource.volume = type.volume;
            sfxSource.loop = type.loop;
            sfxSource.clip = type.audioClip;
            sfxSource.time = type.startTime;
            sfxSource.Play();
        }

        public void PlayBGM(BGMSoundDataSO type)
        {
            if (bgmSource == null) return;

            bgmSource.pitch = 1;
            
            if (type.randomPitch)
                bgmSource.pitch = Random.Range(type.minPitch, type.maxPitch);
            
            bgmSource.volume = type.volume;
            bgmSource.loop = type.loop;
            bgmSource.clip = type.audioClip;
            bgmSource.time = type.startTime;
            bgmSource.Play();
        }
    }
}
