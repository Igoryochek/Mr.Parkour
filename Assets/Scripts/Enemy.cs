using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private AnimationController _animationController;


    public void Move(Player player)
    {
        _enemyMovement.MoveTo(player);
    }

    public void Fall()
    {
        _animationController.Fall();
    }

    public void Kick()
    {
        _animationController.Hit();
    }
    
    public void Flip()
    {
        _animationController.Flip();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Kick();
        }
    }

    public void SetSpeed(float speed)
    {
        _enemyMovement.SetSpeed(speed);
    }
}
