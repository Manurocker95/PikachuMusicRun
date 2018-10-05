using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PikachuMusicRun.Game
{
    public class PMR_Platform : PMR_GameElement
    {
        protected override void Start()
        {
            base.Start();
        }

        protected override void SetVelocity()
        {
            m_speed = PMR_AudioManager.Instance.AudioSpeed;
        }

    }

}
