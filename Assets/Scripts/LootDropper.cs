using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropper : MonoBehaviour {

    public Loot[] lootArray;

    public Loot chosenLoot;

    bool ShouldDropLoot(int enemyDifficulty) {
        System.Random random = new System.Random();
        for (int i = 0; i < lootArray.Length; i++)
        {
            Loot loot = lootArray[i];
            double roll = random.NextDouble();

            if(roll < enemyDifficulty / loot.rarity )
            {
                chosenLoot = loot;
                return true;
            }
        }

        return false;
    }

    public void Drop(int enemyDifficulty)
    {
        if(ShouldDropLoot(enemyDifficulty))
        {
            Vector2 currentPos = transform.position;
            
            Loot loot = Instantiate(chosenLoot, GameObject.Find("Level").transform);
            loot.transform.position = currentPos;
        }
    }
}
