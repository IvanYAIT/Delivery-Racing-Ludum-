using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStrikeController : MonoBehaviour
{
    private List<AirStrike> _airStrikePoints;
    private int _delay;

    public void Construct(Transform airStrikeParentObject, int delay)
    {
        _delay = delay;
        _airStrikePoints = new List<AirStrike>();
        for (int i = 0; i < airStrikeParentObject.childCount; i++)
            _airStrikePoints.Add(airStrikeParentObject.GetChild(i).GetComponent<AirStrike>());
        StartCoroutine(Bombing());
    }

    private IEnumerator Bombing()
    {
        StartCoroutine(_airStrikePoints[Random.Range(0, _airStrikePoints.Count)].Alarm());
        yield return new WaitForSeconds(_delay);
        StartCoroutine(Bombing());
    }
}
