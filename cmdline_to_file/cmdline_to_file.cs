using System;
using System.IO;

namespace IntroCS
{
   public static class FileTest
   {
      public static void WriteText(string path, string contents)
      {
         using var outf = new StreamWriter(path);
         outf.Write(contents);
      }

      public static void Main(string[] args)
      {
         if (args.Length != 2) {
            Console.Error.WriteLine("Usage: cmdline_to_file <output-file> <contents>");
            Environment.ExitCode = 1;
            return;
         }

         WriteText(args[0], args[1]);
      }
   }
}
