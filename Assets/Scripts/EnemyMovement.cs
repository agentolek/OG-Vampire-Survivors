using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public float maxSpeed;
    
    private GameObject _player;
    private Rigidbody2D _rb2d;
    private bool _knockedBack = false;
    private Vector2 _kbVector;
    private Vector2 _moveForce;

    private void Start()
    {
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player1");
    }

    private void FixedUpdate()
    {
        if (!_knockedBack)
        {
            _moveForce = (_player.transform.position - transform.position).normalized * maxSpeed;
        }
        else
        {
            _moveForce = _kbVector;
        }

        _rb2d.velocity = _moveForce;
    }

    // public void ActivateKnockback()
    // {
    //     StartCoroutine(KnockBack(data[0], kbForce, kbTime));
    // }

    public IEnumerator KnockBack(Vector2 pos, float kbForce, float kbTime)
    {
        _knockedBack = true;
        Vector2 thisPos = transform.position;
        _kbVector = (thisPos - pos).normalized * kbForce;
        yield return new WaitForSeconds(kbTime);
        _knockedBack = false;
    }
}
