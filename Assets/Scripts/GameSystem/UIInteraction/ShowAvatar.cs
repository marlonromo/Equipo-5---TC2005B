using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAvatar : MonoBehaviour
{
    public GameObject WindowToOpen;
    public Player player;
    public Text avatarText;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(IterateMenu());

    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator IterateMenu()
    {
        while (true)
        {
            if (player.experience == 0)
            {
                avatarText.text = "Empieza con un generador electrico para alimentar a tu planta";
                WindowToOpen.SetActive(true);
                yield return new WaitForSeconds(2);
                WindowToOpen.SetActive(false);
            }
            if (player.scoreIron > 300)
            {
                avatarText.text = "No acumules tu acero, revisa tus contratos y compra edificios de ventas";
                WindowToOpen.SetActive(true);
                yield return new WaitForSeconds(2);
                WindowToOpen.SetActive(false);
            }
            if (player.scoreMoney < 500 && player.experience > 0)
            {
                avatarText.text = "Acepta contratos o entra a un minijuego para obtener dinero";
                WindowToOpen.SetActive(true);
                yield return new WaitForSeconds(2);
                WindowToOpen.SetActive(false);
            }
        }
    }
}
