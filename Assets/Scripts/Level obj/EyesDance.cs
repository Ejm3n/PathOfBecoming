using System.Collections;
using UnityEngine;

public class EyesDance : MonoBehaviour
{
    [SerializeField] private GameObject _eye;
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    public void Start_Spawn()
    {
        StartCoroutine(Spawner());
    }

    public void Stop_Spawn()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            Instantiate(_eye, new Vector3(Random.Range(_collider.bounds.min.x, _collider.bounds.max.x), 
                Random.Range(_collider.bounds.min.y, _collider.bounds.max.y), 0), 
                Quaternion.identity, transform);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
