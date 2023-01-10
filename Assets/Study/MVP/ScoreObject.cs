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

        //���̃C���X�^���X��Score���Q�Ƃł���悤�ɂ���
        public IObservable<int> Score => _score;

        public void Finished()
        {
            var answer = UnityEngine.Random.Range(0, 10);

            _score.OnNext(answer);

            //�K�X�C���X�^���X��j������
            _score.Dispose();
        }


        private void OnDisable()
        {
            Finished();
        }
    }
}
