using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour

{
    GameObject launcher;
    public float velocidad = 5f;  // velocidad de movimiento de la nave
    private Rigidbody2D rb;  // referencia al componente Rigidbody2D
    private NavMechanics mechanics;
    private StarLauncher starLauncher;

    // Variables para reposicionar la nave
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial = Quaternion.identity;
    string axisX;
    string axisY; 
    [SerializeField] private float speedRotation = 5f;
    [SerializeField] GameObject explosionPrefab;
    private AudioSource explosionSound;
     Transform child;
     AudioSource starSound;

 private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Square"))
    {
        mechanics.restar();
        //explosionSound.enabled = true;
        explosionSound.Play();
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 1.5f);
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Collider2D>().enabled = false;
        Transform child = transform.Find("ShipImage");
        Renderer renderer = child.GetComponent<Renderer>();
        renderer.enabled = false;
        transform.Find("ShipImage/Trail").gameObject.SetActive(false);
        StartCoroutine(RespawnCoroutine());
    }
}

private IEnumerator RespawnCoroutine()
{
    yield return new WaitForSeconds(1.5f);
    Transform child = transform.Find("ShipImage");
    Renderer renderer = child.GetComponent<Renderer>();
    renderer.enabled = true;
    GetComponent<Rigidbody2D>().isKinematic = false;
    GetComponent<Collider2D>().enabled = true;
    transform.position = posicionInicial;
    transform.rotation = rotacionInicial;
    transform.Find("ShipImage/Trail").gameObject.SetActive(true);
}
private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Star")){
        Destroy(other.gameObject);
        starSound.Play();
        starLauncher.LaunchStar();
        mechanics.sumar();
    }
}


     private void Awake()
    {
        explosionSound = GetComponent<AudioSource>();
    }
    private void Start()
    {
        // Obtener la referencia al componente Rigidbody2D
        launcher = GameObject.FindGameObjectWithTag("StarFactory");
        starLauncher = launcher.GetComponent<StarLauncher>();
        rb = GetComponent<Rigidbody2D>();
        mechanics = GetComponent<NavMechanics>();
        rotacionInicial = transform.rotation;
        child = transform.Find("StarSound");
        starSound  = child.GetComponent<AudioSource>();


        if(tag == "Nave1"){
            axisX = "Horizontal";
            axisY = "Vertical";
            posicionInicial=new Vector2(6.4f,3.7f);
        }
        else if(tag == "Nave2"){
            axisX = "Horizontal2";
            axisY = "Vertical2";
            posicionInicial=new Vector2(-6.4f,-3.7f);

        }

    }

    void FixedUpdate()
    {
        // Movimiento horizontal
        float movimientoHorizontal = Input.GetAxis(axisX);
        Vector2 movimiento = new Vector2(movimientoHorizontal, 0) * velocidad * Time.fixedDeltaTime;

        // Movimiento vertical
        float movimientoVertical = Input.GetAxis(axisY);
        movimiento += new Vector2(0, movimientoVertical) * velocidad * Time.fixedDeltaTime;

        // Mover la nave con la física de Unity
        rb.MovePosition(rb.position + movimiento);
    }

    private void Update()
    {
        // Obtener la direccion de movimiento a partir de las entradas del jugador
        Vector2 movementDirection = new Vector2(Input.GetAxisRaw(axisX), Input.GetAxisRaw(axisY)).normalized;

        // Rotar la nave en direccion al movimiento
        if (movementDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speedRotation * Time.deltaTime);
        }
    }
}
