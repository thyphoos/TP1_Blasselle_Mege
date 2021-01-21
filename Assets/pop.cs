using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop : MonoBehaviour

{
    public GameObject Shape;
    [SerializeField] private int Number_Of_Shapes;
    [SerializeField] private float Radius;
    private float x, y, z;
    List<GameObject> listeCubes = new List<GameObject>();
    private GameObject a;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(
            0f,
            0.5f*Input.GetAxis("Vertical"),
            0.5f*Input.GetAxis("Horizontal"));
        
        foreach (GameObject cube in listeCubes)
        {
            Destroy(cube);
        }
        
        listeCubes.Clear();
        float angle = 0.0f;
        float interval = (2 * Mathf.PI) / Number_Of_Shapes;

        while (angle < 2 * Mathf.PI)
        {
            y = (float) ((5*Input.GetAxis("Vertical") + Mathf.Cos(angle))*Radius);
            z = (float) ((5*Input.GetAxis("Horizontal") + Mathf.Sin(angle))*Radius);
            a = Instantiate(Shape, new Vector3(0, y, z), Quaternion.Euler(20f, 3f, 12f));
            listeCubes.Add(a);
            angle += interval;
        }
    }
}