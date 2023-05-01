using System;
using UnityEngine;

public class CarController
{
    private float _speed;
    private float _turnFactor;
    private float _driftMultiplier;
    private float _maxSpeed;
    private Transform transform;
    private Rigidbody2D _rb;

    private float _maxSpeedSaver;

    private float _rotationAngle;
    private float _velocityVsUp;

    private float axisX;
    private float axisY;

    public static Action OnDecreasePetrol;

    private float LateralVelocity =>
        Vector2.Dot(transform.right, _rb.velocity);

    public float VelocityMagnitude =>
        _rb.velocity.magnitude;
    public CarController(float speed, float turnFactor, float driftMultiplier, float maxSpeed, Rigidbody2D rb,Transform transform)
    {
        _speed = speed;
        _turnFactor = turnFactor;
        _driftMultiplier = driftMultiplier;
        _maxSpeed = maxSpeed;
        _rb = rb;
        this.transform = transform;
        _maxSpeedSaver = _maxSpeed;
        GroundChecker.OnGrassStay += DecreaseSpeed;
        GroundChecker.OnGrassExit += IncreaseSpeed;
        Game.OnGameEnd += GameEnd;
    }

    private void GameEnd()
    {
        GroundChecker.OnGrassStay -= DecreaseSpeed;
        GroundChecker.OnGrassExit -= IncreaseSpeed;
        Game.OnGameEnd -= GameEnd;
    }

    private void DecreaseSpeed() =>
         _maxSpeed /= 2f;

    private void IncreaseSpeed()=>
        _maxSpeed = _maxSpeedSaver;

    public void Drive()
    {
        if (axisY != 0)
            OnDecreasePetrol?.Invoke();

        MoveForward();

        Drift();

        Rotate();
    }

    public void Drift()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(_rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(_rb.velocity, transform.right);

        _rb.velocity = forwardVelocity + rightVelocity * _driftMultiplier;
    }

    private void Rotate()
    {
        float minSpeedBeforAllowTurning = Mathf.Clamp01(_rb.velocity.magnitude / 8);

        if (axisY > 0)
            _rotationAngle -= axisX * _turnFactor * minSpeedBeforAllowTurning;
        else if (axisY < 0)
            _rotationAngle += axisX * _turnFactor * minSpeedBeforAllowTurning;

        _rb.MoveRotation(_rotationAngle);
    }

    public bool IsRotating(out float lateralVelocity, out bool IsBraking)
    {
        lateralVelocity = LateralVelocity;
        IsBraking = false;

        if(axisY < 0 && _velocityVsUp > 0)
        {
            IsBraking = true;
            return true;
        }

        if (Mathf.Abs(LateralVelocity) > 4 * _driftMultiplier)
            return true;

        return false;
    }

    private void MoveForward()
    {
        _velocityVsUp = Vector2.Dot(transform.up, _rb.velocity);

        if (_velocityVsUp > _maxSpeed && axisY > 0)
            return;
        if (_velocityVsUp < -_maxSpeed * 0.5f && axisY < 0)
            return;
        if (_rb.velocity.sqrMagnitude > _maxSpeed * _maxSpeed && axisY > 0)
            return;

        if (axisY == 0)
            _rb.drag = Mathf.Lerp(_rb.drag, 3, Time.fixedDeltaTime * 3);
        else
            _rb.drag = 0;

        Vector2 direction = transform.up * axisY * _speed;

        _rb.AddForce(direction, ForceMode2D.Force);

        
    }

    public void SetInput(Vector2 axis)
    {
        axisX = axis.x;
        axisY = axis.y;
    }
}
