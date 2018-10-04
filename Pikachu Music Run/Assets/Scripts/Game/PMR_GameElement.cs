using PikachuMusicRun;
using PikachuMusicRun.Setup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMR_GameElement : MonoBehaviour {

    [SerializeField] protected Vector3 originalPos;
    [SerializeField] protected float m_speed = 5f;
    [SerializeField] protected float m_xMaxLimit;
    [SerializeField] protected float m_xMinLimit;
    [SerializeField] protected bool m_started = false;
    [SerializeField] protected bool m_static = false;

    // Use this for initialization
    protected virtual void Start()
    {
        PMR_EventManager.StartListening(PMR_EventSetup.Game.SET_VELOCITY, SetVelocity);
        PMR_EventManager.StartListening(PMR_EventSetup.Game.END_COUNTDOWN, StartTheGame);
        PMR_EventManager.StartListening(PMR_EventSetup.Game.END_GAME, StopGame);
        originalPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    }

    protected virtual void SetVelocity()
    {
        m_speed = PMR_AudioManager.Instance.AudioSpeed;
    }

    protected virtual void StartTheGame()
    {
        m_started = true;
    }

    protected virtual void StopGame()
    {
        m_started = false;
    }

    protected virtual void ResetTheGame()
    {
        m_started = false;
        transform.localPosition = originalPos;
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        if (m_started && !m_static)
        {
            transform.Translate(Vector3.right * Time.deltaTime * m_speed);

            if (transform.localPosition.x >= m_xMaxLimit)
                transform.localPosition = new Vector3(m_xMinLimit, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
