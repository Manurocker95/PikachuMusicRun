using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PikachuMusicRun.Setup;
using UnityEngine.Video;

namespace PikachuMusicRun
{
    public class PMR_Initializer : MonoBehaviour
    {
        /// <summary>
        /// Videoplayer that playes intro
        /// </summary>
        [SerializeField] private VideoPlayer m_videoPlayer;

        // Use this for initialization
        void Start()
        {
            m_videoPlayer.loopPointReached += EndReached;
        }
        private void Update()
        {
            if (PMR_InputManager.PressedSkipButton())
                EndReached(m_videoPlayer);
        }

        /// <summary>
        /// End of the videoreached
        /// </summary>
        /// <param name="vp"></param>
        void EndReached(UnityEngine.Video.VideoPlayer vp)
        {
            PMR_SceneManager.LoadScene(PMR_SceneSetup.SCENES.MAIN_MENU, 1f, PMR_EventSetup.Menu.INIT);
        }
    }

}
