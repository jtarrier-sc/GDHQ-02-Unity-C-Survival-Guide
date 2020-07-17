using UnityEngine;
using UnityEditor;

namespace UsingTheirs.WhichGitBranch
{
    public class InfoWindow : EditorWindowBase
    {
        [MenuItem("Window/Using Theirs/Which GIT Branch?", false, 0)]
        static void Init()
        {
            var win = EditorWindow.GetWindow<InfoWindow>();
            win.Show();
        }

        string branchInfoText;

        bool needToSetTitle = true;
        void SetTitle()
        {
            if (needToSetTitle)
            {
                titleContent = new GUIContent("GIT Branch?", Styles.windowIcon);
                needToSetTitle = false;
            }
        }

        void OnGUI()
        {
            SetTitle();

            ShowToolbar();

            if (!base.HasErrorMessage())
                ShowInfo();

            base.ShowHelpMessage();

            GUILayout.FlexibleSpace();

            base.ShowLink();

        }

        void ShowToolbar()
        {
            GUILayout.BeginHorizontal(EditorStyles.toolbar);
            {
                if (GUILayout.Button("Refresh", EditorStyles.toolbarButton))
                {
                    base.ClearHelpMessage();
                    UpdateBranchInfo();
                }

                if (GUILayout.Button("Settings", EditorStyles.toolbarButton))
                    SettingsWindow.Popup();
            }
            GUILayout.EndHorizontal();
        }

        void ShowInfo()
        {
            GUILayout.Label(branchInfoText);
        }

        void OnEnable()
        {
            UpdateBranchInfo();
        }

        void UpdateBranchInfo()
        {
            try
            {
                branchInfoText = GitCommand.GetGitInfo();
            }
            catch(System.Exception e)
            {
                base.SetHelpMessage(e.Message, MessageType.Error);
            }
        }
    }
}
