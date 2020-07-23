using System;


namespace AnagramSolver.Contracts
{
    public interface IWordRepository
    {
    }
    public interface IAnagramSolver
    {
    }
    public class Element
    {
        public string Word { get; set; }
        public string Antecedent { get; set; }
    }
}
