using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SwipeManagerTestScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI outputText;

    // Update is called once per frame
    void Update()
    {
        outputText.text = SwipeManager.Instance.Direction.ToString();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
