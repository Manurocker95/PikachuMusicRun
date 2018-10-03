using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PikachuMusicRun.Game
{
    public class PMR_NoteSpawner : PMR_SingletonMonobehaviour<PMR_NoteSpawner>
    {
        [SerializeField] private GameObject m_notePrefab;
        [SerializeField] private float m_noteWidth = 2f;
        [SerializeField] private float m_noteX = 0f;
        public float m_noteBetweenDistance = 2f;

        protected override void Awake()
        {
            m_destroyOnLoad = true;
            base.Awake();
        }

        // Use this for initialization
        void Start()
        {
           


        }

        public void InstantiatePrefab(float _sampleHeight)
        {
           GameObject go = Instantiate(m_notePrefab);
            go.transform.position = new Vector3(transform.position.x - m_noteX, transform.position.y + _sampleHeight, transform.position.z);
            m_noteX += m_noteBetweenDistance;
        }
    }

}
