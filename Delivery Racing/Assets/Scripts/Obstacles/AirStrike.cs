using System.Collections;
using UnityEngine;

public class AirStrike : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private int alarmDuration;

    [SerializeField] private GameObject alarmZone;
    [SerializeField] private GameObject deathZone;

    [SerializeField] private AudioSource audioSource;

    public bool IsActive { get; private set; }
    void Start()
    {
        alarmZone.transform.localScale = new Vector3(radius, radius);
        deathZone.transform.localScale = new Vector3(radius, radius);
    }

    public IEnumerator Alarm()
    {
        IsActive = true;
        alarmZone.SetActive(true);
        yield return new WaitForSeconds(alarmDuration);
        audioSource.Play();
        alarmZone.SetActive(false);
        deathZone.SetActive(true);
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1);
        deathZone.SetActive(false);
        IsActive = false;
    }
}
