using SnowGame.Data;
using System.Collections.Generic;
using UnityEngine;

namespace SnowGame
{
    public class SoundManager : IService, ISoundManager
    {
        private bool _isMute;
        public bool IsMute 
        {
            get { return _isMute; }
            set
            {
                _isMute = value;
                UpdateMuteState();
            }
        }

        private List<SoundSource> _soundSources;

		private Transform _soundContainer;

		private float _soundVolume = 1f;

		public void Init()
		{
			_soundSources = new List<SoundSource>();
			IsMute = _soundVolume == 0;
			_soundContainer = new GameObject("[Sound Container]").transform;
			MonoBehaviour.DontDestroyOnLoad(_soundContainer);
		}

		public void Update()
		{
			if (_soundSources == null)
				return;

			if (_soundSources.Count > 0)
			{
				for (int i = 0; i < _soundSources.Count; i++)
				{
					if (_soundSources[i].IsSoundEnded())
					{
						_soundSources[i].Dispose();
						_soundSources.RemoveAt(i--);
					}
				}
			}
		}

		public void PlaySound(Enumerators.SoundType soundType, bool random = false, SoundParameters parameters = null)
        {
			string path = $"Sounds/{soundType}";
			AudioClip sound;

			sound = Resources.Load<AudioClip>(path);

			if (sound == null)
			{
				Debug.Log($"Sound by path: {path} not found");
				return;
			}

			SoundSource foundSameSource = _soundSources.Find(soundSource => soundSource.SoundType == soundType);

			if (foundSameSource != null)
			{
				foundSameSource.Dispose();
				_soundSources.Remove(foundSameSource);
			}

			if (parameters == null)
			{
				parameters = new SoundParameters()
				{
					Loop = false,
					Volume = 1f,
					AffectedVolume = 0f
				};
			}

			parameters.AffectedVolume = parameters.Volume * _soundVolume;

			_soundSources.Add(new SoundSource(_soundContainer, sound, soundType, parameters));
		}

        public void StopSound(Enumerators.SoundType soundType)
        {
			for (int i = 0; i < _soundSources.Count; i++)
			{
				if (_soundSources[i].SoundType == soundType)
				{
					_soundSources[i].Dispose();
					_soundSources.RemoveAt(i--);
				}
			}
		}

        public void UpdateSoundStatus()
        {
			foreach (var sound in _soundSources)
			{
				sound.AudioSource.mute = _isMute;
			}
		}

        private void UpdateMuteState()
        {
            foreach (var sound in _soundSources)
            {
                sound.AudioSource.mute = _isMute;
            }
        }

        public void Dispose()
        {
			if (_soundContainer != null)
			{
				MonoBehaviour.Destroy(_soundContainer.gameObject);
			}
		}
    }

	class SoundSource
	{
		public GameObject SoundSourceObject { get; }
		public AudioClip Sound { get; }
		public AudioSource AudioSource { get; }
		public Enumerators.SoundType SoundType { get; }
		public SoundParameters SoundParameters { get; }

		public SoundSource(Transform parent, AudioClip sound, Enumerators.SoundType soundType, SoundParameters parameters)
		{
			Sound = sound;
			SoundParameters = parameters;
			SoundType = soundType;

			SoundSourceObject = new GameObject($"[Sound] - {SoundType} - {Time.time}");
			SoundSourceObject.transform.SetParent(parent);
			AudioSource = SoundSourceObject.AddComponent<AudioSource>();
			AudioSource.clip = Sound;

			if (SoundParameters != null)
			{
				AudioSource.volume = SoundParameters.AffectedVolume;
				AudioSource.loop = SoundParameters.Loop;
			}

			AudioSource.Play();
		}

		public bool IsSoundEnded()
		{
			return !AudioSource.loop && !AudioSource.isPlaying;
		}

		public void Dispose()
		{
			AudioSource.Stop();
			MonoBehaviour.Destroy(SoundSourceObject);
		}
	}

	public class SoundParameters
	{
		public bool Loop { get; set; } = false;
		public float Volume { get; set; } = 1f;
		public float AffectedVolume { get; set; } = 1f;
	}
}

