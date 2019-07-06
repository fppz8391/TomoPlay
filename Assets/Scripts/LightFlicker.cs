using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightFlicker : MonoBehaviour
{
    public float FlickSpeed;
    float lightValue;
    public Ease easeType;
   void Start(){
      
       lightValue=GetComponent<Light>().intensity;
       DOTween.To(()=>lightValue,x=>lightValue=x,0,1/FlickSpeed).SetEase(this.easeType).SetLoops(-1,LoopType.Yoyo);
   }

   void Update(){
       GetComponent<Light>().intensity=lightValue;
   }
}
