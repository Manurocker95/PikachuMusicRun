using PikachuMusicRun.Setup;
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
        [SerializeField] private List<GameObject> m_notes;
        public float m_noteBetweenDistance = 2f;
        public bool m_initialized = false;
        
        protected override void Awake()
        {
            m_destroyOnLoad = true;
            m_notes = new List<GameObject>();
            base.Awake();
        }

        // Use this for initialization
        void Start()
        {
            PMR_EventManager.StartListening(PMR_EventSetup.Game.END_GAME, ResetManager);
        }

        private void Update()
        {

        }

        void OnDestroy()
        {
            PMR_EventManager.StopListening(PMR_EventSetup.Game.END_GAME, ResetManager);
        }

        void ResetManager()
        {
            m_noteX = 0;
        }

        public void InstantiatePrefab(float _sampleHeight, int index)
        {
            GameObject go = (m_initialized) ? m_notes[index] : Instantiate(m_notePrefab);
            go.transform.position = new Vector3(transform.position.x - m_noteX, transform.position.y + _sampleHeight, transform.position.z);
            go.SetActive(true);
            m_noteX += m_noteBetweenDistance;

            //Debug.Log(go+"I WAS CREATED!");

            if (!m_initialized)
                m_notes.Add(go);
        }

        public int GetNoteCount()
        {
            return m_notes.Count;
        }
    }

}
