using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private bool juicy = true;
    [SerializeField] private int hitpoints = 5;
    [SerializeField] private float blinkTime = 0.1f;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip dieSound;


    private CameraShake _cameraShake;
    private Material _mat;
    private Color _originalColor;
    private HitEffect _hitEffect;

    private void Start()
    {
        _mat = GetComponent<MeshRenderer>().material;
        _originalColor = _mat.color;
        _hitEffect = GetComponentInChildren<HitEffect>();
        _cameraShake = FindObjectOfType<CameraShake>();
    }

    public void ReceiveDamage(int amount)
    {
        hitpoints -= amount;
        if (hitpoints <= 0)
        {
            Die();
            if (juicy)
            {
                AudioSource.PlayClipAtPoint(dieSound, Camera.main.transform.position);
            }
        }
        else
        {
            if (juicy)
            {
                StartCoroutine(Blink());
                _hitEffect.PlayHit();
                AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
            }
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
        if (_cameraShake != null)
        {
            _cameraShake.Shake();
        }
    }

    private IEnumerator Blink()
    {
        _mat.color = Color.white;
        yield return new WaitForSeconds(blinkTime);
        _mat.color = _originalColor;
    }
}
