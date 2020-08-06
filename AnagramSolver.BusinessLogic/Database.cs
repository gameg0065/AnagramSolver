using System;
using System.IO;
using System.Collections.Generic;
using AnagramSolver.Interfaces;
using AnagramSolver.Contracts;
using AnagramSolver.Data;

namespace AnagramSolver.BusinessLogic
{
    public class DatabaseManager
    {
        public bool CheckIfExists(string key)
        {
            var dataBase = new DataBase();
            return dataBase.CheckIfExists(key);
        }
    }
}
