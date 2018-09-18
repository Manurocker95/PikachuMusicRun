/// This code is personal and can't be used for commercial games.
/// Non-profit projects can use it with explicit permission and credits
/// 
/// Made by Manuel Rodríguez Matesanz.
/// You can contact me on GBATemp as Manurocker95, email: Manuelrodriguezmatesanz@gmail.com
/// or even on my web: Manuelrodriguezmatesanz.com

using UnityEngine;

namespace PikachuMusicRun
{
    /// <summary>
    /// A singleton implementation for MonoBehaviours. 
    /// </summary>
    /// <typeparam name="T">Any type we want</typeparam>
    public class PMR_SingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// The actual instance of this type.
        /// </summary>
        private static MonoBehaviour m_instance;
        /// <summary>
        /// Do we wanna destroy this GO across levels
        /// </summary>
        protected bool m_destroyOnLoad = false;

        /// <summary>
        /// Get an instance to this MonoBehaviour.Always returns a valid object.
        /// </summary>
        public static T Instance { get { return (T)m_instance; } }

        /// <summary>
        /// If overriding, be sure to call base.Awake().
        /// </summary>
        protected virtual void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;

                if (!((PMR_SingletonMonobehaviour<T>)m_instance).m_destroyOnLoad)
                    DontDestroyOnLoad(m_instance.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}