using UnityEngine;
using UnityEngine.Playables; // ������Ѻ Timeline
using UnityEngine.SceneManagement; // ������Ѻ����¹ Scene

public class SenceMove : MonoBehaviour
{
    public PlayableDirector playableDirector; // Drag Timeline PlayableDirector ������ Inspector
    public string nextSceneName; // ��˹����� Scene �Ѵ�� Inspector

    void Start()
    {
        if (playableDirector != null)
        {
            // ��Ѥ� Event ����� Timeline ��
            playableDirector.stopped += OnTimelineFinished;
        }
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        // ����� Timeline �� �������¹ Scene
        SceneManager.LoadScene(nextSceneName);
    }

    void OnDestroy()
    {
        if (playableDirector != null)
        {
            // ź Event ����� Object �١�����
            playableDirector.stopped -= OnTimelineFinished; 
        }
    }
}