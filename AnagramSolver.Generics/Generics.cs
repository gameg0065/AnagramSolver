using System;
using System.ComponentModel;

namespace AnagramSolver.Generic
{
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }

    public enum Weekday
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    public class MapValueToEnum<T, TValue> 
    {
        public static T Map(TValue value)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    return (T)converter.ConvertFromString(value.ToString());
                }
                return default(T);
            }
            catch (NotSupportedException)
            {
                throw new Exception("Value " + value + " us not part of " + typeof(T).FullName + " enum");
            }
        }
    }
}
