using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Transform image;
    private GameObject healthBar;
    private Image imageColor;
    public float startTime = 1000f;
    // Start is called before the first frame update
    void Start()
    {
   
        image = transform.Find("Image");
        healthBar = GameObject.Find("Image");
        imageColor = healthBar.GetComponent<Image>();
        image.localScale = new Vector3(1f, 1f);
    }

    public void SetSize(float sizeNormalized)
    {
        image.localScale = new Vector3(sizeNormalized, 1f);    
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Player.healthAsPercentage <= .30f)
        {
            float t = startTime--;

            if (t % 2 == 0)
            {
                imageColor.color = Color.white;
            }
            if (t % 3 == 0)
            {
                imageColor.color = Color.red;
            }
        }
        if(Player.healthAsPercentage > .70f)
        {
            imageColor.color = Color.red;
        }
     
    }


    
    
}
