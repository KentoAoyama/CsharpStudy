using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVP
{
    public class View : MonoBehaviour
    {
        [SerializeField]
        Text _text;

        //�󂯎�����l��Text�ɔ��f������
        public void SetScore(int score)
        {
            _text.text = score.ToString();

            Debug.Log($"�X�R�A�����s����܂����BScore�́o{score}�p�ł�");
        }
    }
}
