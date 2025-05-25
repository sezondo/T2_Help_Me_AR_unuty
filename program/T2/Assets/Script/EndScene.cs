using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    
    public Text bestTimeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestTimeText.text = "Best Time: " + (int)GameData.bestTime;
    }

    // Update is called once per frame
    void Update()
    {
        
            
    }

    public void Retry()
    {

        SceneManager.LoadScene("StartScene");

    }

    
}
