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

        public bool Paused { get { return m_pause; } }

        // Use this for initialization
        void Start()
        {
            StartAllListeners();

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
