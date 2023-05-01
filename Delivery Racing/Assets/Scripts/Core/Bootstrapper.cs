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
    [SerializeField] private TrailRenderer leftTrailRenderer;
    [SerializeField] private TrailRenderer rightTrailRenderer;
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
    [Header("Audio")]
    [SerializeField] private AudioSource driftAudioSource;
    [SerializeField] private AudioSource engineAudioSource;
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
    [SerializeField] private GameObject losePanel;
    [SerializeField] private Slider petrolSlider;
    [SerializeField] private AudioSource loseAudioSource;
    [SerializeField] private AudioSource winAudioSource;

    private WheelSmokeSystem _leftSmokeSystem;
    private WheelSmokeSystem _rightSmokeSystem;
    private WheelTrailSystem _leftTrailSystem;
    private WheelTrailSystem _rightTrailSystem;
    private CarSFXHandler _carSFX;

    void Start()
    {
        Game game = new Game(winPanel, losePanel, winAudioSource, loseAudioSource);
        CarController carController = new CarController(speed, turnFactor, driftMultiplier, maxSpeed, carRigibody, carTransform);
        inputListener.Construct(carController);

        FinishSystem finishSystem = new FinishSystem(finishPointsParentObject, compas, amountOfPoints);

        PetrolSystem petrolSystem = new PetrolSystem(petrolAmount, petrolPerDriving, petrolSlider, petrolPerSecondOnStation);

        _carSFX = new CarSFXHandler(driftAudioSource, engineAudioSource, carController);

        airStrikeController.Construct(airStrikeParentObject, delay, airStrikesPerBombing);


        _leftTrailSystem = new WheelTrailSystem(carController, leftTrailRenderer);
        _rightTrailSystem = new WheelTrailSystem(carController, rightTrailRenderer);
        _leftSmokeSystem = new WheelSmokeSystem(carController, leftParticleSystem);
        _rightSmokeSystem = new WheelSmokeSystem(carController, rightParticleSystem);
    }

    private void Update()
    {
        _carSFX.UpdateDriftSFX();
        _carSFX.UpdateEngineSFX();

        _leftTrailSystem.Update();
        _rightTrailSystem.Update();
        _leftSmokeSystem.Update();
        _rightSmokeSystem.Update();
    }
}
