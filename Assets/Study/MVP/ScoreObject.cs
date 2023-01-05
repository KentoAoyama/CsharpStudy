using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MVP
{
    public class ScoreObject : MonoBehaviour
    {
        Model _model = new();

        //Model��Score���Q�Ƃł���悤�ɂ���
        public IObservable<int> Score => _model.Score;

        private void OnDisable()
        {
            _model.Finished();
        }
    }
}
