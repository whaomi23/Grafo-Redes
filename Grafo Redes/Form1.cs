using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using static Grafo_Redes.Form1;
using static Grafo_Redes.Nodo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Grafo_Redes
{
    public partial class Form1 : Form
    {
        private List<Nodo> listaNodos = new List<Nodo>(); // Lista para almacenar los nodos agregados
        private bool agregarNodo = false; // Variable para controlar si se debe agregar un nodo
        private int numeroNodo = 0; // Variable para contar el número de nodos agregados
        private ContextMenuStrip contextMenu;
        private bool grafoDirigido = true; // Variable para controlar si el grafo es dirigido o no dirigido
        private Color colorNodo;

        public int Grosor { get; set; }

        public Form1()
        {
            InitializeComponent();
            MenuContextual();
            CONSOLA_GRAFO.MouseDown += CONSOLA_GRAFO_MouseDown;
            CONSOLA_GRAFO.MouseUp += CONSOLA_GRAFO_MouseUp;

            // Asignar el menú contextual a CONSOLA_GRAFO
            CONSOLA_GRAFO.ContextMenuStrip = contextMenu;
            Grosor_Grafo_Nodo();

        }


        private void Grosor_Grafo_Nodo()
        {
            for (int i = 1; i <= 5; i++)
            {
                switch (i)
                {
                    case 1:
                        Tamaño_Nodo_Grafo.Items.Add("1");
                        break;
                    case 2:
                        Tamaño_Nodo_Grafo.Items.Add("2");
                        break;
                    case 3:
                        Tamaño_Nodo_Grafo.Items.Add("3");
                        break;
                    case 4:
                        Tamaño_Nodo_Grafo.Items.Add("4");
                        break;
                    case 5:
                        Tamaño_Nodo_Grafo.Items.Add("5");
                        break;
                    default:
                        break;
                }
            }
            Tamaño_Nodo_Grafo.SelectedIndexChanged += Tamaño_Nodo_Grafo_SelectedIndexChanged;
        }











        private void MenuContextual()
        {
            // Crea el menú contextual
            ContextMenuStrip contextMenu = new ContextMenuStrip();

      

            ToolStripMenuItem GNRMZ = new ToolStripMenuItem("Generar Matriz AD");
            GNRMZ.Font = new Font("Arial", 12, FontStyle.Bold);
            GNRMZ.TextAlign = ContentAlignment.MiddleLeft;
            contextMenu.Items.Add(GNRMZ);

            ToolStripMenuItem TPGRF = new ToolStripMenuItem("Tipo de grafo?");
            TPGRF.Font = new Font("Arial", 12, FontStyle.Bold);
            TPGRF.TextAlign = ContentAlignment.MiddleLeft;
            contextMenu.Items.Add(TPGRF);

            ToolStripMenuItem eliminarNodo = new ToolStripMenuItem("Eliminar Nodo");
            eliminarNodo.Font = new Font("Arial", 12, FontStyle.Bold);
            eliminarNodo.TextAlign = ContentAlignment.MiddleLeft;
            eliminarNodo.Click += EliminarNodo_Click; // Suscribe el evento Click
            contextMenu.Items.Add(eliminarNodo);


            ToolStripMenuItem LMC = new ToolStripMenuItem("Limpiar Todo");
            LMC.Font = new Font("Arial", 12, FontStyle.Bold);
            LMC.TextAlign = ContentAlignment.MiddleLeft;
            LMC.Click += LimpiarTodo_Click; // Suscribe el evento Click
            contextMenu.Items.Add(LMC);



            // Asignar el menú contextual a la variable de instancia
            this.contextMenu = contextMenu;



        }

        private void LimpiarTodo_Click(object sender, EventArgs e)
        {
            // Limpiar la lista de nodos
            listaNodos.Clear();

            // Limpiar la consola del grafo
            CONSOLA_GRAFO.Refresh();

            // Limpiar el ListBox
            LISTA_REGISTROS_GF.Items.Clear();

            // Limpiar los ComboBoxes
            VerticeNodo1.Items.Clear();
            VerticeNodo2.Items.Clear();
        }

        private void EliminarNodo_Click(object sender, EventArgs e)
        {
             if (listaNodos.Count > 0)
    {
        // Obtener el último nodo ingresado
        Nodo ultimoNodo = listaNodos[listaNodos.Count - 1];

        // Eliminar el nodo de los ComboBoxes
        VerticeNodo1.Items.Remove(ultimoNodo);
        VerticeNodo2.Items.Remove(ultimoNodo);

        // Eliminar todas las conexiones del nodo en los otros nodos
        foreach (Nodo nodo in listaNodos)
        {
            nodo.ConexionesSalientes.RemoveAll(conexion => conexion.NodoDestino == ultimoNodo);
        }

        // Eliminar el último nodo de la lista de nodos
        listaNodos.RemoveAt(listaNodos.Count - 1);

        // Volver a dibujar la consola del grafo
        CONSOLA_GRAFO.Refresh();

        // Eliminar el último registro de la lista
        LISTA_REGISTROS_GF.Items.RemoveAt(LISTA_REGISTROS_GF.Items.Count - 1);
    }
        }


        private void NOMBRE_GRAFO_Click(object sender, EventArgs e)
        {

        }





        private void V1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TITULO_VER_PROPIEDADES_Click(object sender, EventArgs e)
        {

        }

        private void POCISION_X_Click(object sender, EventArgs e)
        {

        }

        private void POCISION_X_V_TextChanged(object sender, EventArgs e)
        {

        }

        private void POCISION_Y_Click(object sender, EventArgs e)
        {

        }

        private void POCISION_Y_V_TextChanged(object sender, EventArgs e)
        {

        }

        private void TMÑ_Click(object sender, EventArgs e)
        {

        }

        private void TAMAÑO_TextChanged(object sender, EventArgs e)
        {

        }

        private void CLR_Click(object sender, EventArgs e)
        {

        }

        private void COLOR_TextChanged(object sender, EventArgs e)
        {

        }

        private void GSR_Click(object sender, EventArgs e)
        {

        }

        private void GROSOR_TextChanged(object sender, EventArgs e)
        {

        }

        private void LIMPIAR_Click(object sender, EventArgs e)
        {

        }

        private void ACTUALIZAR_GRAFO_Click(object sender, EventArgs e)
        {

        }

        private void AGREGAR_Click(object sender, EventArgs e)
        {

        }

        private void CONSOLA_GRAFO_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (listaNodos.Count > 0)
            {
                // Dibujar los nodos en la consola del grafo
                foreach (Nodo nodo in listaNodos)
                {
                    int posX = nodo.PosX;
                    int posY = nodo.PosY;
                    int radio = 20; // Radio del círculo del nodo

                    // Dibujar el círculo del nodo en la posición adecuada con el color y grosor especificados
                    g.DrawEllipse(new Pen(nodo.Color, 5), posX - radio, posY - radio, 2 * radio, 2 * radio);

                    // Mostrar el nombre del nodo en una etiqueta
                    g.DrawString(nodo.Nombre, new Font("Arial", 12, FontStyle.Bold), Brushes.White, posX - radio, posY + radio + 5);

                    foreach (Conexion conexion in nodo.ConexionesSalientes)
                    {
                        Nodo nodoDestino = conexion.NodoDestino;
                        DIBUJAR_FLECHA(g, new Pen(Color.White), posX, posY, nodoDestino.PosX, nodoDestino.PosY);

                        // Mostrar el peso de la conexión entre paréntesis
                        string peso = $"({conexion.Peso})";
                        int pesoPosX = (posX + nodoDestino.PosX) / 2;
                        int pesoPosY = (posY + nodoDestino.PosY) / 2;
                        g.DrawString(peso, new Font("Arial", 10, FontStyle.Regular), Brushes.White, pesoPosX, pesoPosY);

                    }

                }
            }
        }

        private void CONSOLA_GRAFO_MouseDown(object sender, MouseEventArgs e)
        {
            agregarNodo = true; // Habilitar la bandera para agregar un nodo
        }

        private void CONSOLA_GRAFO_MouseUp(object sender, MouseEventArgs e)
        {
            if (agregarNodo)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Generar un color aleatorio para el nodo
                    Random rnd = new Random();
                    do
                    {
                        colorNodo = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    } while (colorNodo == Color.Black);

                    // Mostrar el cuadro de diálogo de entrada para solicitar el nombre del nodo
                    string nombreNodo = InputBox("Ingrese el nombre del nodo:", "Nombre del Nodo");

                    if (!string.IsNullOrEmpty(nombreNodo))
                    {
                        numeroNodo++;

                        // Crear un nuevo nodo en la posición del clic con el color correspondiente
                        Nodo nodo = new Nodo(numeroNodo, nombreNodo, colorNodo, e.X, e.Y);

                        // Agregar el nodo a la lista de nodos
                        listaNodos.Add(nodo);

                        // Agregar el nodo al ListBox
                        LISTA_REGISTROS_GF.Items.Add(nodo.ToString());


                        // Agregar el nodo a los ComboBox
                        VerticeNodo1.Items.Add(nodo);
                        VerticeNodo2.Items.Add(nodo);


                        // Volver a dibujar la consola del grafo
                        CONSOLA_GRAFO.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Es necesario asignar un nombre al nodo.", "Nombre requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                agregarNodo = false; // Deshabilitar la bandera para agregar un nodo
            }
        }


        private string InputBox(string prompt, string title)
        {
            Form promptForm = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label lblPrompt = new Label() { Left = 20, Top = 20, Text = prompt };
            TextBox txtInput = new TextBox() { Left = 20, Top = 50, Width = 250 };
            Button btnOk = new Button() { Text = "Aceptar", Left = 180, Width = 80, Top = 80, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Cancelar", Left = 90, Width = 80, Top = 80, DialogResult = DialogResult.Cancel };

            btnOk.Click += (sender, e) => { promptForm.Close(); };

            promptForm.Controls.Add(lblPrompt);
            promptForm.Controls.Add(txtInput);
            promptForm.Controls.Add(btnOk);
            promptForm.Controls.Add(btnCancel);

            promptForm.AcceptButton = btnOk;
            promptForm.CancelButton = btnCancel;

            return promptForm.ShowDialog() == DialogResult.OK ? txtInput.Text : "";
        }

        private void LIMPIAR_CONSOLA_GRAFO_Click(object sender, EventArgs e)
        {

            // Limpiar la lista de nodos
            listaNodos.Clear();

            // Limpiar la consola del grafo
            CONSOLA_GRAFO.Refresh();
        }






        private void Tamaño_Nodo_Grafo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el grosor seleccionado del ComboBox
            int Grosor = int.Parse(Tamaño_Nodo_Grafo.SelectedItem.ToString());

            // Volver a dibujar la consola del grafo
            CONSOLA_GRAFO.Refresh();

        }

        private void LISTA_REGISTROS_GF_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void Calcular_Click(object sender, EventArgs e)
        {
            // Obtener los nodos seleccionados de los ComboBox
            Nodo nodo1 = VerticeNodo1.SelectedItem as Nodo;
            Nodo nodo2 = VerticeNodo2.SelectedItem as Nodo;

            if (nodo1 != null && nodo2 != null)
            {
                // Mostrar el cuadro de diálogo de entrada para solicitar el peso
                string pesoStr = InputBox("Ingrese el peso de la conexión:", "Peso de la Conexión");

                if (!string.IsNullOrEmpty(pesoStr))
                {
                    int peso;
                    if (int.TryParse(pesoStr, out peso))
                    {
                        // Crear una conexión entre los nodos y asignar el peso
                        Conexion conexion = new Conexion { NodoDestino = nodo2, Peso = peso };
                        nodo1.ConexionesSalientes.Add(conexion);

                        // Volver a dibujar la consola del grafo
                        CONSOLA_GRAFO.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("El peso ingresado no es válido.", "Peso inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar dos nodos para realizar la conexión.", "Nodos no seleccionados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DIBUJAR_FLECHA(Graphics g, Pen Dibujar, int x1, int y1, int x2, int y2)
        {
            const int tamañodelaflecha = 5;
            double angle = Math.Atan2(y2 - y1, x2 - x1);
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);

            // Calcular las coordenadas del punto final de la flecha
            int x2a = (int)(x2 - tamañodelaflecha * cos);
            int y2a = (int)(y2 - tamañodelaflecha * sin);

            // Dibujar la línea principal
            g.DrawLine(Dibujar, x1, y1, x2a, y2a);

            // Dibujar la cabeza de flecha
            g.FillPolygon(Brushes.White, new[]
            {
                new Point(x2, y2),
                new Point((int)(x2a + tamañodelaflecha * sin), (int)(y2a - tamañodelaflecha * cos)),
                new Point((int)(x2a - tamañodelaflecha * sin), (int)(y2a + tamañodelaflecha * cos))
            });

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private int[,] CalcularMatrizAdyacencia()
        {
            int[,] matrizAdyacencia = new int[listaNodos.Count, listaNodos.Count];

            for (int i = 0; i < listaNodos.Count; i++)
            {
                for (int j = 0; j < listaNodos.Count; j++)
                {
                    if (i == j)
                    {
                        matrizAdyacencia[i, j] = 0;
                    }
                    else
                    {
                        matrizAdyacencia[i, j] = ObtenerPesoConexion(listaNodos[i], listaNodos[j]);
                    }
                }
            }

            return matrizAdyacencia;
        }

        private int ObtenerPesoConexion(Nodo nodo1, Nodo nodo2)
        {
            foreach (Conexion conexion in nodo1.ConexionesSalientes)
            {
                if (conexion.NodoDestino == nodo2)
                {
                    if (grafoDirigido)
                    {
                        return 1;
                    }
                    else
                    {
                        return conexion.Peso;
                    }
                }
            }

            return 0;
        }


        private void CalcularAdyacencia_Click(object sender, EventArgs e)
        {
            int[,] matrizAdyacencia = CalcularMatrizAdyacencia();

            string matrizAdyacenciaStr = "Matriz de Adyacencia:\n\n";

            for (int i = 0; i < listaNodos.Count; i++)
            {
                for (int j = 0; j < listaNodos.Count; j++)
                {
                    matrizAdyacenciaStr += matrizAdyacencia[i, j] + "\t";
                }

                matrizAdyacenciaStr += "\n";
            }

            MessageBox.Show(matrizAdyacenciaStr, "Matriz de Adyacencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Dirigido_CheckedChanged(object sender, EventArgs e)
        {
            grafoDirigido = true;
        }

        private void NoDirigido_CheckedChanged(object sender, EventArgs e)
        {
            grafoDirigido = false;
        }
    }




    public class Nodo
    {

        public int Numero { get; private set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Color Color { get; set; }

        public string Nombre { get; set; }

        public List<Conexion> ConexionesSalientes { get; set; } = new List<Conexion>();



        public Nodo(int numero, string nombre, Color color, int posX, int posY)
        {

            Numero = numero;
            Nombre = nombre;
            Color = color;
            PosX = posX;
            PosY = posY;
            ConexionesSalientes = new List<Conexion>();

        }
        public override string ToString()
        {
            return $"Grafo {Numero}: Nombre = {Nombre}, Poscision: X = {PosX}, Posicion: Y = {PosY}";
        }

        public class Conexion
        {
            public Nodo NodoDestino { get; set; }
            public int Peso { get; set; }
        }
    }
}
   




