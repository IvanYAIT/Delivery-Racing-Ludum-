using System;
using UnityEngine.UI;

public class PetrolSystem
{
    private float _petrolPerSecond;
    private Slider _petrolSlider;
    private float _petrolAmount;
    private float _petrolPerSecondOnStation;

    public static Action OnZeroPetrol;

    public PetrolSystem(float petrolAmount, float petrolPerSecond, Slider petrolSlider, float petrolPerSecondOnStation)
    {
        _petrolPerSecondOnStation = petrolPerSecondOnStation;
        _petrolPerSecond = petrolPerSecond;
        _petrolSlider = petrolSlider;
        _petrolSlider.maxValue = petrolAmount;
        _petrolSlider.value = petrolAmount;
        _petrolAmount = petrolAmount;
        PetrolChecker.OnPetrolIncrease += IncreasePetrol;
        CarController.OnDecreasePetrol += DecreasePetrol;
        Game.OnGameEnd += GameEnd;
    }

    private void GameEnd()
    {
        PetrolChecker.OnPetrolIncrease -= IncreasePetrol;
        CarController.OnDecreasePetrol -= DecreasePetrol;
        Game.OnGameEnd -= GameEnd;
    }

    private void IncreasePetrol()
    {
        if(_petrolSlider.value != _petrolAmount)
            _petrolSlider.value += _petrolPerSecondOnStation;
    }

    public void DecreasePetrol()
    {
        _petrolSlider.value -= _petrolPerSecond;
        if (_petrolSlider.value <= 0)
            OnZeroPetrol?.Invoke();
    }
}
