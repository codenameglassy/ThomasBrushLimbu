using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;



public class PlayerMovement : MonoBehaviour
{
    private CharacterController2D controller;
    Animator animator;
    float horizontalMovement;

    [SerializeField] float speed;

    ParticleSystem dust;
    AudioManagerCS audio_;

    IKManager2D ik;


    GameObject crossHair;
    [HideInInspector]public GameObject gunCanvas;
    public GameObject gun;

    public GameObject effectorTarget;
    bool canMove = true;
    Transform gunPoint;
    [SerializeField] GameObject bulletDustPs;
    [SerializeField] GameObject bulletPrefab;
    GameObject rightEye;
    CapsuleCollider2D collider;
    // Start is called before the first frame update

    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        dust = gameObject.transform.Find("DustPS").GetComponent<ParticleSystem>();
        audio_ = FindObjectOfType<AudioManagerCS>();
        ik = GetComponent<IKManager2D>();
       
        gunPoint = GameObject.Find("gunPoint").transform;
       // rightEye = gameObject.transform.Find("EyeL_1").gameObject;
        collider = GetComponent<CapsuleCollider2D>();
        //groundCheckPos = gameObject.transform.Find("GroundCheckPos").transform;

        // gun = transform.Find("Gun").gameObject;
        gunCanvas = GameObject.Find("GunView");

    }
    void Start()
    {

        if (crossHair == null)
        {
            crossHair = GameObject.Find("CrossHair");
        }

        if(PlayerPrefs.GetInt("PlayerHasGun") == 0)
        {
            gun.SetActive(false);
            gunCanvas.SetActive(false);
        }else if(PlayerPrefs.GetInt("PlayerHasGun") == 1)
        {
            gun.SetActive(true);
            gunCanvas.SetActive(true);
        }


    }



    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
      
        animator.SetFloat("speed", Mathf.Abs(horizontalMovement));

        CheckSurroundings();
        Jump();
        Aim();
       

       
    }

    private void FixedUpdate()
    {
        
        controller.Move(horizontalMovement * speed * Time.deltaTime, false, jump);
    }

    public void CreateDust()
    {
        if(dust == null)
        {
            Debug.Log("Dust particle not found in child of player gameobject");
            return;
        }
        dust.Play();
    }

    public void PlayStepSound()
    {
        int index = Random.Range(1, 4);
        FindObjectOfType<AudioManagerCS>().PlayOneShot("footstep" + index);
    }



    [HideInInspector]public bool aiming = false;

    Vector2 direction;
    void Aim()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            if (!aiming)
            {
                return;
            }
            Instantiate(bulletDustPs, gunPoint.position, gunPoint.rotation);
            SpawnBullet();
            FindObjectOfType<AudioManagerCS>().PlayOneShot("Fire");
        }
        if (Input.GetMouseButtonDown(1))
        {

            if (PlayerPrefs.GetInt("PlayerHasGun") == 0)
            {
                return;
            }
            FindObjectOfType<AudioManagerCS>().Play("GunCock");
        }
        if (Input.GetMouseButton(1))
        {
            if (PlayerPrefs.GetInt("PlayerHasGun") == 0)
            {
                return;
            }
            aiming = true;
            SetIkWeight(1);
            crossHair.SetActive(true);

            //rightEye.transform.localScale = new Vector2(.5f, 1.2f);

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
            if (direction.x < 0 && controller.m_FacingRight || direction.x > 0 && !controller.m_FacingRight)
            {
                controller.Flip_Aim();
            }

            return;
        }
        aiming = false;
        SetIkWeight(0);
        crossHair.SetActive(false);
       // rightEye.transform.localScale = new Vector2(1f, 1f);
    }

    bool jump = false;
    
    void Jump()
    {
        

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {


            if (!controller.m_Grounded)
            {
                return;
            }
           
            animator.SetTrigger("takeOff");
            //animator.SetBool("jump", true);
            jump = true;
           
        }
        
    }

    public void OnLand()
    {

        jump = false;
        controller.m_Grounded = true;

    }

    public void MoveStateOFF()
    {
        speed = 0;
    }

    public void MoveStateOn()
    {
        speed = 70;
    }

    public void JumpGruntSound()
    {
        FindObjectOfType<AudioManagerCS>().Play("jumpGrunt");
        
    }
    public void LandSound()
    {
        CreateDust();
        FindObjectOfType<AudioManagerCS>().Play("footstep2");
    }
    public void SetIkWeight(float weight)
    {

        ik.weight = weight;
    }

    public void SpawnBullet()
    {
        Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
    }
  

    
    public void CheckSurroundings()
    {
       

        if (controller.m_Grounded)
        {
            
                jump = false;
                animator.SetBool("jump", false);
            
           
        }
        else
        {
            animator.SetBool("jump", true);
        }
    }


}
