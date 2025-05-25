using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameData
{
    public static float bestTime = 0f;
}

public class GameManager : MonoBehaviour
{
    bool isGameover;
    float surviveTime;
    public Text textRecord;
    public Text timeText;

    void Awake()
    {
	    Application.targetFrameRate = 60;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: "+(int) surviveTime;
        }else
        {
            /*
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            */
            
        }
    }

    public void EndGame(){

        float bestTime = PlayerPrefs.GetFloat("BestTime",0);

        if (bestTime == 0f || surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        //textRecord.text = "Best Time: " + (int)bestTime;

        GameData.bestTime = bestTime;

        SceneManager.LoadScene("EndScene");

    }
}
