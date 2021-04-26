using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private bool juicy = true;
    [SerializeField] private GameObject projectile;
    [SerializeField] private int firerate = 10;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private float shootVolume = 0.5f;

    private int _speed;
    private float _cooldown;


    private void Start()
    {
        _speed = projectile.GetComponent<Projectile>().speed;
    }

    public void Fire()
    {
        if (_cooldown > 0f)
            return;

        GameObject p = Instantiate(projectile);
        p.transform.position = transform.position;
        Vector3 velocity = Vector3.forward * _speed;
        p.GetComponent<Rigidbody>().velocity = velocity;
        _cooldown = 1.0f / firerate;
        if (juicy)
        {
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootVolume);
        }
    }

    private void Update()
    {
        if (_cooldown > 0f)
        {
            _cooldown -= Time.deltaTime;
        }
    }
}
