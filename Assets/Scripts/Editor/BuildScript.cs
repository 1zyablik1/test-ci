using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Android;
using UnityEngine;

public class BuildScript : MonoBehaviour
{
    public static void BuildAndroid()
    {
        // Get the current build target
        BuildTarget currentBuildTarget = EditorUserBuildSettings.activeBuildTarget;

        // Change the build target to Android
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);

        // Set the build options
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = EditorBuildSettings.scenes.Select(s => s.path).ToArray(),
            locationPathName = "./Builds/Android/my_game.apk",
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        // Build the player
        BuildPipeline.BuildPlayer(buildPlayerOptions);

        // Change the build target back to the original
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Unknown, currentBuildTarget);
    }
    
    public static void BuildIos()
    {
        // Get the current build target
        BuildTarget currentBuildTarget = EditorUserBuildSettings.activeBuildTarget;

        // Change the build target to iOS
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.iOS, BuildTarget.iOS);

        EditorUserBuildSettings.development = true;
        EditorUserBuildSettings.allowDebugging = true;
        
        // Set the build options
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = EditorBuildSettings.scenes.Select(s => s.path).ToArray(),
            locationPathName = "./Builds/iOS/my_game",
            target = BuildTarget.iOS,
            options = BuildOptions.None
        };

        // Build the player
        BuildPipeline.BuildPlayer(buildPlayerOptions);

        // Change the build target back to the original
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Unknown, currentBuildTarget);
    }
}
