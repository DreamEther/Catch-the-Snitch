using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundScroller : MonoBehaviour
{

    [SerializeField] float backgroundScrollSpeed = 0.5f;
    Material myMaterial;
    Vector2 offsetMovementUp;
    Vector2 offsetMovementDown;
    Vector2 offsetMovementLeft;
    Vector2 offsetMovementRight;
    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            offsetMovementDown = new Vector2(0f, -backgroundScrollSpeed);
            myMaterial.mainTextureOffset += offsetMovementDown * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            offsetMovementUp = new Vector2(0f, backgroundScrollSpeed);
            myMaterial.mainTextureOffset += offsetMovementUp * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            offsetMovementRight = new Vector2(backgroundScrollSpeed, 0f);
            myMaterial.mainTextureOffset += offsetMovementRight * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            offsetMovementLeft = new Vector2(-backgroundScrollSpeed, 0f);
            myMaterial.mainTextureOffset += offsetMovementLeft * Time.deltaTime;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            offsetMovementUp = new Vector2(0f, backgroundScrollSpeed);
            myMaterial.mainTextureOffset += offsetMovementUp * Time.deltaTime;
        }

    }
}
