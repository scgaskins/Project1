using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FallingBird");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FallingBird()
    {
        yield return new WaitForSeconds(2f);
        for(; ; )
        {
            Instantiate(bird);
            bird.transform.position = new Vector2(Random.Range(-9f,9f), 6);
            yield return new WaitForSeconds(Random.Range(.5f,1.5f));
        }
    }

}
