using System.Text;

public class ArbolBinarioBusqueda
{
    public Nodo? Raiz { get; private set; }

    public ArbolBinarioBusqueda()
    {
        Raiz = null;
    }

    public void Agregar(Libro libro)
    {
        Raiz = AgregarRecursivo(Raiz, libro);
    }

    private Nodo AgregarRecursivo(Nodo? nodo, Libro libro)
    {
        if (nodo == null)
        {
            return new Nodo(libro);
        }

        if (libro.ISBN < nodo.Datos.ISBN)
        {
            nodo.Izquierdo = AgregarRecursivo(nodo.Izquierdo, libro);
        }
        else if (libro.ISBN > nodo.Datos.ISBN)
        {
            nodo.Derecho = AgregarRecursivo(nodo.Derecho, libro);
        }

        return nodo;
    }

    public Libro? Buscar(int isbn)
    {
        return BuscarRecursivo(Raiz, isbn);
    }

    private Libro? BuscarRecursivo(Nodo? nodo, int isbn)
    {
        if (nodo == null)
        {
            return null;
        }

        if (isbn == nodo.Datos.ISBN)
        {
            return nodo.Datos;
        }

        if (isbn < nodo.Datos.ISBN)
        {
            return BuscarRecursivo(nodo.Izquierdo, isbn);
        }

        return BuscarRecursivo(nodo.Derecho, isbn);
    }

    public void Eliminar(int isbn)
    {
        Raiz = EliminarRecursivo(Raiz, isbn);
    }

    private Nodo? EliminarRecursivo(Nodo? nodo, int isbn)
    {
        if (nodo == null)
        {
            return null;
        }

        if (isbn < nodo.Datos.ISBN)
        {
            nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, isbn);
        }
        else if (isbn > nodo.Datos.ISBN)
        {
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, isbn);
        }
        else
        {
            if (nodo.Izquierdo == null) return nodo.Derecho;
            if (nodo.Derecho == null) return nodo.Izquierdo;

            Nodo sucesor = ObtenerMinimo(nodo.Derecho);
            nodo.Datos = sucesor.Datos;
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, sucesor.Datos.ISBN);
        }

        return nodo;
    }

    private Nodo ObtenerMinimo(Nodo nodo)
    {
        while (nodo.Izquierdo != null)
        {
            nodo = nodo.Izquierdo;
        }
        return nodo;
    }

    public string MostrarEnOrden()
    {
        StringBuilder sb = new StringBuilder();
        MostrarEnOrdenRecursivo(Raiz, sb);
        return sb.ToString();
    }

    private void MostrarEnOrdenRecursivo(Nodo? nodo, StringBuilder sb)
    {
        if (nodo != null)
        {
            MostrarEnOrdenRecursivo(nodo.Izquierdo, sb);
            sb.AppendLine(nodo.Datos.ToString());
            MostrarEnOrdenRecursivo(nodo.Derecho, sb);
        }
    }
}
