/// This code is personal and can't be used for commercial games.
/// Non-profit projects can use it with explicit permission and credits
/// 
/// Made by Manuel Rodríguez Matesanz.
/// You can contact me on GBATemp as Manurocker95, email: Manuelrodriguezmatesanz@gmail.com
/// or even on my web: Manuelrodriguezmatesanz.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PikachuMusicRun.Setup;
using PikachuMusicRun.Game;

namespace PikachuMusicRun
{
    /// <summary>
    /// AudioManager. Plays sounds :D
    /// </summary>
    public class PMR_AudioManager : PMR_SingletonMonobehaviour<PMR_AudioManager>
    {
        #region Variables
        [Header("AudioSources"), Space(10)]
        /// <summary>
        /// BGM Source - Changes between scenes
        /// </summary>
        [SerializeField] private AudioSource m_bgmSource;
        /// <summary>
        /// SFX Source - Plays SFX
        /// </summary>
        [SerializeField] private AudioSource m_sxfAudioSource;

        [Header("Clips"), Space(10)]
        /// <summary>
        /// SFX Source - Plays SFX
        /// </summary>
        [SerializeField] private AudioClip m_noteSFX;

        /// <summary>
        /// If we want to stop the music when pausing or not
        /// </summary>
        [SerializeField] private bool m_stopSourcesOnPause;
        /// <summary>
        /// Audio speed
        /// </summary>
        [SerializeField] private float m_audioSpeed = 0;
        /// <summary>
        /// properties
        /// </summary>
        public float AudioSpeed { get { return m_audioSpeed; } }
        public float BGMLength { get { return m_bgmSource.clip.length; } }
        #endregion

        #region Monobehaviour
        // Use this for initialization
        void Start()
        {
            
            StartAllListeners();
        }

        private void OnDestroy()
        {
            StopAllListeners();
        }
        #endregion

        void StartAllListeners()
        {
            PMR_EventManager.StartListening(PMR_EventSetup.Game.GO_TO_MENU, PlayMenuBGM);
            PMR_EventManager.StartListening(PMR_EventSetup.Game.PAUSE_GAME, CheckPause);
            PMR_EventManager.StartListening(PMR_EventSetup.Game.UNPAUSE_GAME, CheckUnPause);
        }


        void StopAllListeners()
        {
            if (PMR_EventManager.Instance)
            {
                PMR_EventManager.StopListening(PMR_EventSetup.Game.GO_TO_MENU, PlayMenuBGM);
                PMR_EventManager.StopListening(PMR_EventSetup.Game.PAUSE_GAME, CheckPause);
                PMR_EventManager.StopListening(PMR_EventSetup.Game.UNPAUSE_GAME, CheckUnPause);
            }
        }

        private void Update()
        {
        }

        public void StopBGM()
        {
            m_bgmSource.Stop();
        }

        public float[] SetBGMSpectrum(int samples, DIFICULTY difficulty)
        {
            float[] m_spectrumArray = new float[samples];
            m_bgmSource.GetSpectrumData(m_spectrumArray, 0, FFTWindow.Rectangular);

            int difficultyMultiplier = 0;

            switch (difficulty)
            {
                case DIFICULTY.EASY:
                    difficultyMultiplier = PMR_GameSetup.Dificulty_Velocities.EASY;
                    break;
                case DIFICULTY.MID:
                    difficultyMultiplier = PMR_GameSetup.Dificulty_Velocities.MID;
                    break;
                case DIFICULTY.DIFFICULT:
                    difficultyMultiplier = PMR_GameSetup.Dificulty_Velocities.DIFFICULT;
                    break;
            }


            m_audioSpeed = difficultyMultiplier; //(m_bgmSource.clip.length / samples) * difficultyMultiplier * m_bgmSource.pitch;

            return m_spectrumArray;
        }

        /// <summary>
        /// Check bgm music when going to pause
        /// </summary>
        void CheckPause()
        {
            if (m_bgmSource.isPlaying && m_stopSourcesOnPause)
                m_bgmSource.Stop();
        }
        /// <summary>
        /// Check music when unpausing the game
        /// </summary>
        void CheckUnPause()
        {
            if (m_stopSourcesOnPause)
            {
                m_bgmSource.Play();
            }
        }

        /// <summary>
        /// Play Game BGM when going to game scene
        /// </summary>
        public void PlayGameBGM()
        {
            m_bgmSource.loop = false;
            m_bgmSource.clip = Resources.Load<AudioClip>(PMR_AudioSetup.GAME_BGM);
            m_bgmSource.Play();
        }
        /// <summary>
        /// Play Menu BGM when going to menu scene
        /// </summary>
        public void PlayMenuBGM()
        {
            m_bgmSource.loop = true;
            m_bgmSource.clip = Resources.Load<AudioClip>(PMR_AudioSetup.MENU_BGM);
            m_bgmSource.Play();
        }

        public void PlayNoteSFX()
        {
            m_sxfAudioSource.PlayOneShot(m_noteSFX);
        }
    }

}
