using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObstacle : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;

    private int _playerLayerMask;

    private void Start()
    {
        _playerLayerMask = (int)Mathf.Log(playerLayer.value, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _playerLayerMask)
            gameObject.SetActive(false);
    }
}
