using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Flip()
    {
        _animator.SetTrigger("Flip");
    }
    
    public void ChampionFlip()
    {
        _animator.SetTrigger("ChampionFlip");
    }
    
    public void BonusFlip()
    {
        _animator.SetTrigger("BonusFlip");
    }
    
    public void SideFlip()
    {
        _animator.SetTrigger("SideFlip");
    }
    
    public void Fall()
    {
        _animator.SetTrigger("Fall");
    }
    
    public void Hit()
    {
        _animator.SetTrigger("Hit");
    }
}
