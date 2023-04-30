using UnityEngine;
using UnityEngine.UI;

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
    [Header("Air Strike Controller")]
    [SerializeField] private int delay;
    [SerializeField] private int airStrikesPerBombing;
    [Space]
    [Header("Petrol System")]
    [SerializeField] private float petrolAmount;
    [SerializeField] private float petrolPerDriving;
    [SerializeField] private float petrolPerSecondOnStation;
    [Space]
    [Header("Finish")]
    [SerializeField] private int amountOfPoints;
    [Space]
    [Header("Other")]
    [SerializeField] private Transform carTransform;
    [SerializeField] private Rigidbody2D carRigibody;
    [SerializeField] private InputListener inputListener;
    [SerializeField] private Transform airStrikeParentObject;
    [SerializeField] private AirStrikeController airStrikeController;
    [SerializeField] private Transform finishPointsParentObject;
    [SerializeField] private Compas compas;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Slider petrolSlider;

    private WheelSmokeSystem _leftSmokeSystem;
    private WheelSmokeSystem _rightSmokeSystem;

    void Start()
    {
        Game game = new Game(winPanel);
        CarController carController = new CarController(speed, turnFactor, driftMultiplier, maxSpeed, carRigibody, carTransform);
        inputListener.Construct(carController);

        FinishSystem finishSystem = new FinishSystem(finishPointsParentObject, compas, amountOfPoints);

        PetrolSystem petrolSystem = new PetrolSystem(petrolAmount, petrolPerDriving, petrolSlider, petrolPerSecondOnStation);

        airStrikeController.Construct(airStrikeParentObject, delay, airStrikesPerBombing);

        _leftSmokeSystem = new WheelSmokeSystem(carController, leftParticleSystem);
        _rightSmokeSystem = new WheelSmokeSystem(carController, rightParticleSystem);
    }

    private void Update()
    {
        _leftSmokeSystem.Update();
        _rightSmokeSystem.Update();
    }
}
