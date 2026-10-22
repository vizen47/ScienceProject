using UnityEngine;

namespace KDH.Scripts.Sounds
{
    [CreateAssetMenu(fileName = "SFXSoundData", menuName = "SO/KDH/SFXSoundData")]
    public class SFXDataSO : ScriptableObject
    {
        public AudioClip audioClip;
        public float startTime;
        public bool randomPitch;
        public bool loop;
        [Range(0f, 1f)] public float volume = 1f;
        [Range(-3f, 3f)]public float minPitch;
        [Range(-3f, 3f)]public float maxPitch;
    }
}
