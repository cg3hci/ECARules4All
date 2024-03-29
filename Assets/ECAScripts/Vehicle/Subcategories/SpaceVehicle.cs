﻿using System.Collections;
using ECARules4All;
using UnityEngine;
using ECARules4All.RuleEngine;

/// <summary>
/// A <b>SpaceVehicle</b> can fly in the air.
/// </summary>
[ECARules4All("space-vehicle")]
[RequireComponent(typeof(Vehicle))]
[DisallowMultipleComponent]
public class SpaceVehicle : MonoBehaviour
{
    private bool isBusyMoving;
    /// <summary>
    /// <b>Oxygen</b> is the resource that the <b>SpaceVehicle</b> uses to fly.
    /// </summary>
    [StateVariable("oxygen", ECARules4AllType.Float)] public float oxygen;   
    /// <summary>
    /// <b>Gravity</b> is the force of gravity that the <b>SpaceVehicle</b> experiences.
    /// </summary>
    [StateVariable("gravity", ECARules4AllType.Float)] public float gravity;

    /// <summary>
    /// <b>TakesOff</b> is the action that the <b>SpaceVehicle</b> can perform to take off.
    /// </summary>
    /// <param name="p">The new position</param>
    [Action(typeof(SpaceVehicle), "takes-off", typeof(Position))]
    public void TakesOff(Position p)
    {
        float speed = 20.0F;
        Vector3 endMarker = new Vector3(p.x, p.y, p.z);
        StartCoroutine(MoveObject(speed, endMarker));
    }
        
    /// <summary>
    /// <b>Lands</b>: The action that the <b>SpaceVehicle</b> can perform to land.
    /// </summary>
    /// <param name="p">The new position</param>
    [Action(typeof(SpaceVehicle), "lands", typeof(Position))]
    public void Lands(Position p)
    {
        float speed = 20.0F;
        Vector3 endMarker = new Vector3(p.x, p.y, p.z);
        StartCoroutine(MoveObject(speed, endMarker));
    }
    
    private IEnumerator MoveObject( float speed, Vector3 endMarker)
    {
        isBusyMoving = true;
        Vector3 startMarker = gameObject.transform.position;
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(startMarker, endMarker);
        while (gameObject.transform.position != endMarker)
        {
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.

            gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);
            yield return null;
        }

        isBusyMoving = false;
    }
}