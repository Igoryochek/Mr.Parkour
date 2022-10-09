using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private PlayerMovement _playerMovement;

    private int _crystalsCount;
    private int _startCrystalsCount;
    private Coroutine _falling;

    public int CrystalsCount => _crystalsCount;
    public int StartCrystalsCount => _startCrystalsCount;

    public event UnityAction<int> GotDiamond;
    public event UnityAction GotHealth;
    public event UnityAction GotHourGlass;
    public event UnityAction LostHealth;
    public event UnityAction Finished;
    public event UnityAction Restarting;
    public event UnityAction GotJumpBonus;
    public event UnityAction GotShieldJumpBonus;
    public event UnityAction<Transform> ChangedPosition;

    public void SlowDownTime(float time)
    {
        StartCoroutine(SlowingDownTime(time));
        GetHourGlass();
    }

    private IEnumerator SlowingDownTime(float time)
    {
        Time.timeScale = 0.5f;
        _playerMovement.SetJumpForce(time);
        yield return new WaitForSeconds(time);
        Time.timeScale = 1f;

    }

    public void Fall()
    {
        if (_falling==null)
        {
            _falling = StartCoroutine(Falling());
        }
    }

    private IEnumerator Falling()
    {
        RemoveHealth();
        _animationController.Fall();
        yield return new WaitForSeconds(1);
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
    
    public void SideFlip()
    {
        _animationController.SideFlip();
    }

    public void TakeDiamond(int crystalsCount)
    {      
        GotDiamond?.Invoke(crystalsCount);
    }
    
    public void TakeHealth()
    {      
        GotHealth?.Invoke();
    }
    
    private void RemoveHealth()
    {      
        LostHealth?.Invoke();
    }
    
    public void FinishGame()
    {      
        Finished?.Invoke();
    }
    
    public void GetHourGlass()
    {      
        GotHourGlass?.Invoke();
    }

    public void GetJumpBonus()
    {
        GotJumpBonus?.Invoke();
    }
    
    public void GetShieldJumpBonus()
    {
        GotShieldJumpBonus?.Invoke();
    }
    
    public void GetChangingPosition(Transform target)
    {
        ChangedPosition?.Invoke(target);
    }

    public float Speed()
    {
        float speed=GetComponent<PlayerMovement>().Speed;
        return speed;
    }
}
