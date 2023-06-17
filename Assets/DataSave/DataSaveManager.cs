using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class DataSaveManager
{
    private static DataSaveManager _instance = new ();
    public static DataSaveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"Error! Please correct!");
            }
            return _instance;
        }
    }
    private DataSaveManager() { }

    /// <summary>
    /// �f�[�^�̃Z�[�u���s���N���X
    /// </summary>
    /// <typeparam name="T">�ۑ�����f�[�^�̌^</typeparam>
    /// <param name="targetObj">�ۑ�����f�[�^�i�K�� System.Serializable ����������j</param>
    /// <param name="fileName">�ۑ�����t�@�C���̖��O</param>
    public void Save<T>(T saveObj, string fileName)
    {
        StreamWriter writer;
        string path = Application.persistentDataPath + "/" + fileName + ".json";
        writer = new StreamWriter(path, false);

        string saveData = JsonUtility.ToJson(saveObj);

        writer.Write(saveData);
        writer.Flush();
        writer.Close();
    }

    /// <summary>
    /// �f�[�^�̃��[�h���s���N���X
    /// </summary>
    /// <typeparam name="T">�ǂݍ��ރf�[�^�̌^</typeparam>
    /// <param name="fileName">�ǂݍ��ރf�[�^�̃t�@�C�����i�Z�[�u�������Ɠ������́j</param>
    /// <returns>�ǂݍ��񂾃f�[�^</returns>
    public T Load<T> (string fileName)
    {
        StreamReader reader;
        reader = new StreamReader(Application.persistentDataPath + "/" + fileName + ".json");
        string data = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<T>(data);
    }
}
