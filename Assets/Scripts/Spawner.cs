using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Player _player;
    
    private float _playerSpeed;



    private void Start()
    {
        StartCoroutine(SpawningEnemies());
        _playerSpeed = _player.Speed();
    }

    private IEnumerator SpawningEnemies()
    {
        yield return new WaitForSeconds(0.2f);
        foreach (var point in _points)
        {
            Enemy enemy=Instantiate(_enemyPrefab, point.position, Quaternion.identity);
            enemy.SetSpeed(_playerSpeed+0.2f);
            enemy.Move(_player);
        }
    }
}
