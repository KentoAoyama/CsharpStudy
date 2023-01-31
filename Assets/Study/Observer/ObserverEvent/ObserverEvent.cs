using UnityEngine;

public class ObserverEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject _subjectPrefab;

    SubjectEvent _subject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //オブジェクトを生成し、そのSubjectコンポーネントを取得
            var go = Instantiate(_subjectPrefab);
            _subject = go.GetComponent<SubjectEvent>();

            // 監視対象が消えたらコールバック(監視対象を購読)
            _subject.OnFinished += Finished;

            // 監視対象を3秒後に削除
            Destroy(go, 3);
        }
    }

    // 監視対象からのコールバック
    private void Finished(int value)
    {
        Debug.Log($"Subjectからスコアが発行されました。Scoreは｛{value}｝です");
    }

    private void OnDisable()
    {
        _subject.OnFinished -= Finished;
    }
}
