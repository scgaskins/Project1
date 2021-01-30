using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public GameObject bird;
    public TextMeshProUGUI textBox;
    public float timeBalancing;
    public float highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeBalancing = 0f;
        highScore = 0f;
        StartCoroutine("FallingBird");
    }

    // Update is called once per frame
    void Update()
    {
        timeBalancing += Time.deltaTime;
        textBox.text = "Time with Pancake: " + timeBalancing.ToString("F2") +
            "\n" + "High Score: " + highScore.ToString("F2");
    }

    public void ResetTime()
    {
        if (timeBalancing > highScore)
        {
            highScore = timeBalancing;
        }
        timeBalancing = 0f;
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
