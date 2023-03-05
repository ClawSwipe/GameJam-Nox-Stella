using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected Rigidbody Rigidbody;
    [SerializeField] protected float Step;
    [SerializeField] protected float Velocity;
    [SerializeField] protected float MovementSpeed;
    [SerializeField] protected float RaycastDistance;
    [SerializeField] protected Vector3 Direction;
    [SerializeField] protected LayerMask LayerMask;

    private bool _stopMovement;

    private void Awake()
    {
        Application.targetFrameRate = 10;
    }

    private void Start()
    {
        //Rigidbody.velocity = Direction * Velocity;
    }

    private void Update()
    {
        //Debug.LogError("Update");

        //if (_stopMovement) return;

        //var step = Step * Time.deltaTime;
        //var nextPosition = transform.position + (Direction * step);

        //transform.position = Vector3.Lerp(transform.position, nextPosition, MovementSpeed * Time.deltaTime);

        //DetectObjectThroughRaycast();
    }

    private void FixedUpdate()
    {
        //Debug.LogError("Fixed Update");

        if (_stopMovement) return;

        var step = Step * Time.fixedDeltaTime;

        var nextPosition = transform.position + (Direction * step);

        nextPosition = Vector3.Lerp(transform.position, nextPosition, MovementSpeed * Time.fixedDeltaTime);

        Rigidbody.MovePosition(nextPosition);

        //DetectObjectThroughRaycast();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopMovement();
            ApplyForce(collision.transform);
            ApplyTorque(collision.transform);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Objects Interacted");
        }
    }

    private void DetectObjectThroughRaycast()
    {
        if (_stopMovement) return;

        RaycastHit hit;

        if(Physics.Raycast(transform.position, Direction, out hit, RaycastDistance, LayerMask))
        {
            if (hit.collider.CompareTag("Player"))
            {
                StopMovement();
            }
        }
    }

    private void ApplyForce(Transform collidedObj)
    {
        var direction = transform.position - collidedObj.position;
        direction.Normalize();

        var force = Random.Range(1.5f, 3f);
        var forceVector = direction * force + Vector3.up * force;
        Rigidbody.AddForce(forceVector, ForceMode.Impulse);
    }

    private void ApplyTorque(Transform collidedObj)
    {
        var direction = transform.position - collidedObj.position;
        direction.Normalize();

        var torque = Random.Range(0.5f, 1.5f);
        var torqueVector = new Vector3(0, 0, -direction.x) * torque;
        Rigidbody.AddTorque(torqueVector, ForceMode.Impulse);
    }

    private void StopMovement()
    {
        _stopMovement = true;
        //ResetVelocity();
    }

    private void ResetVelocity() => Rigidbody.velocity = Vector3.zero;
}
