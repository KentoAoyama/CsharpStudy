using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsDataController : MonoBehaviour
{
    [SerializeField]
    private IntValueSaveTest[] _buttons = default;

    [SerializeField]
    private DataSaveTest _dataSave = default;

    [SerializeField]
    private Button _resetButton;

    /// <summary>
    /// ����ۑ�����t�@�C���̖��O
    /// </summary>
    private const string FILE_NAME = "test";

    /// <summary>
    /// ����ۑ�����f�[�^
    /// Serializable�������������Ȃ��ƃ_��
    /// </summary>
    [System.Serializable]
    public struct ButtonData
    {
        public int[] nums;
    }

    private void Start()
    {
        DataLoad();

        //���Z�b�g���������Z�b�g�{�^���ɒǉ�
        _resetButton?.onClick.AddListener(DataReset);
    }

    /// <summary>
    /// �f�[�^�̃��[�h���s���N���X
    /// </summary>
    private void DataLoad()
    {
        ButtonData buttonData = _dataSave.Load(FILE_NAME);
        //�f�[�^��ǂݍ��߂Ȃ�������f�[�^��0�����Ă���
        if (buttonData.nums == null)
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].Initialize(0);
            }
        }
        //�ǂݍ��߂���f�[�^���{�^���ɓn��
        else
        {
            for (int j = 0; j < _buttons.Length; j++)
            {
                _buttons[j].Initialize(buttonData.nums[j]);
            }
        }
    }

    private void OnDisable()
    {
        DataSave();
    }

    /// <summary>
    /// �f�[�^�̕ۑ����s���N���X
    /// </summary>
    private void DataSave()
    {
        var data = new ButtonData
        {
            nums = new int[5]
        };

        for (int k = 0; k < _buttons.Length; k++)
        {
            //���ꂼ��̃{�^�������l���\���̂ɓn��
            data.nums[k] = _buttons[k].CurrentValue;
        }

        _dataSave.Save(data, FILE_NAME);
    }

    /// <summary>
    /// �f�[�^��S��0�Ƀ��Z�b�g����
    /// </summary>
    private void DataReset()
    {
        var data = new ButtonData
        {
            nums = new int[5]
        };

        for (int l = 0; l < _buttons.Length; l++)
        {
            _buttons[l].SetValue(0);
        }

        _dataSave.Save(data, FILE_NAME);
    }
}
