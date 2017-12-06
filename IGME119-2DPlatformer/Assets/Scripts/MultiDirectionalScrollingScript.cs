using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDirectionalScrollingScript : MonoBehaviour {
    float leftBorder;
    float rightBorder;
    float topBorder;
    float bottomBorder;
    Vector2 size;
    Vector2 extents;
    float prevY;
    public bool loopY = false;
    public bool loopX = true;

	// Use this for initialization
	void Awake () {

        this.size = gameObject.GetComponent<SpriteRenderer>().bounds.size;
        this.extents = gameObject.GetComponent<SpriteRenderer>().bounds.extents;
        this.prevY = Camera.main.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        float yDiff = Camera.main.transform.position.y - prevY;

        float dist = (transform.position - Camera.main.transform.position).z;

        leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)
            ).x;

        rightBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, dist)
            ).x;

        topBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)
            ).y;

        bottomBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 1, dist)
            ).y;

        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
            transform.position.z
        );

        float xPos = transform.position.x;
        float yPos = transform.position.y;
        float movingRight = Input.GetAxis("Horizontal");
        float movingUp = Input.GetAxis("Vertical");
        bool completelyLeft = (transform.position.x < clampedPosition.x) && (transform.position.x + extents.x < clampedPosition.x);
        bool completelyRight = (transform.position.x > clampedPosition.x) && (transform.position.x - extents.x > clampedPosition.x);

        bool completelyAbove = (transform.position.y > clampedPosition.y) && (transform.position.y - extents.y > clampedPosition.y);
        bool completelyBelow = (transform.position.y < clampedPosition.y) && (transform.position.y + extents.y < clampedPosition.y);



        if (loopX)
        {
            if (completelyLeft)
            {
                xPos += 3 * size.x;
                //completelyRight = (xPos > clampedPosition.x);
                //xPos = completelyRight ? transform.position.x : xPos;
            }
            else if (completelyRight)
            {
                xPos -= 3 * size.x;
                //completelyLeft = (xPos < clampedPosition.x);
                //xPos = completelyLeft ? transform.position.x : xPos;

            }
        }

        if (loopY)
        {
            if (completelyBelow)
            {
                yPos += 2 * size.y;
                //completelyAbove = (yPos > clampedPosition.y);
                //yPos = completelyAbove ? transform.position.y : yPos;
            }
            else if (completelyAbove)
            {
                yPos -= 2 * size.y;
                //completelyBelow = (yPos < clampedPosition.y);
                //yPos = completelyBelow ? transform.position.y : yPos;
            }
        }
        else
        {
            yPos += yDiff;
        }

        transform.position = new Vector3(xPos, yPos, transform.position.z);
        prevY = Camera.main.transform.position.y;
	}
}
