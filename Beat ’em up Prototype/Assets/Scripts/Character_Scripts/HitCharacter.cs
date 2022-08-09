using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
    [SerializeField] private Hits _handHit;
    [SerializeField] private Hits _lowKick;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Hit(_handHit);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Hit(_lowKick);
        }
    }
    void Hit(Hits obj)
    {
        _animator.SetTrigger(obj.animationName);
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(obj.hitTransform.position, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            IEnemy enemy = collider.GetComponent<IEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(obj.attackDelay);
            }
        }
    }
}
