public class Libro
{
    public int ISBN { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }

    public Libro(int isbn, string titulo, string autor)
    {
        ISBN = isbn;
        Titulo = titulo;
        Autor = autor;
    }

    public override string ToString()
    {
        return $"ISBN: {ISBN}, Título: {Titulo}, Autor: {Autor}";
    }
}
