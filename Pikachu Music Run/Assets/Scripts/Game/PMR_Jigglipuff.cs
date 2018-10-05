using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PikachuMusicRun.Setup;

namespace PikachuMusicRun.Game
{
    public class PMR_Jigglipuff : MonoBehaviour
    {
        /// <summary>
        /// When does Jigglipuff have to go in?
        /// </summary>
        [SerializeField] private bool m_goIn = false;
        /// <summary>
        /// Movement speed
        /// </summary>
        [SerializeField] protected float m_speed = 5f;
        /// <summary>
        /// The position where jig starts the game so can be reseted 
        /// </summary>
        [SerializeField] private Vector3 m_originalPosition;

        // Use this for initialization
        void Start()
        {
            m_originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            PMR_EventManager.StartListening(PMR_EventSetup.Game.END_GAME, GoIn);
            PMR_EventManager.StartListening(PMR_EventSetup.Game.RESET, ResetGame);
        }

        private void OnDestroy()
        {
            PMR_EventManager.StopListening(PMR_EventSetup.Game.END_GAME, GoIn);
            PMR_EventManager.StopListening(PMR_EventSetup.Game.RESET, ResetGame);
        }
        /// <summary>
        /// Reset the gameez
        /// </summary>
        public void ResetGame()
        {
            m_goIn = false;
            transform.position = m_originalPosition;
        }

        /// <summary>
        /// Sure, we must go in
        /// </summary>
        void GoIn()
        {
            m_goIn = true;
            m_speed = PMR_AudioManager.Instance.AudioSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            if (m_goIn)
            {
                transform.Translate(Vector3.right * Time.deltaTime * m_speed);
            }
        }

        /// <summary>
        /// When jigglipuff touches pikachu, we hide end panel
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (m_goIn && collision.gameObject.tag == PMR_GameSetup.Tags.PLAYER)
            {
                m_goIn = false;
                PMR_EventManager.TriggerEvent(PMR_EventSetup.Game.SHOW_END_PANEL);
            }
        }
    }

}
