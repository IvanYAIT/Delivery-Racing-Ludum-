using System.Collections;
using UnityEngine;

public class DestroyableObstacle : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator animator;

    private int _playerLayerMask;

    private void Start()
    {
        _playerLayerMask = (int)Mathf.Log(playerLayer.value, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _playerLayerMask)
        {
            StartCoroutine(Explosion());
        }
    }

    private IEnumerator Explosion()
    {
        audioSource.Play();
        animator.SetTrigger("OnExplosion");
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
