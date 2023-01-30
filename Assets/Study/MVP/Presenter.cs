using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MVP
{
    public class Presenter : MonoBehaviour
    {
        [Header("View")]
        [SerializeField]
        private View _view;

        [Header("Score�𔭍s����Model")]
        [SerializeField]
        private GameObject _scoreObject;


        void Update()
        {
            //�����Presenter���Ő����Ɣj�����s���Ă��邪�A���ۂ͂��܂�悭�Ȃ�
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //�I�u�W�F�N�g�𐶐����A���̃R���|�[�l���g���擾
                var scoreObject = Instantiate(_scoreObject);
                var score = scoreObject.GetComponent<ModelObject>();

                //�V�����Ď��Ώۂ��w�ǂ��A�l���ω������Ƃ��̏�����o�^����
                score.Score.Subscribe(i => _view.SetScore(i));

                //�Ď��Ώۂ�3�b��ɍ폜
                Destroy(scoreObject, 3.0f);
            }
        }
    }
}
