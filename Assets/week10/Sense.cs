using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sense : MonoBehaviour, ISenseBehaviour{
    public abstract void Initialize();
    public abstract void UpdateSense();
    protected AspectType aType = AspectType.ENEMY;

   
    //herhangi bir implement yapılmayacağı kod yazılmayacağı için abstract yazıldı.

    // Use this for initialization
    void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSense();
	}
}