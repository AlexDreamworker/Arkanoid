using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
	public class SettingsWindow : MonoBehaviour
	{
		[SerializeField] private AudioButton _sound;
		[SerializeField] private AudioButton _music;

		private void OnEnable()
		{
			_music.SetState(AudioController.Audio.GetMusicValue());
			_sound.SetState(AudioController.Audio.GetSoundValue());
		}

		public void ChangeSound()
		{
			AudioController.Audio.ChargeSound();
		}

		public void ChangeMusic()
		{
			AudioController.Audio.ChargeMusic();
		}

		public void ClearProgress() 
		{
			LevelIndex levelIndex = new LevelIndex();
			levelIndex.Clear();
			LevelsData levelsData = new LevelsData();
			levelsData.Clear();
			Loader loader = new Loader();
			loader.LoadingMainScene(true);
		}
	}
}

