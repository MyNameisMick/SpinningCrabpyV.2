using UnityEngine;
using UnityEngine.UI;

public class Aim2 : MonoBehaviour
{
    //public Camera cam;
    //public Image aimPoint; // UI Image ของ Aim Point
    //public float maxDistance = 100f;

    //void Update()
    //{
    //    Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // กลางหน้าจอ
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit, maxDistance))
    //    {
    //        // ย้าย Aim Point ไปที่ตำแหน่งที่ Raycast ชน
    //        aimPoint.transform.position = cam.WorldToScreenPoint(hit.point);
    //    }
    //    else
    //    {
    //        // หากไม่ชนอะไร ให้ย้าย Aim Point ไปที่ตำแหน่งไกล ๆ
    //        aimPoint.transform.position = cam.WorldToScreenPoint(ray.GetPoint(maxDistance));
    //    }
    //}

    public Camera cam;
    public Image aimPoint; // UI Image ของ Aim Point

    void Update()
    {
        // ให้ Aim Point อยู่กลางหน้าจอเสมอ
        aimPoint.transform.position = cam.WorldToScreenPoint(cam.transform.position + cam.transform.forward * 100f);
    }
}
