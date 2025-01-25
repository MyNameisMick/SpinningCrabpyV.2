using UnityEngine;
using UnityEngine.UI;

public class Aim2 : MonoBehaviour
{
    //public Camera cam;
    //public Image aimPoint; // UI Image �ͧ Aim Point
    //public float maxDistance = 100f;

    //void Update()
    //{
    //    Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // ��ҧ˹�Ҩ�
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit, maxDistance))
    //    {
    //        // ���� Aim Point 价����˹觷�� Raycast ��
    //        aimPoint.transform.position = cam.WorldToScreenPoint(hit.point);
    //    }
    //    else
    //    {
    //        // �ҡ��誹���� ������� Aim Point 价����˹��� �
    //        aimPoint.transform.position = cam.WorldToScreenPoint(ray.GetPoint(maxDistance));
    //    }
    //}

    public Camera cam;
    public Image aimPoint; // UI Image �ͧ Aim Point

    void Update()
    {
        // ��� Aim Point �����ҧ˹�Ҩ�����
        aimPoint.transform.position = cam.WorldToScreenPoint(cam.transform.position + cam.transform.forward * 100f);
    }
}
