using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
  //public Button MinarBtn;
  public GameObject MinarBtn;
  public GameObject EntregarBtn;
  public GameObject ReduBtn;
  public GameObject AcBtn;
  public GameObject LamBtn;
  public GameObject CamBtn;
  public GameObject StoneIron;
  public GameObject pellets;
  public GameObject pellets2;
  public GameObject aceracion;
  public GameObject laminacion;
  public GameObject camionOb;
  public Rigidbody2D camion;
  public static bool colisionMina;
  public static bool colisionEd;
  public static bool colisionRedu;
  public static bool colisionAc;
  public static bool colisionLam;
  public static bool colisionCamion;
  public Text mensaje;
  public int contador;
    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1;
      colisionMina = false;
      colisionEd = false;
      colisionRedu = false;
      colisionAc = false;
      colisionLam = false;
      colisionCamion = false;
      MinarBtn.SetActive(colisionMina);
      EntregarBtn.SetActive(colisionEd);
      ReduBtn.SetActive(colisionRedu);
      AcBtn.SetActive(colisionAc);
      LamBtn.SetActive(colisionLam);
      CamBtn.SetActive(colisionCamion);
      mensaje.text = "Para empezar debemos encontrar una mina para extraer los minerales, Ve y encuentra una!";
      Invoke("destroyMessage",5);
    }

    // Update is called once per frame
    void Update()
    {

      if(MinarBtn != null){
        MinarBtn.SetActive(colisionMina);
      }
      if(EntregarBtn != null){
        EntregarBtn.SetActive(colisionEd);
      }
      if(ReduBtn != null){
        ReduBtn.SetActive(colisionRedu);
      }
      if(AcBtn != null){
        AcBtn.SetActive(colisionAc);
      }
      if(LamBtn != null){
        LamBtn.SetActive(colisionLam);
      }
      if(CamBtn != null){
        CamBtn.SetActive(colisionCamion);
      }
    }
    public void PressedButtonMinar(){
      Destroy(MinarBtn);
      StoneIron.SetActive(false);
      mensaje.text = "1.\nEn la mina se extraen los minerales como el hierro.\nEl hierro es sacado de las rocas y llevado directamente a las plantas de Ternium.\nAhora que ya tienes el hierro, busca a la fabricación de pellets para trabajar con los minerales ahí." ;
      contador = 2;
      Invoke("destroyMessage",10);
    }
    public void PressedButtonEntregar(){
      Destroy(EntregarBtn);
      //pellets.SetActive(false);
      mensaje.text = "2.\nAhora viene la fabricación de pellets. El hierro sacado de las rocas pasa por un proceso en donde se limpia y se forman pequeños paquetes en forma de esferas. Estos paquetes se llaman pellets.\nAhora avanza a la reducción de mineral de hierro.";
      contador = 3;
      Invoke("destroyMessage",10);
    }
    public void pressedButtonRedu(){
      Destroy(ReduBtn);
      //pellets2.SetActive(false);
      mensaje.text = "3.\nEste paso se llama 'Reducción del mineral de hierro', en esta parte tomamos los pellets y se meten en un recipiente caliente con forma de jarrón. Ahi purificamos bien nuestro metal. Ahora avanza al paso de aceración";
      contador = 4;
      Invoke("destroyMessage",10);
    }
    public void pressedButtonAc(){
      Destroy(AcBtn);
      //aceracion.SetActive(false);
      contador = 5;
      mensaje.text = "4.\nLlegamos a la parte de aceración, tomamos los pellets y chatarra de acero, lo metemos en un horno con forma de olla, lo calentamos y le agregamos unos ingredientes extras para hacerlo más resitente, se cocina todo y ahora tenemos acero líquido. Ve al siguiente paso!";
      Invoke("destroyMessage",10);
    }
    public void pressedButtonLam(){
      Destroy(LamBtn);
      //laminacion.SetActive(false);
      contador = 6;
      mensaje.text = "5.\nAhora sigue lo que se llama 'laminación', se llama así porque tomamos el acero que ya tenemos, lo vaciamos y lo vamos aplastando por arriba y por abajo para que se haga en forma de laminas grandes ó bien en piezas más largas y fáciles de doblar con las que se hacen alambres o varillas.\nAvanza al siguiente paso.";
      Invoke("destroyMessage",10);
    }
    //Este es el ultimo paso que hara el jugador
    public void pressedButtonCam(){
      Destroy(CamBtn);
      mensaje.text = "6.\nPor último tenemos los revestidos. Esto es cuando tomamos el acero y lo cubrimos con elementos que lo hacen más resistente a que se oxide y así pueda durar más tiempo.\nCon el acero que se hace en ternium, se construyen edificios, casas, coches y aparatos que encuentras en tu casa como refrigeradores, lavadoras, hornos, etc.";
      camion.velocity = new Vector2(2f,0f);
      Invoke("destroyMessage",10);
      //Aqui carga la escena final
      Invoke("finalScene",5);

    }
    public void destroyMessage(){
      mensaje.text = "";
    }
    public void finalScene(){
      SceneManager.LoadScene("Final");
    }
}
