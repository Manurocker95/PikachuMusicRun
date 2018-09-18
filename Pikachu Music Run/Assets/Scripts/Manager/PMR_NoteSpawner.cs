using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMR_NoteSpawner : MonoBehaviour {

    [SerializeField] private GameObject m_notePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	public void InstantiatePrefab()
    {
        GameObject go = Instantiate(m_notePrefab, this.transform);
    }
}
