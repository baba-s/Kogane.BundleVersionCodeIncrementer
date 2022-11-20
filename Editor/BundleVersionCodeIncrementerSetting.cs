using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "UserSettings/Kogane/BundleVersionCodeIncrementerSetting.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class BundleVersionCodeIncrementerSetting : ScriptableSingleton<BundleVersionCodeIncrementerSetting>
    {
        [SerializeField] private bool m_isEnable;

        public bool IsEnable => m_isEnable;

        public void Save()
        {
            Save( true );
        }
    }
}