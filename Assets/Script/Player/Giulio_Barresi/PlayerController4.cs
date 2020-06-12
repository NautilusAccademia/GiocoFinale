using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool isRunning;
    private Animator playerAn;

    public float maxFallDistance = 0f;

    public Transform tr;
    public Transform spawnPointPresent;
    public Transform spawnPointPast;

    public bool ignoreInput = false;

    [SerializeField] Transform groudPosition;
    [SerializeField] float rangeGroundCheck = 0.1f;
    [SerializeField] float heightGroundCheck = 0.4f;
    [SerializeField] bool showGroundCheck;

    GameObject lastPlatform;

    Rigidbody rb;

    [SerializeField] Collider colliderFriction;

    [SerializeField] LayerMask groundcheckmask;
    bool lastframeOnIce = false;
    //public float maxVelocity;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.5f;
        isRunning = false;
        maxFallDistance = spawnPointPresent.position.y - 10f;
        maxFallDistance = spawnPointPast.position.y - 10f;
        rb = GetComponent<Rigidbody>();
        playerAn = GetComponent<Animator>(); //aggiunta elisa
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!ignoreInput)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.0f || Input.GetAxisRaw("Horizontal") < -0.0f
                || Input.GetAxisRaw("Vertical") > 0.0f || Input.GetAxisRaw("Vertical") < -0.0f)
            {
                isRunning = false;

                float assX = Input.GetAxis("Horizontal");

                float assZ = Input.GetAxis("Vertical");

                Vector3 direction = new Vector3(assX, 0, assZ).normalized;

                transform.rotation = Quaternion.LookRotation(direction);

                rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) && isRunning == false)
                {
                    isRunning = true;
                    speed = 3.5f;
                }
                if (!isRunning)
                {
                    speed = 2.5f;
                }

                /*if(rb.velocity.magnitude > maxVelocity)
                {
                    rb.velocity = rb.velocity.normalized * maxVelocity;
                }
                else
                {
                    rb.AddForce(direction * acceleration * Time.fixedDeltaTime);
                }*/

                playerAn.SetBool("is_walking", true); //aggiunta elisa
            }
            else
            {
                playerAn.SetBool("is_walking", false); //aggiunta elisa
            }

            //rb.AddForce(direction * speed);
        }
        else
        {
            playerAn.SetBool("is_walking", false); //aggiunta elisa
        }

        Collider[] colliders = Physics.OverlapBox(groudPosition.position, new Vector3(rangeGroundCheck, heightGroundCheck, rangeGroundCheck),Quaternion.identity,groundcheckmask);
        GameObject tempPlatform = null;
        bool lastPlatformPresent = false;
        bool OnlyOnIce = true;

        foreach (Collider collider in colliders)
        {
            if (collider.tag != "colliderIce")
            {
                OnlyOnIce = false;
            }
            if (collider.tag == "Platform")
            {
                tempPlatform = collider.gameObject;
                if (lastPlatform != null && tempPlatform == lastPlatform)
                {
                    lastPlatformPresent = true;
                    break;
                }
            }
        }

        if (OnlyOnIce)
        {
            OnIce();

            

        }
        else
        {
            if (lastframeOnIce)
            {
                EndIgnoreInput();
            }
        }

        if (!lastPlatformPresent)
        {
            lastPlatform = tempPlatform;
        }
        if (lastPlatform != null)
        {
            transform.parent = lastPlatform.transform;
        }
        else
        {
            transform.parent = null;
        }

        if (tr.position.y < maxFallDistance && GameManager.instance.YouAreInThePresent == true && GameManager.health.health > 0)
        {
            GameManager.health.DecreaseHealth();
            GameManager.instance.playerGameObject.transform.position = spawnPointPresent.transform.position;
        }
        if (tr.position.y < maxFallDistance && GameManager.instance.YouAreInThePresent == false && GameManager.health.health > 0)
        {
            GameManager.health.DecreaseHealth();
            GameManager.instance.playerGameObject.transform.position = spawnPointPast.transform.position;
        }
        if (GameManager.health.health == 1)
        {
            spawnPointPresent = null;
            spawnPointPast = null;
            //Destroy(spawnPointPast.gameObject);
            //Destroy(spawnPointPresent.gameObject);
        }

        lastframeOnIce = OnlyOnIce;

    }
    private void OnDrawGizmos()
    {
        if (showGroundCheck)
        {
            Gizmos.DrawCube(groudPosition.position, new Vector3(rangeGroundCheck, heightGroundCheck, rangeGroundCheck));
        }
    }
    public void StartIgnoreInput()
    {
        ignoreInput = true;
    }

    public void EndIgnoreInput()
    {
        ignoreInput = false;
    }

    public IEnumerator EndIgnoreInputAfterCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameManager.playerController4.EndIgnoreInput();
    }

    void OnIce()
    {
        {
            Debug.Log("MADONNA");
            if (!ignoreInput)
            {
                if (Input.GetAxisRaw("Horizontal") > 0.0f || Input.GetAxisRaw("Horizontal") < -0.0f
               || Input.GetAxisRaw("Vertical") > 0.0f || Input.GetAxisRaw("Vertical") < -0.0f)

                {
                    isRunning = false;

                    Debug.Log("Inizio");
                    StartIgnoreInput();

                    float assX = Input.GetAxis("Horizontal");

                    float assZ = Input.GetAxis("Vertical");

                    Vector3 direction = new Vector3(assX, 0, assZ).normalized;

                    transform.rotation = Quaternion.LookRotation(direction);

                    //rb.AddForce(direction * speed);

                    rb.velocity = direction * 3.5f;


                    colliderFriction.material.dynamicFriction = 0;
                    colliderFriction.material.staticFriction = 0;


                }
            }
        }

    }
        /*void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "colliderIce")
            {
                Debug.Log("MADONNA");
                if (!ignoreInput)
                {
                    if (Input.GetAxisRaw("Horizontal") > 0.0f || Input.GetAxisRaw("Horizontal") < -0.0f
                   || Input.GetAxisRaw("Vertical") > 0.0f || Input.GetAxisRaw("Vertical") < -0.0f)

                    {
                        isRunning = false;

                        Debug.Log("Inizio");
                        StartIgnoreInput();

                        float assX = Input.GetAxis("Horizontal");

                        float assZ = Input.GetAxis("Vertical");

                        Vector3 direction = new Vector3(assX, 0, assZ).normalized;

                        transform.rotation = Quaternion.LookRotation(direction);

                        //rb.AddForce(direction * speed);

                        rb.velocity = direction * 3.5f;


                        colliderFriction.material.dynamicFriction = 0;
                        colliderFriction.material.staticFriction = 0;


                    }
                }
            }
        }*/

        /*private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "colliderIce")
            {
                EndIgnoreInput();
                Debug.Log("Fine");
            }
        }*/
    
}