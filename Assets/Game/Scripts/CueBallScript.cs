using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private CueStickScript _cueStick;
    [SerializeField]
    private float _strikeForce = 10f;
    [SerializeField]
    private float _nextStrikeDelay = 7f;

    private float _timeOfLastStrike;

    private bool _wasStruck = false;

    private void Update()
    {
        HandleInput();

        if (CanStrikeAgain())
        {
            _wasStruck = false;

            Freeze();
            ShowCueStick();
        }
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0) && !_wasStruck)
        {
            _wasStruck = true;

            Unfreeze();
            Strike();
            HideCueStick();
        }
    }

    private bool CanStrikeAgain()
    {
        return _wasStruck && Time.time - _timeOfLastStrike > _nextStrikeDelay;
    }

    private void Strike()
    {
        Vector3 directionToStrike = Mouse.GetWorldPosition() - transform.position;
        directionToStrike = directionToStrike.normalized;
        _timeOfLastStrike = Time.time;

        _rb.AddForce(directionToStrike * _strikeForce, ForceMode.Impulse);
    }

    private void HideCueStick()
    {
        _cueStick.gameObject.SetActive(false);
    }

    private void ShowCueStick()
    {
        _cueStick.gameObject.SetActive(true);
    }

    private void Freeze()
    {
        _rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    private void Unfreeze()
    {
        _rb.constraints = RigidbodyConstraints.None;
    }
}
