using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
	public class AudioController : MonoBehaviour
	{
		public static AudioController Audio = null;
		private AudioState _audioState;
		[SerializeField] private AudioSource _backgroundSource;

		private void Awake()
		{
			if (Audio == null)
			{
				Audio = this;
				DontDestroyOnLoad(gameObject);
				_audioState = new AudioState();
				if (_audioState.GetAudioValues().Music) 
				{
					_backgroundSource.Play();
				}
			}
			else 
			{
				Destroy(gameObject);
			}
		}

		public void ChargeMusic()
		{
			_audioState.EnableMusic(!_audioState.GetAudioValues().Music);

			if (_audioState.GetAudioValues().Music)
			{
				_backgroundSource.Play();
			}
			else 
			{
				_backgroundSource.Stop();
			}
		}

		public void ChargeSound() 
		{
			_audioState.EnableSound(!_audioState.GetAudioValues().Sound);
		}

		public bool GetSoundValue()
		{
			return _audioState.GetAudioValues().Sound;
		}

		public bool GetMusicValue()
		{
			return _audioState.GetAudioValues().Music;
		}
	}
}

