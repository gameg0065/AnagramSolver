using System.Collections.Generic;

namespace AnagramSolver.Interfaces
{
    public interface IUserInteraction
    {
        void AskForUserInput(int minLength, int anagramNumber);
        string GetWord(int minLength);
        bool AskToEndApp();
    }
}
