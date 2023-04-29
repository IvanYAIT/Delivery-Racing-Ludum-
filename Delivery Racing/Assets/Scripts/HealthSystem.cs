using DG.Tweening;
using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int damageCooldown;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private GameObject firstHeart;
    [SerializeField] private GameObject secondHeart;
    [SerializeField] private GameObject thirdHeart;
    [SerializeField] private SpriteRenderer carSprite;

    private bool _idamageable;
    private int _hearts = 3;
    private int _obstacleLayerMask;

    public static Action OnZeroHealth;

    void Start()
    {
        _obstacleLayerMask = (int)Mathf.Log(obstacleLayer.value, 2);
    }


    void Update()
    {
        if (_hearts <= 0)
            OnZeroHealth?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _obstacleLayerMask && !_idamageable)
        {
            _idamageable = true;
            DecreaseHealth();
        }
    }

    private void DecreaseHealth()
    {
        _hearts--;

        switch (_hearts)
        {
            case 0:
                thirdHeart.SetActive(false);
                break;
            case 1:
                secondHeart.SetActive(false);
                GetDamage();
                break;
            case 2:
                firstHeart.SetActive(false);
                GetDamage();
                break;
        }
    }

    private void GetDamage()
    {
        int counter = 0;

        carSprite.DOFade(0.5f, 0.5f).OnComplete(() =>
        {
            carSprite.DOFade(1f, 0.5f);
        }).SetLoops(damageCooldown).OnStepComplete(() =>
        {
            counter++;

            if (counter == damageCooldown)
                _idamageable = false;
        });
    }
}
