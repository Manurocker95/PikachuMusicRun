using PikachuMusicRun.Setup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PikachuMusicRun.Menu
{
    /// <summary>
    /// Main menu
    /// </summary>
    public class PMR_Menu : MonoBehaviour
    {
        [SerializeField] private Animator m_mainAnimator;
        [SerializeField] private GameObject m_pressStartGO;

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
            PMR_EventManager.StartListening(PMR_EventSetup.Menu.INIT, InitMenu);
        }

        void StopAllListeners()
        {
            if (PMR_EventManager.Instance)
                PMR_EventManager.StopListening(PMR_EventSetup.Menu.INIT, InitMenu);
        }
        
        void InitMenu()
        {
            PMR_EventManager.TriggerEvent(PMR_EventSetup.Game.GO_TO_MENU);
            m_mainAnimator.SetTrigger("init");
        }

        public void StartMenu()
        {
            m_pressStartGO.SetActive(true);
        }

    }

}
