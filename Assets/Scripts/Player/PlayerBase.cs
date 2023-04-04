using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBase : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    private bool alive = true;

    [Header("Speed")]
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed;
    public float speedRun;
    public float jumpForce = 2;

    [Header("Animation")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 1f;
    public float animationDuration = .5f;
    public Ease ease = Ease.OutBack;
    


    [Header("Shooter")]
    public GameObject ammo;
    public Transform shootPoint;
    public ShooterManager poolManager;
    
    public int deathNumber = 0;


    [Header("Animation Player")]
    public string boolRun = "Run";
    public Animator animator;
    public float playerSwipeDuration = .1f;
    bool isJumping = false;
    public bool isLookingUp = false;
    
    
    private float _currentSpeed;
    

    private void Update()
    {
        Restart();
        if (alive)
        {
            HandleMoviment();
            HandleJump();
            LookUp();
        }
          

        /*if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnObject();
        }*/
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.Z))
            _currentSpeed = speedRun;
        else
            _currentSpeed = speed;


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            if(!animator.GetBool("Jump"))
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, playerSwipeDuration);
            }
            if (!animator.GetBool("Jump"))
                animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        if(myRigidBody.velocity.x > 0)
        {
            myRigidBody.velocity += friction;
        }
        else if (myRigidBody.velocity.x <0)
        {
            myRigidBody.velocity -= friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidBody.velocity = Vector2.up * jumpForce;
            //usado para que não buggue o scale!//
            myRigidBody.transform.localScale = Vector2.one;
            if (!animator.GetBool("Jump"))
            {
                isJumping = true;
                animator.SetBool("Jump", true);
            }
            DOTween.Kill(myRigidBody.transform);

            HandleScale();
        }
        if (!isJumping)
        {
            return;
        }

        isJumping = false;
    }

    private void HandleScale()
    {
        myRigidBody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidBody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    /*private void SpawnObject()
    {
        var obj = poolManager.GetPooledObject();
        obj.SetActive(true);
        obj.GetComponent<ProjectileFire>().StartProjectileFire();
        obj.GetComponent<ProjectileFire>().dir = Vector3.left;
        obj.GetComponent<ProjectileFire>().OnHitTarget = CountDeaths;
        obj.transform.position = shootPoint.transform.position;
    }

    private void CountDeaths()
    {
        deathNumber++;
        Debug.Log("Count" + deathNumber);
    }*/
    public void Restart()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetTrigger("Idle");
            alive = true;
        }
    }

    public void LookUp()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            isLookingUp = true;
            animator.SetBool("LookUp", true);
            
            
        }
        else
        {
            isLookingUp = false;
        }
    }

   
}
