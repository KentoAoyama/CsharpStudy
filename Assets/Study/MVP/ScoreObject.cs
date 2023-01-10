using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

namespace MVP
{
    public class ModelObject : MonoBehaviour
    {
        private Subject<int> _score = new();

        //このインスタンスのScoreを参照できるようにする
        public IObservable<int> Score => _score;

        public void Finished()
        {
            var answer = UnityEngine.Random.Range(0, 10);

            _score.OnNext(answer);

            //適宜インスタンスを破棄する
            _score.Dispose();
        }


        private void OnDisable()
        {
            Finished();
        }
    }
}
