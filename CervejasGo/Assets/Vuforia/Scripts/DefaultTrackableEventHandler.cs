/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES


        static GameObject checkin = null;
        static GameObject button = null;
        static GameObject cerveja1 = null;
        static GameObject cerveja2 = null;
        static GameObject cerveja3 = null;
        static GameObject cerveja4 = null;
        static GameObject cerveja5 = null;
        static GameObject cerveja6 = null;
        static GameObject cerveja7 = null;
        static GameObject cerveja8 = null;
        
        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS

        private void Awake()
        {
            checkin = GameObject.Find("Checkin");
            button = GameObject.Find("Button");
            cerveja1 = GameObject.Find("riAntuerpia");
            cerveja2 = GameObject.Find("riAxbeer");
            cerveja3 = GameObject.Find("ribacker__34767_zoom");
            cerveja4 = GameObject.Find("riBruder");
            cerveja5 = GameObject.Find("riFalke");
            cerveja6 = GameObject.Find("riHeineken");
            cerveja7 = GameObject.Find("riKrugBeer");
            cerveja8 = GameObject.Find("riMadalena");
        }


        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            //ObjectHandlerHelper.Show(mTrackableBehaviour.TrackableName);
            checkin.SetActive(true);
            button.SetActive(true);
            switch (mTrackableBehaviour.TrackableName)
            {
                case "Antuerpia":
                    cerveja1.SetActive(true);
                    break;
                case "Axbeer":
                    cerveja2.SetActive(true);
                    break;
                case "backer__34767_zoom":
                    cerveja3.SetActive(true);
                    break;
                case "Bruder":
                    cerveja4.SetActive(true);
                    break;
                case "Falke":
                    cerveja5.SetActive(true);
                    break;
                case "Heineken":
                    cerveja6.SetActive(true);
                    break;
                case "KrugBeer":
                    cerveja7.SetActive(true);
                    break;
                case "Madalena":
                    cerveja8.SetActive(true);
                    break;
            }
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }


        }

        #endregion // PRIVATE_METHODS
    }
}
