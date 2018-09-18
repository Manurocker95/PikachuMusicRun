/// This code is personal and can't be used for commercial games.
/// Non-profit projects can use it with explicit permission and credits
/// 
/// Made by Manuel Rodríguez Matesanz.
/// You can contact me on GBATemp as Manurocker95, email: Manuelrodriguezmatesanz@gmail.com
/// or even on my web: Manuelrodriguezmatesanz.com

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace PikachuMusicRun
{
    /// <summary>
    /// Unity tutorial for handling simple events. 
    /// </summary>
    public class PMR_EventManager : PMR_SingletonMonobehaviour<PMR_EventManager>
    {
        /// <summary>
        /// Event dictionary saving the desired Unity Event
        /// </summary>
        private Dictionary<string, UnityEvent> eventDictionary;

        /// <summary>
        /// Singleton Initialization 
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            Init();
        }

        /// <summary>
        /// Dictionary initialization
        /// </summary>
        void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<string, UnityEvent>();
            }
        }
        /// <summary>
        /// Register and event adding it to the dictionary
        /// </summary>
        /// <param name="eventName"></param>
        public static void RegisterEvent(string eventName, UnityEvent eventData)
        {
            if (Instance == null) return;

            Instance.eventDictionary.Add(eventName, eventData);
        }

        /// <summary>
        /// The desired object is now listening if it wasn't
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public static void StartListening(string eventName, UnityAction listener)
        {
            if (Instance == null) return;
            UnityEvent thisEvent = null;
            if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Instance.eventDictionary.Add(eventName, thisEvent);
            }
        }
        /// <summary>
        /// The desired object is no longer listening
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public static void StopListening(string eventName, UnityAction listener)
        {
            if (Instance == null) return;
            UnityEvent thisEvent = null;
            if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }
        /// <summary>
        /// Triggers the event and calls every object that is listening to that event
        /// </summary>
        /// <param name="eventName"></param>
        public static void TriggerEvent(string eventName)
        {
            if (Instance == null) return;
            UnityEvent thisEvent = null;
            if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }

}
