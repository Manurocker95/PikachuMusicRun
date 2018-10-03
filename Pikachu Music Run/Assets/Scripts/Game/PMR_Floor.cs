using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PikachuMusicRun.Game
{
    public class PMR_Floor : MonoBehaviour
    {
        [SerializeField] private float m_speed = 5f;

        // Use this for initialization
        void Start()
        {
            m_speed = PMR_AudioManager.Instance.AudioSpeed;
        }


        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.right * Time.deltaTime * m_speed);
        }
    }

}
