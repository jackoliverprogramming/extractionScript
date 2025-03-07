using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class extractionScript : MonoBehaviour
{
    private Text timerText;
    public GameObject player;
    public float timeLeft = 10;
    public GameObject extractionCanvas;
    public bool extracting;

    [SerializeField]
    private Text extractionTimer;

    // Start is called before the first frame update
    void Start()
    {
        extractionCanvas.SetActive(false);
        extracting = false;
    }

    // Update is called once per frame
    void Update()
    {
        extractionCanvas.SetActive(extracting);

        if (extracting)
        {
            timeLeft = timeLeft - Time.deltaTime;
            extractionTimer.text = "YOU ARE EXTRACTING IN:" + " " + timeLeft.ToString();

            if (timeLeft < 0)
            {
                extractionTimer.text = "YOU ARE EXTRACTING IN:" + " 0";
                Debug.Log("player has extracted");
                SceneManager.LoadScene(2);
            }
        }
        else { timeLeft = 10; }
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == player)
        {
            extracting = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject == player) 
        { 
            extracting = false; 
        }
    }


}
