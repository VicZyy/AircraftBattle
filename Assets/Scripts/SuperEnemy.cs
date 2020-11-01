using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemy : Enemy
{
    private float rocketTimer; //发射间隔
    private GameObject _player;


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
    protected override void Move()
    {
        transform.Translate(new Vector3(0, 0, -MoveSpeed * Time.deltaTime));
    }
}
