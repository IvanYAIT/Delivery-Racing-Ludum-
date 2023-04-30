using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStrikeController : MonoBehaviour
{
    private List<AirStrike> _airStrikePoints;
    private int _delay;
    private int _airStrikesPerBombing;

    public void Construct(Transform airStrikeParentObject, int delay, int airStrikesPerBombing)
    {
        _delay = delay;
        _airStrikesPerBombing = airStrikesPerBombing;
        _airStrikePoints = new List<AirStrike>();
        for (int i = 0; i < airStrikeParentObject.childCount; i++)
            _airStrikePoints.Add(airStrikeParentObject.GetChild(i).GetComponent<AirStrike>());
        StartCoroutine(Bombing());
    }

    private IEnumerator Bombing()
    {
        for (int i = 0; i < _airStrikesPerBombing; i++)
        {
            AirStrike currentAirStrike = _airStrikePoints[Random.Range(0, _airStrikePoints.Count)];
            
            if (!currentAirStrike.IsActive)
                StartCoroutine(currentAirStrike.Alarm());
            else i--;
        }
        yield return new WaitForSeconds(_delay);
        StartCoroutine(Bombing());
    }
}
