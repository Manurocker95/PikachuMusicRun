﻿/// This code is personal and can't be used for commercial games.
/// Non-profit projects can use it with explicit permission and credits
/// 
/// Made by Manuel Rodríguez Matesanz.
/// You can contact me on GBATemp as Manurocker95, email: Manuelrodriguezmatesanz@gmail.com
/// or even on my web: Manuelrodriguezmatesanz.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PikachuMusicRun.Setup
{
    public static class PMR_GameSetup
    {
        public static class Tags
        {
            public const string PLAYER = "Player";
            public const string NOTE = "Note";
        }

        public static class PlayerPrefs
        {
            public const string LAST_LANGUAGE = "lastLanguagePMR_PP";
            public const string MAIN_VOLUME = "mainVolumePMR_PP";
            public const string BEST_SCORE = "bestScorePMR_PP";
        }

        public static class Dificulty_Samples
        {
            public const int EASY = 512;
            public const int MID = 1024;
            public const int DIFFICULT = 2048;
        }

        public static class Dificulty_Velocities
        {
            public const int EASY = 10;
            public const int MID = 20;
            public const int DIFFICULT = 50;
        }
    }

    public enum DIFICULTY
    {
        EASY,
        MID,
        DIFFICULT
    }
   
}
