using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    [SerializeField] private float strength = 5f;

    private float _countdown;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    public void Shake()
    {
        _countdown = duration;
        StartCoroutine(DoShake());
    }

    private IEnumerator DoShake()
    {
        while (_countdown > 0f)
        {
            Vector3 offset = new Vector3(Random.value, Random.value, Random.value);
            offset.Normalize();
            offset = offset * strength;
            transform.position = _startPosition + offset;

            _countdown -= Time.deltaTime;
            yield return null;
        }
        transform.position = _startPosition;
    }
}
