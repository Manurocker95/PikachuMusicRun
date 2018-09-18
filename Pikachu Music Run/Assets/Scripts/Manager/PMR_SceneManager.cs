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
using UnityEngine.SceneManagement;

namespace PikachuMusicRun
{
    /// <summary>
    /// This class controls everything related to scene load and unload
    /// </summary>
    public class PMR_SceneManager : PMR_SingletonMonobehaviour<PMR_SceneManager>
    {
        /// <summary>
        /// Loading Screen group. 
        /// </summary>
        [SerializeField] GameObject m_loadingScreenGroup;
        /// <summary>
        /// Text shows "loading..." with an animation
        /// </summary>
        [SerializeField] Text m_loadingText;

        // Use this for initialization
        void Start()
        {

        }

        /// <summary>
        /// When destroying the object we must stop listening events
        /// </summary>
        private void OnDestroy()
        {
            StopAllListeners();
        }
        /// <summary>
        /// Start Listening to events
        /// </summary>
        private void StartAllListeners()
        {

        }
        /// <summary>
        /// Stop Listening to events
        /// </summary>
        private void StopAllListeners()
        {
            //
        }

        private void _HidePanel()
        {
            m_loadingScreenGroup.SetActive(false);
        }

        public static void HidePanel()
        {
            Instance._HidePanel();
        }

        /// <summary>
        /// Load Scene from anywhere (static method)
        /// </summary>
        /// <param name="_scene"></param>
        /// <param name="_delayAfterLoading"></param>
        /// <param name="_eventName"></param>
        public static void LoadScene(PMR_SceneSetup.SCENES _scene, float _delayAfterLoading = 1f, string _eventName = "")
        {
            Instance.LoadSceneAsync(_scene, _delayAfterLoading, _eventName);
        }
        /// <summary>
        /// Load Level Async so we can show the 
        /// </summary>
        /// <param name="_scene"></param>
        /// <param name="_delayAfterLoading"></param>
        /// <param name="_eventName"></param>
        private void LoadSceneAsync(PMR_SceneSetup.SCENES _scene, float _delayAfterLoading = 1f, string _eventName = "")
        {         
            StartCoroutine(LoadingScreen((int)_scene, _delayAfterLoading, _eventName));
        }
        /// <summary>
        /// Coroutine called for loading the next scene
        /// </summary>
        /// <param name="_index"></param>
        /// <param name="_delayAfterLoading"></param>
        /// <param name="_eventName"></param>
        /// <returns></returns>
        IEnumerator LoadingScreen(int _index, float _delayAfterLoading = 1f, string _eventName = "")
        {
            m_loadingScreenGroup.SetActive(true);
            m_loadingText.text = PMR_TextManager.GetText(PMR_TextSetup.LoadingScreen.LOADING_TEXT);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_index);
           
            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            yield return new WaitForSeconds(_delayAfterLoading);
            m_loadingScreenGroup.SetActive(false);

            if (_eventName != "")
            {
                PMR_EventManager.TriggerEvent(_eventName);
            }
        }
    }

}
