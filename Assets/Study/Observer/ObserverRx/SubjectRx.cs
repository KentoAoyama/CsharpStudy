using UnityEngine;
using UniRx;

public class SubjectRx : MonoBehaviour
{
    private ReactiveProperty<int> _subjectUniRx = new();

    //このインスタンスのReactivePropertyを参照できるようにする
    public IReadOnlyReactiveProperty<int> SubjectUniRx => _subjectUniRx;

    private void OnDisable()
    {
        var answer = Random.Range(0, 10);

        //値を変更する
        _subjectUniRx.Value = answer;

        //適宜インスタンスを破棄する
        _subjectUniRx.Dispose();
    }
}
