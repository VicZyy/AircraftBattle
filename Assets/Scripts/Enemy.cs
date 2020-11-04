using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MoveSpeed = 5;
    public int Life = 10;

    public float FireInterval = 2f;  //发射间隔
    public GameObject Rocket;
    public int Point;

    private float rocketTimer; //发射间隔
    private GameObject _player;

    public GameObject ExplosionFX;
    public int Damage;

    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        rocketTimer -= Time.deltaTime;
        if (rocketTimer < 0)
        {
            if (_player)
            {
                Instantiate(Rocket, transform.position, Quaternion.LookRotation(_player.transform.position - transform.position));
                rocketTimer = FireInterval;
            }
            else
            {
                _player = GameObject.FindGameObjectWithTag("Player");
            }
        }
    }

    protected virtual void Move()
    {
        transform.Translate(new Vector3(Mathf.Sin(Time.time) * Time.deltaTime, 0, -MoveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerRocket")
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if (rocket)
            {
                Life -= rocket.Power;
                if (Life < 0)
                {
                    GameManager.Instance.AddScore(Point);
                    Instantiate(ExplosionFX,transform.position,Quaternion.identity);
                    Destroy(gameObject);
                }
            }
        }
        else if (other.tag == "Player")
        {
            Life = 0;
            
            Destroy(gameObject);
        }
    }
    private void OnBecameVisible()
    {
        isActive = true;
    }
    private void OnBecameInvisible()
    {
        if (isActive)
        {
            Destroy(gameObject);
        }
    }

}
