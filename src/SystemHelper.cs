/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceição Nº 11903
 * Gonçalo Lampreia Nº 11906
 * https://code.google.com/p/eda12131190311906/
 */

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace eda12131190311906
{
    /// <summary>
    /// System Helper Utilities
    /// </summary>
    public sealed class SystemHelper {
        /// <summary>
        /// Get program files X86 path, windows only
        /// </summary>
        /// <returns>Program files X86 path</returns>
        public static string GetProgramFilesX86Path()
        {
            if (!IsWindows())
            {
                return string.Empty;
            }
            if (8 == IntPtr.Size
            || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }
            return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        }

        /// <summary>
        /// Is windows OS
        /// </summary>
        /// <returns>True if Windows, otherwise false</returns>
        public static bool IsWindows()
        {
            return !string.IsNullOrEmpty(Environment.GetFolderPath(Environment.SpecialFolder.Programs));
        }

        /// <summary>
        /// Is UNIX OS
        /// </summary>
        /// <returns>True if Unix, otherwise false</returns>
        public static bool IsUnix()
        {
                var p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
        }

        /// <summary>
        /// Generate a random integer array
        /// </summary>
        /// <param name="size">Size of array</param>
        /// <param name="maxValue">Max value for random numbers</param>
        /// <returns>An array populated with random values</returns>
        public static int[] RandomIntegerArray(int size, int maxValue)
        {
            return RandomIntegerArray(size, 1, maxValue);
        }

        /// <summary>
        /// Generate a random integer array
        /// </summary>
        /// <param name="size">Size of array</param>
        /// <param name="minValue">Min value for random numbers</param>
        /// <param name="maxValue">Max value for random numbers</param>
        /// <returns>An array populated with random values</returns>
        public static int[] RandomIntegerArray(int size, int minValue, int maxValue)
        {
            var rand = new Random();
            var A = new int[size];
            for (int i = 0; i < size; i++)
            {
                int number = rand.Next(minValue, maxValue);
                A[i] = number;
            }
            return A;
        }

        /// <summary>
        /// Clone an List int[]
        /// </summary>
        /// <param name="list">list List to clone</param>
        /// <returns>Cloned list</returns>
        public static List<int[]> CloneListIntArray(List<int[]> list)
        {
            return list.Select(A => (int[]) A.Clone()).ToList();
        }

        /// <summary>
        /// Convert an array to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ArrayToString<T>(T[] list)
        {
            return ArrayToString(list, 20000);
        }

        /// <summary>
        /// Convert an array to string
        /// </summary>
        /// <typeparam name="T">Array class</typeparam>
        /// <param name="list">List with arrays</param>
        /// <param name="limit">Elements limit to output to string</param>
        /// <returns>A formated string</returns>
        public static string ArrayToString<T>(T[] list, int limit)
        {
            /*string result = list.Aggregate("[", (current, element) => current + (element.ToString() + ", "));
            result = result.Remove(result.Length - 2, 2);
            result += "]";*/
            string result = "[";
            for (int i = 0; i < list.Length; i++)
            {
                if (i >= limit)
                {
                    result += "..., ";
                    break;
                }
                result += string.Format("{0}, ", list[i]);
            }
            result = string.Format("{0}]", result.Remove(result.Length - 2, 2));
            return result;
        }

        /// <summary>
        /// Open website link
        /// </summary>
        /// <param name="address">URL address</param>
        public static void OpenLink(string address)
        {
            try
            {
                if (!IsUnix())
                {
                    // Use Microsoft's way of opening sites
                    using(Process.Start(address))
                    {}
                }
                else
                {
                    // We're on Unix, try gnome-open (used by GNOME), then open
                    // (used my MacOS), then Firefox or Konqueror browsers (our last
                    // hope).
                    string cmdline = string.Format("xdg-open {0} || gnome-open {0} || open {0} || " +
                        "chromium-browser {0} || mozilla-firefox {0} || firefox {0} || konqueror {0}", address);
                    using (TextWriter textWriter = new StreamWriter("tempopenlink.sh"))
                    {
                        textWriter.WriteLine(cmdline);
                        textWriter.WriteLine("rm -f tempopenlink.sh");
                        textWriter.Close();
                    }
                    using (Process proc = new Process())
                    {
                        proc.StartInfo.FileName = "sh";
                        proc.StartInfo.Arguments = "tempopenlink.sh";
                        proc.Start();
                        proc.Close();
                    }
                }
            }
            catch (Exception e)
            {
                // We don't want any surprises
                return;
            }
        }
    }
}
