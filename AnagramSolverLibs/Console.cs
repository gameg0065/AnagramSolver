﻿using System;

namespace AnagramSolver.Consoleno
{
    public static class GetUserInput
    {
        public static string GetName()
        {
            System.Console.WriteLine("Input your name: ");
            string name = System.Console.ReadLine();

            return name;
        } 
    }
}