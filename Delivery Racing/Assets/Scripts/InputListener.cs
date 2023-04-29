using UnityEngine;

public class InputListener : MonoBehaviour
{
    private CarController _carController;
    private Vector2 _axis;

    private void FixedUpdate()
    {
        _axis.x = Input.GetAxis("Horizontal");
        _axis.y = Input.GetAxis("Vertical");
        _carController.Drive(_axis);
    }

    public void Construct(CarController carController)
    {
        _carController = carController;
    }
}