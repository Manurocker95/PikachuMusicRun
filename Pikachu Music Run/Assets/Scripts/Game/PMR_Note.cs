﻿using PikachuMusicRun.Game;
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

        // Use this for initialization
        void Start()
        {
            m_noteSpeed = PMR_AudioManager.Instance.AudioSpeed;
        }

        private void Update()
        {
            transform.Translate(Vector3.right * Time.deltaTime * m_noteSpeed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == PMR_GameSetup.Tags.PLAYER)
            {
                PMR_AudioManager.Instance.PlayNoteSFX();
                PMR_GameManager.Instance.AddScore(m_score);
                Destroy(this.gameObject);
            }
        }
    }

}
