using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    [Header("Movement")]
    [Range(100, 1000)]
    [SerializeField] float Speed;
    float XInput, YInput;
    Rigidbody2D RB;

    [Header("Player Bools")]
    [SerializeField]
    private bool isAnimationPlaying = false;
    public bool isInteracting;



    void Awake()
    {
       
    }



    // Start is called before the first frame update

    void Start()
    {
        //gameManager = FindObjectOfType<GameManager>();
        //gameManager.LoadSettings();
        anim = GetComponentInChildren<Animator>();
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponentInChildren<Animator>() != null)
        {
            Animation();
            Movement();


         
        }


    }
    private void FixedUpdate()
    {
        XInput = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        YInput = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        RB.velocity = new Vector2(XInput, YInput);
    }


    public void SetAnimationPlaying(bool isPlaying)
    {
        isAnimationPlaying = isPlaying;
    }
    void Animation()
    {
        //walking animation
        anim.SetFloat("XInput", Mathf.Abs(XInput));
        anim.SetFloat("YInput", Mathf.Abs(YInput));
    }

    void Movement()
    {
        //Input
        XInput = Input.GetAxisRaw("Horizontal");
        YInput = Input.GetAxisRaw("Vertical");
       
        InteractingKey();

        //Flipping Sprite

        if (XInput >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (XInput <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);


        }
      

    }
    void InteractingKey()
    {
        if (Input.GetKey(KeyCode.E))
        {
            isInteracting = true;
        }
        else isInteracting = false;
        if (isInteracting)
        {
           // anim.SetTrigger("InteractingKey");
        }
        if (!isInteracting)
        {
            //anim.ResetTrigger("InteractingKey");
        }
    }

  
}
