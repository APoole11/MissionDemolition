using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHard : MonoBehaviour {
    static public bool goalMet = false;
    public float radius = 5f;
    public float speed = 2f;
    private float angle = 0f;

    void Update()
    {
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x+70, y, transform.position.z);
        angle += speed * Time.deltaTime;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Projectile proj = other.GetComponent<Projectile>();
        if (proj != null)
        {
            Goal.goalMet = true;
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }
}
