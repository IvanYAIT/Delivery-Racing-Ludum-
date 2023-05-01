using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask grassLayer;

    private int _grassLayerMask;

    public static Action OnGrassStay;
    public static Action OnGrassExit;

    private void Start()
    {
        _grassLayerMask = (int)Mathf.Log(grassLayer.value, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _grassLayerMask)
            OnGrassStay?.Invoke();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _grassLayerMask)
            OnGrassExit?.Invoke();
    }
}
