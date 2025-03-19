using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text txtPoint;
    public Text txtFinalPoint;

    public Button btnRestart;
    public Button btnHome;

    public Sprite ResClick;
    public Sprite ResOut;
    public Sprite HomOut;
    public Sprite HomClick;

    public GameObject pnlEndGame;

    private int point;
    // Start is called before the first frame update
    void Start()
    {
        pnlEndGame.SetActive(false);
        point = 0;
    }
    public void Endgame()
    {
        Time.timeScale = 0;
        txtFinalPoint.text = "Your Score: " + point.ToString();
        pnlEndGame.SetActive(true);
        var clones = GameObject.FindGameObjectsWithTag("Spike");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
        clones = GameObject.FindGameObjectsWithTag("Warning");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }

    public void GotoHome()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        point = 0;
        pnlEndGame.SetActive(false);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void RestartButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = ResClick;
    }
    public void RestartButtonOut()
    {
        btnRestart.GetComponent<Image>().sprite = ResOut;
    }
    public void HomeButtonClick()
    {
        btnHome.GetComponent<Image>().sprite = HomClick;
    }
    public void HomeButtonOut()
    {
        btnHome.GetComponent<Image>().sprite = HomOut;
    }
    public void IncPoint()
    {
        point++;
        txtPoint.text = point.ToString();
    }
}
