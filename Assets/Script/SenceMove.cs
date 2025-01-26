using UnityEngine;
using UnityEngine.Playables; // ใช้สำหรับ Timeline
using UnityEngine.SceneManagement; // ใช้สำหรับเปลี่ยน Scene

public class SenceMove : MonoBehaviour
{
    public PlayableDirector playableDirector; // Drag Timeline PlayableDirector เข้ามาใน Inspector
    public string nextSceneName; // กำหนดชื่อ Scene ถัดไปใน Inspector

    void Start()
    {
        if (playableDirector != null)
        {
            // สมัคร Event เมื่อ Timeline จบ
            playableDirector.stopped += OnTimelineFinished;
        }
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        // เมื่อ Timeline จบ ให้เปลี่ยน Scene
        SceneManager.LoadScene(nextSceneName);
    }

    void OnDestroy()
    {
        if (playableDirector != null)
        {
            // ลบ Event เมื่อ Object ถูกทำลาย
            playableDirector.stopped -= OnTimelineFinished; 
        }
    }
}