using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace UsingTheirs.WhichGitBranch
{

    public class EditorWindowBase : EditorWindow
    {
        #region Help Message
        string helpMessage;
        MessageType helpMessageType;
        double lastMessageTime;
        int lastMessageIndex;
        const float minHelpMessageShowSec = 0.1f;

        protected void ShowHelpMessage()
        {
            if (!string.IsNullOrEmpty(helpMessage))
            {
                EditorGUILayout.HelpBox(helpMessage, helpMessageType);
            }
        }

        protected bool HasErrorMessage()
        {
            return !string.IsNullOrEmpty(helpMessage) && helpMessageType == MessageType.Error;
        }

        protected void SetHelpMessage(string message, MessageType type)
        {
            helpMessage = message;
            helpMessageType = type;
            lastMessageTime = EditorApplication.timeSinceStartup;
            lastMessageIndex++;
            Repaint();
        }

        protected void ClearHelpMessage()
        {
            if (EditorApplication.timeSinceStartup - lastMessageTime >= minHelpMessageShowSec)
            {
                ClearHelpMessageImpl();
            }
            else
            {
                EditorCoroutine.Start(DelayedClearHelpMessage(lastMessageIndex));
            }

        }

        IEnumerator DelayedClearHelpMessage(int clearMessageIndex)
        {
            yield return new EditorCoroutine.CustomWaitForSeconds(minHelpMessageShowSec);

            if (clearMessageIndex == lastMessageIndex)
                ClearHelpMessageImpl();
        }

        void ClearHelpMessageImpl()
        {
            helpMessage = null;
            Repaint();
        }
        #endregion

        #region Link
        protected void ShowLink()
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Kinds", EditorStyles.miniButton))
                Application.OpenURL(Consts.kKindsAssetStoreUrlLite);

            GUILayout.FlexibleSpace();

            GUILayout.Label(string.Format("Ver {0}", Consts.kVersion), EditorStyles.miniLabel);

            if (GUILayout.Button("Online Doc", EditorStyles.miniButton))
                Application.OpenURL(Consts.kOnlineDocUrl);

            if (GUILayout.Button("Review", EditorStyles.miniButton))
                Application.OpenURL(Consts.kAssetStoreReviewUrl);

            EditorGUILayout.EndHorizontal();
        }
        #endregion
    }
}