using UnityEngine;

public class CarSFXHandler
{
    private AudioSource _driftAudioSource;
    private AudioSource _engineAudioSource;
    private CarController _carController;

    private float _desiredEnginePitch = 0.5f;
    private float _driftPitch = 0.5f;

    public CarSFXHandler(AudioSource driftAudioSource, AudioSource engineAudioSource, CarController carController)
    {
        _driftAudioSource = driftAudioSource;
        _engineAudioSource = engineAudioSource;
        _carController = carController;
    }

    public void UpdateDriftSFX()
    {
        if (_carController.IsRotating(out float lateralVelocity, out bool isBraking))
        {
            if (isBraking)
            {
                _driftAudioSource.volume = Mathf.Lerp(_driftAudioSource.volume, 1, Time.deltaTime * 10);
                _driftPitch = Mathf.Lerp(_driftPitch, 0.5f, Time.deltaTime * 10);
                _driftAudioSource.pitch = _driftPitch;
            }
            else
            {
                _driftAudioSource.volume = Mathf.Abs(lateralVelocity) * 0.05f;
                _driftAudioSource.pitch = Mathf.Abs(lateralVelocity) * 0.1f;
            }
        }
        else
            _driftAudioSource.volume = Mathf.Lerp(_driftAudioSource.volume, 0, Time.deltaTime * 10);
    }

    public void UpdateEngineSFX()
    {
        float velocityMagnitude = _carController.VelocityMagnitude;
        float desiredEngineVolume = velocityMagnitude * 0.05f;
        
        desiredEngineVolume = Mathf.Clamp(desiredEngineVolume, 0.2f, 1);
        _engineAudioSource.volume = Mathf.Lerp(_engineAudioSource.volume, desiredEngineVolume, Time.deltaTime * 10);

        _desiredEnginePitch = velocityMagnitude * 0.2f;
        _desiredEnginePitch = Mathf.Clamp(_desiredEnginePitch, 0.5f, 2);
        _engineAudioSource.pitch = Mathf.Lerp(_engineAudioSource.pitch, _desiredEnginePitch, Time.deltaTime * 1.5f);
    }
}
