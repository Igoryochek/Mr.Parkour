using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Player _player;



    private void Start()
    {
        StartCoroutine(SpawningEnemies());
    }

    private IEnumerator SpawningEnemies()
    {
        yield return new WaitForSeconds(0.2f);
        foreach (var point in _points)
        {
            Enemy enemy=Instantiate(_enemyPrefab, point.position, Quaternion.identity);
            enemy.Move(_player);
        }
    }
}
