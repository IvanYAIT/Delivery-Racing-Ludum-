using System;
using UnityEngine;

public class FinishChecker : MonoBehaviour
{
    [SerializeField] private LayerMask finishLayer;

    private int _finishLayerMask;
    
    public static Action OnFinish;

    private void Start()
    {
        _finishLayerMask = (int)Mathf.Log(finishLayer.value, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _finishLayerMask)
            OnFinish?.Invoke();
    }
}
