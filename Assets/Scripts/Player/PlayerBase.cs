using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;


public class PlayerBase : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    private bool alive = true;
    public HealthBase healthBase;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;
      
    private float _currentSpeed;
    private Animator _currentPlayer;
    bool isJumping = false;
    public bool isLookingUp = false;

    [Header("Jump Collision Check")]
    public Collider2D collider2D;
    public float distanceToGround;
    public float spaceToGround;

    public ParticleSystem jumpVFX;

    public AudioSource audioSourceDeath;
    public AudioRandomPlayAudioClips randomJump;
    public GameOver gameOver;

    public float timeToChangeScreen = .2f;
    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }

        _currentPlayer = Instantiate(soPlayerSetup.player, transform);
        //_currentPlayer.GetComponentInChildren<ShooterManager>().playerSideReference = transform;

        if(collider2D != null)
        {
            distanceToGround = collider2D.bounds.extents.y;
        }
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.green, distanceToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround + spaceToGround);
    }
   
    
    private void OnPlayerKill()
    {
        if (audioSourceDeath != null) audioSourceDeath.Play();

        healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);

        if(collider2D != null)
        {
            collider2D.enabled = false;
        }

        StartCoroutine(TimeChangeScreen());
    }

    
    private void Update()
    {
        Restart();
        if (alive)
        {
            IsGrounded();
            HandleMoviment();
            HandleJump();
            LookUp();
            Attack();
        }
    }
  
    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.Z))
            _currentSpeed = soPlayerSetup.speedRun;
        else
            _currentSpeed = soPlayerSetup.speed;


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);
            }
            if(!_currentPlayer.GetBool("Jump"))
                _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
            }
            if (!_currentPlayer.GetBool("Jump"))
                _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }
        else
        {
            _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
        }

        if(myRigidBody.velocity.x > 0)
        {
            myRigidBody.velocity += soPlayerSetup.friction;
        }
        else if (myRigidBody.velocity.x <0)
        {
            myRigidBody.velocity -= soPlayerSetup.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            ResetAnimation();
            myRigidBody.velocity = Vector2.up * soPlayerSetup.jumpForce;
            //usado para que não buggue o scale!//
            myRigidBody.transform.localScale = Vector2.one;
            if (!_currentPlayer.GetBool("Jump"))
            {
                isJumping = true;
                _currentPlayer.SetBool("Jump", true);
            }
            DOTween.Kill(myRigidBody.transform);

            HandleScale();
            PlayJumpVFX();

            if (randomJump != null) randomJump.PlayRandom();
        }
        if (!isJumping)
        {
            return;
        }
        else
        {
            isJumping = false;
        }
    }

    private void PlayJumpVFX()
    {
        //if (jumpVFX != null) jumpVFX.Play();
        VFXManager.Instance.PlayByTypeVFX(VFXManager.VFXType.JUMP, transform.position);
    }

    private void HandleScale()
    {
        myRigidBody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigidBody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }

   
    public void Restart()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _currentPlayer.SetTrigger("Idle");
            alive = true;
        }
    }

    public void LookUp()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ResetAnimation();
            _currentPlayer.SetBool("LookUp", true);
            
            
        }
        else
        {
            isLookingUp = false;
        }
    }
  
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
    
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ResetAnimation();
            _currentPlayer.SetTrigger("Attack");
        }
    }
    public void ResetAnimation()
    {
        _currentPlayer.SetBool("LookUp", false);
        _currentPlayer.SetBool("Jump", false);
    }

    IEnumerator TimeChangeScreen()
    {
        yield return new WaitForSeconds(timeToChangeScreen);
        gameOver.ShowGameOverScreen();
        gameObject.SetActive(false);
    }
}
