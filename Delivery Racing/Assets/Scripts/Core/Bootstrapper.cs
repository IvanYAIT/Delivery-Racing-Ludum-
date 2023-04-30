using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [Header("Car Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float turnFactor;
    [SerializeField] private float driftMultiplier;
    [SerializeField] private float maxSpeed;
    [Space]
    [Header("Wheels")]
    [SerializeField] private ParticleSystem leftParticleSystem;
    [SerializeField] private ParticleSystem rightParticleSystem;
    [Space]
    [Header("Other")]
    [SerializeField] private Transform carTransform;
    [SerializeField] private Rigidbody2D carRigibody;
    [SerializeField] private InputListener inputListener;

    private WheelSmokeSystem _leftSmokeSystem;
    private WheelSmokeSystem _rightSmokeSystem;

    void Start()
    {
        Game game = new Game();
        CarController carController = new CarController(speed, turnFactor, driftMultiplier, maxSpeed, carRigibody, carTransform);
        inputListener.Construct(carController);

        _leftSmokeSystem = new WheelSmokeSystem(carController, leftParticleSystem);
        _rightSmokeSystem = new WheelSmokeSystem(carController, rightParticleSystem);
    }

    private void Update()
    {
        _leftSmokeSystem.Update();
        _rightSmokeSystem.Update();
    }
}
