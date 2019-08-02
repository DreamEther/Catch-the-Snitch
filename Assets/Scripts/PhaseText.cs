using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PhaseText : MonoBehaviour
{

    public TextMeshProUGUI phaseText;
    bool nextSceneIsLoaded = false;
    SceneLoader sceneLoader;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void OnSceneLoad()
    {
        // fades the image out when you click
        StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 2; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                phaseText.color = new Color(1, 0, 0.01667595f, i);
                yield return null;
            }

        }

        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                phaseText.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
