using System;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour, IGravityBoxClient
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;

    [SerializeField] float maxJumpHeight;
    [SerializeField] float maxJumpTime;
    float timetoApex;
    float gravity;
    float initialVelocity;
    float groundedVelocity = -0.5f;
    bool isGrounded;
    float fallGravityMultiplayer = 2;
    float y;
    bool isJumping;

    [SerializeField] float accleration;
    [SerializeField] float deccleration;
    [SerializeField] float maxSpeed;
    [SerializeField] float airSpeed;
    [SerializeField] float maxAirDistance = 4f;

    [SerializeField] LayerMask platformLayer;
    [SerializeField] float boxcastDistance = 1f;
    [SerializeField] float forwardJumpSpeed = 2f; // New variable for forward speed during jump
    float x;
    Vector2 targetVelocity;
    Vector2 moveVelocity;
    public bool canJump = false;
    bool jumped = false;


    [SerializeField] LayerMask interactables;
    [SerializeField] float interactableDistance =1f;
    
    float previous_X = -3;
    Vector2 interactDirection;

    PullBox currentPullBox;

    bool canPush;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        SetUpJumpProperties();
        InputManager.Instance.OnJump += HandelJump;
        InputManager.Instance.OnInteract += HandelInteraction;
    }

    private void HandelJump(object sender, EventArgs e)
    {
        if (canJump && !jumped)
        {
            y = initialVelocity;
            isJumping = true;
            jumped = true;
            moveVelocity.x = forwardJumpSpeed * Mathf.Sign(x); // Apply forward motion during jump
        }
    }

    // Update is called once per frame
    void Update()
    {
        x = InputManager.Instance.Horizontal;
        float currentSpeed = isGrounded ? maxSpeed : airSpeed;

        if (Mathf.Abs(x) > 0.1f)
        {
            targetVelocity = new Vector2(x, 0) * currentSpeed;
        }
        else
        {
            targetVelocity = Vector2.zero;
        }

        float currentAccleration = (Mathf.Abs(x) > 0.1f) ? accleration : deccleration;

        // Adjust horizontal velocity only if not jumping
        if (!isJumping)
        {
            moveVelocity = Vector2.Lerp(moveVelocity, targetVelocity, currentAccleration * Time.deltaTime);
        }

        rb.velocity = new Vector2(moveVelocity.x, y);

        Handelgravity();



        if(x != 0)
        {
            previous_X = x;
            interactDirection = new Vector2(previous_X,0);

        }




    }

    void SetUpJumpProperties()
    {
        timetoApex = maxJumpTime / 2;
        initialVelocity = 2 * maxJumpHeight / timetoApex;
        gravity = -2 * maxJumpHeight / Mathf.Pow(timetoApex, 2);
    }

    void Handelgravity()
    {
        isGrounded = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, boxcastDistance, platformLayer);

        if (isGrounded && y <= 0)
        {
            y = groundedVelocity;
            isJumping = false;
        }
        else if (isJumping && y <= 0)
        {
            float perviousVelocity = y;
            float newVelcity = perviousVelocity + (gravity * fallGravityMultiplayer);
            float nextvelocity = perviousVelocity + newVelcity * 0.5f * Time.deltaTime;
            y = nextvelocity;
        }
        else
        {
            float perviousVelocity = y;
            float newVelcity = perviousVelocity + gravity;
            float nextvelocity = perviousVelocity + newVelcity * 0.5f * Time.deltaTime;
            y = nextvelocity;
        }
    }

    public void EnableJump()
    {
        canJump = true;
    }

    public Rigidbody2D GetRigidbody2D()
    {
        return rb;
    }

    void HandelInteraction(object sender, EventArgs e)
    {

        if(currentPullBox != null)
        {
            currentPullBox.Interact(this);
            currentPullBox = null;

        }


        RaycastHit2D hit2D = Physics2D.Raycast(transform.position , interactDirection  , interactableDistance , interactables );



        if(hit2D.collider != null)
        {
            if(hit2D.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                if(interactable is PullBox && canPush)
                {
                    if(currentPullBox == null)
                    {
                        interactable.Interact(this);
                        currentPullBox = interactable as PullBox;

                    }

                }
                else{
                    
                        interactable.Interact(this);
                        

                }
                
            }
        }
    }


    public void EnablePushAbility()
    {
        canPush = true;
    }
}
