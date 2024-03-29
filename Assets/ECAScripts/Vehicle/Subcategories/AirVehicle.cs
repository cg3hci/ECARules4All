﻿using System.Collections;
using ECARules4All;
using UnityEngine;
using ECARules4All.RuleEngine;

/// <summary>
/// <b>AirVehicle</b> is a class that represents a air vehicle.
/// </summary>
[ECARules4All("air-vehicle")]
[RequireComponent(typeof(Vehicle))]
[DisallowMultipleComponent]
public class AirVehicle : MonoBehaviour
{
    private bool isBusyMoving = false;
    /// <summary>
    /// <b>TakesOff</b> is a method that represents a action that a air vehicle can take off.
    /// </summary>
    /// <param name="p">The new position</param>
    [Action(typeof(AirVehicle), "takes-off", typeof(Position))]
    public void TakesOff(Position p)
    {
        float speed = 10.0F;
        Vector3 endMarker = new Vector3(p.x, p.y, p.z);
        StartCoroutine(MoveObject(speed, endMarker));
    }
    
    /// <summary>
    /// <b>Lands</b> is a method that represents a action that a air vehicle can land.
    /// </summary>
    /// <param name="p">The new position</param>
    [Action(typeof(AirVehicle), "lands", typeof(Position))]
    public void Lands(Position p)
    {
        float speed = 10.0F;
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