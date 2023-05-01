using UnityEngine;

public class Compas : MonoBehaviour
{
    [SerializeField] private RectTransform uiCompass;

    private Transform _target;

    void Update()
    {
        float dirX = (transform.position - _target.position).x;
        float dirY = (_target.position- transform.position).y;
        var angle = Mathf.Atan2(dirX, dirY) * Mathf.Rad2Deg;
        uiCompass.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
    }

    public void SetTarget(Transform target) => _target = target;
}
