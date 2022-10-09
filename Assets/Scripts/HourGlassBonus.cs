using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlassBonus : Bonus
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _enemySpeed;

    private Enemy _enemy;

    public void StartHourGlass(Player player)
    {
        _enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
        _enemy.transform.LookAt(transform);
        Kick(player);
    }

    private void Kick(Player player)
    {
        _enemy.SetSpeed(player.Speed()-1f);
        _enemy.Move(player);
        _enemy.Kick();
        player.SlowDownTime(LifeTime);
        gameObject.SetActive(false);



    }
}
