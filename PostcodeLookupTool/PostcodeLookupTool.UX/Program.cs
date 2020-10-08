using Microsoft.Extensions.CommandLineUtils;
using PostcodeLookupTool.Helpers;
using PostcodeLookupTool.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PostcodeLookupTool.UX
{
    public class Program
    {
        /// <summary>
        /// Example arguments: "ME10 3"; First argmument is a string from the sample dataset;
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            PostcodeLookup postcodeLookup = new PostcodeLookup();

            for (int i = 0; i < args.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        foreach (string s in postcodeLookup.GetValidDeliveryOptions(args[i]))
                        {
                            Console.WriteLine(s);
                        }

                        break;
                }
            }
        }
    }
}
