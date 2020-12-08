#if UNITY_EDITOR

namespace Markdown.Markdig
{
    using System;
    using System.Linq;
    using UnityEditor;

    public static class DefineMarkdigPackage
    {
        public  static readonly string[] DEFINES = new string[] { "MARKDIG_PACKAGE" };

        [InitializeOnLoadMethod]
        private static void SetScriptingDefineSymbol()
        {
            var currentTarget = EditorUserBuildSettings.selectedBuildTargetGroup;
            
            if (currentTarget == BuildTargetGroup.Unknown)
                return;

            var definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup(currentTarget).Trim();
            var defines = definesString.Split(';');

            bool changed = false;

            foreach (var define in DEFINES)
            {
                if (!defines.Contains(define))
                {
                    if (!definesString.EndsWith(";", StringComparison.InvariantCulture))
                        definesString += ";";

                    definesString += define;
                    changed = true;
                }
            }

            if (changed)
            {
                PlayerSettings.SetScriptingDefineSymbolsForGroup(currentTarget, definesString);
            }
        }
    }
}

#endif
