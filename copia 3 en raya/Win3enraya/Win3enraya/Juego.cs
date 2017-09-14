using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win3enraya
{
    /// <summary>
    /// Estructura creada para guardar las posiciones que se van escribir y que sirva de intercambio entre clases.
    /// </summary>
    public struct Devolucion
    {
        /// <summary>
        /// Posición de la fila donde se va escribir.
        /// </summary>
        public int Fila;
        /// <summary>
        /// Posición de la columna donde se va escribir.
        /// </summary>
        public int Columna;
        /// <summary>
        /// 1 gana jugador, 2 gana maquina, 3 empate, 0 inicio variable.
        /// </summary>
        public int Ganador;
        /// <summary>
        /// 1 gana jugador, 2 gana maquina.
        /// </summary>
        public int Empieza;
    };
    class Juego
    {
        /// <summary>
        /// Valor global de la clase que determina el tamaño máximo de filas/columnas.
        /// </summary>
        private int n = 3;
        /// <summary>
        /// Varible de tipo estructura para poder trabajar con la estructura creada.
        /// </summary>
        Devolucion _devol = new Devolucion();
        /// <summary>
        /// Array multidimensional que guarda las posiciones donde se escribe y compararlas para determinar ganador.
        /// </summary>
        string[,] _casilla;
        /// <summary>
        /// Determina que el ganador ha sido la O.
        /// </summary>
        bool _ganaO;
        /// <summary>
        /// Determina que el ganador ha sido la X.
        /// </summary>
        bool _ganaX;
        /// <summary>
        /// Booleano para los while, para que mientras sea true no salga.
        /// </summary>
        bool _continuar;
        /// <summary>
        /// Booleano que, una vez haya una jugada confirmada, no pase por el resto de posibles jugadas.
        /// </summary>
        bool _seguir;
        /// <summary>
        /// Booleano que permite que en el segundo turno de la máquina, empezando ella, ponga su caracter en una esquina aleatoria.
        /// </summary>
        private bool _segturno = false;
        /// <summary>
        /// Comtador de cantidad de casillas para la comprobación del empate.
        /// </summary>
        private int _contador = 9;
        /// <summary>
        /// Constructor vacio para poder acceder desde otra clase
        /// </summary>
        public Juego() { }
        /// <summary>
        /// Array de string que guardará las posiciones, comprobar si se ha ganado o empatado, para enviarlas luego a la clase form1
        /// Y pone valores por defecto al iniciar otra partida.
        /// </summary>
        /// <param name="defecto">Valor pasado desde form1 con dato por defecto de ganador en la estructura</param>
        public void Crear(int defecto)
        {
            //Reinicio de valores por defecto--
            _devol.Ganador = defecto;
            _ganaX = false;
            _ganaO = false;
            _continuar = true;
            _seguir = true;
            _segturno = false;
            //---------------------------------
            _casilla = new string[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    _casilla[i, j] = "-";
                }
            }

        }
        /// <summary>
        /// Guarda la "X" en la posicion dada por fila y columna de la estruc. y devuelve esta última.
        /// </summary>
        /// <returns></returns>
        public Devolucion Movimientojugador()
        {
            _casilla[_devol.Fila, _devol.Columna] = "X";
            return _devol;
        }
        /// <summary>
        /// Genera un moviento acorde a cada jugada, intentando ganar, cubrir, poner una esquina o movimiento aleatorio si no hay otra opción.
        /// </summary>
        /// <returns>Devuelve la estructura devol con la posicion del movimiento</returns>
        public Devolucion Movimientomaquina(Devolucion devolf)
        {
            // Copia de valores de la estructura de form1.
            _devol = devolf;
            // Reinicio de la variable para que pueda elegir la jugada.
            _seguir = true;
            // Condición que indica que si el centro no está ocupado, se escribirá ahí.
            if (_casilla[1, 1] == "-")
            {
                _casilla[1, 1] = "O";
                _devol.Fila = 1;
                _devol.Columna = 1;
                _seguir = false;
                _segturno = true;
                return _devol;
            }
            Ganar();
            NoPerder();
            Esquina();
            Aleatorio();
            return _devol;
        }
        /// <summary>
        /// Hace una busqueda por toda la tabla, buscando una jugada que le permita ganar.
        /// </summary>
        /// <returns></returns>
        public Devolucion Ganar()
        {
            int c = 0;
            int j = 0;
            int x = 0;
            if (_seguir)
            {
                //--------------------filas----------------------------
                for (int i = 0; i < n; i++)
                {
                    c = 0;
                    x = 0;
                    for (j = 0; j < n; j++)
                    {
                        if (_casilla[i, j] == "-")
                        {
                            _devol.Fila = i;
                            _devol.Columna = j;
                        }
                        else if (_casilla[i, j] == "O")
                        {
                            c++;
                        }
                        else if (_casilla[i, j] == "X")
                        {
                            x++;
                        }
                    }
                    if (_casilla[_devol.Fila, _devol.Columna] == "-" && c == n - 1 && x == 0)
                    {
                        _casilla[_devol.Fila, _devol.Columna] = "O";
                        _seguir = false;
                        return _devol;
                    }
                }
                //--------------------Columnas------------------------
                for (int i = 0; i < n; i++)
                {
                    c = 0;
                    x = 0;
                    for (j = 0; j < n; j++)
                    {
                        if (_casilla[j, i] == "-")
                        {
                            _devol.Fila = j;
                            _devol.Columna = i;
                        }
                        else if (_casilla[j, i] == "O")
                        {
                            c++;
                        }
                        else if (_casilla[j, i] == "X")
                        {
                            x++;
                        }
                    }
                    if (_casilla[_devol.Fila, _devol.Columna] == "-" && c == n - 1 && x == 0)
                    {
                        _casilla[_devol.Fila, _devol.Columna] = "O";
                        _seguir = false;
                        return _devol;
                    }
                }
                //---------------Diagonal 1-------------------------------------
                j = 0;
                c = 0;
                x = 0;
                for (int i = 0; i < n; i++)
                {
                    if (_casilla[i, j] == "-")
                    {
                        _devol.Fila = i;
                        _devol.Columna = j;
                    }
                    else if (_casilla[i, j] == "O")
                    {
                        c++;
                    }
                    else if (_casilla[i, j] == "X")
                    {
                        x++;
                    }
                    j++;
                }
                if (_casilla[_devol.Fila, _devol.Columna] == "-" && c == n - 1 && x == 0)
                {
                    _casilla[_devol.Fila, _devol.Columna] = "O";
                    _seguir = false;
                    return _devol;
                }
                //---------------Diagonal 2-------------------------------------
                j = 2;
                c = 0;
                x = 0;
                for (int i = 0; i < n; i++)
                {
                    if (_casilla[i, j] == "-")
                    {
                        _devol.Fila = i;
                        _devol.Columna = j;
                    }
                    else if (_casilla[i, j] == "O")
                    {
                        c++;
                    }
                    else if (_casilla[i, j] == "X")
                    {
                        x++;
                    }
                    j--;
                }
                if (_casilla[_devol.Fila, _devol.Columna] == "-" && c == n - 1 && x == 0)
                {
                    _casilla[_devol.Fila, _devol.Columna] = "O";
                    _seguir = false;
                    return _devol;
                }
            }
            return _devol;
        }
        /// <summary>
        /// Hace una busqueda por toda la tabla, buscando evitar perder, bloqueando la jugada del oponente.
        /// </summary>
        /// <returns></returns>
        public Devolucion NoPerder()
        {
            int c = 0;
            int j = 0;
            int x = 0;
            if (_seguir)
            {
                //--------------------filas----------------------------
                for (int i = 0; i < n; i++)
                {
                    c = 0;
                    x = 0;
                    for (j = 0; j < n; j++)
                    {
                        if (_casilla[i, j] == "-")
                        {
                            _devol.Fila = i;
                            _devol.Columna = j;
                        }
                        else if (_casilla[i, j] == "O")
                        {
                            c++;
                        }
                        else if (_casilla[i, j] == "X")
                        {
                            x++;
                        }
                    }
                    if (_casilla[_devol.Fila, _devol.Columna] == "-" && x == n - 1 && c == 0)
                    {
                        _casilla[_devol.Fila, _devol.Columna] = "O";
                        _seguir = false;
                        return _devol;
                    }
                }
                //--------------------Columnas------------------------
                for (int i = 0; i < n; i++)
                {
                    c = 0;
                    x = 0;
                    for (j = 0; j < n; j++)
                    {
                        if (_casilla[j, i] == "-")
                        {
                            _devol.Fila = j;
                            _devol.Columna = i;
                        }
                        else if (_casilla[j, i] == "O")
                        {
                            c++;
                        }
                        else if (_casilla[j, i] == "X")
                        {
                            x++;
                        }
                    }
                    if (_casilla[_devol.Fila, _devol.Columna] == "-" && x == n - 1 && c == 0)
                    {
                        _casilla[_devol.Fila, _devol.Columna] = "O";
                        _seguir = false;
                        return _devol;
                    }
                }
                //---------------Diagonal 1-------------------------------------
                j = 0;
                c = 0;
                x = 0;
                for (int i = 0; i < n; i++)
                {
                    if (_casilla[i, j] == "-")
                    {
                        _devol.Fila = i;
                        _devol.Columna = j;
                    }
                    else if (_casilla[i, j] == "O")
                    {
                        c++;
                    }
                    else if (_casilla[i, j] == "X")
                    {
                        x++;
                    }
                    j++;
                }
                if (_casilla[_devol.Fila, _devol.Columna] == "-" && x == n - 1 && c == 0)
                {
                    _casilla[_devol.Fila, _devol.Columna] = "O";
                    _seguir = false;
                    return _devol;
                }
                //---------------Diagonal 2-------------------------------------
                j = 2;
                c = 0;
                x = 0;
                for (int i = 0; i < n; i++)
                {
                    if (_casilla[i, j] == "-")
                    {
                        _devol.Fila = i;
                        _devol.Columna = j;
                    }
                    else if (_casilla[i, j] == "O")
                    {
                        c++;
                    }
                    else if (_casilla[i, j] == "X")
                    {
                        x++;
                    }
                    j--;
                }
                if (_casilla[_devol.Fila, _devol.Columna] == "-" && x == n - 1 && c == 0)
                {
                    _casilla[_devol.Fila, _devol.Columna] = "O";
                    _seguir = false;
                    return _devol;
                }
            }
            return _devol;
        }
        /// <summary>
        /// Coloca en una esquina aleatoria en el segundo movimiento.
        /// </summary>
        public void Esquina()
        {
            Random auto = new Random();
            int cont = 0;
            if (_seguir)
            {
                if (_devol.Empieza == 1 || _segturno)
                {
                    while (_continuar && cont < 10)
                    {
                        var esquina = auto.Next(1, 5);
                        if (esquina == 1 && _casilla[0, 0] == "-")
                        {
                            _casilla[0, 0] = "O";
                            _devol.Fila = 0;
                            _devol.Columna = 0;
                            _continuar = false;
                            _segturno = false;
                            _seguir = false;
                        }
                        else if (esquina == 2 && _casilla[0, n - 1] == "-")
                        {
                            _casilla[0, n - 1] = "O";
                            _devol.Fila = 0;
                            _devol.Columna = n - 1;
                            _continuar = false;
                            _segturno = false;
                            _seguir = false;
                        }
                        else if (esquina == 3 && _casilla[n - 1, 0] == "-")
                        {
                            _casilla[n - 1, 0] = "O";
                            _devol.Fila = n - 1;
                            _devol.Columna = 0;
                            _continuar = false;
                            _segturno = false;
                            _seguir = false;
                        }
                        else if (esquina == 4 && _casilla[n - 1, n - 1] == "-")
                        {
                            _casilla[n - 1, n - 1] = "O";
                            _devol.Fila = n - 1;
                            _devol.Columna = n - 1;
                            _continuar = false;
                            _segturno = false;
                            _seguir = false;
                        }
                        cont++;
                    }
                }
            }
        }
        /// <summary>
        /// Hace una jugada aleatoria, si no hay otra opción.
        /// </summary>
        private void Aleatorio()
        {
            Random auto = new Random();
            if (_seguir)
            {
                bool continuar = true;
                while (continuar)
                {
                    var fila = auto.Next(0, n);
                    var col = auto.Next(0, n);
                    if (_casilla[fila, col] == "-")
                    {
                        _casilla[fila, col] = "O";
                        continuar = false;
                        _seguir = false;
                    }
                    _devol.Fila = fila;
                    _devol.Columna = col;
                }
            }
        }
        /// <summary>
        /// Comprueba si hay tres "X" o "O" iguales en la misma fila
        /// </summary>
        /// <param name="turno">Determina el turno de juego, "true" para jugador y "false" para la máquina</param>
        public void GanaFilas(bool turno)
        {
            int cont = 0;
            if (turno)
            {
                for (int i = 0; i < n; i++)
                {
                    if (_casilla[_devol.Fila, i] == "X")
                    {
                        cont++;
                    }
                    if (cont == 3)
                    {
                        _ganaX = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (_casilla[_devol.Fila, i] == "O")
                    {
                        cont++;
                    }
                    if (cont == 3)
                    {
                        _ganaO = true;
                    }
                }
            }
        }
        /// <summary>
        /// Comprueba si hay tres "X" o "O" iguales en la misma columna
        /// </summary>
        /// <param name="turno">Determina el turno de juego, "true" para jugador y "false" para la máquina</param>
        public void GanaColumnas(bool turno)
        {
            int cont = 0;
            if (turno)
            {
                for (int i = 0; i < n; i++)
                {
                    if (_casilla[i, _devol.Columna] == "X")
                    {
                        cont++;
                    }
                    if (cont == 3)
                    {
                        _ganaX = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (_casilla[i, _devol.Columna] == "O")
                    {
                        cont++;
                    }
                    if (cont == 3)
                    {
                        _ganaO = true;
                    }
                }
            }

        }
        /// <summary>
        /// Comprueba que la diagonal dcha-izda tenga el mismo texto y pone a "true" la propiedad ganador correspondiente
        /// </summary>
        public void GanaDiagonal1()
        {
            int j = 0;
            int o = 0;
            int x = 0;
            for (int i = 0; i < n; i++)
            {
                if (_casilla[i, j] == "O")
                {
                    o++;
                }
                else if (_casilla[i, j] == "X")
                {
                    x++;
                }
                j++;
            }
            if (x == 3)
            {
                _ganaX = true;
            }
            if (o == 3)
            {
                _ganaO = true;
            }
        }
        /// <summary>
        /// Comprueba que la diagonal izda-dcha tenga el mismo texto y pone a "true" la propiedad ganador correspondiente
        /// </summary>
        public void GanaDiagonal2()
        {
            int j = 2;
            int o = 0;
            int x = 0;
            for (int i = 0; i < n; i++)
            {
                if (_casilla[i, j] == "O")
                {
                    o++;
                }
                else if (_casilla[i, j] == "X")
                {
                    x++;
                }
                j--;
            }
            if (x == 3)
            {
                _ganaX = true;
            }
            if (o == 3)
            {
                _ganaO = true;
            }
        }
        /// <summary>
        /// Si no ha ganado nadie, comprueba mediante una busqueda por toda la tabla que no hayan guiones
        /// </summary>
        /// <returns></returns>
        public int Empate()
        {
            if (!_ganaX || !_ganaO)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (_casilla[i, j] != "-")
                        {
                            _contador--; //  Se le resta uno a contador por cada campo que no tenga un "-" hasta llegar a 9
                        }
                    }
                }
                if (_contador == 0)
                {
                    return 1;
                }
                _contador = 9;
            }
            return 0;
        }
        /// <summary>
        /// Agrupa todos los metodos de ganar y devuelve la estructura con el ganador en caso de haberlo
        /// </summary>
        /// <param name="turno"></param>
        /// <returns></returns>
        public Devolucion Comprobar(bool turno)
        {
            GanaFilas(turno);
            GanaColumnas(turno);
            GanaDiagonal1();
            GanaDiagonal2();
            if (_ganaX)
            {
                _devol.Ganador = 1;
            }
            else if (_ganaO)
            {
                _devol.Ganador = 2;
            }
            return _devol;
        }
        /// <summary>
        /// Guarda en el array la posicion recibida.
        /// </summary>
        /// <param name="fila">Posición de la fila del boton pulsado por el jugador</param>
        /// <param name="col">Posición de la columna del boton pulsado por el jugador</param>
        /// <param name="devolf">Copia de la estructura de la clase form</param>
        public void PosiX(string fila, string col, Devolucion devolf)
        {
            _devol = devolf;
            _devol.Fila = Convert.ToInt32(fila);
            _devol.Columna = Convert.ToInt32(col);
            _casilla[_devol.Fila, _devol.Columna] = "X";
        }
    }
}


