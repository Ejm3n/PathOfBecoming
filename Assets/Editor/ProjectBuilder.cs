using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System;
using UnityEditor.Build.Reporting;

public class ProjectBuilder
{
    static EditorBuildSettingsScene[] Get_Scenes()
    {
        EditorBuildSettingsScene[] scenes;
        List<EditorBuildSettingsScene> sceneList = new List<EditorBuildSettingsScene>();
        foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
                sceneList.Add(scene);
            Debug.Log(scene.path);
        }
        scenes = sceneList.ToArray();
        return scenes;
    }

    public static void Build_Windows()
    {
        Debug.Log("Build started");
        Show_Summary(BuildPipeline.BuildPlayer(Get_Scenes(), Path.GetDirectoryName(Application.dataPath) + "/Builds/Windows/Play.exe", BuildTarget.StandaloneWindows, BuildOptions.None));
    }

    public static void Build_Android()
    {
        Debug.Log("Build started");
        Show_Summary(BuildPipeline.BuildPlayer(Get_Scenes(), Path.GetDirectoryName(Application.dataPath) + "/Builds/Android/BuildAndroid.apk", BuildTarget.Android, BuildOptions.None));
    }

    static void Show_Summary(BuildReport report)
    {
        if (report.summary.result == BuildResult.Succeeded)
            Debug.Log("Success: " + report.summary.platform + " " + report.summary.totalSize + " bytes");
        else if (report.summary.result == BuildResult.Failed)
            Debug.Log("Build failed");
    }

}
