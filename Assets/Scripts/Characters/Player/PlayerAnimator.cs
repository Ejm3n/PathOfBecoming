using UnityEngine;
using PlayerControls;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    private float walk;
    private PlayerController PC;
    bool faceRight = true;
    private bool _run;

    const float _Eps = 0.001f; 

    AudioClip[] steps;
    AudioClip jump;

    void Start()
    {
        PC = transform.parent.GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        steps = Resources.LoadAll<AudioClip>("Sounds/Effects/Footsteps/Stone");
        jump = Resources.Load<AudioClip>("Sounds/Effects/Footsteps/jump");
    }

    public void Step()
    {
        SoundRecorder.Play_Effect(steps[Random.Range(0, steps.Length)]);
    }

    public void Jump()
    {
        SoundRecorder.Play_Effect(jump);
    }

    void Update()
    {
        walk = ControlButtonsAxis.xAxisRaw;
        _run = ControlButtonsHold.RUN;
        if (walk != 0 && PC.rb.velocity.sqrMagnitude > _Eps)
        {
            if (_run)
            {
                anim.SetBool("run", true);
                anim.SetBool("walk", false);
            }
            else
            {
                anim.SetBool("walk", true);
                anim.SetBool("run", false);
            }                
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }

        if (!(PC.buttonsControl is UncontrollableHandler) && Engine.current.PlayerHandler)
            if (faceRight == false && walk > 0)
                Flip();
            else if (faceRight == true && walk < 0)
                Flip();

        if (!PC.isGround)
            anim.SetBool("jump", true);
        else
            anim.SetBool("jump", false);
    }

    public void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(Vector3.up * 180);
    }

    public void AfterCast()
    {
        if (Engine.current.playerController.buttonsControl is UncontrollableHandler)
            Engine.current.playerController.Change_Controls<DefaultHandler>();
    }

    public void Spawn_Rock()
    {
        Level2 _engine = (Level2)Engine.current;
        _engine.Spawn_Rock();
    }
    public void TranslateToWindmill()
    {
        Level2 _engine = (Level2)Engine.current;
        _engine.WindmillGo();
    }
}
