using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchDestroy : MonoBehaviour
{

    public GameObject pancake;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pancake);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.collider.name == "Pancake(Clone)")
        {
            Instantiate(pancake);
            GameManager.Instance.ResetTime();
        }
    }
}
