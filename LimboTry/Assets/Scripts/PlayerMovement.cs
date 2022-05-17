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
    public GameObject effectorTarget;
    bool canMove = true;
    Transform gunPoint;
    [SerializeField] GameObject bulletDustPs;

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
        crossHair = GameObject.Find("CrossHair");
        gunPoint = GameObject.Find("gunPoint").transform;
        rightEye = GameObject.Find("EyeL_1");
        collider = GetComponent<CapsuleCollider2D>();
        //groundCheckPos = gameObject.transform.Find("GroundCheckPos").transform;

    }
    void Start()
    {

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
            FindObjectOfType<AudioManagerCS>().Play("Fire");
        }
        if (Input.GetMouseButtonDown(1))
        {

            FindObjectOfType<AudioManagerCS>().Play("GunCock");
        }
        if (Input.GetMouseButton(1))
        {
            aiming = true;
            SetIkWeight(1);
            crossHair.SetActive(true);

            rightEye.transform.localScale = new Vector2(.5f, 1.2f);

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
        rightEye.transform.localScale = new Vector2(1f, 1f);
    }

    bool jump = false;
    
    void Jump()
    {
        

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!IsGrounded())
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


    [Header("CheckGround")]
    [SerializeField] float radius;
    [SerializeField] Transform groundCheckPos;
    [SerializeField] LayerMask whatIsGround;
   // bool isGrounded;

    const int maxReturnedIntersections = 1;
    private RaycastHit2D[] hits = new RaycastHit2D[maxReturnedIntersections];
    public void CheckSurroundings()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheckPos.position, radius, whatIsGround);

        // return;

      

        if (IsGrounded())
        {
            
                jump = false;
                animator.SetBool("jump", false);
            
           
        }
        else
        {
            animator.SetBool("jump", true);
        }
    }

    public bool IsGrounded()
    {
        float extraHeight = .03f;
        RaycastHit2D rayCastHit = Physics2D.Raycast(collider.bounds.center, Vector2.down, collider.bounds.extents.y + extraHeight, whatIsGround);
        Color rayColor;
        if(rayCastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(collider.bounds.center, Vector2.down * (collider.bounds.extents.y + extraHeight));
        return rayCastHit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckPos.position, radius);
        //Gizmos.DrawRay(groundCheckPos.position, Vector2.down * radius);
    }
}
