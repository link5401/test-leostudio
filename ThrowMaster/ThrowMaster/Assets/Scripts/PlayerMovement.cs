using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] private float turnSpeed = 360;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] private Transform groundCheck;
    private Vector3 _input;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    private void Update()
    {
        Look();

    }
    //Physical Update call
    private void FixedUpdate()
    {
        //Getting input
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Move();
    }
    private void Move()
    {
        transform.position = (transform.position + transform.forward * _input.normalized.magnitude * movementSpeed * Time.deltaTime);
    }
    //Look in isometric direction
    private void Look()
    {
        if (_input == Vector3.zero) return;
        var rotation = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }



}
public static class Helpers
{
    //Creating a 4x4 matrix then rotate it 45 degree
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    //Transform a vector3 into isometric coodirnation
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}