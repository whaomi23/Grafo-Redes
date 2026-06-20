using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using static Grafo_Redes.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Grafo_Redes
{
    public partial class Form1 : Form
    {
        private List<Nodo> listaNodos = new List<Nodo>(); // Lista para almacenar los nodos agregados
        private bool agregarNodo = false; // Variable para controlar si se debe agregar un nodo
        private int numeroNodo = 0; // Variable para contar el número de nodos agregados


        public Form1()
        {
            InitializeComponent();
            Menuconextual();
            CONSOLA_GRAFO.MouseDown += CONSOLA_GRAFO_MouseDown;
            CONSOLA_GRAFO.MouseUp += CONSOLA_GRAFO_MouseUp;
        }


        private void Menuconextual()
        {
            // Crea el menú contextual
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem ACTG = new ToolStripMenuItem("Actualizar Grafo");
            ACTG.Font = new Font("Arial", 12, FontStyle.Bold);
            ACTG.TextAlign = ContentAlignment.MiddleLeft;
            contextMenu.Items.Add(ACTG);


            ToolStripMenuItem EGF = new ToolStripMenuItem("Eliminar Grafo");
            EGF.Font = new Font("Arial", 12, FontStyle.Bold);
            EGF.TextAlign = ContentAlignment.MiddleLeft;
            contextMenu.Items.Add(EGF);



            ToolStripMenuItem GNR = new ToolStripMenuItem("Generar Recorrido");
            GNR.Font = new Font("Arial", 12, FontStyle.Bold);
            GNR.TextAlign = ContentAlignment.MiddleLeft;
            contextMenu.Items.Add(GNR);




            ToolStripMenuItem GNRMZ = new ToolStripMenuItem("Generar Matriz AD");
            GNRMZ.Font = new Font("Arial", 12, FontStyle.Bold);
            GNRMZ.TextAlign = ContentAlignment.MiddleLeft;
            contextMenu.Items.Add(GNRMZ);


            ToolStripMenuItem LMC = new ToolStripMenuItem("Limpiar Todo");
            LMC.Font = new Font("Arial", 12, FontStyle.Bold);
            LMC.TextAlign = ContentAlignment.MiddleLeft;
            contextMenu.Items.Add(LMC);






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
                // Generar un color aleatorio para el nodo
                Random rnd = new Random();
                Color colorNodo = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));


                // Mostrar el cuadro de diálogo de entrada para solicitar el nombre del nodo
                string Nombrenodo = InputBox("Ingrese el nombre del nodo:", "Nombre del Nodo");
                numeroNodo++;

                // Crear un nuevo nodo en la posición del clic con el color correspondiente
                Nodo nodo = new Nodo(numeroNodo, Nombrenodo, colorNodo, e.X, e.Y);

                // Agregar el nodo a la lista de nodos
                listaNodos.Add(nodo);

                // Agregar el nodo al ListBox
                listBox1.Items.Add(nodo.ToString());

                // Volver a dibujar la consola del grafo
                CONSOLA_GRAFO.Refresh();



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

     

    }


        public class Nodo
        {

        public int Numero { get; private set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Color Color { get; set; }

        public string Nombre { get; set; }
         
        public Nodo(int numero, string nombre, Color color, int posX, int posY)
            {

            Numero = numero;
            Nombre = nombre;
            Color = color;
            PosX = posX;
            PosY = posY;
         
            }
        public override string ToString()
        {
            return $"Grafo {Numero}: Nombre = {Nombre}, Poscision: X = {PosX}, Posicion: Y = {PosY}";
        }
    }
 }


   




