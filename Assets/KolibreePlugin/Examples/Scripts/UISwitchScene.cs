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
    public class UISwitchScene : MonoBehaviour
    {
        public void LaunchScene(int index)
        {
            SceneUtils.LaunchScene(index, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }

        public void LaunchScene(string name)
        {
            SceneUtils.LaunchScene(name, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}