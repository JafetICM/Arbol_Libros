public class Nodo
{
    public Libro Datos { get; set; }
    public Nodo? Izquierdo { get; set; }
    public Nodo? Derecho { get; set; }

    public Nodo(Libro libro)
    {
        Datos = libro;
        Izquierdo = null;
        Derecho = null;
    }
}
