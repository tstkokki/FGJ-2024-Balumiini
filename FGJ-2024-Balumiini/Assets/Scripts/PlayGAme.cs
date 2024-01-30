using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGAme : MonoBehaviour
{

    public List<Stats> stats = new();

    public void PlayGame()
    {
        foreach (var item in stats)
        {
            item.OnReset();
        }


        SceneManager.LoadScene(1);
    }
}
