using UnityEngine;

public class WeaponCommand : MonoBehaviour
{
    [SerializeField] ProjectileLauncher launcherLeft;
    [SerializeField] ProjectileLauncher launcherRight;
    [SerializeField] AudioClip shootSound;

    private void Update()
    {
        if (Input.GetAxis("Fire1") > 0f)
        {
            launcherLeft.Fire();
            launcherRight.Fire();
        }
    }
}
