using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    
    public GameObject bulletPrefab;

    Camera cam;
    public float width;
    private float speed=3f;

    bool isShooting;
    float coolDown = 0.5f;
    // Start is called before the first frame update
    private void Awake()
    {
        cam = Camera.main;
        width = (1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f) / 2)-0.50f;

    }
    void Start()
    {
        Debug.Log(width);
        
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        if(Input.GetKey(KeyCode.A)&& transform.position.x > -width)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < width)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);

        }
        if (Input.GetKey(KeyCode.Space) && !isShooting)
        {
            StartCoroutine(Shoot());
        }

#endif

    }
    private IEnumerator Shoot()
    {
        isShooting = true;

        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(coolDown);

        isShooting = false;
    }
}
