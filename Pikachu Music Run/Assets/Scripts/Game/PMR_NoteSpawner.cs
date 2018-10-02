using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PikachuMusicRun.Game
{
    public class PMR_NoteSpawner : PMR_SingletonMonobehaviour<PMR_NoteSpawner>
    {
        [SerializeField] private GameObject m_notePrefab;
        int _x = 0;
        int jump = 2;

        protected override void Awake()
        {
            m_destroyOnLoad = true;
            base.Awake();
        }

        // Use this for initialization
        void Start()
        {
 
    
        }

        public void InstantiatePrefab(float sampleHeight)
        {
            GameObject go = Instantiate(m_notePrefab);
            float _y = transform.position.y;
            float _val = _y + sampleHeight;
            
            go.transform.position = new Vector3(transform.position.x-_x, _val, transform.position.z);
            _x += jump;
        }
    }

}
