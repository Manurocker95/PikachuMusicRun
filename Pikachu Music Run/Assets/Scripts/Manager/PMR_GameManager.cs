/// This code is personal and can't be used for commercial games.
/// Non-profit projects can use it with explicit permission and credits
/// 
/// Made by Manuel Rodríguez Matesanz.
/// You can contact me on GBATemp as Manurocker95, email: Manuelrodriguezmatesanz@gmail.com
/// or even on my web: Manuelrodriguezmatesanz.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PikachuMusicRun.Setup;
using PikachuMusicRun.Localization;
using UnityEngine.EventSystems;

namespace PikachuMusicRun.Game
{
    public class PMR_GameManager : PMR_SingletonMonobehaviour<PMR_GameManager>
    {
        /// <summary>
        /// Current score
        /// </summary>
        [SerializeField] private int m_score;
        /// <summary>
        /// If the game is paused or not
        /// </summary>
        [SerializeField] private bool m_pause = false;
        /// <summary>
        /// If the game has ended
        /// </summary>
        [SerializeField] private bool m_ended = false;
        /// <summary>
        /// Current Difficulty
        /// </summary>
        [SerializeField] private DIFICULTY m_difficulty = DIFICULTY.DIFFICULT;
        /// <summary>
        /// Number of samples / Notes
        /// </summary>
        [SerializeField] private int m_samples = 0;
        /// <summary>
        /// Spectrum sample array
        /// </summary>
        [SerializeField] private float[] m_samplesArray;
        /// <summary>
        /// Audio Length
        /// </summary>
        [SerializeField] private float m_gameLenght = 0f;
        /// <summary>
        /// Timer to know when the game has ended
        /// </summary>
        [SerializeField] private float m_timer = 0f;
        /// <summary>
        /// Time spent after ending the game (delay to stop playing)
        /// </summary>
        [SerializeField] private float m_timeThreshold = 5f;

        [Header("End panel"), Space(10)]
        [SerializeField] private Text m_scoreText;
        [SerializeField] private Text m_scoreEndText;
        [SerializeField] private Text m_endText;
        [SerializeField] private Text m_restartbtnText;
        [SerializeField] private Text m_backbtnText;
        [SerializeField] private GameObject m_endPanel;

        [Header("Platform"), Space(10)]
        [SerializeField] private GameObject m_platformPrefab;
        [SerializeField] private Vector3 m_platformOrigin;
        [SerializeField] private float m_timeToSpawnPlatform = 5f;
        [SerializeField] private float m_platformTimer = 0f;

        [Header("Animator"), Space(10)]
        [SerializeField] private Animator m_animator;
        [SerializeField] private AudioClip[] m_clip;
        [SerializeField] private AudioSource m_source;
        [SerializeField] private bool m_started = false;

        [Header("EventSystem"), Space(10)]
        [SerializeField] private EventSystem m_eventSystem;
        private bool m_showingEndPanel = false;

        [Header("Notes"), Space(10)]
        [SerializeField] public int m_notes = 0;


        public bool Paused { get { return m_pause; } }
        
