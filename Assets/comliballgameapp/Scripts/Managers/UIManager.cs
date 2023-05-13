using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance 
    { 
        get => FindObjectOfType<UIManager>(); 
    }

    int score = 0;
    [SerializeField] Text scoreText;

    private GameObject _gameRef;

    [SerializeField] GameObject menuLandscape;

    [Space(10)]
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject records;
    [SerializeField] GameObject game;
    [SerializeField] GameObject pause;
    [SerializeField] GameObject result;

    private void Awake()
    {
        Platform.OnPlatformCollided += () =>
        {
            score++;
            scoreText.text = $"{score}";
        };
    }


    private void Start()
    {
        OpenMenu();
    }

    public void StartGame()
    {
        score = 0;
        scoreText.text = $"{score}";

        Time.timeScale = 1;
        menuLandscape.SetActive(false);

        var _parent = GameObject.Find("Environment").transform;
        var _prefab = Resources.Load<GameObject>("level");

        _gameRef = Instantiate(_prefab, _parent);

        menu.SetActive(false);

        game.SetActive(true);
        result.SetActive(false);
    }

    public void OpenSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void OpenRecords()
    {
        menu.SetActive(false);
        records.SetActive(true);
    }

    public void OpenPause(bool open)
    {
        Time.timeScale = open ? 0 : 1;
        pause.SetActive(open);
    }

    public void OpenMenu()
    {
        if(_gameRef)
        {
            Destroy(_gameRef);
        }

        menuLandscape.SetActive(true);

        game.SetActive(false);
        settings.SetActive(false);
        records.SetActive(false);
        pause.SetActive(false);
        result.SetActive(false);

        menu.SetActive(true);

        CameraFollower.target = null;
        Camera.main.transform.position = new Vector3(0, 0, -10);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        result.SetActive(true);
    }
}
