using System;
using System.IO;
using IntroCS;
using NUnit.Framework;

namespace CmdlineToFile.Tests;

public class CmdlineToFileTests
{
   [Test]
   public void WriteTextCreatesFileWithRequestedContents()
   {
      var tempFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

      try {
         const string contents = "Hello, world!";
         FileTest.WriteText(tempFile, contents);

         var text = File.ReadAllText(tempFile);
         Assert.That(text, Is.EqualTo(contents));
      }
      finally {
         if (File.Exists(tempFile)) {
            File.Delete(tempFile);
         }
      }
   }

   [Test]
   public void MainSetsExitCodeWhenArgumentsAreMissing()
   {
      Environment.ExitCode = 0;

      FileTest.Main([]);

      Assert.That(Environment.ExitCode, Is.EqualTo(1));
   }
}
