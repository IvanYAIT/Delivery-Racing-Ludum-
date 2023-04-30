using System;
using System.Collections.Generic;
using UnityEngine;

public class FinishSystem
{
    private List<Transform> _finishPoints;
    private List<Transform> _currentPath;
    private int _counter=0;
    private Compas _compas;

    public static Action OnEndPath;

    public FinishSystem(Transform finishPointsParentObject, Compas compas, int amountOfPoints)
    {
        _compas = compas;
        _finishPoints = new List<Transform>();
        _currentPath = new List<Transform>();
        for (int i = 0; i < finishPointsParentObject.childCount; i++)
        {
            _finishPoints.Add(finishPointsParentObject.GetChild(i));
            _finishPoints[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < amountOfPoints; i++)
        {
            Transform currentPoint = _finishPoints[UnityEngine.Random.Range(0, _finishPoints.Count)];
            if (!currentPoint.gameObject.activeSelf)
                _currentPath.Add(currentPoint);
            else i--;
        }
        foreach (var item in _currentPath)
            item.gameObject.SetActive(false);
        _currentPath[0].gameObject.SetActive(true);
        _compas.SetTarget(_currentPath[0]);

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
        _currentPath[_counter].gameObject.SetActive(false);
        _counter++;
        if (_counter < _currentPath.Count)
        {
            _currentPath[_counter].gameObject.SetActive(true);
            _compas.SetTarget(_currentPath[_counter]);
        }
        else
            OnEndPath?.Invoke();
        
    }
}
