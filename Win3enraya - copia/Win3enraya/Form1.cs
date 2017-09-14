using System;
using System.Windows.Forms;

namespace Win3enraya
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Creación variable de tipo array de botones.
        /// </summary>
        private Button[,] _boton;
        /// <summary>
        /// Constante de numero entero que indica el nº de casillas por fila/columna
        /// </summary>
        private const int N = 3;
        /// <summary>
        /// Variable que guarda las partidas ganadas.
        /// </summary>
        private int _ganadas;
        /// <summary>
        /// Variable que guarda las partidas perdidas.
        /// </summary>
        private int _perdidas;
        /// <summary>
        /// Variable que guarda las partidas empatadas.
        /// </summary>
        private int _empatadas;
        /// <summary>
        /// Llamada al constructor para poder llamar a sus metodos de la clase juego
        /// </summary>
        private readonly Juego _enraya = new Juego();
        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            panel1.Enabled = false; //  se dehabilitan el panel para que no se pueda clicar hasta que se inicie el juego
        }
        /// <summary>
        /// Creacion de array de botones, guardando los botones de forma inversa para que queden ordenados desde el primero que colocamos hasta el último,
        /// ya que al colocarlos por defecto pone el último como si fuera el primero.
        /// </summary>
        private void Crea()
        {
            int i, j, k;
            _boton = new Button[N, N];
            k = panel1.Controls.Count - 1;
            for (i = 0; i < N; i++)
                for (j = 0; j < N; j++)
                {
                    _boton[i, j] = (Button)panel1.Controls[k];
                    k--;
                }
            int num=0;
            for (i = 0; i < N; i++)
                for (j = 0; j < N; j++)
                {
                    _boton[i, j].Text = _boton[i,j].Name;
                    num++;
                }
        }
        /// <summary>
        /// Asignado al boton inicia del juego, que desbloquea el panel y pregunta el orden de turnos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BInicia_Click(object sender, EventArgs e)
        {
            Crea();     // Llama a la función que crea el array de botones y los ordena.
            _enraya.Crear();   // Llama al metodo crea de la clase juego para poner valores por defecto, para cuando juega mas de una vez
            panel1.Enabled = true;  // Habilita el panel y se desqbloquean los botones
            // Bucle que rellena los botones con el texto "-". La "i" son las filas y la "j" las columnas.
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    _boton[i, j].Text = @"-";
                    _boton[i, j].Enabled = true;
                }
            }
            // Cuadro de mensaje que pregunta quien quiere comenzar, para asignar "1" o "2" al turno de la estructura de la clase juego
            switch (MessageBox.Show("\"Yes\" player \n \"No\" machine", @"New game", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            {
                case DialogResult.Yes:
                    _enraya.Devol.Turno = 1;    //Inicia Jugador
                    break;
                default:
                    _enraya.Devol.Turno = 2;    //Inicia máquina
                    Click_Maquina();
                    break;
            }
        }
        /// <summary>
        /// Gestiona los movimientos del jugador y llama al movimiento de la maquina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Movimiento(object sender, EventArgs e)
        {
            //  Se crea una variable de tipo boton para generalizar el objeto y se pueda usar con todos los botones de form
            Button click = (Button)sender;
            //  Llama al movimientojugador al que se le pasa a partir del nombre, posicion "1" para fila y posicion "2" para columna, para guardar la posicion del boton
            _enraya.Movimientojugador(click.Name[1].ToString(), click.Name[2].ToString());
            click.Text = @"X";   //  Escribe el texto en el boton pulsado recogido con sender
            // Llama al metodo que comprueba si se ha ganado enviando el turno y guardando en el campo ganador de la estructura un "1" si gana jugador o "2" si gana la maquina
            _enraya.Comprobar(true);
            click.Enabled = false;  // Deshabilita el boton para que no pueda volver a clicar en el
            Ganador(); //  En caso de que se haya ganado o empatado mostrara el mensaje correspondiente
            // En caso de no resultar ganador el jugador(1) o haber empatado(3), se llama al movimiento de la maquina
            if (_enraya.Devol.Ganador != 1 && _enraya.Devol.Ganador != 3)    
                Click_Maquina();
        }
        /// <summary>
        /// Gestiona los pasos que debe hacer la maquina
        /// </summary>
        private void Click_Maquina()
        {
            //  Se llama al movimiento de la maquina en la clase juego.
            _enraya.Movimientomaquina();
            //  Escribe el texto en la posicion generada por el metodo anterior
            _boton[_enraya.Devol.Fila, _enraya.Devol.Columna].Text = @"O";
            _boton[_enraya.Devol.Fila, _enraya.Devol.Columna].Enabled = false;
            _enraya.Comprobar(false);
            Ganador();
        }
        /// <summary>
        /// Si ha ganado el jugador, la maquina o si se ha empatado muestra el mensaje correspondiente
        /// </summary>
        private void Ganador()
        {
            switch (_enraya.Devol.Ganador)
            {
                case 1:
                    panel1.Enabled = false;
                    MessageBox.Show(@"You win!", @"Winner!");
                    _ganadas++;
                    break;
                case 2:
                    panel1.Enabled = false;
                    MessageBox.Show(@"You lose!", @"Winner!");
                    _perdidas++;
                    break;
                default:
                    int s = _enraya.Empate();   //  Comprueba si se ha empatado, si devuelve "1" muestra el mensaje de lo contrario continua el juego
                    if (s == 1)
                    {
                        panel1.Enabled = false;
                        MessageBox.Show(@"It's a Draw!", @"End Game");
                        _enraya.Devol.Ganador = 3;
                        _empatadas++;
                    }
                    break;
            }
            Marcador();
        }
        /// <summary>
        /// Guarda cada valor de la puntuación en el lugar correspondiente de la tabla.
        /// </summary>
        private void Marcador()
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
    }
}
