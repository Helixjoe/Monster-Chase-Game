using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] charArray;

    public static GameManager instance;

    private int _charIndex;
    public int CharIndex
    {
        get
        {
            return _charIndex;
        }
        set
        {
            _charIndex = value;
        }
    }

    private void Awake()
    {
        //singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GamePlay")
        {
            Instantiate(charArray[CharIndex]);
        }
    }
}
