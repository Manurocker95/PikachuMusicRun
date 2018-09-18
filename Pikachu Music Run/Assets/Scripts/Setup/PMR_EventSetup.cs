/// This code is personal and can't be used for commercial games.
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
    public static class PMR_EventSetup
    {
        public static class Game
        {
            public const string PAUSE_GAME = "pauseGameEvent";
            public const string UNPAUSE_GAME = "unpauseGameEvent";

            public const string GO_TO_GAME = "goToGameEvent";
            public const string GO_TO_MENU = "goToMenuEvent";
        }

        public static class Localization
        {
            public const string TRANSLATE_TEXTS = "translateTextsEvent";
        }

        public static class Menu
        {
            public const string INIT = "InitMenuEvent";
        }


    }

}
