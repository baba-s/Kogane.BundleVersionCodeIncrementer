using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kogane.Internal
{
    internal sealed class BundleVersionCodeIncrementerSettingProvider : SettingsProvider
    {
        private const string PATH = "Kogane/Bundle Version Code Incrementer";

        private Editor m_editor;

        private BundleVersionCodeIncrementerSettingProvider
        (
            string              path,
            SettingsScope       scopes,
            IEnumerable<string> keywords = null
        ) : base( path, scopes, keywords )
        {
        }

        public override void OnActivate( string searchContext, VisualElement rootElement )
        {
            var instance = BundleVersionCodeIncrementerSetting.instance;

            instance.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            Editor.CreateCachedEditor( instance, null, ref m_editor );
        }

        public override void OnGUI( string searchContext )
        {
            using var changeCheckScope = new EditorGUI.ChangeCheckScope();

            var setting = BundleVersionCodeIncrementerSetting.instance;

            m_editor.OnInspectorGUI();

            if ( !changeCheckScope.changed ) return;

            setting.Save();
        }

        [SettingsProvider]
        private static SettingsProvider CreateSettingProvider()
        {
            return new BundleVersionCodeIncrementerSettingProvider
            (
                path: PATH,
                scopes: SettingsScope.Project
            );
        }
    }
}