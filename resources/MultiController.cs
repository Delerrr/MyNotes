/* Copyright © 2019 Philipp The Programmer

This work is free. You can redistribute it and/or modify it under the
terms of the Do What The Fuck You Want To Public License, Version 2,
as published by Sam Hocevar. See http://www.wtfpl.net/ for more details.

 */

using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class MultiController : MonoBehaviour
{
    public enum INPUT_MODE {
        RAW,
        FILTERED
    }

    public enum PHYSICS_MODE {
        TRANSFORM_POSITION,
        TRANSFORM_TRANSLATE,
        RIGIDBODY_MOVEPOSITION,
        RIGIDBODY_SET_VELOCITY,
        RIGIDBODY_ADD_VELOCITY,
        RIGIDBODY_ADDFORCE
    }

    [SerializeField] float speed;
    public INPUT_MODE inputMode;
    public PHYSICS_MODE physicsMode;


    void FixedUpdate()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Vector2 input = Vector2.zero;

        switch (inputMode) {
            case INPUT_MODE.RAW:
                input = new Vector2(
                    Input.GetAxisRaw("Horizontal") * speed ,
                    Input.GetAxisRaw("Vertical") * speed 
                );
                break;
            case INPUT_MODE.FILTERED:
                input = new Vector2(
                    Input.GetAxis("Horizontal") * speed ,
                    Input.GetAxis("Vertical") * speed 
                );
                break;
        };

        Vector3 newPos = transform.position ;
        newPos.x += input.x * Time.fixedDeltaTime;
        newPos.y += input.y * Time.fixedDeltaTime;

        switch (physicsMode) {
            case PHYSICS_MODE.TRANSFORM_POSITION:
                transform.position = newPos;
                break;
            case PHYSICS_MODE.TRANSFORM_TRANSLATE:
                transform.Translate(input * Time.fixedDeltaTime);
                break;
            case PHYSICS_MODE.RIGIDBODY_MOVEPOSITION:
                rigidbody.MovePosition(newPos);
                break;
            case PHYSICS_MODE.RIGIDBODY_SET_VELOCITY:
                rigidbody.velocity = input;
                break;
            case PHYSICS_MODE.RIGIDBODY_ADD_VELOCITY:
                rigidbody.velocity += input / rigidbody.drag;
                break;
            case PHYSICS_MODE.RIGIDBODY_ADDFORCE:
                rigidbody.AddForce(input * rigidbody.drag);
                break;
        }

        
    }
}
