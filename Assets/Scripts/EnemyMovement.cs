using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Enemy _enemy;

    public void MoveTo(Player player)
    {
        StartCoroutine(MovingTo(player));
    }

    private IEnumerator MovingTo(Player player)
    {
        while (transform.position.z!=player.transform.position.z)
        {
            transform.position = Vector3.MoveTowards(transform.position,player.transform.position,_speed*Time.deltaTime);
            transform.LookAt(player.transform);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            _enemy.Flip();
        }
        
        if (other.TryGetComponent(out BigObstacles bigObstacles))
        {
            _enemy.Fall();
            _speed = 0;
        }
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
