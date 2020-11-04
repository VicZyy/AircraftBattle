using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int Life = 1;
    public float MoveSpeed = 5;   //移动速度
    public GameObject Rocket;
    public AudioClip ShootClip;

    public GameObject ExplosionFX;

    private AudioSource _audio;

    private float moveV = 0;    //垂直移动距离
    private float moveH = 0;    //水平移动距离
    public float FireInterval = 0.2f;  //发射间隔
    private float rocketTimer; //发射间隔


    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        moveH = 0;
        moveV = 0;
        if (Input.GetKey(KeyCode.W))
        {
            moveV += MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveV -= MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveH -= MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveH += MoveSpeed * Time.deltaTime;
        }
        transform.Translate(new Vector3(moveH, 0, moveV));
        rocketTimer -= Time.deltaTime;
        if (rocketTimer < 0)
        {
            if (Input.GetKey(KeyCode.J))
            {
                Instantiate(Rocket, transform.position, transform.rotation);
                _audio.PlayOneShot(ShootClip);
                rocketTimer = FireInterval;
            }
            else
            {
                rocketTimer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "PlayerRocket")
        {
            GameManager.Instance.ChangeLife(other.GetComponent<Rocket>().Power);
            if (Life <= 0)
            {
                Instantiate(ExplosionFX, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
