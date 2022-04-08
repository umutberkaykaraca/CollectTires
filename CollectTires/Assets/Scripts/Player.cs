using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager _gameManager;
    public float speed;
    public List<GameObject> tires;
    // Start is called before the first frame update
    void Start()
    {
        tires = new List<GameObject>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    private float touch;
    // Update is called once per frame
    void Update()
    {
        if (_gameManager.currentGameState != GameState.Start) {
            {
                return;
            }
        }
        Vector3 moveVector = new Vector3(0, 0, speed*Time.deltaTime);

        float diff = 0;

        if (Input.GetMouseButtonDown(0))
        {
            touch = Input.mousePosition.x;
        }
        
        else if (Input.GetMouseButton(0))
        {
            float touch2 = Input.mousePosition.x;
            diff = touch2 - touch;
            moveVector += new Vector3(diff * Time.deltaTime * 0.2f, 0, 0);
            touch = touch2;
        }

        transform.position += moveVector;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            other.transform.SetParent(transform);
            tires.Add(other.gameObject);
        }
        
        else if (other.CompareTag("Finish"))
        {
            _gameManager.EndGame();
        }
        else
        {
            Destroy(tires[tires.Count - 1]);
            tires.RemoveAt(tires.Count - 1);
        }
        
    }
}
