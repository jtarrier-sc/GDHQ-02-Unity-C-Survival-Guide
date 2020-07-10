using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System.IO;

namespace UsingTheirs.WhichGitBranch
{

    public static class Styles
    {
        private static GUIStyle _linkButton;
        public static GUIStyle linkButton
        {
            get
            {
                if (_linkButton != null) return _linkButton;
                _linkButton = new GUIStyle(EditorStyles.label);
                _linkButton.richText = true;
                return _linkButton;
            }
        }

        private static Texture2D _windowIcon;
        public static Texture2D windowIcon
        {
            get
            {
                if (_windowIcon != null) return _windowIcon;
                _windowIcon = AssetDatabase.LoadAssetAtPath<Texture2D>( windowIconPath);
                return _windowIcon;
            }
        }

        private static string windowIconPath
        {
            get
            {
                return windowIconDirPath + "Window.png";
            }
        }

        private static string windowIconDirPath
        {
            get
            {
                var thisFilePath = new StackFrame(0, true).GetFileName();
                var dir = Path.GetDirectoryName(thisFilePath);
                var iconDirPath = Path.Combine(dir, ".." + Path.DirectorySeparatorChar + "Icon" + Path.DirectorySeparatorChar);
                iconDirPath = Path.GetFullPath(iconDirPath);  // Normalize
                var assetRootPath = Path.GetFullPath(Application.dataPath); // Normalize
                return "Assets" + iconDirPath.Substring(assetRootPath.Length); // Relative
            }
        }

        private static GUIStyle GetStyle( string styleName)
        {
            GUIStyle guiStyle = GUI.skin.FindStyle(styleName) ?? EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).FindStyle(styleName);
            if (guiStyle == null)
            {
                Logger.LogError("Style Not Found: " + styleName);
            }
            return guiStyle;
        }

        public static Texture2D MakeTex(int width, int height, Color col)
        {
            Color[] pix = new Color[width * height];

            for (int i = 0; i < pix.Length; i++)
                pix[i] = col;

            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();

            return result;
        }

    }

}
