using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class DragonPicker : MonoBehaviour
{
    public GameObject explosion;
    public GameObject gameOver;
    public GameObject menuButton;
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldButtomY = 5f;
    public float energyShieldRadius = 1.5f;
    
    private List<GameObject> energyShields = new List<GameObject>();
    void Start()
    {
        gameOver.SetActive(false);
        menuButton.SetActive(false);
        for (int i = 0; i <= numEnergyShield; i++)
        {
            GameObject tBasketGo = Instantiate(energyShieldPrefab, Camera.main.transform);
            tBasketGo.transform.position = new Vector3(i * 0.7F, energyShieldButtomY, 0);
            tBasketGo.transform.localScale = new Vector3(energyShieldRadius, energyShieldRadius, energyShieldRadius);
            energyShields.Add(tBasketGo);
        }

        energyShields.Last().GetComponent<EnergyShield>().Activate();
    }

    public void DestroyShield()
    {
        if (energyShields.Count == 0)
        {
            return;
        }

        var shield = energyShields.Last();
        explosion = Instantiate(explosion, shield.transform.position, Quaternion.identity, transform);
        shield.GetComponent<Renderer>().enabled = false;
        Destroy(shield, 3);
        energyShields.Remove(shield);

        if (energyShields.Count == 0)
        {
            GameOver();
            return;
        }

        energyShields.Last().GetComponent<EnergyShield>().Activate();
    }

    private void GameOver()
    {
        gameOver.SetActive(true);
        menuButton.SetActive(true);
    }
}