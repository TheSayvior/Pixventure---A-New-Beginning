using UnityEngine;
using System.Collections;
using System; //This allows the IComparable Interface

//This is the class you will be storing
//in the different collections. In order to use
//a collection's Sort() method, this class needs to
//implement the IComparable interface.
public class Tile : IComparable<Tile>
{
    public GameObject tileSort;
    public int x,y;

    public Tile(GameObject newTileSort, int newX, int newY)
    {
        tileSort = newTileSort;
        x = newX;
        y = newY;
    }

    //This method is required by the IComparable
    //interface. 
    public int CompareTo(Tile other)
    {
        if (other == null)
        {
            return 1;
        }

        //Return the difference in power.
        return x - other.x;
    }
}
