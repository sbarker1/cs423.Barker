Renderer rend;
Material material;
// Start is called before the first frame update
void Start()
{
     rend = GetComponent<Renderer>();
     material = rend.material;
     material.SetColor("_Color", Color.magenta);
}