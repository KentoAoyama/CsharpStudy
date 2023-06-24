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
        GUILayout.Label("���낢��G�f�B�^�[�g���ɂ��Ē��ׂĂ��܂�", EditorStyles.boldLabel);
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // �E�B���h�E��GUI���쐬����
        if (GUILayout.Button("�{�^��"))
        {
            // �{�^�����N���b�N���ꂽ���̏���
            // �����ɏ������e���L�q���܂�
        }
    }
}