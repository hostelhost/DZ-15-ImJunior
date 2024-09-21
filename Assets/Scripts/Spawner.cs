using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Player _prefab;
    [SerializeField] private Purpose _target;
    [SerializeField] private float _sleepTime = 1.0f;
    private ObjectPool<Player> _pool;

    private void Start()
    {
        _pool = CreatePool();
        InvokeRepeating(nameof(SpawnPlayer), _sleepTime, _sleepTime);
    }

    private void SpawnPlayer()
    {
        _pool.Get();
    }

    private ObjectPool<Player> CreatePool()
    {
        return new ObjectPool<Player>(
            CreatePlayer,
            GetPlayer,
        player => { player.gameObject.SetActive(false); },
        player => { Destroy(player.gameObject); }
        );
    }

    private Player CreatePlayer()
    {
        Player newPlayer = Instantiate<Player>(_prefab);
        newPlayer.Initialize(_material, _target, _pool.Release);
        return newPlayer;
    }

    private void GetPlayer(Player player)
    {
        player.gameObject.SetActive(true);
        player.transform.position = transform.position;
    }
}
