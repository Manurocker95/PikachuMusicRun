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
    /// <summary>
    /// This class stores data for strings related to textmanager dictionary keys
    /// and parsed from the language XML
    /// </summary>
    /// 
    public static class PMR_TextSetup
    {
        /// <summary>
        /// Resources/Archives/English.xml...
        /// </summary>
        public const string LOCALIZATION_FILES_PATH = "Archives";

        public class LoadingScreen
        {
            public const string LOADING_TEXT = "loadingText";
        }
        public class Game
        {
            public const string END_TEXT = "endText";
            public const string SCORE_TEXT = "scoreEndText";
            public const string RESTART = "restartText";
        }

        public class Menu
        {
            public const string CONTINUE = "continueText";
            public const string NEW_GAME = "newGameText";
            public const string OPTIONS = "optionsText";
            public const string CREDITS = "creditsText";
            public const string EXIT = "exitText";

            public const string OPTIONS_TITLE = "optionsTitleText";
            public const string VOLUME = "optionsVolumeText";
            public const string GRAPHICS = "optionsGraphicsText";
            public const string BACK = "backText";
            public const string LANGUAGE = "languageText";

            public const string CREDITS_TITLE = "creditsTitleText";
            public const string CREDITS_TEXT = "creditsMainText";

            public const string RESUME = "resumeText";
            public const string BACK_TO_MENU = "backToMenuText";
            public const string PRESS_START = "pressStartText";
            public const string BEST_SCORE = "bestScoreText";
            public const string DIFFICULTY = "difficultyText";

        }
    }

}
