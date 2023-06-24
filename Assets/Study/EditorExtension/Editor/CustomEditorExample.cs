using UnityEditor;
using UnityEngine;

public class CustomWindowScript : EditorWindow
{
    [MenuItem("Window/EditorExtension/Custom Window")]
    public static void ShowWindow()
    {
        GetWindow<CustomWindowScript>("Custom Window");
    }

    private void OnGUI()
    {
        GUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("いろいろエディター拡張について調べています", EditorStyles.boldLabel);
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // ウィンドウのGUIを作成する
        if (GUILayout.Button("ボタン"))
        {
            // ボタンがクリックされた時の処理
            // ここに処理内容を記述します
        }
    }
}