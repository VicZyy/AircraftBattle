using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float MoveSpeed = 10;
    public int Power = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, MoveSpeed * Time.deltaTime));
    }

    private void OnBecameInvisible()
    {
        if (enabled)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Enemy")
        {
            Destroy(gameObject);
        }
    }
}
