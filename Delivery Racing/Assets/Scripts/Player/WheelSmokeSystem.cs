using UnityEngine;

public class WheelSmokeSystem
{
    private float _particalEmissionRate;
    private CarController _carController;
    private ParticleSystem.EmissionModule _particleSystemEmission;

    public WheelSmokeSystem(CarController carController, ParticleSystem particleSystem)
    {
        _carController = carController;
        _particleSystemEmission = particleSystem.emission;
        _particleSystemEmission.rateOverTime = 0;
    }

    public void Update()
    {
        _particalEmissionRate = Mathf.Lerp(_particalEmissionRate, 0, Time.deltaTime * 5);
        _particleSystemEmission.rateOverTime = _particalEmissionRate;

        if(_carController.IsRotating(out float lateralVelocity, out bool isBraking))
        {
            if (isBraking)
                _particalEmissionRate = 30;
            else
                _particalEmissionRate = Mathf.Abs(lateralVelocity) * 5;
        }
    }
}
