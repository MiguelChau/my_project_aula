using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType
    {
        JUMP,
        RUN
    }

    public List<VFXManagerSetup> vfxSetup;

    public void PlayByTypeVFX(VFXType vfxType, Vector3 position)
    {
        foreach (var a in vfxSetup)
        {
            if(a.vfxType == vfxType)
            {
                var item = Instantiate(a.prefab);
                item.transform.position = position;
                Destroy(item.gameObject, 2f);
                break;
            }
        }
    }
}

[System.Serializable]
public class VFXManagerSetup
{
    public VFXManager.VFXType vfxType;
    public GameObject prefab;
}
