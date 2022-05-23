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
    private Vector3 _respawnPoint;

    private bool _wasStruck = false;
    private bool _gameStarted = false;

    private void Start()
    {
        _respawnPoint = transform.position;
    }

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

        if (Input.GetKey(KeyCode.DownArrow) && !_gameStarted &&
            transform.position.z > -2.5f)
        {
            transform.Translate(Vector3.back * 0.01f);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && !_gameStarted &&
            transform.position.z < 1.6f)
        {
            transform.Translate(Vector3.forward * 0.01f);
        }
    }

    private bool CanStrikeAgain()
    {
        return _wasStruck && Time.time - _timeOfLastStrike > _nextStrikeDelay;
    }

    private void Strike()
    {
        if (!_gameStarted) _gameStarted = true;

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
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Unfreeze()
    {
        _rb.constraints = RigidbodyConstraints.None;
    }

    private void OnTriggerEnter(Collider other)
    {
        Freeze();
        ShowCueStick();

        transform.position = _respawnPoint;
        transform.rotation = Quaternion.identity;

        _wasStruck = false;
        _gameStarted = false;
    }
}
