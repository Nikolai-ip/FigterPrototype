using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControllerCharacter : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 200f;
    private Transform _transformCharacter;
    private Animator _animator;
    void Start()
    {
        _transformCharacter=GetComponent<Transform>();
        _animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal")*Time.deltaTime*_moveSpeed;
        transform.position+=new Vector3 (move,0,0);       
        if (!Mathf.Approximately(move, 0))
        {
            _animator.SetFloat("speed", Mathf.Abs(move*100));
            Flip(move);
        }
    }
    void Flip(float move)
    {
        transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
    }
}
