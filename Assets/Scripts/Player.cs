using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0f;
    [SerializeField] private GameObject laserPrefab = null;
    [SerializeField] private float projectileSpeed = 0f;
    [SerializeField] private float projectileFireSpeed = 0f;

    Coroutine fireCoroutine;

    float minX;
    float maxX;
    float minY;
    float maxY;
    // Start is called before the first frame update
    void Start()
    {
        CalculateBorder();
    }

    
    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFireSpeed);
        } 
        
        
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        float nexXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        float nexYPos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(nexXPos, nexYPos);
    }


    private void CalculateBorder()
    {
        Camera camera = Camera.main;

        minX = camera.ViewportToWorldPoint(new Vector2(0, 0)).x;
        maxX = camera.ViewportToWorldPoint(new Vector2(1, 1)).x;
        minY = camera.ViewportToWorldPoint(new Vector2(0, 0)).y;
        maxY = camera.ViewportToWorldPoint(new Vector2(1, 1)).y;
    }


}
