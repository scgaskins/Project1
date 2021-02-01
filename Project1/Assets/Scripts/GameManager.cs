using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private GameObject[] birds;
    public GameObject bird1;
    public GameObject bird2;
    public GameObject bird3;
    public TextMeshProUGUI textBox;
    public float timeBalancing;
    public float highScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        birds = new GameObject[] { bird1, bird2, bird3};
        timeBalancing = 0f;
        highScore = 0f;
        StartCoroutine("FallingBird");
    }

    // Update is called once per frame
    void Update()
    {
        timeBalancing += Time.deltaTime;
        if (timeBalancing > highScore)
        {
            highScore = timeBalancing;
        }
        textBox.text = "Time with Pancake: " + timeBalancing.ToString("F2") +
            "\n" + "High Score: " + highScore.ToString("F2");
    }

    public void ResetTime()
    {
        timeBalancing = 0f;
    }

    IEnumerator FallingBird()
    {
        yield return new WaitForSeconds(2f);
        for(; ; )
        {
            GameObject bird = birds[Random.Range(0, birds.Length)];
            GameObject birdObject = Instantiate(bird);
            birdObject.transform.position = new Vector2(Random.Range(-9f,9f), 6);
            yield return new WaitForSeconds(Random.Range(.5f,1.5f));
        }
    }

}
