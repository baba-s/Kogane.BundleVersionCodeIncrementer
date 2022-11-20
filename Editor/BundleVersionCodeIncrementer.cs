using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace Kogane.Internal
{
    internal sealed class BundleVersionCodeIncrementer : IPostprocessBuildWithReport
    {
        public int callbackOrder => 0;

        void IPostprocessBuildWithReport.OnPostprocessBuild( BuildReport report )
        {
            if ( !BundleVersionCodeIncrementerSetting.instance.IsEnable ) return;

            var platform = report.summary.platform;

            switch ( platform )
            {
                case BuildTarget.iOS:
                    var number = int.Parse( PlayerSettings.iOS.buildNumber ) + 1;
                    PlayerSettings.iOS.buildNumber = number.ToString();
                    break;

                case BuildTarget.Android:
                    var code = PlayerSettings.Android.bundleVersionCode + 1;
                    PlayerSettings.Android.bundleVersionCode = code;
                    break;
            }
        }
    }
}