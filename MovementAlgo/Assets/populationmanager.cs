using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class populationmanager : MonoBehaviour
{

    public GameObject characterprefab;
    public int populationsize = 10;
    List<GameObject> Population = new List<GameObject>();
    public static float elapsed = 0;
    public float trialtime = 5f;
    int generation = 0;

    GUIStyle gui = new GUIStyle();
    private void OnGUI()
    {
        gui.fontSize = 25;
        gui.normal.textColor = Color.white;
        GUI.BeginGroup(new Rect(10, 10, 250, 150));
        GUI.Box(new Rect(0, 0, 140, 140), "Stats:", gui);
        GUI.Label(new Rect(10, 25, 200, 30), "Geneartion:" + generation, gui);
        GUI.Label(new Rect(10, 50, 200, 30), "Time:" + elapsed, gui);
        GUI.Label(new Rect(10, 75, 200, 30), "Population:" + Population.Count, gui);
        GUI.EndGroup();
    }
    private void Start()
    {
        for (int i = 0; i < populationsize; i++)
        {
            Vector3 position = new Vector3(this.transform.position.x+Random.Range(-2, 2), transform.position.y,this.transform.position.z+ Random.Range(-2, 2));
            GameObject characterclone = Instantiate(characterprefab, position, Quaternion.identity);
            characterclone.GetComponent<Brain>().init();
            Population.Add(characterclone);
        }
    }

    private GameObject breed(GameObject d1,GameObject d2)
    {
        Vector3 position = new Vector3(this.transform.position.x + Random.Range(-2, 2), transform.position.y, this.transform.position.z + Random.Range(-2, 2));
        GameObject characterclone = Instantiate(characterprefab, position, Quaternion.identity);
        Brain brain = characterclone.GetComponent<Brain>();
        if(Random.Range(1,100)==1)
        {
            brain.init();
            brain.dna.mutate();
        }

        else
        {
            brain.init();
            brain.dna.combinedna(d1.GetComponent<Brain>().dna,d2.GetComponent<Brain>().dna);
        }
        return characterclone;
    }

    void Breednewpopulation()
    {
        List<GameObject> sortedlist = Population.OrderBy(o => o.GetComponent<Brain>().timealive).ToList();
        Population.Clear();
        for (int i=(int)(sortedlist.Count/2.0f)-1; i<sortedlist.Count-1;i++)
        {
            breed(sortedlist[i], sortedlist[i + 1]);
            breed(sortedlist[i + 1], sortedlist[i]);
        }
        for(int i=0;i<sortedlist.Count;i++)
        {
            Destroy(sortedlist[i]);
        }
        generation++;
    }
    private void Update()
    {
        elapsed += Time.deltaTime;
        if(elapsed>=trialtime)
        {
            Breednewpopulation();
            elapsed = 0;
        }
    }

}


