using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA 
{
    List<int> genes = new List<int>();
    int dnalength = 0;
    int maxvalues = 0;

    public DNA(int l,int v) //Constructor
    {
        dnalength = l;
        maxvalues = v;
    }

    public void setrandom() //set random value for all
    {
        for(int i=0;i<dnalength;i++)
        {
            genes.Clear();
            genes.Add(Random.Range(0, maxvalues));
        }
    }

    public void setint(int val,int pos) //set the value 
    {
        genes[pos] = val;
    }

    public void combinedna(DNA d1,DNA d2) //combine the dna for the next population
    {
        for (int i = 0; i <dnalength;i++)
        {
            if(i<dnalength/2.0)
            {
                genes[i] = d1.genes[i];
            }

            else
            {
                genes[i] = d2.genes[i];
            }
        }
    }

    public void mutate()  //it basically sets a random value to a random gene number
    {
        genes[Random.Range(0,dnalength)] = Random.Range(0, maxvalues);
    }

    public int GetGene(int pos)  //returns a gene at a a given position
    {
        return genes[pos];
    }
}
