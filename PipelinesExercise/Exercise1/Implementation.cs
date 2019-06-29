using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace PipelinesExercise
{
    public static class Implementation
    {
        public static readonly bool Log = true;
        public static readonly bool Error = false;

        public static bool LogOrError = Error;

        public static void Do([CallerFilePath]string callerFilePath = null, [CallerMemberName] string callerMemberName = null)
        {
            if (LogOrError == Log)
            {
                var callerFileName = Path.GetFileNameWithoutExtension(callerFilePath);
                Console.WriteLine($"{callerFileName}.{callerMemberName}");
            }
            else
            {
                throw new Exception("Unable to connect to service");
            }
        }
    }
}