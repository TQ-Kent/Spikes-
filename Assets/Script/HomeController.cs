using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    public Button btnStart;
    public Sprite StaClick;
    public Sprite StaOut;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void StartClick()
    {
        btnStart.GetComponent<Image>().sprite = StaClick;
    }
    public void StartIdle()
    {
        btnStart.GetComponent<Image>().sprite = StaOut;
    }
}
