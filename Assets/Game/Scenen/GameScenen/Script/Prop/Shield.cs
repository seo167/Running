using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
public class Shield : GameProp{
    protected override void Login(object obj)
    {
        Player p = ((Player)obj);
        p.isInvincible = true;
        Particle p1 = ParticleManager.Instace.GetParticle();
        Particle p2 = ParticleManager.Instace.GetParticle();
        Transform objTransform = p.gameObject.transform.Find("ParticleParent");

        if (p1 == null && p2 == null){
            ParticleManager.Instace.ParticlePlayForParent("FX_GuangZhao", Vector3.zero, true,2, objTransform);
            p1 = ParticleManager.Instace.GetParticle();
            p2 = ParticleManager.Instace.GetParticle();
        } else {
            p1.gameObject.SetActive(true);
            p1.GetPS.Play();
            p2.gameObject.SetActive(true);
            p2.GetPS.Play();
            
        }
        DelayCoroutine(5.0f, () => {
            p1.gameObject.SetActive(false);
            p2.gameObject.SetActive(false);
            ParticleManager.Instace.SetParticle(p1);
            ParticleManager.Instace.SetParticle(p2);
            ((Player)obj).isInvincible = false;
        });
    }
}
