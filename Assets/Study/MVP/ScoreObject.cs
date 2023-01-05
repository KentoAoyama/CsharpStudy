using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MVP
{
    public class ScoreObject : MonoBehaviour
    {
        Model _model = new();

        //Model‚ÌScore‚ğQÆ‚Å‚«‚é‚æ‚¤‚É‚·‚é
        public IObservable<int> Score => _model.Score;

        private void OnDisable()
        {
            _model.Finished();
        }
    }
}
