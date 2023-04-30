using System;
using System.Collections.Generic;
using UnityEngine;

public class FinishSystem
{
    private List<Transform> _finishPoints;
    private int _counter=0;
    private Compas _compas;

    public static Action OnEndPath;

    public FinishSystem(Transform finishPointsParentObject, Compas compas)
    {
        _compas = compas;
        _finishPoints = new List<Transform>();
        for (int i = 0; i < finishPointsParentObject.childCount; i++)
        {
            _finishPoints.Add(finishPointsParentObject.GetChild(i));
            _finishPoints[i].gameObject.SetActive(false);
        }

        _finishPoints[0].gameObject.SetActive(true);
        _compas.SetTarget(_finishPoints[0]);

        FinishChecker.OnFinish += NextPoint;
        Game.OnGameEnd += GameEnd;
    }

    private void GameEnd()
    {
        FinishChecker.OnFinish -= NextPoint;
        Game.OnGameEnd -= GameEnd;
    }

    private void NextPoint()
    {
        _finishPoints[_counter].gameObject.SetActive(false);
        _counter++;
        if (_counter < _finishPoints.Count)
        {
            _finishPoints[_counter].gameObject.SetActive(true);
            _compas.SetTarget(_finishPoints[_counter]);
        }
        else
            OnEndPath?.Invoke();
        
    }
}
