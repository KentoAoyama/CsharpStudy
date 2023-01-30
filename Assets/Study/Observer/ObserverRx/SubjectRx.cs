using UnityEngine;
using UniRx;

public class SubjectRx : MonoBehaviour
{
    private ReactiveProperty<int> _subjectUniRx = new();

    //���̃C���X�^���X��ReactiveProperty���Q�Ƃł���悤�ɂ���
    public IReadOnlyReactiveProperty<int> SubjectUniRx => _subjectUniRx;

    private void OnDisable()
    {
        var answer = Random.Range(0, 10);

        //�l��ύX����
        _subjectUniRx.Value = answer;

        //�K�X�C���X�^���X��j������
        _subjectUniRx.Dispose();
    }
}
