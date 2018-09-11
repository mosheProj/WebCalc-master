using System.Collections.Generic;

namespace WebCalc.ExtensionMethods
{
    public static class StackExtensionMethods
    {
        public static bool IsEmpty<T>(this Stack<T> stack) =>  stack.Count == 0;
        
    }
}
