using System.Diagnostics;
using System.Text.RegularExpressions;
using Debug = UnityEngine.Debug;

namespace UsingTheirs.WhichGitBranch
{
    public static class GitCommand
    {
        public static string GetGitInfo()
        {
            string stdError;
            string output = RunProcess(SettingsWindow.GetGitBinPath(), "show-branch --reflog=1", out stdError);

            Logger.Log("[GitCommand] git show-branch: STDOUT\n" + output);
            Logger.Log("[GitCommand] git show-branch: STDERR\n" + stdError);

            if (!string.IsNullOrEmpty(stdError))
                throw new System.Exception(stdError);

            string gitBranch = output;
            string localPath = System.IO.Path.GetFullPath(".");

            return string.Format("WORK: {0}\nBRANCH:{1}", localPath, gitBranch);
        }

        public static string Parse(string svnInfoOutput, string regex)
        {
            var regExpr = new Regex(regex);
            var match = regExpr.Match(svnInfoOutput);
            if (match.Groups.Count < 2 || match.Groups[1].Captures.Count < 1)
            {
                Logger.LogError("[GitCommand] Failed to parse. regex:" + regex);
                throw new System.Exception("Failed to parse");
            }

            return match.Groups[1].Captures[0].ToString();
        }

        public static string RunProcess(string exePath, string args, out string stdError)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            stdError = proc.StandardError.ReadToEnd();
            return proc.StandardOutput.ReadToEnd();
        }
    }
}
