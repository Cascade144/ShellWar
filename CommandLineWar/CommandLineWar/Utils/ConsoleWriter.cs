// Written by Gustavo N. Chavez, All rights reserved
// Copyright © Gustavo N. Chavez

namespace CommandLineWar.Utils
{
    /// <summary>
    /// A singleton ConsoleWriter.
    /// </summary>
    public sealed class ConsoleWriter
    {
        /// <summary>
        /// The variable storing the object reference.
        /// </summary>
        private static ConsoleWriter instance = null;

        /// <summary>
        /// Locking object to make singleton thread safe.
        /// </summary>
        private static readonly object padlock = new object();

        /// <summary>
        /// A singleton ConsoleWriter.
        /// </summary>
        public static ConsoleWriter Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ConsoleWriter();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// Writes a line to the standard console output stream.
        /// </summary>
        /// <param name="line"></param>
        public static void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
