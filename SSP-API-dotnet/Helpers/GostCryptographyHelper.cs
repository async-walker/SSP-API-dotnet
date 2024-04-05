﻿using System.Diagnostics;
using System.Text;

namespace SSP_API.Helpers
{
    internal static class GostCryptographyHelper
    {
        public static string SignMessage(string exe, string subjectName, string inMessagePath)
        {
            var outMessagePath = $"{inMessagePath}.p7s";

            var cmd = $"{exe} CMS.StreamSign {subjectName} {inMessagePath} {outMessagePath}";

            RunProcessCMD(cmd);

            return outMessagePath;
        }

        public static string VerifyMessage(string exe, string inMessagePath)
        {
            var outMessagePath = inMessagePath.Remove(inMessagePath.Length - 4);

            var cmd = $"{exe} CMS.StreamVerify {inMessagePath} {outMessagePath}";

            RunProcessCMD(cmd);

            return outMessagePath;
        }

        static string RunProcessCMD(string cmd)
        {
            var processInfo = new ProcessStartInfo()
            {
                StandardErrorEncoding = Encoding.GetEncoding(866),
                StandardOutputEncoding = Encoding.GetEncoding(866),
                UseShellExecute = false,
                FileName = "cmd.exe",
                Arguments = $"/c {cmd}",
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            };

            var process = new Process
            {
                StartInfo = processInfo
            };

            process.Start();

            var log = string.Empty;

            while (!process.StandardOutput.EndOfStream)
            {
                log += process.StandardOutput.ReadToEnd();
                log += process.StandardError.ReadToEnd();
            }

            process.WaitForExit();
            process.Kill();

            return log;
        }
    }
}
