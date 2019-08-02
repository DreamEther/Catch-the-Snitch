using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] public float moveSpeedX = 10f; // variable to store the speed of Player Object. 
    [SerializeField] public float moveSpeedY = 10f;
    [SerializeField] float padding = 1f; // so spaceship stops at edge of screen, considering the pivot point is the center of the ship
    [SerializeField] float health = 200;
    [SerializeField] public static float healthAsPercentage = 1;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;
    [SerializeField] AudioClip laserSound;
    [SerializeField] [Range(0, 1)] float laserSoundVolume = 0.25f;
    [SerializeField] GameObject hitParticlePrefab;

    [Header("Player Projectile")]
    [SerializeField] public GameObject playerLaserPrefab;
    [SerializeField] float projectileFiringPeriod = 0.5f;
    int hitBlinkCounter = 2;
    HealthBar healthBar;
    SceneLoader sceneLoader;
    Enemy enemy;
    int snitches;
    [Header("Oscillate On Hit")]
    [SerializeField] float startTime;
    [SerializeField] float speed;
    [SerializeField] bool repeatable = false;

    [Header("Forces Applied On Hit")]
    [SerializeField] float forceFieldForce;
    [SerializeField] float projectileForce;

    Joystick joystickMovement;
    Vector3 moveVector;

    public GameObject playerDeathParticlePrefab;

    float horizontalMove = 0f;
    Coroutine firingCoroutine;

    public Vector3 minPlayerPos;
    public Vector3 maxPlayerPos;
    public Joystick joystick;
    float rotationDuration = 0.5f;
    float smooth;

    float yMin;
    float yMax;
    float xMin;
    float xMax;

    float minScreenBoundsX;
    float maxScreenBoundsX;
    float minScreenBoundsY;
    float maxScreenBoundsY;

    public float knockBackForce;

    public Quaternion newRotation;

    Joystick joystickRef;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        healthBar = FindObjectOfType<HealthBar>();
        healthAsPercentage = 1;
        joystickMovement = FindObjectOfType<Joystick>();
    }


    // Update is called once per frame
    void Update()
    {
        snitches = FindObjectsOfType<Snitch>().Length;
        Move(); 
        Fire();
        Rotate();
        OscillateColorsWhenHit();
        if (snitches <= 0)
        {
            healthAsPercentage = 1;
        }
    }



    private void OscillateColorsWhenHit()
    {
        if (repeatable == true)
        {
            float t = startTime--;

            if (t % 2 == 0)
            {
                GetComponent<SpriteRenderer>().material.color = Color.black;
            }
            if (t % 3 == 0)
            {
                GetComponent<SpriteRenderer>().material.color = Color.white;
            }
            if (startTime == 0)
            {
                GetComponent<SpriteRenderer>().material.color = Color.white;
                repeatable = false;
            }
        }
    }
    private void Rotate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            smooth = Time.deltaTime * rotationDuration;
            var rotateRight = new Vector3(0, 0, -359 * smooth);
            transform.Rotate(rotateRight, Space.World);
            //  Vector3 rot = gameObject.transform.localRotation.eulerAngles;
            // OTHER METHODS - CAN ONLY GO UP TO 180 THO - transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 180), rotationDuration * Time.deltaTime);
            // OTHER METHODS - TRANSFORMS LOCAL TRANSFORM BUT IT CAN ONLY BE AN ABSOLUTE VALUE. CANNOT INCREMENT transform.localEulerAngles = new Vector3(0, 0, 359);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            smooth = Time.deltaTime * rotationDuration;
            var rotateLeft = new Vector3(0, 0, 359 * smooth);
            transform.Rotate(rotateLeft, Space.World);
            // var rot = gameObject.transform.localRotation.eulerAngles;
        }
    }

    private void Fire()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (CrossPlatformInputManager.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {                                                // Quaternion.identity is simply saying - 'keep rotation as is'
        while (true)
        {
            AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
            GameObject laser = ObjectPooler.SharedInstance.GetPooledObject("Laser");
            if (laser != null)
            {
                laser.transform.position = transform.position;
                laser.transform.rotation = transform.rotation;
                laser.SetActive(true);

            }
            yield return new WaitForSecondsRealtime(projectileFiringPeriod);
            // GameObject laser = Instantiate(playerLaserPrefab, transform.position, transform.rotation) as GameObject; // transform.position because that is the position of the player ship, which has a pivot point at its center.
            // laser.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
            // AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
            // yield return new WaitForSecondsRealtime(projectileFiringPeriod);
        }

    }

    private void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        DamageDealer damageDealer = otherGameObject.gameObject.GetComponent<DamageDealer>();
        if (otherGameObject.gameObject.tag == "mutant beam" || otherGameObject.gameObject.tag == "spike laser left" || otherGameObject.gameObject.tag == "spike laser right"
            || otherGameObject.gameObject.tag == "cluster projectile" || otherGameObject.gameObject.tag == "orange heavy" || otherGameObject.gameObject.tag == "blue heavy" || otherGameObject.gameObject.tag == "pink heavy" || otherGameObject.gameObject.tag == "green heavy")
        {
            startTime = 20;
            repeatable = true;
            otherGameObject.gameObject.SetActive(false);
            GameObject explosionParticleEffect = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(explosionParticleEffect, .30f);
        }
      
        if (!damageDealer)
        {
            return;
        }
       
        ProcessShipCollision(damageDealer);
        ProcessChargingLaserAndOrbLightning(damageDealer);
        //ProcessForceFieldDamage(damageDealer);
        ProcessAllEnemyProjectileDamage(damageDealer);
     
    }

    IEnumerator Knockback(GameObject attacker, float force)
    {
        Vector3 knock = attacker.transform.up;
        knock *= force;
        GetComponent<Rigidbody2D>().AddForce(knock);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero; // this is necessary. Otherwise the force we added will be continuous.
    }

    IEnumerator KnockbackSelf(GameObject self, float force)
    {
        Vector3 knock = self.transform.up * -1;
        knock *= force;
        GetComponent<Rigidbody2D>().AddForce(knock, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero; // this is necessary. Otherwise the force we added will be continuous.
    }



    private void ProcessShipCollision(DamageDealer damageDealer)
    {
            if (damageDealer.gameObject.tag == "enemy")
            {
                if (healthAsPercentage > 0)
                {
                     StartCoroutine(Knockback(damageDealer.gameObject, 50));
                     healthAsPercentage -= 0.0666666666666667f;
                     healthBar.SetSize(healthAsPercentage);
                     GameObject explosionParticleEffect = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity) as GameObject;
                     Destroy(explosionParticleEffect, 2);
                }
                   Die();
            }        
    }

    private void ProcessChargingLaserAndOrbLightning(DamageDealer damageDealer)
    {
        if (damageDealer.gameObject.tag == "charging laser" || damageDealer.gameObject.tag == "orb lightning")
        {
          
            if (healthAsPercentage > 0)
            {
                StartCoroutine(KnockbackSelf(damageDealer.gameObject, 2));
                healthAsPercentage -= 0.05f;
                healthBar.SetSize(healthAsPercentage);
                GameObject explosionParticleEffect = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity) as GameObject;
                Destroy(explosionParticleEffect, .13f);
            }
            Die();
        }
        
    }

    private void ProcessForceFieldDamage(DamageDealer damageDealer)
    {
        if (damageDealer.gameObject.tag == "force field")
        {
            
            if (healthAsPercentage > 0)
            {
                StartCoroutine(KnockbackSelf(this.gameObject, 2));
                healthAsPercentage -= 0.10f;
                healthBar.SetSize(healthAsPercentage);
                GameObject explosionParticleEffect = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity) as GameObject;
                Destroy(explosionParticleEffect, .13f);
            }
            Die();
        }
       
    }

    private void ProcessAllEnemyProjectileDamage(DamageDealer damageDealer)
    {
        if (damageDealer.gameObject.tag == "spike laser left" || damageDealer.gameObject.tag == "spike laser right" || damageDealer.gameObject.tag == "mutant beam" || damageDealer.gameObject.tag == "cluster projectile"
            || damageDealer.gameObject.tag == "orange heavy" || damageDealer.gameObject.tag == "blue heavy" || damageDealer.gameObject.tag == "pink heavy" || damageDealer.gameObject.tag == "green heavy")

        {
        
            if (healthAsPercentage > 0)
            {
                StartCoroutine(Knockback(damageDealer.gameObject, 50));
                healthAsPercentage -= 0.04f;
                healthBar.SetSize(healthAsPercentage);
                GameObject explosionParticleEffect = Instantiate(hitParticlePrefab, transform.position, Quaternion.identity) as GameObject;
                Destroy(explosionParticleEffect, .12f);
            }
            Die();
        }

    }

  
    public void Die()
    {
        if (healthAsPercentage <= 0)
        {
            Destroy(gameObject);
            GameObject explosionParticleEffect = Instantiate(playerDeathParticlePrefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(explosionParticleEffect, 2);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
            sceneLoader.LoadGameOver();

            // using transform.position would make the sound lose power due to the audio
            //being played in a 3D space. So, instead we are playing audio where the main camera resides
            //which is where the audio listener is. 
        }
    }

    public void Move()
    {
       // var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeedX; // FOR KEYBOARD.   reference to File- Project Settings - Input - refers to the horizontal axis. 
      //  var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeedY;  // FOR KEYBOARD
        var deltaX = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * moveSpeedX; // FOR MOBILE
        var deltaY = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * moveSpeedY;// FOR MOBILE 
        if (deltaX != 0 || deltaY != 0)
         {
            if (joystickMovement.delta.x < -.40f || joystickMovement.delta.x > .40f || joystickMovement.delta.y < -.40f || joystickMovement.delta.y > .40f)
            {
                var newXPos = transform.position.x + deltaX;
                var newYPos = transform.position.y + deltaY;
                transform.position = new Vector3(Mathf.Clamp(transform.position.x + deltaX, minPlayerPos.x, maxPlayerPos.x),
                        Mathf.Clamp(transform.position.y + deltaY, minPlayerPos.y, maxPlayerPos.y),
                        Mathf.Clamp(transform.position.z, minPlayerPos.z, maxPlayerPos.z));

               Vector3 moveVector = new Vector3(deltaX, deltaY, 0);
                newRotation = Quaternion.LookRotation(moveVector, transform.forward * -1);
                newRotation.x = 0;
                newRotation.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.3f + Time.deltaTime);

            }
            else
            {
                deltaX = 0;
                deltaY = 0;
                var deltaXStat = CrossPlatformInputManager.GetAxis("Horizontal");
                var deltaYStat = CrossPlatformInputManager.GetAxis("Vertical");
                Vector3 moveVector = new Vector3(deltaXStat, deltaYStat, 0);
                newRotation = Quaternion.LookRotation(moveVector, transform.forward * -1);
                newRotation.x = 0;
                newRotation.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.3f + Time.deltaTime);
            }
        }
     

    }
  
   

   /* private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding; //viewporttoworldpoint converts the position of something as it relates to the camera view, into a world space value
        // world space value has bottomleft corner(0,0), bottomright corner(1,0), top left(0,1), and top right(1,1)
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding; // first two numbers represent the x and y axis. Third number represents the z axis
    }*/
           
}
    