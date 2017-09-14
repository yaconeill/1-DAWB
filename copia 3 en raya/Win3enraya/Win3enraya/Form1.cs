using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win3enraya
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Creación variable de tipo array de botones.
        /// </summary>
        private Button[,] _boton;
        /// <summary>
        /// Numero entero que indica el nº de casillas por fila/columna
        /// </summary>
        private const int N = 3;
        /// <summary>
        /// Declaración de un copia de la estructura de la clase Juego.
        /// </summary>
        Devolucion _devolf;
        /// <summary>
        /// Atributo booleana usada para organizar el orden de turnos "true" para el jugador y "false" para la máquina
        /// </summary>
        public bool Turno;
        /// <summary>
        /// Areibuto de tipo resultado de diálogo para iniciar el turno según la respuesta del recibida.
        /// </summary>
        DialogResult _turn;
        /// <summary>
        /// Variable que guarda las partidas ganadas.
        /// </summary>
        private int _ganadas = 0;
        /// <summary>
        /// Variable que guarda las partidas perdidas.
        /// </summary>
        private int _perdidas = 0;
        /// <summary>
        /// Variable que guarda las partidas empatadas.
        /// </summary>
        private int _empatadas = 0;
        /// <summary>
        /// Llamada al constructor para poder llamar a sus metodos de la clase juego
        /// </summary>
        Juego _enraya = new Juego(); 
        public Form1()
        {
            InitializeComponent();
            panel1.Enabled = false; //  se dehabilitan el panel para que no se pueda clicar hasta que se inicie el juego
        }
        /// <summary>
        /// Creacion de array de botones
        /// </summary>
        private void Crea()
        {
            int i, j, k;
            _boton = new Button[N, N];
            k = panel1.Controls.Count - 1;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    _boton[i, j] = (Button)panel1.Controls[k];
                    k--;
                }
            }
            string[] fila0 = { _ganadas.ToString(), _perdidas.ToString(), _empatadas.ToString() };
            //dataGridView1.Rows.Add(fila0);
        }
        /// <summary>
        /// Asignado al boton inicia del juego, que desbloquea el panel y pregunta el orden de turnos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BInicia_Click(object sender, EventArgs e)
        {
            _devolf.Ganador = 0;
            Crea();
            _enraya.Crear(_devolf.Ganador);   // Llama al metodo crea de la clase juego para poner valores por defecto, para cuando juega mas de una vez
            panel1.Enabled = true;  // Habilita el panel y se desqbloquean los botones
            // Bucle que rellena los botones con el texto "-". La "i" son las filas y la "j" las columnas.
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    _boton[i, j].Text = "-";
                    _boton[i, j].Enabled = true;
                }
            }
            // Cuadro de mensaje que pregunta quien quiere comenzar, para asignar "true" o "false" al campo turno de la estructura de la clase juego
            // para organizar el orden de turnos
            _turn = MessageBox.Show("\"Yes\" to play first, \"No\" to let the machine", "New game", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (_turn == DialogResult.Yes)
            {
                Turno = true; //Inicia Jugador
                _devolf.Empieza = 1;
            }
            else
            {
                Turno = false; //Inicia máquina
                _devolf.Empieza = 2;
                Click_Maquina(sender, e);
            }
        }
        /// <summary>
        /// Gestiona los moviemientos del jugador y llama al moviento de la maquina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Movimiento(object sender, EventArgs e)
        {
            //  Se crea una variable de tipo boton para generalizar el objeto y se pueda usar con todos los botones de form
            Button click = (Button)sender;
            //  Llama a un metodo para guardar la posicion del boton, que se le pasa a partir del nombre, posicion "1" para fila y posicion "2" para columna
            _enraya.PosiX(click.Name[1].ToString(), click.Name[2].ToString(), _devolf);
            //  A partir de la posicion extraida del metodo anterior se llama al movimiento que devuelve la estructura como esa posicion
            _devolf = _enraya.Movimientojugador();
            click.Text = "X";   //  Escribe el texto en el boton pulsado recogido con sender
            // Llama al metodo que comprueba si se ha ganado enviando el turno y devolviendo en el campo ganador de la estruc. un "1" si gana jugador o "2" para la maquina
            _devolf = _enraya.Comprobar(true);
            click.Enabled = false;  // Deshanilita el boton para que no pueda volver a clicar en el
            Ganador(sender, e); //  En caso de que se haya ganado o empatado mostrara el mensaje correspondiente
            //devolf.turno = false;   //  Invierte el turno para que juegue la maquina
            if (_devolf.Ganador != 1 && _devolf.Ganador != 3)    //  En caso de no resultar ganador el jugador, se llama a la maquina
            {
                Click_Maquina(sender, e);
            }
        }
        /// <summary>
        /// Gestiona los pasos que debe hacer la maquina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Maquina(object sender, EventArgs e)
        {
            //  Se llama al movimiento de la maquina en la clase juego y devuelve la estructura con la posicion de la jugada
            _devolf = _enraya.Movimientomaquina(_devolf);
            //  Escribe el texto en la posicion generada por el metodo anterior
            _boton[_devolf.Fila, _devolf.Columna].Text = "O";
            _boton[_devolf.Fila, _devolf.Columna].Enabled = false;
            _devolf = _enraya.Comprobar(false);
            Ganador(sender, e);
            //devolf.turno = true;
        }
        /// <summary>
        /// Si ha ganado el jugador, la maquina o si se ha empatado muestra el mensaje correspondiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Ganador(object sender, EventArgs e)
        {
            if (_devolf.Ganador == 1)
            {
                panel1.Enabled = false;
                MessageBox.Show("You win!", "Winner!");
                _ganadas++;
            }
            else if (_devolf.Ganador == 2)
            {
                panel1.Enabled = false;
                MessageBox.Show("You lose!", "Winner!");
                _perdidas++;
            }
            else
            {
                int s = _enraya.Empate();   //  Comprueba si se ha empado, si devuelve "1" muestra el mensaje de lo contrario continua el juego
                if (s == 1)
                {
                    panel1.Enabled = false;
                    MessageBox.Show("It's a Draw", "End Game");
                    _devolf.Ganador = 3;
                    _empatadas++;
                }
            }
            Marcador();
        }
        /// <summary>
        /// Guarda cada valor de la puntuación en el lugar correspondiente de la tabla.
        /// </summary>
        void Marcador()
        {
            Won.Text = _ganadas.ToString();
            Lost.Text = _perdidas.ToString();
            Draw.Text = _empatadas.ToString();
        }
        /// <summary>
        /// Método que borra el contenido de la tabla de puntuación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Won.Text = 0.ToString();
            Lost.Text = 0.ToString();
            Draw.Text = 0.ToString();
        }

        //void GuardadoScore()
        //{
        //    FileStream fw;
        //    bool carpeta = false;
        //    if (Directory.Exists(@"..\..\saving\save.txt") == false)
        //    {
        //        try
        //        {
        //            Directory.CreateDirectory(@"..\..\saving");
        //            carpeta = true;
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("No se pudo crear la carrpeta ficheros");
        //            return;
        //        }
        //    }

        //    if (File.Exists(@"..\..\saving\save.txt") == false)
        //    {
        //        try
        //        {
        //            fw = new FileStream(@"..\..\saving\save.txt", FileMode.Append, FileAccess.Write);
        //            fw.Close();
        //        }
        //        catch (Exception)
        //        {
        //            if (carpeta == true)
        //            {
        //                try
        //                {
        //                    Directory.Delete(@"..\..\saving");
        //                }
        //                catch (Exception)
        //                {
        //                    MessageBox.Show("No se pudo borra la carpeta ficheros");
        //                }
        //            }
        //            MessageBox.Show("No se pudo crear el fichero");
        //            return;
        //        }
        //    }
        //    try
        //    {
        //        //dataGridView1.Rows(@"..\..\saving\save.txt", RichTextBoxStreamType.PlainText);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("No se pudo grabar el fichero");
        //    }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            //if (File.Exists(@"..\..\saving\save.txt") == true)
            //{
            //    try
            //    {
            //        dataGridView1(@"..\..\saving\save.txt", RichTextBoxStreamType.PlainText);
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("No se pudo leer del fichero");
            //    }
            //}

        }

        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (!Directory.Exists(@"..\..\saving"))
        //    {
        //        Directory.CreateDirectory(@"..\..\saving");
        //    }

        //    TextWriter sw = new StreamWriter(@"..\..\saving\save.txt");
        //        sw.WriteLine(dataGridView1.Rows[0].Cells[0].Value.ToString() + "\t"
        //                     + dataGridView1.Rows[0].Cells[1].Value.ToString() + "\t"
        //                      + dataGridView1.Rows[0].Cells[2].Value.ToString());
        //    sw.Close();
        //}
    }


}
