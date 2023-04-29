using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [Header("Car Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float turnFactor;
    [SerializeField] private float driftMultiplier;
    [SerializeField] private float maxSpeed;
    [Space]
    [Header("Other")]
    [SerializeField] private Transform carTransform;
    [SerializeField] private Rigidbody2D carRigibody;
    [SerializeField] private InputListener inputListener;


    void Start()
    {
        Game game = new Game();
        CarController carController = new CarController(speed, turnFactor, driftMultiplier, maxSpeed, carRigibody, carTransform);
        inputListener.Construct(carController);
    }
}
