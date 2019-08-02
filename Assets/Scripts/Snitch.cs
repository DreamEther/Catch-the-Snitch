using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snitch : MonoBehaviour
{

    [SerializeField] GameObject snitchDeathParticlePrefab;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f; // the range is from 0 to 1 for 'PlayClipAtPoint's 3rd argument
    [SerializeField] GameObject forceFieldPrefab;
    [SerializeField] AudioClip forceFieldSound;
    [SerializeField] [Range(0, 1)] float forceFieldSoundVolume;
    [SerializeField] int incrementSnitchCounter = 1;
    [SerializeField] GameObject hitParticlePrefab;

    Phase phase;
    Enemy enemy;
    Orb1 orb1;
    Orb2 orb2;
    Orb3 orb3;
    Orb4 orb4;
    Orb5 orb5;
    Color orbColor1;
    Color orbColor2;
    Color orbColor3;
    Color orbColor4;
    Color orbColor5;
    Color colorBlue;
    Color colorRed;
    Color colorGreen;
    Color colorPurple;
    Color colorPink;
  
   [SerializeField] Colors colors_db;

    GameTimer gameTimer;

    [SerializeField] int health = 2000;

   
    GameObject blueSnitch;
    GameObject redSnitch;
    GameObject greenSnitch;
    GameObject pinkSnitch;
    GameObject purpleSnitch;

    Vector2 force = new Vector2(0, 0);
    Player player;
    public Vector3 targetPos;
    public bool isMoving;
    public float maxRange = 2f;
    public float waitTime = 1f;
    int currentSceneIndex;

   // public GameObject[] waypoints;
   // int currentWP = 0;

    //float speed = 10f;
    //float accuracy = .3f;
    //float rotSpeed = 3f;

    void Start()
    {
        colorBlue = colors_db.GetColor("Blue");
        colorRed = colors_db.GetColor("Red");
        colorGreen = colors_db.GetColor("Green");
        colorPink = colors_db.GetColor("Pink");
        colorPurple = colors_db.GetColor("Purple");

        player = FindObjectOfType<Player>();

        blueSnitch = GameObject.FindGameObjectWithTag("blue snitch");
        redSnitch = GameObject.FindGameObjectWithTag("red snitch");
        greenSnitch = GameObject.FindGameObjectWithTag("green snitch");
        pinkSnitch = GameObject.FindGameObjectWithTag("pink snitch");
        purpleSnitch = GameObject.FindGameObjectWithTag("purple snitch");

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        gameTimer = FindObjectOfType<GameTimer>();

        orb1 = FindObjectOfType<Orb1>();
        orb2 = FindObjectOfType<Orb2>();
        orb3 = FindObjectOfType<Orb3>();
        orb4 = FindObjectOfType<Orb4>();
        orb5 = FindObjectOfType<Orb5>();
        //waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    void Update()
    {

        

        if (currentSceneIndex == 1)
        {
            orbColor1 = orb1.GetComponent<SpriteRenderer>().material.color;
        }

         if (currentSceneIndex == 2)
          {
             orbColor2 = orb2.GetComponent<SpriteRenderer>().material.color;
          }

         if (currentSceneIndex == 3)
         {
            orbColor3 = orb3.GetComponent<SpriteRenderer>().material.color;
         }
          if (currentSceneIndex == 4)
          {
              orbColor4 = orb4.GetComponent<SpriteRenderer>().material.color;
          }

          if (currentSceneIndex == 5)
          {
              orbColor5 = orb5.GetComponent<SpriteRenderer>().material.color;
          }

        StartCoroutine(DestroyForceField());

    }
    void LateUpdate()
    {

      
        /* if (waypoints.Length == 0)
         {
             return;
         }
         Vector3 lookAt = new Vector3(waypoints[currentWP].transform.position.x, waypoints[currentWP].transform.position.y, this.transform.position.z);
         var direction = lookAt - transform.position;

         var newRotation = Quaternion.LookRotation(waypoints[currentWP].transform.position - transform.position, Vector3.forward); //we set the upwards rotation to forward, which makes are z axis up and allows us rotate along it 'forwards' aka horizontally
         newRotation.x = 0.0f;
         newRotation.y = 0.0f;
         transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * speed); 


             if (direction.magnitude < accuracy)
         {
             currentWP++;
             if (currentWP >= waypoints.Length)
             {
                 currentWP = 0;
             }
         } */

       //  transform.position = Vector3.MoveTowards(transform.position, lookAt, speed * Time.deltaTime);

    }

    /*private void FindNewTargetPos()
    {
        Vector3 pos = transform.position;
        targetPos = new Vector3();
        targetPos.x = Random.Range(pos.x - maxRange, pos.x + maxRange);
        targetPos.y = Random.Range(pos.y - maxRange, pos.y + maxRange);
        targetPos.z = transform.position.z;
        transform.LookAt(targetPos);
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        isMoving = true;

        for(float t = 0.0f; t < 1f; t += Time.deltaTime * speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, t);
        }

        yield return new WaitForSeconds(waitTime);
        isMoving = false;
        yield return null;
    } */


  
    IEnumerator DestroyForceField()
    {

        if (orbColor1 == colorBlue || orbColor2 == colorBlue || orbColor3 == colorBlue || orbColor4 == colorBlue || orbColor5 == colorBlue)
        {
            Animator blueSnitchForceField = blueSnitch.GetComponentInChildren<Animator>();
            if (blueSnitchForceField != null)  //if it isn't null (i.e. it has a GameObject)
            {
                blueSnitchForceField.gameObject.SetActive(false);
                yield return new WaitWhile(() => orbColor1 == colorBlue || orbColor2 == colorBlue || orbColor3 == colorBlue || orbColor4 == colorBlue || orbColor5 == colorBlue);
                blueSnitchForceField.gameObject.SetActive(true);
            }
        }
        
        if (orbColor1 == colorGreen || orbColor2 == colorGreen || orbColor3 == colorGreen || orbColor4 == colorGreen || orbColor5 == colorGreen)
        {
            Animator greenSnitchForceField = greenSnitch.GetComponentInChildren<Animator>();
            if (greenSnitchForceField != null)
            {
                greenSnitchForceField.gameObject.SetActive(false);
                yield return new WaitWhile(() => orbColor1 == colorGreen || orbColor2 == colorGreen || orbColor3 == colorGreen || orbColor4 == colorGreen || orbColor5 == colorGreen);
                greenSnitchForceField.gameObject.SetActive(true);
            }
        }

        if (orbColor1 == colorRed || orbColor2 == colorRed || orbColor3 == colorRed || orbColor4 == colorRed || orbColor5 == colorRed)
        {
           
            Animator redSnitchForceField = redSnitch.GetComponentInChildren<Animator>();
            if (redSnitchForceField != null)
            {
                redSnitchForceField.gameObject.SetActive(false);
                yield return new WaitWhile(() => orbColor1 == colorRed || orbColor2 == colorRed || orbColor3 == colorRed || orbColor4 == colorRed || orbColor5 == colorRed);
                redSnitchForceField.gameObject.SetActive(true);
            }
        }

        if (orbColor1 == colorPink || orbColor2 == colorPink || orbColor3 == colorPink || orbColor4 == colorPink || orbColor5 == colorPink)
        {

            Animator pinkSnitchForceField = pinkSnitch.GetComponentInChildren<Animator>();
            if (pinkSnitchForceField != null)
            {
                pinkSnitchForceField.gameObject.SetActive(false);
                yield return new WaitWhile(() => orbColor1 == colorPink || orbColor2 == colorPink || orbColor3 == colorPink || orbColor4 == colorPink || orbColor5 == colorPink);
                pinkSnitchForceField.gameObject.SetActive(true);
            }
        }

        if (orbColor1 == colorPurple || orbColor2 == colorPurple || orbColor3 == colorPurple || orbColor4 == colorPurple || orbColor5 == colorPurple)
        {
            Animator purpleSnitchForceField = purpleSnitch.GetComponentInChildren<Animator>();
            if (purpleSnitchForceField != null)
            {
                purpleSnitchForceField.gameObject.SetActive(false);
                yield return new WaitWhile(() => orbColor1 == colorPurple  || orbColor2 == colorPurple || orbColor3 == colorPurple || orbColor4 == colorPurple || orbColor5 == colorPurple);
                purpleSnitchForceField.gameObject.SetActive(true);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        DamageDealer damageDealer = otherGameObject.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer) // this is saying: 'when anything calls ProcessHit, we need to know who is 'damageDealer'.
    {
        if (damageDealer.gameObject.tag == "Laser")
        {
            health -= 50;
            GameObject explosionParticleEffect = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity) as GameObject;
        }
       
        Die();
        
    }


    public void Die()
    {
        
        if (health <= 0)
        {
            
                FindObjectOfType<GameTimer>().AddToScore(incrementSnitchCounter);
                GameObject explosionParticleEffect = Instantiate(snitchDeathParticlePrefab, transform.position, Quaternion.identity) as GameObject;
                Destroy(gameObject);
                float durationOfExplosion = 1f;
                Destroy(explosionParticleEffect, durationOfExplosion);
                AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
                enemy.DieWithSnitch();
            
           
            
        }

    }

   
    
}


        