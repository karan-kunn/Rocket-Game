using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction Thrust;
    [SerializeField] InputAction RSpeed;
    [SerializeField] float ThrustSpeed = 1000;
    [SerializeField] float RoSpeed = 100;
    [SerializeField] AudioClip mainengine;
    [SerializeField] ParticleSystem mainbooster;
    [SerializeField] ParticleSystem Leftbooster;
    [SerializeField] ParticleSystem Rightbooster;
    Rigidbody rb;
    [SerializeField] AudioSource au;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        au = GetComponent<AudioSource>();

    }

    void OnEnable()
    {
        Thrust.Enable();
        RSpeed.Enable();
    }

    void FixedUpdate()
    {
        Thrustup();
        Rotation();
    }
    private void Thrustup()
    {
        if (Thrust.IsPressed())
        {
            startthrusting();
        }
        else
        {
            stopthrusting();
        }
            
    }

    private void startthrusting()
    {
        rb.AddRelativeForce(Vector3.up * ThrustSpeed * Time.fixedDeltaTime);
        if (!au.isPlaying)
        {
            au.PlayOneShot(mainengine);
        }
        if (!mainbooster.isPlaying)
        {
            mainbooster.Play();
        }
    }

    private void stopthrusting()
    {
        au.Stop();
        mainbooster.Stop();
    }

    private void Rotation()
    {
        float Rotates = RSpeed.ReadValue<float>();
        if (Rotates > 0)
        {
            Rotateright();
        }
        else if (Rotates < 0)
        {
            RotateLeft();
        }
        else
        {
            Stoprotatingboster();
        }
    }

    private void Rotateright()
    {
        Rotationmain(RoSpeed);
        if (!Rightbooster.isPlaying)
        {
            Leftbooster.Stop();
            Rightbooster.Play();
        }
    }

    private void RotateLeft()
    {
        Rotationmain(-RoSpeed);
        if (!Leftbooster.isPlaying)
        {
            Rightbooster.Stop();
            Leftbooster.Play();
        }
    }

    private void Stoprotatingboster()
    {
        Rightbooster.Stop();
        Leftbooster.Stop();
    }

    private void Rotationmain(float rotationthrust)
    {
        rb.freezeRotation= true;
        transform.Rotate(Vector3.forward * rotationthrust * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
