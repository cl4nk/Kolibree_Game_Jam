/**
 * Copyright (c) 2017 Kolibree. All rights reserved
 *
 * Copying this file via any medium without the prior written consent of Kolibree is strictly
 * prohibited
 * Proprietary and confidential
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KolibreeExamples
{
    public class FaceDetector : MonoBehaviour
    {
        void OnEnable()
        {
            FaceDetectionManager.OnFaceUpdate += OnFaceUpdateHandler;
            FaceDetectionManager.OnWrongFaceDistance += OnWrongFaceDistanceHandler;
            FaceDetectionManager.OnToothbrushPosition += OnToothbrushPositionHandler;
            FaceDetectionManager.OnFaceTrackingStatusChange += OnFaceTrackingStatusChangeHandler;
        }

        void OnDisable()
        {
            FaceDetectionManager.OnFaceUpdate -= OnFaceUpdateHandler;
            FaceDetectionManager.OnWrongFaceDistance -= OnWrongFaceDistanceHandler;
            FaceDetectionManager.OnToothbrushPosition -= OnToothbrushPositionHandler;
            FaceDetectionManager.OnFaceTrackingStatusChange -= OnFaceTrackingStatusChangeHandler;
        }

        void OnFaceUpdateHandler(FaceData data)
        {
            /* Only those properties are available
            
                data.LeftEye
                data.RightEye
                data.Mouth
                data.Nose
                data.Head
                data.Rotation
             */
        }

        void OnWrongFaceDistanceHandler()
        {
            // notification : player is too far or too close
        }

        void OnToothbrushPositionHandler(ToothbrushPosition position)
        {
            // position = Magik toothbrush position
        }

        void OnFaceTrackingStatusChangeHandler(bool state)
        {
            // state = true -> face is available
            // state = false -> face is lost
        }
    }
}