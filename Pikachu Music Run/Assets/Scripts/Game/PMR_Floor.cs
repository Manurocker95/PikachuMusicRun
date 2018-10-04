using PikachuMusicRun.Setup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PikachuMusicRun.Game
{
    public class PMR_Floor : PMR_GameElement
    {
        protected override void SetVelocity()
        {
            m_speed = PMR_AudioManager.Instance.AudioSpeed;
        }
    }

}