        // Use this for initialization
        void Start()
        {
            m_started = false;
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

        private void Update()
        {
            if (!m_pause && !m_ended && m_started)
            {
                m_timer += Time.deltaTime;

                if (m_timer > m_gameLenght + m_timeThreshold || m_notes >= m_samples)
                {
                    EndGame();
                }
            }

            if (m_showingEndPanel)
            {
                if (m_eventSystem.currentSelectedGameObject == null && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    m_eventSystem.SetSelectedGameObject(m_restartbtnText.transform.parent.gameObject);
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
                GoBackToMenu();
        }

    

        private void OnDestroy()
        {
            StopAllListeners();
        }

        void StartAllListeners()
        {
            PMR_EventManager.StartListening(PMR_EventSetup.Game.GO_TO_GAME, ResetGame);
            PMR_EventManager.StartListening(PMR_EventSetup.Game.SHOW_END_PANEL, ShowPanel);
        }


        void StopAllListeners()
        {
          
          PMR_EventManager.StopListening(PMR_EventSetup.Game.GO_TO_GAME, ResetGame);
          PMR_EventManager.StopListening(PMR_EventSetup.Game.SHOW_END_PANEL, ShowPanel);
        }
        
        public void GoBackToMenu()
        {
            PMR_SceneManager.LoadScene(PMR_SceneSetup.SCENES.MAIN_MENU, 1f, PMR_EventSetup.Game.GO_TO_MENU);
        }


        public void EndGame()
        {
            PMR_AudioManager.Instance.StopBGM();

            m_ended = true;
            int bestScore = PlayerPrefs.GetInt(PMR_GameSetup.PlayerPrefs.BEST_SCORE, 0);

            if (m_score > bestScore)
                PlayerPrefs.SetInt(PMR_GameSetup.PlayerPrefs.BEST_SCORE, m_score);

            m_endText.text = PMR_TextManager.GetText(PMR_TextSetup.Game.END_TEXT);
            m_scoreEndText.text = PMR_TextManager.GetText(PMR_TextSetup.Game.SCORE_TEXT) + m_score;
            m_restartbtnText.text = PMR_TextManager.GetText(PMR_TextSetup.Game.RESTART);
            m_backbtnText.text = PMR_TextManager.GetText(PMR_TextSetup.Menu.BACK_TO_MENU);

            PMR_EventManager.TriggerEvent(PMR_EventSetup.Game.END_GAME);
        }

        public void ShowPanel()
        {
            m_scoreText.gameObject.SetActive(false);
            m_showingEndPanel = true;
            m_endPanel.SetActive(true);
            m_eventSystem = EventSystem.current;
            m_eventSystem.SetSelectedGameObject(m_restartbtnText.transform.parent.gameObject);
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
            PMR_AudioManager.Instance.StopBGM();
            PMR_EventManager.TriggerEvent(PMR_EventSetup.Game.RESET);
            m_endPanel.SetActive(false);
            m_scoreText.gameObject.SetActive(true);
            m_pause = false;
            m_ended = false;
            m_started = false;
            m_score = 0;
            m_notes = 0;
            m_scoreText.text = "x" + m_score;
            m_animator.SetTrigger(PMR_GameSetup.Triggers.COUNTDOWN);
        }

        public void PlaySound(int index)
        {
            m_source.clip = m_clip[index];
            m_source.Play();
        }

        public void StartTheGame()
        {
            m_started = true;
            PMR_EventManager.TriggerEvent(PMR_EventSetup.Game.END_COUNTDOWN);
            InitSpectrum();
        }

        public void InitSpectrum()
        {
            PMR_AudioManager.Instance.PlayGameBGM();

            m_gameLenght = PMR_AudioManager.Instance.BGMLength;

            m_samplesArray = PMR_AudioManager.Instance.SetBGMSpectrum(m_samples, m_difficulty);
            string str;
            float newValue = 0f;

            PMR_NoteSpawner.Instance.m_noteBetweenDistance = 2f;

            for (int i = 0; i < m_samplesArray.Length; i++)
            {
                str = m_samplesArray[i].ToString();

                if (str.Length > 0)
                {
                    str = (str.Length - 4 > 0) ? str.Remove(str.Length - 4) : str.Remove(0);
                    newValue = float.Parse(str);

                    if (newValue > 2f && newValue < 3.5f)
                        newValue -= 2.5f;
                    else if (newValue > 3.5f)
                        newValue = 2.5f;

                    m_samplesArray[i] = newValue;
                }

                PMR_NoteSpawner.Instance.InstantiatePrefab(m_samplesArray[i], i);
            }

            PMR_EventManager.TriggerEvent(PMR_EventSetup.Game.SET_VELOCITY);
        }

        /// <summary>
        /// Add score to the current one
        /// </summary>
        /// <param name="score"></param>
        public void AddScore(int score)
        {
            m_score += score;
            m_scoreText.text = "x" + m_score;
            m_notes++;
        }
    }

}
