using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Classes;

namespace TextRPG.Interfaces
{
    public interface IPlayer
    {
        void Attack(Enemy enemy);
        void PrintPlayerInformation();
        void LevelUp();
    }
}
