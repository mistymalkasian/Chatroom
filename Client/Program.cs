﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Client client = new Client("192.168.0.119", 14234);
            client.Send();
            client.Receive();

            Console.ReadLine();

        }

    }
}
