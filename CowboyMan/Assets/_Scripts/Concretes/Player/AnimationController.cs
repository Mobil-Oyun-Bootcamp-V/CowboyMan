using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator _animator;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        GameManager.Instance.OnIsWalking += WalkingAnim;
        GameManager.Instance.OnIsRunning += SprintAnim;
        GameManager.Instance.OnIsSuperRunning += SuperSprintAnim;
        GameManager.Instance.OnIsDead += DeadAnim;
        GameManager.Instance.OnIsWin += WinAnim;
    }
    void OnDisable()
    {
        GameManager.Instance.OnIsWalking -= WalkingAnim;
        GameManager.Instance.OnIsRunning -= SprintAnim;
        GameManager.Instance.OnIsSuperRunning -= SuperSprintAnim;
        GameManager.Instance.OnIsDead -= DeadAnim;
        GameManager.Instance.OnIsWin -= WinAnim;
    }
    void WalkingAnim()
    {
        if (_animator == null) {
            Debug.LogError("Arýyor");
            _animator = GameObject.FindObjectOfType<Animator>();

        }
        _animator.SetTrigger("IsWalk");
        _animator.ResetTrigger("IsSprint");
        _animator.ResetTrigger("IsSuperSprint");
        _animator.ResetTrigger("IsDead");

    }
    void SprintAnim()
    {
        _animator.ResetTrigger("IsWalk");
        _animator.SetTrigger("IsSprint");
        _animator.ResetTrigger("IsSuperSprint");
    }
    void SuperSprintAnim()
    {   
        _animator.ResetTrigger("IsSprint");
        _animator.SetTrigger("IsSuperSprint");
    }
    void DeadAnim()
    {
        _animator.ResetTrigger("IsWalk");
        _animator.ResetTrigger("IsSprint");
        _animator.ResetTrigger("IsSuperSprint");
        _animator.SetTrigger("IsDead");
    }
    void WinAnim()
    {
        _animator.ResetTrigger("IsWalk");
        _animator.ResetTrigger("IsSprint");
        _animator.ResetTrigger("IsSuperSprint");
        _animator.SetTrigger("IsWin");
    }
}
