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

        //���̃C���X�^���X��Score���Q�Ƃł���悤�ɂ���
        public IObservable<int> Score => _score;

        public void Finished()
        {
            var answer = UnityEngine.Random.Range(0, 10);

            _score.OnNext(answer);

            //�K�X�C���X�^���X��j������
            _score.Dispose();
        }
    }
}
