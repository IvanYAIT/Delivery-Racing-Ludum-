using System;
using UnityEngine;

public class PetrolChecker : MonoBehaviour
{
    [SerializeField] private LayerMask petrolStationLayer;
    [SerializeField] private AudioSource audioSource;

    private int _petrolStationLayerMask;

    public static Action OnPetrolIncrease;

    private void Start()
    {
        _petrolStationLayerMask = (int)Mathf.Log(petrolStationLayer.value, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _petrolStationLayerMask)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _petrolStationLayerMask)
        {
            OnPetrolIncrease?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _petrolStationLayerMask)
        {
            audioSource.Stop();
        }
    }
}
