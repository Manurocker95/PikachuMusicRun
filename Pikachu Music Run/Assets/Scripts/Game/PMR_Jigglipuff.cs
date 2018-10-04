using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PikachuMusicRun.Setup;

namespace PikachuMusicRun.Game
{
    public class PMR_Jigglipuff : MonoBehaviour
    {
        [SerializeField] private bool m_goIn = false;
        [SerializeField] protected float m_speed = 5f;

        // Use this for initialization
        void Start()
        {
            PMR_EventManager.StartListening(PMR_EventSetup.Game.END_GAME, GoIn);
        }

        private void OnDestroy()
        {
            PMR_EventManager.StopListening(PMR_EventSetup.Game.END_GAME, GoIn);
        }

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

        private void OnCollisionEnter(Collision collision)
        {
            if (m_goIn && collision.gameObject.tag == PMR_GameSetup.Tags.PLAYER)
            {
                m_goIn = false;
                PMR_EventManager.TriggerEvent(PMR_EventSetup.Game.SHOW_END_PANEL);
            }
        }
    }

}
