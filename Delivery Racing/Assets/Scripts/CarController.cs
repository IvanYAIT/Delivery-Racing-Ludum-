using UnityEngine;

public class CarController
{
    public float _speed;
    public float _turnFactor;
    public float _driftMultiplier;
    public float _maxSpeed;
    private Transform transform;
    private Rigidbody2D _rb;

    private float _rotationAngle;
    private float _velocityVsUp;
    

    public CarController(float speed, float turnFactor, float driftMultiplier, float maxSpeed, Rigidbody2D rb,Transform transform)
    {
        _speed = speed;
        _turnFactor = turnFactor;
        _driftMultiplier = driftMultiplier;
        _maxSpeed = maxSpeed;
        _rb = rb;
        this.transform = transform;
    }

    public void Drive(Vector2 axis)
    {
        MoveForward(axis.y);

        Drift();

        Rotate(axis.x);
    }

    public void Drift()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(_rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(_rb.velocity, transform.right);

        _rb.velocity = forwardVelocity + rightVelocity * _driftMultiplier;
    }

    private void MoveForward(float axisY)
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

    private void Rotate(float axisX)
    {
        float minSpeedBeforAllowTurning = Mathf.Clamp01(_rb.velocity.magnitude / 8);

        _rotationAngle -= axisX * _turnFactor * minSpeedBeforAllowTurning;

        _rb.MoveRotation(_rotationAngle);
    }
}
