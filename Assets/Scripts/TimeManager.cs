using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public bool gameOver = false; 
    public bool gameFinished = false;
    [SerializeField] private float levelFinishTime = 5f;
    [SerializeField] private Text timeText;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private List<GameObject> destoryAfterGame = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameFinished == false && gameOver == false)
        {
            UpdateTheTimer();
        }
        
        if (Time.timeSinceLevelLoad >= levelFinishTime && gameOver == false)
        {
            gameFinished = true;
            winPanel.gameObject.SetActive(true);
            losePanel.gameObject.SetActive(false);
            UpdateObjectList("Objects");
            UpdateObjectList("Enemy");
            foreach (GameObject allObjects in destoryAfterGame)
            {
                Destroy(allObjects);
            }
        }
        if (gameOver == true)
        {
            winPanel.gameObject.SetActive(false);
            losePanel.gameObject.SetActive(true);
            UpdateObjectList("Objects");
            UpdateObjectList("Enemy");
            foreach (GameObject allObjects in destoryAfterGame  )
            {
                Destroy(allObjects);
            }
        }
    }

    private void UpdateObjectList(string tag)
    {
        destoryAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));
    }

    private void UpdateTheTimer()
    {
        timeText.text = "Time: " + (int)Time.timeSinceLevelLoad;  
    }

}
