using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EyesDance : MonoBehaviour
{
    [SerializeField] private GameObject[] _eyes;
    [SerializeField] private Collider2D[] _colliders;
    [SerializeField] private Light2D _light;
    [SerializeField] private AudioSource _musicTrack;
    [SerializeField] private AudioClip _changeTrack;

    const float timeToDie = 17f;
    const float intencityThreshold = 0.1f;
    private float startIntencity;

    private Coroutine _spawner;

    private void Awake()
    {
        startIntencity = _light.intensity;
    }

    public void Start_Spawn()
    {
        _spawner = StartCoroutine(Spawner());
    }

    public void Stop_Spawn()
    {
        if (_spawner != null)
            StopCoroutine(_spawner);
        _light.intensity = startIntencity;
        StartCoroutine(MusicFade(1.5f));
    }

    private IEnumerator Spawner()
    {
        float intencityChange = (_light.intensity - intencityThreshold) * 0.5f / (timeToDie * 0.9f);
        float startTime = Time.time;
        while (Time.time - startTime < timeToDie)
        {
            foreach (Collider2D collider in _colliders)
            {
                Instantiate(_eyes[Random.Range(0, _eyes.Length)], new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                            Random.Range(collider.bounds.min.y, collider.bounds.max.y), 0),
                            Quaternion.identity, transform);
            }
            _light.intensity -= intencityChange;
            yield return new WaitForSeconds(0.5f);
        }
        Engine.current.playerController.Die();
        _musicTrack.Stop();
    }

    private IEnumerator MusicFade(float timeToFade)
    {
        _musicTrack.volume = 1;
        float step = _musicTrack.volume / timeToFade;
        while (_musicTrack.volume > 0)
        {
            _musicTrack.volume -= step * Time.deltaTime;
            yield return null;
        }
        _musicTrack.volume = 1;
        SoundRecorder.Play_Music(_changeTrack);
    }
}
