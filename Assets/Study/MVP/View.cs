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

        //受け取った値をTextに反映させる
        public void SetScore(int score)
        {
            _text.text = score.ToString();

            Debug.Log($"スコアが発行されました。Scoreは｛{score}｝です");
        }
    }
}
