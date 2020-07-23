using UnityEngine;
using UnityEditor;

namespace UsingTheirs.WhichGitBranch
{
    public class SettingsWindow : EditorWindowBase
    {
        #if UNITY_EDITOR_WIN
        static readonly string defaultGitPath = System.Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Local\Atlassian\SourceTree\git_local\bin\git.exe");
        #elif UNITY_EDITOR_OSX
        static readonly string defaultGitPath = @"/usr/bin/git";
        #else
        static readonly string defaultGitPath = @"Type a git path here";
        #endif

        string gitPath;
        string testStdOut;

        public static void Popup()
        {
            SettingsWindow window = (SettingsWindow)EditorWindow.GetWindow(typeof(SettingsWindow));
            window.Show();
        }

        public static string GetGitBinPath()
        {
            return EditorPrefs.GetString("GitInfo_BinPath", defaultGitPath);
        }

        static void SetGitBinPath(string path)
        {
            EditorPrefs.SetString("GitInfo_BinPath", path);
        }

        void OnEnable()
        {
            gitPath = GetGitBinPath();
        }

        bool needToSetTitle = true;
        void SetTitle()
        {
            if (needToSetTitle)
            {
                titleContent = new GUIContent("Git Settings", Styles.windowIcon);
                needToSetTitle = false;
            }
        }

        void OnGUI()
        {
            SetTitle();

            gitPath = EditorGUILayout.TextField(gitPath);

            GUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("Reset"))
                {
                    gitPath = defaultGitPath;
                    // If the text field has focus, the editing text is not updated.
                    GUI.FocusControl(null);
                    Repaint();
                }

                if (GUILayout.Button("Test"))
                    OnTest();

                if (GUILayout.Button("OK"))
                {
                    SetGitBinPath(gitPath);
                    Close();
                }
            }
            GUILayout.EndHorizontal();

            if (!string.IsNullOrEmpty(testStdOut))
                EditorGUILayout.HelpBox(testStdOut, MessageType.Info);

            base.ShowHelpMessage();
        }

        void OnTest()
        {
            try
            {
                string testStdErr;
                testStdOut = GitCommand.RunProcess(gitPath, "show-branch -a", out testStdErr);
                Repaint();

                Logger.Log("[SettingsWindow] svn info : STDOUT\n" + testStdOut);
                Logger.Log("[SettingsWindow] svn info : STDERR\n" + testStdErr);

                base.SetHelpMessage(testStdErr, MessageType.Error);
            }
            catch( System.Exception e )
            {
                base.SetHelpMessage(e.Message, MessageType.Error);
            }
        }
    }
} 