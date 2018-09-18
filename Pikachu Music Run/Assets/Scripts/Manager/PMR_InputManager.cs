/// This code is personal and can't be used for commercial games.
/// Non-profit projects can use it with explicit permission and credits
/// 
/// Made by Manuel Rodríguez Matesanz.
/// You can contact me on GBATemp as Manurocker95, email: Manuelrodriguezmatesanz@gmail.com
/// or even on my web: Manuelrodriguezmatesanz.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PikachuMusicRun
{
    /// <summary>
    /// Just a custom input manager. We set here the keycodes instead of using Unity Keycodes so we can 
    /// set custom keys in-game
    /// </summary>
    public class PMR_InputManager : PMR_SingletonMonobehaviour<PMR_InputManager>
    {
        /// <summary>
        /// Jump keycode - Serialized for access in inspector
        /// </summary>
        [SerializeField] private KeyCode[] m_jumpKeyCodes = { KeyCode.Space, KeyCode.Joystick1Button0 };        /// <summary>
        /// Jump keycode - Serialized for access in inspector
        /// </summary>
        [SerializeField] private KeyCode[] m_introSkipKeyCodes = { KeyCode.Return, KeyCode.Joystick1Button0 };

        // Use this for initialization
        void Start()
        {

        }

        /// <summary>
        /// Did we press jump button?
        /// </summary>
        /// <returns></returns>
        private bool _PressedJumpButton()
        {
            foreach (KeyCode k in m_jumpKeyCodes)
            {
                if (Input.GetKeyDown(k))
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Static method so it can be easier to access.
        /// </summary>
        /// <returns></returns>
        public static bool PressedJumpButton()
        {
            return Instance._PressedJumpButton();
        }        
        /// <summary>
        /// Did we press jump button?
        /// </summary>
        /// <returns></returns>
        private bool _PressedSkipButton()
        {
            foreach (KeyCode k in m_introSkipKeyCodes)
            {
                if (Input.GetKeyDown(k))
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Static method so it can be easier to access.
        /// </summary>
        /// <returns></returns>
        public static bool PressedSkipButton()
        {
            return Instance._PressedSkipButton();
        }
    }

}
