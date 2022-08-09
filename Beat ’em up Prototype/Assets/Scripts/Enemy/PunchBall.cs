using UnityEngine;

public class PunchBall : MonoBehaviour,IEnemy
{
    [SerializeField] private SpriteRenderer _sp;
    [SerializeField] private float _timeToChangeColor=0.5f;
    [SerializeField] private Color _color;
    [SerializeField] private Color _defoultColor;
    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
        _defoultColor = _sp.color;
    }
    public void TakeDamage(float attackDelay)
    {
        Invoke("SetNewColor", attackDelay); 
    }
    void SetNewColor()
    {
        _sp.color = _color;
        Invoke("SetDefoultColor", _timeToChangeColor);
    }    
    void SetDefoultColor()
    {
        _sp.color = _defoultColor;
    }
}
