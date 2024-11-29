using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public TMP_Text score, finalscore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int uiscore;

    public int UIScore
    {
        get
        {
            return uiscore;
        }
        set
        {
            uiscore = value;
            score.text = uiscore.ToString();
            finalscore.text = uiscore.ToString();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
