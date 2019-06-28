/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;
using Vuforia;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    public static int state = 0;
    public Sprite logo_1;
    public GameObject m_button;
    #region PROTECTED_MEMBER_VARIABLES
    public static bool synagog_control;

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            AssignLastTracedObject();
            OnTrackingFound();
            m_button.GetComponent<UnityEngine.UI.Image>().sprite = logo_1;
            if (mTrackableBehaviour.TrackableName == "card_1"
               || mTrackableBehaviour.TrackableName == "card_2"
               || mTrackableBehaviour.TrackableName == "card_3"
               || mTrackableBehaviour.TrackableName == "card_4"
               || mTrackableBehaviour.TrackableName == "card_5"
               || mTrackableBehaviour.TrackableName == "card_6"
               || mTrackableBehaviour.TrackableName == "card_7"
               || mTrackableBehaviour.TrackableName == "card_8"
               || mTrackableBehaviour.TrackableName == "card_9"
               || mTrackableBehaviour.TrackableName == "card_10"
               || mTrackableBehaviour.TrackableName == "card_11"
               || mTrackableBehaviour.TrackableName == "card_12")
            {
                this.gameObject.GetComponent<VideoPlayer>().enabled = true;
                this.gameObject.GetComponent<VideoPlayer>().Play();
            }

        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
            if (mTrackableBehaviour.TrackableName == "card_1"
               || mTrackableBehaviour.TrackableName == "card_2"
               || mTrackableBehaviour.TrackableName == "card_3"
               || mTrackableBehaviour.TrackableName == "card_4"
               || mTrackableBehaviour.TrackableName == "card_5"
               || mTrackableBehaviour.TrackableName == "card_6"
               || mTrackableBehaviour.TrackableName == "card_7"
               || mTrackableBehaviour.TrackableName == "card_8"
               || mTrackableBehaviour.TrackableName == "card_9"
               || mTrackableBehaviour.TrackableName == "card_10"
               || mTrackableBehaviour.TrackableName == "card_11"
               || mTrackableBehaviour.TrackableName == "card_12")
            {
                this.gameObject.GetComponent<VideoPlayer>().Pause();
            }
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    public void AssignLastTracedObject()
    {
        if (mTrackableBehaviour.TrackableName == "Brain_synagogue" || mTrackableBehaviour.TrackableName == "sinagog1"
            || mTrackableBehaviour.TrackableName == "sinagog_2" || mTrackableBehaviour.TrackableName == "sinagogue_3")
        {
            state = 1;
            Debug.Log("State: " + state);
        }
        else if (mTrackableBehaviour.TrackableName == "Repairing_2_school")
        {
            state = 2;
            Debug.Log("State: " + state);
        }
        else if (mTrackableBehaviour.TrackableName == "Celebrating_3_Church")
        {
            state = 3;
            Debug.Log("State: " + state);
        }
        else if (mTrackableBehaviour.TrackableName == "Gardening_4_Yannis")
        {
            state = 4;
            Debug.Log("State: " + state);
        }
        else if (mTrackableBehaviour.TrackableName == "Repairing_5_football")
        {
            state = 5;
            Debug.Log("State: " + state);
        }
        else if (mTrackableBehaviour.TrackableName == "Gardening_6_future")
        {
            state = 6;
            Debug.Log("State: " + state);
        }
        else if (mTrackableBehaviour.TrackableName == "Celebrate_7_ecevit" 
                || mTrackableBehaviour.TrackableName == "Gardening_7_ecevit"
                || mTrackableBehaviour.TrackableName == "Repair_7_ecevit")
        {
            state = 7;
            Debug.Log("State: " + state);
        }
        else if (mTrackableBehaviour.TrackableName == "Celebrating_8_fisherman")
        {
            state = 8;
            Debug.Log("State: " + state);
        }
        else if ( mTrackableBehaviour.TrackableName == "card_1"
               || mTrackableBehaviour.TrackableName == "card_2"
               || mTrackableBehaviour.TrackableName == "card_3"
               || mTrackableBehaviour.TrackableName == "card_4"
               || mTrackableBehaviour.TrackableName == "card_5"
               || mTrackableBehaviour.TrackableName == "card_6"
               || mTrackableBehaviour.TrackableName == "card_7"
               || mTrackableBehaviour.TrackableName == "card_8"
               || mTrackableBehaviour.TrackableName == "card_9"
               || mTrackableBehaviour.TrackableName == "card_10"
               || mTrackableBehaviour.TrackableName == "card_11"
               || mTrackableBehaviour.TrackableName == "card_12")
        {
            state = 9;
            gameObject.GetComponent<VideoPlayer>().enabled = true;
            Debug.Log("State: " + state);
        }

    }

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {

        GetComponent<AudioSource>().Play();
        

        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }


    protected virtual void OnTrackingLost()
    {
        GetComponent<AudioSource>().Pause();

        

        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }

    #endregion // PROTECTED_METHODS
}
