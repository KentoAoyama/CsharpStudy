using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace MVP
{
    public class Model
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
    }
}
