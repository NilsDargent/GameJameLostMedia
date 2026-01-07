using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private bool actif = false;
    public bool isActif
    {
        get { return actif; }
        set { actif = value; }
    }
}
