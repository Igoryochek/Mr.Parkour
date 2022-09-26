using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlass : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _enemySpeed;

    private Enemy _enemy;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _enemy = Instantiate(_enemyPrefab,_spawnPoint.position,Quaternion.identity);
            _enemy.transform.LookAt(transform);
            Kick(player);
        }
    }

    private void Kick(Player player)
    {
        _enemy.SetSpeed(_enemySpeed);
        _enemy.Move(player);
        _enemy.Kick();
        player.SlowDownTime();
        gameObject.SetActive(false);



    }
}
