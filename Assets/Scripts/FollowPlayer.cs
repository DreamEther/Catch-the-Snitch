using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public bool bounds;
   public Vector3 minCameraPos; // we set the values in the Inspector
    public Vector3 maxCameraPos; // we set the values in the Inspector
    public SpriteRenderer rink;

    // Start is called before the first frame update
    void Start()
    {  
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = rink.bounds.size.x / rink.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = rink.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = rink.bounds.size.y / 2 * differenceInSize;
        }
    }
    /* // set the desired aspect ratio (the values in this example are
     // hard-coded for 16:9, but you could make them into public
     // variables instead so you can set them at design time)
     float targetaspect = 1080f / 2200f;

     // determine the game window's current aspect ratio
     float windowaspect = (float)Screen.width / (float)Screen.height;

     // current viewport height should be scaled by this amount
     float scaleheight = windowaspect / targetaspect;

     // obtain camera component so we can modify its viewport
     Camera camera = GetComponent<Camera>();

     // if scaled height is less than current height, add letterbox
     if (scaleheight < 1.0f)
     {
         Rect rect = camera.rect;

         rect.width = 1.0f;
         rect.height = scaleheight;
         rect.x = 0;
         rect.y = (1.0f - scaleheight) / 2.0f;

         camera.rect = rect;
     }
     else // add pillarbox
     {
         float scalewidth = 1.0f / scaleheight;

         Rect rect = camera.rect;

         rect.width = scalewidth;
         rect.height = 1.0f;
         rect.x = (1.0f - scalewidth) / 2.0f;
         rect.y = 0;

         camera.rect = rect;
     } */


    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    
    public void Follow()
    {
        var player = FindObjectOfType<Player>().transform.position;
        Vector3 followPlayer = new Vector3(player.x, player.y, 0);
        transform.position = followPlayer;
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }

    } 



    }
