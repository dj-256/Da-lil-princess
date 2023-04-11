using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LoopingAnimationController : MonoBehaviour
{
    public Animator animator;
    public string loopAnimationName;

    public string defaultState;
    
    private void ToggleLoopAnimation(bool enable)
    {
        if (enable)
        {
            animator.Play(loopAnimationName);
        }
        else
        {
            animator.Play(defaultState);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleLoopAnimation(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleLoopAnimation(false);
        }
    }

}
