using PikachuMusicRun.Localization;
using PikachuMusicRun.Setup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using PikachuMusicRun.Game;

namespace PikachuMusicRun.Menu
{
    /// <summary>
    /// Main menu
    /// </summary>
    public class PMR_Menu : MonoBehaviour
    {
        [Header("Animator"), Space(10)]
        [SerializeField] private Animator m_mainAnimator;

        [Header("Groups and GOs"), Space(10)]
        [SerializeField] private GameObject m_pressStartGO;
        [SerializeField] private GameObject m_mainGroup;
        [SerializeField] private GameObject m_optionsGroup;
        [SerializeField] private GameObject m_creditsGroup;

        [Header("Texts"), Space(10)]
        [SerializeField] private Text m_pressStartText;
        [SerializeField] private Text m_newGameText;
        [SerializeField] private Text m_bestScoreText;
        [SerializeField] private Text m_optionsText;
        [SerializeField] private Text m_creditsText;
        [SerializeField] private Text m_exitText;
        [SerializeField] private Text m_difficultyText;

        [Header("EventSystem"), Space(10)]
        [SerializeField] private EventSystem m_eventSystem;

        private MENU_STATE m_state;

        /// <summary>
        /// On Start we start all listeners 
        /// </summary>
        // Use this for initialization
        void Start()
        {
            m_eventSystem = EventSystem.current;
            m_state = MENU_STATE.INIT;
            TranslateTexts();
            StartAllListeners();
        }
        /// <summary>
        /// Just event system and change difficulty stuff
        /// </summary>
        private void Update()
        {
            if (m_state == MENU_STATE.PRESS_START)
            {
                if (PMR_InputManager.PressedSkipButton())
                {
                    m_state = MENU_STATE.MAIN;
                    m_eventSystem.SetSelectedGameObject(m_newGameText.transform.parent.gameObject);
                    ShowMainAnimation();
                }
            }
            else if (m_state == MENU_STATE.MAIN)
            {
                if (m_eventSystem.currentSelectedGameObject == null && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    m_eventSystem.SetSelectedGameObject(m_newGameText.transform.parent.gameObject);
                }

                if (Input.GetKeyDown(KeyCode.Keypad1) && PMR_GameManager.Instance.Difficulty != DIFICULTY.EASY)
                {
                    PMR_GameManager.Instance.ChangeDifficulty(DIFICULTY.EASY);
                    m_difficultyText.text = PMR_TextManager.GetText(PMR_TextSetup.Menu.DIFFICULTY) + PMR_TextManager.GetText(PMR_GameManager.Instance.Difficulty.ToString());
                }


                if (Input.GetKeyDown(KeyCode.Keypad2) && PMR_GameManager.Instance.Difficulty != DIFICULTY.MID)
                {
                    PMR_GameManager.Instance.ChangeDifficulty(DIFICULTY.MID);
                    m_difficultyText.text = PMR_TextManager.GetText(PMR_TextSetup.Menu.DIFFICULTY) + PMR_TextManager.GetText(PMR_GameManager.Instance.Difficulty.ToString());
                }


                if (Input.GetKeyDown(KeyCode.Keypad3) && PMR_GameManager.Instance.Difficulty != DIFICULTY.DIFFICULT)
                {
                    PMR_GameManager.Instance.ChangeDifficulty(DIFICULTY.DIFFICULT);
                    m_difficultyText.text = PMR_TextManager.GetText(PMR_TextSetup.Menu.DIFFICULTY) + PMR_TextManager.GetText(PMR_GameManager.Instance.Difficulty.ToString());
                }
            }
        }
        /// <summary>
        /// On destroy we stop listening
        /// </summary>
        private void OnDestroy()
        {
            StopAllListeners();
        }
        /// <summary>
        /// Event Listeners
        /// </summary>

