using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimationController _animationController;

    public event UnityAction<int> GettingDiamond;
    public event UnityAction Finished;
    public event UnityAction Restarting;
    public event UnityAction GotJumpBonus;

    public void SlowDownTime()
    {
        StartCoroutine(SlowingDownTime());
    }

    private IEnumerator SlowingDownTime()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(3.5f);
        Time.timeScale = 1f;

    }

    public void Fall()
    {
        _animationController.Fall();
        Restarting?.Invoke();
    }
    
    public void ChampionFlip()
    {
        _animationController.ChampionFlip();
    }
    
    public void BonusFlip()
    {
        _animationController.BonusFlip();
    }

    public void TakeDiamond(int points)
    {      
        GettingDiamond?.Invoke(points);
    }
    
    public void FinishGame()
    {      
        Finished?.Invoke();
    }

    public void GetJumpBonus()
    {
        GotJumpBonus?.Invoke();
    }
}
