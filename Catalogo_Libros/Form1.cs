using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArbolBinarioApp
{
    public partial class Form1 : Form
    {
        private ArbolBinarioBusqueda arbol;

        public Form1()
        {
            InitializeComponent();
            arbol = new ArbolBinarioBusqueda();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtISBN.Text, out int isbn))
            {
                txtResultado.Text = "El ISBN debe ser un número.";
                return;
            }

            string titulo = txtTitulo.Text;
            string autor = txtAutor.Text;

            arbol.Agregar(new Libro(isbn, titulo, autor));
            txtResultado.Text = "Libro agregado exitosamente.";
            DibujarArbol();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtISBN.Text, out int isbn))
            {
                txtResultado.Text = "El ISBN debe ser un número.";
                return;
            }

            var libro = arbol.Buscar(isbn);
            txtResultado.Text = libro != null
                ? $"Libro encontrado:\n{libro}"
                : "No se encontró ningún libro con ese ISBN.";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtISBN.Text, out int isbn))
            {
                txtResultado.Text = "El ISBN debe ser un número.";
                return;
            }

            arbol.Eliminar(isbn);
            txtResultado.Text = "Libro eliminado.";
            DibujarArbol();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "Catálogo de Libros:\n" + arbol.MostrarEnOrden();
            DibujarArbol();
        }

        private void DibujarArbol()
        {
            Graphics g = panelArbol.CreateGraphics();
            g.Clear(Color.White);
            if (arbol.Raiz != null)
            {
                DibujarNodo(g, arbol.Raiz, panelArbol.Width / 2, 20, panelArbol.Width / 4);
            }
        }

        private void DibujarNodo(Graphics g, Nodo nodo, int x, int y, int distancia)
        {
            g.FillEllipse(Brushes.LightBlue, x - 20, y - 20, 40, 40);
            g.DrawEllipse(Pens.Black, x - 20, y - 20, 40, 40);
            g.DrawString(nodo.Datos.ISBN.ToString(), new Font("Arial", 10), Brushes.Black, x - 15, y - 10);

            if (nodo.Izquierdo != null)
            {
                g.DrawLine(Pens.Black, x, y, x - distancia, y + 60);
                DibujarNodo(g, nodo.Izquierdo, x - distancia, y + 60, distancia / 2);
            }

            if (nodo.Derecho != null)
            {
                g.DrawLine(Pens.Black, x, y, x + distancia, y + 60);
                DibujarNodo(g, nodo.Derecho, x + distancia, y + 60, distancia / 2);
            }
        }
    }
}
