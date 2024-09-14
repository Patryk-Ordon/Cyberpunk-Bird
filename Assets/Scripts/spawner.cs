using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float wait = 1.5F;
    private float time = 0;
    [SerializeField] float startV = 25;
    float v = 25;
    [SerializeField] float a = 3f;
    public GameObject Przeszkoda;
    public float height;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time > wait)
        {
            GameObject go = Instantiate(Przeszkoda);
            go.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            go.tag = "Clone";
            time = 0;
            Przeszkoda przeszkodaKlon = go.GetComponent<Przeszkoda>();
            przeszkodaKlon.V = v;
            Destroy(go, 10);
        }

        time += Time.deltaTime;
    }

    public void Increase()
    {
        v *= a;
    }

    public void Reset()
    {
        v = startV;
    }
}
