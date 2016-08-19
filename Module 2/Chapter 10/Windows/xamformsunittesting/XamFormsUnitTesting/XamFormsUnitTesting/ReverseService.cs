using System;

namespace XamFormsUnitTesting
{
    public class ReverseService
    {
        public string ReverseWord(string word)
        {
            char[] arr = word.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
