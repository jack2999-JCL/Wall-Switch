using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigiboday2D;
    private float x = 3;
    private float y = 5;
    public float Speed { get => _speed; set => _speed = value; }

    void Start()
    {
        Bouncing();
        StartCoroutine(Destroy());
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(6f);
        Destroy(this.gameObject);
    }


    // Update is called once per frame
    public void Bouncing()
    {
        if (this.transform.position.x > 0)
        {
            if (this.transform.position.y > -60)
            {
                _rigiboday2D.velocity = new Vector2(-x * _speed, -y * _speed);
            }
            else
            {
                _rigiboday2D.velocity = new Vector2(-x * _speed, y * _speed);
            }
        }
        else
        {
            if (this.transform.position.y > -60)
            {
                _rigiboday2D.velocity = new Vector2(x * _speed, y * _speed);
            }
            else
            {
                _rigiboday2D.velocity = new Vector2(x * _speed, -y * _speed);
            }
        }
    }
}
