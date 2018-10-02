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

namespace PikachuMusicRun.Game
{
    public class PMR_GameManager : PMR_SingletonMonobehaviour<PMR_GameManager>
    {
        [SerializeField] private int m_score;
        [SerializeField] private bool m_pause = false;
        [SerializeField] private DIFICULTY m_difficulty = DIFICULTY.DIFFICULT;
        [SerializeField] private int m_samples = 0;
        [SerializeField] private float[] m_samplesArray;

        public bool Paused { get { return m_pause; } }
        
        // Use this for initialization
        void Start()
        {
            StartAllListeners();
            switch (m_difficulty)
            {
                case DIFICULTY.EASY:
                    m_samples = PMR_GameSetup.Dificulty_Samples.EASY;
                    break;
                case DIFICULTY.MID:
                    m_samples = PMR_GameSetup.Dificulty_Samples.MID;
                    break;
                case DIFICULTY.DIFFICULT:
                    m_samples = PMR_GameSetup.Dificulty_Samples.DIFFICULT;
                    break;
            }
        }
        private void OnDestroy()
        {
            StopAllListeners();
        }

        void StartAllListeners()
        {
            PMR_EventManager.StartListening(PMR_EventSetup.Game.GO_TO_GAME, ResetGame);
        }


        void StopAllListeners()
        {
            if (PMR_EventManager.Instance)
                PMR_EventManager.StopListening(PMR_EventSetup.Game.PAUSE_GAME, ResetGame);
        }

        public void PauseAndUnpause()
        {
            m_pause = !m_pause;

            if (m_pause)
                PMR_EventManager.TriggerEvent(PMR_EventSetup.Game.PAUSE_GAME);
            else
                PMR_EventManager.TriggerEvent(PMR_EventSetup.Game.UNPAUSE_GAME);
        }

        public void ResetGame()
        {
            m_pause = false;
            m_score = 0;
            InitSpectrum();
        }

        public void InitSpectrum()
        {
            PMR_AudioManager.Instance.PlayGameBGM();

            m_samplesArray = PMR_AudioManager.Instance.SetBGMSpectrum(m_samples);
            string str;
            float newValue = 0f;

            for (int i = 0; i < m_samplesArray.Length; i++)
            {
                str = m_samplesArray[i].ToString();

                if (str.Length > 0)
                {
                    str = (str.Length - 4 > 0) ? str.Remove(str.Length - 4) : str.Remove(0);
                    newValue = float.Parse(str);

                    if (newValue > 3)
                        newValue -= 2f;

                    m_samplesArray[i] = newValue;
                }

                PMR_NoteSpawner.Instance.InstantiatePrefab(m_samplesArray[i]);
            }
        }

        /// <summary>
        /// Add score to the current one
        /// </summary>
        /// <param name="score"></param>
        public void AddScore(int score)
        {
            m_score += score;
        }
    }

}
