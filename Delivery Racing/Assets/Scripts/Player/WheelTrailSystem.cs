using UnityEngine;

public class WheelTrailSystem
{
    private CarController _carController;
    private TrailRenderer _trailRenderer;

    public WheelTrailSystem(CarController carController, TrailRenderer trailRenderer)
    {
        _carController = carController;
        _trailRenderer = trailRenderer;
        trailRenderer.emitting = false;
    }

    public void Update()
    {
        if (_carController.IsRotating(out float lateralVelocity, out bool osBraking))
            _trailRenderer.emitting = true;
        else _trailRenderer.emitting = false;
    }
}
