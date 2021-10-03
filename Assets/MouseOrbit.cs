
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MouseOrbit : MonoBehaviour
{
    public Transform target;
    public float maxOffsetDistance = 2000f;
    public float orbitSpeed = 15f;
    public float panSpeed = .5f;
    public float zoomSpeed = 10f;
    private Vector3 targetOffset = Vector3.zero;
    private Vector3 targetPosition;
    public float minDist;
    public float maxDist;
    public float TouchZoomSpeed = 0.01f;
    float aggiusta = -1;

    public float limitup;
    public float limidown;
    public float limidx;
    public float limisx;
    public float limiavanti;
    public float limidietro;
    private Vector3 position;

    // Use this for initialization
    void Start()
    {
        if (target != null) transform.LookAt(target);
    }

    void Update()
    {
        if (transform.position.x > limisx && transform.position.x < limidx && transform.position.y < limitup && transform.position.y > limidown && transform.position.z > limidietro && transform.position.z < limiavanti) {
            targetPosition = target.position + targetOffset;

            position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            if (target != null)
            {
                targetPosition = target.position + targetOffset;

                // Left Mouse to Orbit
                if (Input.GetMouseButton(0))
                {
                    float pitchAngle = Vector3.Angle(Vector3.up, transform.forward);
                    float pitchDelta = -Input.GetAxis("Mouse Y") * orbitSpeed;
                    float newAngle = Mathf.Clamp(pitchAngle + pitchDelta, 0f, 180f);
                    pitchDelta = newAngle - pitchAngle;
                    transform.RotateAround(targetPosition, Vector3.up, Input.GetAxis("Mouse X") * orbitSpeed);
                    transform.RotateAround(targetPosition, transform.right, pitchDelta);
                }

                /*
                if (orbitSpeed > 0)
                {
                    while (orbitSpeed > 0)
                    {
                        orbitSpeed = orbitSpeed - 1;
                        if (orbitSpeed < 1)
                            orbitSpeed = 0;
                    }
                }
                */

                /*
                // Right Mouse To Pan
                if (Input.GetMouseButton(1))
                {
                    Vector3 offset = transform.right * -Input.GetAxis("Mouse X") * panSpeed + transform.up * -Input.GetAxis("Mouse Y") * panSpeed;
                    Vector3 newTargetOffset = Vector3.ClampMagnitude(targetOffset + offset, maxOffsetDistance);
                    transform.position += newTargetOffset - targetOffset;
                    targetOffset = newTargetOffset;
                }
                */

                // Scroll to Zoom
                // transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

                if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
                {
                    float dist = Vector3.Distance(target.position, transform.position);
                    if (dist > minDist)
                    {
                        // transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
                        transform.position += transform.forward * zoomSpeed;
                    }
                }
                if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    float dist = Vector3.Distance(target.position, transform.position);
                    if (dist < maxDist)
                    {
                        //    transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
                        transform.position += transform.forward * aggiusta * zoomSpeed;
                    }
                }


                if (Input.touchSupported)
                {
                    //codice un dito
                    if (Input.touchCount == 1)
                    {/*
                        float pitchAngle = Vector3.Angle(Vector3.up, transform.forward);
                        float pitchDelta = -Input.GetAxis("Mouse Y") * orbitSpeed;
                        float newAngle = Mathf.Clamp(pitchAngle + pitchDelta, 0f, 180f);
                        pitchDelta = newAngle - pitchAngle;
                        transform.RotateAround(targetPosition, Vector3.up, Input.GetAxis("Mouse X") * orbitSpeed);
                        transform.RotateAround(targetPosition, transform.right, pitchDelta);
                    */
                        //posizione corrente
                        Touch tZero = Input.GetTouch(0);
                        //posizione precedente
                        Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;

                        transform.RotateAround(targetPosition, tZeroPrevious, orbitSpeed);
                        // transform.RotateAround(targetPosition, tZeroPrevious.y, orbitSpeed);


                    }


                    // zoom con dita
                    if (Input.touchCount == 2)
                    {

                        // posizione corrente dita
                        Touch tZero = Input.GetTouch(0);
                        Touch tOne = Input.GetTouch(1);
                        // posizione precedente dita
                        Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                        Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                        float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                        float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                        // get offset value
                        float deltaDistance = oldTouchDistance - currentTouchDistance;

                        if (deltaDistance < 0)
                        {
                            float dist = Vector3.Distance(target.position, transform.position);
                            if (dist < maxDist)
                                //        transform.position += transform.forward * deltaDistance * TouchZoomSpeed;

                                transform.position += transform.forward * TouchZoomSpeed * aggiusta;
                        }

                        if (deltaDistance > 0)
                        {
                            float dist = Vector3.Distance(target.position, transform.position);
                            if (dist > minDist)
                                // transform.position += transform.forward * deltaDistance * TouchZoomSpeed;
                                transform.position += transform.forward * TouchZoomSpeed;

                        }
                    }
                }
            }


            if (transform.position.x <= limisx)
            {
                position = new Vector3(limisx+0.01f, transform.position.y, transform.position.z);
                transform.position = position;
                transform.LookAt(target);

            }

            if (transform.position.x >= limidx)
            {
                position = new Vector3(limidx - 0.01f, transform.position.y, transform.position.z);
                transform.position = position;
                transform.LookAt(target);

            }

            if (transform.position.y >= limitup)
            {
                position = new Vector3(transform.position.x, limitup -0.01f, transform.position.z);
                transform.position = position;
                transform.LookAt(target);
            }

            if (transform.position.y <= limidown)
            {
                position = new Vector3(transform.position.x, limidown + 0.01f, transform.position.z);
                transform.position = position;
                transform.LookAt(target);
            }

            if (transform.position.z <= limidietro) {

                position = new Vector3(transform.position.x, transform.position.y, limidietro+0.01f);
                transform.position = position;
                transform.LookAt(target);
            }

            if (transform.position.z >= limiavanti)
            {

                position = new Vector3(transform.position.x, transform.position.y, limiavanti - 0.01f);
                transform.position = position;
                transform.LookAt(target);

            }


        }

        else
            {
                transform.position = position;
                transform.LookAt(target);
            }
    }
}