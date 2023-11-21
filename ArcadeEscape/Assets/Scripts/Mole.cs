using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public float visibleHeight = -0.779f;
    public float hiddenHeight = -1.1f;
    private Vector3 newPosition;
    public float speed = 4f;
    public float hideMoleTimer = 1.5f;
    public float timerLength = 1.5f;
    // Start is called before the first frame update

    void Awake()
    {
        HideMole();

        transform.localPosition = newPosition;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            newPosition,
            Time.deltaTime * speed
            );
        hideMoleTimer -= Time.deltaTime;
        if (hideMoleTimer < 0 )
        {
            HideMole();
        }
    }

    public void HideMole()
    {
        newPosition = new Vector3(
            transform.localPosition.x,
            hiddenHeight,
            transform.localPosition.z
            );
    }
    public void ShowMole()
    {
        newPosition = new Vector3(
            transform.localPosition.x,
            visibleHeight,
            transform.localPosition.z
            );

        hideMoleTimer = timerLength; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            //Destroy(gameObject);
            HideMole();
        }
    }
}
