using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SelectedProfile
{
    private static PlayerProfile selectedProfile;

    public static PlayerProfile SelectedProfileInstance
    {
        get { return selectedProfile; }
        set { selectedProfile = value; }
    }
}

