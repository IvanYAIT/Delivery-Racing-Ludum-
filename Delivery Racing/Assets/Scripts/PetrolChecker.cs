using System;
using UnityEngine;

public class PetrolChecker : MonoBehaviour
{
    [SerializeField] private LayerMask petrolStationLayer;

    private int _petrolStationLayerMask;

    public static Action OnPetrolIncrease;

    private void Start()
    {
        _petrolStationLayerMask = (int)Mathf.Log(petrolStationLayer.value, 2);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _petrolStationLayerMask)
            OnPetrolIncrease?.Invoke();
    }
}
