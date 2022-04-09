using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    public Button startButton, nextlevelButton;
    public GameObject menuUI, inGameUI, endUI;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        SetBindings();
        
    }

    private void SetBindings()
    {
        startButton.onClick.AddListener( () =>
            {
            
                _gameManager.StartGame();
                menuUI.SetActive(false);
            }
        );
        nextlevelButton.onClick.AddListener( () =>
            {
                endUI.SetActive(false);
                _gameManager.StartNextGame();
            }
        );
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndLevel()
    {
        endUI.SetActive(true);
    }
}
