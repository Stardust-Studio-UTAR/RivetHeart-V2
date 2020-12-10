﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GrapplingHook : MonoBehaviour
{
    //public GameObject ropeHingeAnchor;
    //public DistanceJoint2D ropeJoint;
    //public Transform crosshair;
    //public SpriteRenderer crosshairSprite;
    //public PlayerMovement playerMovement;
    //private bool ropeAttached;
    //private Vector2 playerPos;
    //private Rigidbody2D rb;
    //private SpriteRenderer ropeHingeAnchorSprite;

    //public LineRenderer ropeRenderer;
    //public LayerMask ropeLayerMask;
    //private float ropeMaxCastDist = 20f;
    //private List<Vector2> ropePositions = new List<Vector2>();

    //private bool distSet;

    ///// <summary>
    ///// Disable rope joint component and set current position.
    ///// </summary>
    //private void Awake()
    //{
    //    ropeJoint.enabled = false;
    //    playerPos = transform.position;
    //    rb = ropeHingeAnchor.GetComponent<Rigidbody2D>();
    //    ropeHingeAnchorSprite = ropeHingeAnchor.GetComponent<SpriteRenderer>();
    //}


    //void Update()
    //{
    //    // Capture the world position of mouse cursor, mousePos.z is the distance from the camera.
    //    var worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));
    //    // Calculate the facing direction.
    //    var facingDirection = worldMousePos - transform.position;
    //    // Represent the aiming angle of mouse cursor and keep value positive with if statement.
    //    var aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);
    //    if (aimAngle < 0f)
    //    {
    //        aimAngle = Mathf.PI * 2 + aimAngle;
    //    }

    //    // For rotation. Converts radian angle to degree angle.
    //    var aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;

    //    // Track player's position constantly.
    //    playerPos = transform.position;

    //    if (!ropeAttached)
    //    {
    //        SetCrosshairPosition(aimAngle);
    //    }
    //    else
    //    {
    //        crosshairSprite.enabled = false;
    //    }

    //    // Allow player to shoot grapple.
    //    HandleInput(aimDirection);

    //    UpdateRopePositions();
    //}

    ///// <summary>
    ///// Position the crosshair based on the aiming angle.
    ///// </summary>
    ///// <param name="aimAngle"></param>
    //private void SetCrosshairPosition(float aimAngle)
    //{
    //    if (!crosshairSprite.enabled)
    //    {
    //        crosshairSprite.enabled = true;
    //    }

    //    // Circles around the player in a radius of specified unit.
    //    var x = transform.position.x + 2f * Mathf.Cos(aimAngle);
    //    var y = transform.position.y + 2f * Mathf.Sin(aimAngle);

    //    var crosshairPosition = new Vector3(x, y, 0);
    //    crosshair.transform.position = crosshairPosition;
    //}

    //private void HandleInput(Vector2 aimDirection)
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        if (ropeAttached)
    //        {
    //            return;
    //        }
    //        ropeRenderer.enabled = true;

    //        var hit = Physics2D.Raycast(playerPos, aimDirection, ropeMaxCastDist, ropeLayerMask);

    //        if (hit.collider != null)
    //        {
    //            ropeAttached = true;
    //            if (!ropePositions.Contains(hit.point))
    //            {
    //                // Bounce player up when grappled
    //                transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2f), ForceMode2D.Impulse);
    //                ropePositions.Add(hit.point);
    //                ropeJoint.distance = Vector2.Distance(playerPos, hit.point);
    //                ropeJoint.enabled = true;
    //                ropeHingeAnchorSprite.enabled = true;
    //            }
    //        }
    //        else
    //        {
    //            ropeRenderer.enabled = false;
    //            ropeAttached = false;
    //            ropeJoint.enabled = false;
    //        }
    //    }

    //    if (Input.GetMouseButton(1))
    //    {
    //        ResetRope();
    //    }
    //}

    //private void ResetRope()
    //{
    //    ropeJoint.enabled = false;
    //    ropeAttached = false;
    //    playerMovement.isSwinging = false;
    //    ropeRenderer.positionCount = 2;
    //    ropeRenderer.SetPosition(0, transform.position);
    //    ropeRenderer.SetPosition(1, transform.position);
    //    ropePositions.Clear();
    //    ropeHingeAnchorSprite.enabled = false;
    //}

    //private void UpdateRopePositions()
    //{
    //    if (!ropeAttached)
    //    {
    //        return;
    //    }

    //    ropeRenderer.positionCount = ropePositions.Count + 1;

    //    for (int i = ropeRenderer.positionCount - 1; i >= 0; i--)
    //    {
    //        // If not last point of line renderer.
    //        if (i != ropeRenderer.positionCount - 1)
    //        {
    //            ropeRenderer.SetPosition(i, ropePositions[i]);

    //            if (i == ropePositions.Count - 1 || ropePositions.Count == 1)
    //            {
    //                var ropePos = ropePositions[ropePositions.Count - 1];
    //                if (ropePositions.Count == 1)
    //                {
    //                    rb.transform.position = ropePos;
    //                    if (!distSet)
    //                    {
    //                        ropeJoint.distance = Vector2.Distance(transform.position, ropePos);
    //                        distSet = true;
    //                    }
    //                }
    //                else
    //                {
    //                    rb.transform.position = ropePos;
    //                    if (!distSet)
    //                    {
    //                        ropeJoint.distance = Vector2.Distance(transform.position, ropePos);
    //                        distSet = true;
    //                    }
    //                }
    //            }
    //            else if (i - 1 == ropePositions.IndexOf(ropePositions.Last()))
    //            {
    //                var ropePos = ropePositions.Last();
    //                rb.transform.position = ropePos;
    //                if (!distSet)
    //                {
    //                    ropeJoint.distance = Vector2.Distance(transform.position, ropePos);
    //                    distSet = true;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            ropeRenderer.SetPosition(i, transform.position);
    //        }
    //    }
    //}

    public LineRenderer ropeRenderer;
    public LayerMask ropeLayerMask;
    public float climbSpeed = 3f;
    public GameObject ropeHingeAnchor;
    public DistanceJoint2D ropeJoint;
    public Transform crosshair;
    public SpriteRenderer crosshairSprite;
    public PlayerMovement playerMovement;
    private bool ropeAttached;
    private Vector2 playerPosition;
    private List<Vector2> ropePositions = new List<Vector2>();
    public float ropeMaxCastDistance = 10f;
    private Rigidbody2D ropeHingeAnchorRb;
    private bool distanceSet;
    private bool isColliding;
    //private Dictionary<Vector2, int> wrapPointsLookup = new Dictionary<Vector2, int>();
    private SpriteRenderer ropeHingeAnchorSprite;

    void Awake()
    {
        ropeJoint.enabled = false;
        playerPosition = transform.position;
        ropeHingeAnchorRb = ropeHingeAnchor.GetComponent<Rigidbody2D>();
        ropeHingeAnchorSprite = ropeHingeAnchor.GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Figures out the closest Polygon collider vertex to a specified Raycast2D hit point in order to assist in 'rope wrapping'
    /// </summary>
    /// <param name="hit">The raycast2d hit</param>
    /// <param name="polyCollider">the reference polygon collider 2D</param>
    /// <returns></returns>
    //private Vector2 GetClosestColliderPointFromRaycastHit(RaycastHit2D hit, PolygonCollider2D polyCollider)
    //{
    //    // Transform polygoncolliderpoints to world space (default is local)
    //    var distanceDictionary = polyCollider.points.ToDictionary<Vector2, float, Vector2>(
    //        position => Vector2.Distance(hit.point, polyCollider.transform.TransformPoint(position)),
    //        position => polyCollider.transform.TransformPoint(position));

    //    var orderedDictionary = distanceDictionary.OrderBy(e => e.Key);
    //    return orderedDictionary.Any() ? orderedDictionary.First().Value : Vector2.zero;
    //}

    // Update is called once per frame
    void Update()
    {
        var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));
        var facingDirection = worldMousePosition - transform.position;
        var aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);
        if (aimAngle < 0f)
        {
            aimAngle = Mathf.PI * 2 + aimAngle;
        }

        var aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;
        playerPosition = transform.position;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!ropeAttached)
            {
                SetCrosshairPosition(aimAngle);
                playerMovement.isSwinging = false;
            }
            else
            {
                playerMovement.isSwinging = true;
                playerMovement.ropeHook = ropePositions.Last();
                crosshairSprite.enabled = false;
            }
            UpdateRopePositions();
            HandleRopeLength();
            HandleInput(aimDirection);
        }
        else
        {
            ResetRope();
            crosshairSprite.enabled = false;
        }
    }

    /// <summary>
    /// Handles input within the RopeSystem component
    /// </summary>
    /// <param name="aimDirection">The current direction for aiming based on mouse position</param>
    private void HandleInput(Vector2 aimDirection)
    {
        if (Input.GetMouseButton(1))
        {
            if (ropeAttached) return;
            ropeRenderer.enabled = true;

            var hit = Physics2D.Raycast(playerPosition, aimDirection, ropeMaxCastDistance, ropeLayerMask);
            Debug.Log(hit.point);
            if (hit.collider != null)
            {
                ropeAttached = true;
                if (!ropePositions.Contains(hit.point))
                {
                    // Jump slightly to distance the player a little from the ground after grappling to something.
                    transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2f), ForceMode2D.Impulse);
                    ropePositions.Add(hit.point);
                    //wrapPointsLookup.Add(hit.point, 0);
                    ropeJoint.distance = Vector2.Distance(playerPosition, hit.point);
                    ropeJoint.enabled = true;
                    ropeHingeAnchorSprite.enabled = true;
                }
            }
            else
            {
                Debug.Log("too short");
                ropeRenderer.enabled = false;
                ropeAttached = false;
                ropeJoint.enabled = false;
            }
        }
        else
        {
            ResetRope();
        }
    }

    /// <summary>
    /// Resets the rope in terms of gameplay, visual, and supporting variable values.
    /// </summary>
    private void ResetRope()
    {
        ropeJoint.enabled = false;
        ropeAttached = false;
        playerMovement.isSwinging = false;
        ropeRenderer.positionCount = 2;
        ropeRenderer.SetPosition(0, transform.position);
        ropeRenderer.SetPosition(1, transform.position);
        ropePositions.Clear();
        //wrapPointsLookup.Clear();
        ropeHingeAnchorSprite.enabled = false;
    }

    /// <summary>
    /// Move the aiming crosshair based on aim angle
    /// </summary>
    /// <param name="aimAngle">The mouse aiming angle</param>
    private void SetCrosshairPosition(float aimAngle)
    {
        if (!crosshairSprite.enabled)
        {
            crosshairSprite.enabled = true;
        }

        var x = transform.position.x + 1f * Mathf.Cos(aimAngle);
        var y = transform.position.y + 1f * Mathf.Sin(aimAngle);

        var crossHairPosition = new Vector3(x, y, 0);
        crosshair.transform.position = crossHairPosition;
    }

    /// <summary>
    /// Retracts or extends the 'rope'
    /// </summary>
    private void HandleRopeLength()
    {
        if (Input.GetAxis("Vertical") >= 1f && ropeAttached && !isColliding)
        {
            ropeJoint.distance -= Time.deltaTime * climbSpeed;
        }
        else if (Input.GetAxis("Vertical") < 0f && ropeAttached)
        {
            ropeJoint.distance += Time.deltaTime * climbSpeed;
        }
    }

    /// <summary>
    /// Handles updating of the rope hinge and anchor points based on objects the rope can wrap around. These must be PolygonCollider2D physics objects.
    /// </summary>
    private void UpdateRopePositions()
    {
        if (ropeAttached)
        {
            ropeRenderer.positionCount = ropePositions.Count + 1;

            for (var i = ropeRenderer.positionCount - 1; i >= 0; i--)
            {
                if (i != ropeRenderer.positionCount - 1) // if not the Last point of line renderer
                {
                    ropeRenderer.SetPosition(i, ropePositions[i]);

                    // Set the rope anchor to the 2nd to last rope position (where the current hinge/anchor should be) or if only 1 rope position then set that one to anchor point
                    if (i == ropePositions.Count - 1 || ropePositions.Count == 1)
                    {
                        if (ropePositions.Count == 1)
                        {
                            var ropePosition = ropePositions[ropePositions.Count - 1];
                            ropeHingeAnchorRb.transform.position = ropePosition;
                            if (!distanceSet)
                            {
                                ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                                distanceSet = true;
                            }
                        }
                        else
                        {
                            var ropePosition = ropePositions[ropePositions.Count - 1];
                            ropeHingeAnchorRb.transform.position = ropePosition;
                            if (!distanceSet)
                            {
                                ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                                distanceSet = true;
                            }
                        }
                    }
                    else if (i - 1 == ropePositions.IndexOf(ropePositions.Last()))
                    {
                        // if the line renderer position we're on is meant for the current anchor/hinge point...
                        var ropePosition = ropePositions.Last();
                        ropeHingeAnchorRb.transform.position = ropePosition;
                        if (!distanceSet)
                        {
                            ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                            distanceSet = true;
                        }
                    }
                }
                else
                {
                    // Player position
                    ropeRenderer.SetPosition(i, transform.position);
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D colliderStay)
    {
        isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D colliderOnExit)
    {
        isColliding = false;
    }
}
