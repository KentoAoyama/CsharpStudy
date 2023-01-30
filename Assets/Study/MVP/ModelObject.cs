using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

namespace MVP
{
    public class ModelObject : MonoBehaviour
    {
        private ReactiveProperty<int> _score = new();

        //このインスタンスのScoreを参照できるようにする
        public IReadOnlyReactiveProperty<int> Score => _score;

        public void Finished()
        {
            var answer = UnityEngine.Random.Range(0, 10);

            _score.Value = answer;

            //適宜インスタンスを破棄する
            _score.Dispose();
        }


        private void OnDisable()
        {
            Finished();
        }
    }
}
