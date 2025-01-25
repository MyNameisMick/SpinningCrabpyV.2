using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassButtonPlayAnim : MonoBehaviour
{
    public Animator animator; // ลิงก์กับ Animator
    
    public void PlayAnimation(string NameTriggerAnim)
    {
        if (animator != null)
        {
            animator.SetTrigger(NameTriggerAnim);
        }
    }
}
