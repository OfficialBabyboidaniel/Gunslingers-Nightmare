using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    // Start is called before the first frame update

    public void Restart()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("PreviosScene"));
        Debug.Log("tryinng to restart");
    }
}
