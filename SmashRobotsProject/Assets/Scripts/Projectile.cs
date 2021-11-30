using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float max_time_alive, damage;
    [SerializeField]
    float speed;

    float time_alive;

    float time_colision = 0;
    // Start is called before the first frame update
    void Start()
    {
        time_alive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time_alive += Time.deltaTime;
        if (time_alive >= max_time_alive)
            Destroy(gameObject);
        gameObject.transform.position -= gameObject.transform.forward*Time.deltaTime*speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (speed != 0 && time_alive > Time.deltaTime)
        {
            //if (time_alive > Time.deltaTime)
            //{
            Bot_Movement bot = other.GetComponent<Bot_Movement>();
            if (bot != null)
                bot.Da�o(damage);
            else
            {
                Enemy_Controller e = other.GetComponent<Enemy_Controller>();
                if (e != null)
                    e.Da�o(damage);
            }
            if(speed!=0)
                Destroy(gameObject);
            //}
        }
    }

    private void OnTriggerStay(Collider other)
    {
        time_colision += Time.deltaTime;
        if(time_colision >= max_time_alive/10)
        {
            time_colision = 0;

            Bot_Movement bot = other.GetComponent<Bot_Movement>();
            if (bot != null)
                bot.Da�o(damage/10);
            else
            {
                Enemy_Controller e = other.GetComponent<Enemy_Controller>();
                if (e != null)
                    e.Da�o(damage/10);
            }
        }
    }

    public float Da�o()
    {
        return damage;
    }
}
