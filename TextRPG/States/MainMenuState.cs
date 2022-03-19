using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.States
{
    class MainMenuState : BaseState
    {
        
        public override List<string> AddOptions()
        {
            return new List<string>() {"New Game","Load Game","Quit" };
        }

        public override void EnterState()
        {
            State = "Main Menu";
            //Console.WriteLine("Entered MainMenuState");
            //Console.WriteLine("... configuring main menu options...");
        }
    }
}
