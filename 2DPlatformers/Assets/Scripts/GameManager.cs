using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public GameObject startButton;
    public GameObject creditsButton;
    public GameObject tutorialButton;
    public GameObject menuButton;
    public GameObject backgroundImage;
    public GameObject events;
    public GameObject canvas;
    public Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerFalls();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Travel(string scene)
    {
        StartCoroutine(LoadYourAsyncScene(scene));
    }

    IEnumerator LoadYourAsyncScene(string scene)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 2f));
    }

    IEnumerator ColorLerp(Color endValue, float duration)
    {
        float time = 0;
        Image sprite = backgroundImage.GetComponent<Image>();
        Color startValue = sprite.color;

        while (time < duration)
        {
            sprite.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        sprite.color = endValue;
    }

    public void StartButton()
    {
        startButton.SetActive(false);
        StartCoroutine(LoadYourAsyncScene("Level1"));
    }

    public void CreditsButton()
    {
        creditsButton.SetActive(false);
        StartCoroutine(LoadYourAsyncScene("Credits"));
    }

    public void TutorialButton()
    {
        tutorialButton.SetActive(false);
        StartCoroutine(LoadYourAsyncScene("Tutorial"));
    }

    public void MenuButton()
    {
        menuButton.SetActive(false);
        StartCoroutine(LoadYourAsyncScene("Title Screen"));
    }

    public void GameOver()
    {
        startButton.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 1), 2f));
    }

    public void PlayerFalls()
    {
       if (player.position.y < -30) {
            GameOver();
        }
    }

}
