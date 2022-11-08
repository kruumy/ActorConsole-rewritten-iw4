﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ActorConsole.Core.Memory
{
    public static class SendDvarQueue
    {
        private static List<string> Queue = new List<string>();
        public static int Count
        {
            get
            {
                return Queue.Count;
            }
        }
        internal static bool IsRunning { get; private set; }
        private static readonly int WaitTime = 1100;
        internal static void Add(string input)
        {
            Queue.Add(input);
            if (!IsRunning)
            {
                Task.Run(MainLoop);
            }
        }
        private static void MainLoop()
        {
            IsRunning = true;
            while (Queue.Count > 0)
            {
                string dvar = Queue.First();
                ExternalConsole.Send(dvar);
                Queue.Remove(dvar);
                System.Threading.Thread.Sleep(WaitTime);
            }
            IsRunning = false;
        }
    }
}
