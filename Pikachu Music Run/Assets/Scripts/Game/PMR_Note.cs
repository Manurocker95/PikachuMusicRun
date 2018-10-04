using PikachuMusicRun.Game;
using PikachuMusicRun.Setup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PikachuMusicRun.Game
{
    public class PMR_Note : MonoBehaviour
    {
        /// <summary>
        /// Score this note gives to the player when being touched
        /// </summary>
        [SerializeField] private int m_score = 1;
        /// <summary>
        /// Note speed
        /// </summary>
        [SerializeField] private float m_noteSpeed = 5f;
        /// <summary>
        /// Limit where the note is destroyed if not gotten
        /// </summary>
        [SerializeField] private float m_xMaxLimit = 30f;

        // Use this for initialization
        void Start()
        {
            m_noteSpeed = PMR_AudioManager.Instance.AudioSpeed;
        }

        private void Update()
        {
            transform.Translate(Vector3.right * Time.deltaTime * m_noteSpeed);

            if (transform.position.x > m_xMaxLimit)
            {
                this.gameObject.SetActive(false);
                PMR_GameManager.Instance.m_notes++;
            }
                
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == PMR_GameSetup.Tags.PLAYER)
            {
                PMR_AudioManager.Instance.PlayNoteSFX();
                PMR_GameManager.Instance.AddScore(m_score);
                this.gameObject.SetActive(false);
            }
        }
    }

}
