using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Purpose _target;
    [SerializeField] private float _sleepTime = 1.0f;
    private ObjectPool<Enemy> _pool;
    private Coroutine _coroutine;

    private void Awake()
    {
        _pool = CreatePool();
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Repeating(_sleepTime));
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Repeating(float sleepTime)
    {
        while (true)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(sleepTime);
        }
    }

    private void SpawnEnemy()
    {
        _pool.Get();
    }

    private ObjectPool<Enemy> CreatePool()
    {
        return new ObjectPool<Enemy>(
            CreateEnemy,
            EnemyActivation,
        enemy => { enemy.gameObject.SetActive(false); },
        enemy => { Destroy(enemy.gameObject); }
        );
    }

    private Enemy CreateEnemy()
    {
        Enemy newEnemy = Instantiate<Enemy>(_prefab);
        newEnemy.Initialize(_material, _target, _pool.Release);
        return newEnemy;
    }

    private void EnemyActivation(Enemy enemy)
    {
        enemy.transform.position = transform.position;
        enemy.gameObject.SetActive(true);
    }
}