        void StartAllListeners()
        {
            PMR_EventManager.StartListening(PMR_EventSetup.Menu.INIT, InitMenu);
            PMR_EventManager.StartListening(PMR_EventSetup.Localization.TRANSLATE_TEXTS, TranslateTexts);
        }
        /// <summary>
        /// Stop all listeners when ended
        /// </summary>
        void StopAllListeners()
        {
            PMR_EventManager.StopListening(PMR_EventSetup.Localization.TRANSLATE_TEXTS, TranslateTexts);
            PMR_EventManager.StopListening(PMR_EventSetup.Menu.INIT, InitMenu);
        }
        /// <summary>
        /// Translate all texts when changing language or going to menu
        /// </summary>
        void TranslateTexts()
        {
            m_pressStartText.text = PMR_TextManager.GetText(PMR_TextSetup.Menu.PRESS_START);
            m_newGameText.text = PMR_TextManager.GetText(PMR_TextSetup.Menu.NEW_GAME);
            m_bestScoreText.text = PMR_TextManager.GetText(PMR_TextSetup.Menu.BEST_SCORE) + PlayerPrefs.GetInt(PMR_GameSetup.PlayerPrefs.BEST_SCORE, 0);
            m_difficultyText.text = PMR_TextManager.GetText(PMR_TextSetup.Menu.DIFFICULTY) + PMR_TextManager.GetText(PMR_GameManager.Instance.Difficulty.ToString());
            //m_optionsText.text = PMR_TextManager.GetText(PMR_TextSetup.Menu.OPTIONS);
            //m_creditsText.text = PMR_TextManager.GetText(PMR_TextSetup.Menu.CREDITS);
            m_exitText.text = PMR_TextManager.GetText(PMR_TextSetup.Menu.EXIT);         
        }
        /// <summary>
        /// Init animation (Ho-OH and Title appears)
        /// </summary>
        void InitMenu()
        {
            m_state = MENU_STATE.INIT;
            PMR_AudioManager.Instance.PlayMenuBGM();
            PMR_EventManager.TriggerEvent(PMR_EventSetup.Game.GO_TO_MENU);
            m_mainAnimator.SetTrigger("init");
        }
        /// <summary>
        /// Start menu is shown (Has an animation in loop)
        /// </summary>
        public void StartMenu()
        {
            m_state = MENU_STATE.PRESS_START;
            m_pressStartGO.SetActive(true);
        }
        public void ShowMainAnimation()
        {
            m_mainAnimator.SetTrigger("showMain");
        }
        /// <summary>
        /// Pressed a button in any of the panels
        /// </summary>
        /// <param name="button"></param>
        public void PressedButton(string button)
        {
            switch (button)
            {
                case "NewGame":
                    m_mainAnimator.SetTrigger("newGame");
                    break;
                case "Options":
                    ShowOptions();
                    break;
                case "Credits":
                    ShowCredits();
                    break;
                case "Back":
                    ShowMain();
                    break;
                case "Exit":
                    ExitGame();
                    break;
            }
        }


        /// <summary>
        /// Going to game!!
        /// </summary>
        public void NewGame()
        {
            PMR_SceneManager.LoadScene(PMR_SceneSetup.SCENES.GAME, 1f, PMR_EventSetup.Game.GO_TO_GAME);
        }
        /// <summary>
        /// Show options panel
        /// </summary>
        public void ShowOptions()
        {
            m_state = MENU_STATE.OPTIONS;
            m_optionsGroup.SetActive(true);
            m_creditsGroup.SetActive(false);
            m_mainGroup.SetActive(false);
        }
        /// <summary>
        /// Show credits panel
        /// </summary>
        public void ShowCredits()
        {
            m_state = MENU_STATE.CREDITS;
            m_optionsGroup.SetActive(false);
            m_creditsGroup.SetActive(true);
            m_mainGroup.SetActive(false);
        }
        /// <summary>
        /// Show main panel
        /// </summary>
        public void ShowMain()
        {
            m_state = MENU_STATE.MAIN;
            m_optionsGroup.SetActive(false);
            m_creditsGroup.SetActive(false);
            m_mainGroup.SetActive(true);
        }
        /// <summary>
        /// Exit the game
        /// </summary>
        public void ExitGame()
        {
            Application.Quit();
        }
        /// <summary>
        /// Go back to the menu
        /// </summary>
        public void GoBackToMenu()
        {
            PMR_SceneManager.LoadScene(PMR_SceneSetup.SCENES.MAIN_MENU, 1f, PMR_EventSetup.Game.GO_TO_MENU);
        }
    }
    /// <summary>
    /// Each menu state
    /// </summary>
    public enum MENU_STATE
    {
        INIT,
        PRESS_START,
        MAIN,
        OPTIONS,
        CREDITS
    }
}
