using System;

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
        /// 1 para jugador, 2 para maquina.
        /// </summary>
        public int Turno;
    };
    internal class Juego
    {
        /// <summary>
        /// Valor global de la clase que determina el tamaño máximo de filas/columnas.
        /// </summary>
        private const int N = 3;
        /// <summary>
        /// Varible de tipo estructura para poder trabajar con la estructura creada.
        /// </summary>
        public Devolucion Devol;
        /// <summary>
        /// Array multidimensional que guarda las posiciones donde se escribe y compararlas para determinar ganador.
        /// </summary>
        private string[,] _casilla;
        /// <summary>
        /// Determina que el ganador ha sido la O.
        /// </summary>
        private bool _ganaO;
        /// <summary>
        /// Determina que el ganador ha sido la X.
        /// </summary>
        private bool _ganaX;
        /// <summary>
        /// Booleano que, una vez haya una jugada confirmada, no pase por el resto de posibles jugadas.
        /// </summary>
        private bool _seguir;
        /// <summary>
        /// Comtador de cantidad de casillas para la comprobación del empate.
        /// </summary>
        private int _contador = 9;
        /// <summary>
        /// Contador que suma las "O" de una línea, contador que suma las "X" de una línea.
        /// </summary>
        public int O, X;
        /// <summary>
        /// Constructor interno que contiene los contadores para determinar cuantas veces en una línea se repite el mismo caracter.
        /// </summary>
        internal Juego()
        {
            O = 0;
            X = 0;
        }
        /// <summary>
        /// Array de string que guardará las posiciones, comprobar si se ha ganado o empatado, para enviarlas luego a la clase form1
        /// Y pone valores por defecto al iniciar otra partida.
        /// </summary>
        public void Crear()
        {
            //----Reinicio de valores por defecto----
            Devol.Ganador = 0;    // Pone el valor por defecto para evitar fallos al volver a jugar.
            _ganaX = false; _ganaO = false; _seguir = true;
            //---------------------------------------
            _casilla = new string[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    _casilla[i, j] = "-";
        }
        /// <summary>
        /// Guarda la "X" en la posicion dada por fila y columna de la estruc. y devuelve esta última.
        /// </summary>
        /// <returns></returns>
        public void Movimientojugador(string fila, string col)
        {
            Devol.Fila = Convert.ToInt32(fila);
            Devol.Columna = Convert.ToInt32(col);
            _casilla[Devol.Fila, Devol.Columna] = "X";
        }
        /// <summary>
        /// Genera un moviento acorde a cada jugada, intentando ganar o cubrir.
        /// </summary>
        public void Movimientomaquina()
        {
            _seguir = true; // Reinicio de la variable para que pueda elegir la jugada.
            // Genera el primer movimiento de la maquina
            if (_casilla[0, 0] == "-" && Devol.Turno == 2 || _casilla[1, 1] == "X" && Devol.Turno == 1)
            {
                Esquina();
                Devol.Turno = 0; return;
            }
            if (_casilla[1, 1] == "-")  //En caso de que una esquina este ocupada la maquina pone en el centro.
                for (int i = 0; i <= N - 1; i += 2)
                    for (int j = 0; j <= N - 1; j += 2)
                        if (_casilla[i, j] == "X" || _casilla[i, j] == "O")
                        {
                            _casilla[1, 1] = "O";
                            Devol.Fila = 1; Devol.Columna = 1;
                            _seguir = false;
                        }
            Adyacente();
        }
        /// <summary>
        /// Si jugador coloca en alguna casilla de los extremos del "+", la maquina colocará a su lado en una esquina.
        /// </summary>
        private void Adyacente()
        {
            if (_seguir)
                if (Devol.Turno == 1) // Adyacente en jugada +
                {
                    for (int i = 0, j = 1; i < N - 1; i++, j++)
                    {
                        if (_casilla[i, j] == "X")
                        {
                            _casilla[0, N - 1] = "O";
                            Devol.Fila = 0; Devol.Columna = N - 1;
                            _seguir = false;
                        }
                        if (_casilla[j, i] == "X")
                        {
                            _casilla[N - 1, 0] = "O";
                            Devol.Fila = N - 1; Devol.Columna = 0;
                            _seguir = false;
                        }
                    }
                    Devol.Turno = 0;    // Se pone el valor a 0 para que solo entre en la primera jugada.
                }
            Ganar();
        }
        /// <summary>
        /// Hace una busqueda por toda la tabla, determinando si hay una jugada que le permita ganar.
        /// </summary>
        /// <returns></returns>
        public void Ganar()
        {
            int j = 0; O = 0; X = 0;
            if (_seguir)
            {
                //--------------------filas--------------------------------------
                for (int i = 0; i < N; i++)
                {
                    O = 0; X = 0;
                    Busqueda(i, j, 1);
                    if (_casilla[Devol.Fila, Devol.Columna] == "-" && O == N - 1 && X == 0)
                    {
                        _casilla[Devol.Fila, Devol.Columna] = "O";
                        _seguir = false; return;
                    }
                }
                //--------------------Columnas-----------------------------------
                for (int i = 0; i < N; i++)
                {
                    O = 0;
                    X = 0;
                    Busqueda(i, j, 2);
                    if (_casilla[Devol.Fila, Devol.Columna] == "-" && O == N - 1 && X == 0)
                    {
                        _casilla[Devol.Fila, Devol.Columna] = "O";
                        _seguir = false; return;
                    }
                }
                //---------------Diagonal 1-------------------------------------
                j = 0; O = 0; X = 0;
                for (int i = 0; i < N; i++, j++)
                {
                    Busqueda(i, j, 3);
                }
                if (_casilla[Devol.Fila, Devol.Columna] == "-" && O == N - 1 && X == 0)
                {
                    _casilla[Devol.Fila, Devol.Columna] = "O";
                    _seguir = false; return;
                }
                //---------------Diagonal 2-------------------------------------
                j = 2; O = 0; X = 0;
                for (int i = 0; i < N; i++, j--)
                {
                    Busqueda(i, j, 3);
                }
                if (_casilla[Devol.Fila, Devol.Columna] == "-" && O == N - 1 && X == 0)
                {
                    _casilla[Devol.Fila, Devol.Columna] = "O";
                    _seguir = false; return;
                }
            }
            NoPerder();
        }
        /// <summary>
        /// Hace una busqueda por toda la tabla, evitando perder, bloqueando la jugada del oponente.
        /// </summary>
        /// <returns></returns>
        public void NoPerder()
        {
            int j = 0;
            if (_seguir)
            {
                //--------------------filas----------------------------
                for (int i = 0; i < N; i++)
                {
                    O = 0; X = 0;
                    Busqueda(i, j, 1);
                    if (_casilla[Devol.Fila, Devol.Columna] == "-" && X == N - 1 && O == 0)
                    {
                        _casilla[Devol.Fila, Devol.Columna] = "O";
                        _seguir = false; return;
                    }
                }
                //--------------------Columnas------------------------
                for (int i = 0; i < N; i++)
                {
                    O = 0; X = 0;
                    Busqueda(i, j, 2);
                    if (_casilla[Devol.Fila, Devol.Columna] == "-" && X == N - 1 && O == 0)
                    {
                        _casilla[Devol.Fila, Devol.Columna] = "O";
                        _seguir = false; return;
                    }
                }
                //---------------Diagonal 1-------------------------------------
                j = 0; O = 0; X = 0;
                for (int i = 0; i < N; i++, j++)
                {
                    Busqueda(i, j, 3);
                }
                if (_casilla[Devol.Fila, Devol.Columna] == "-" && X == N - 1 && O == 0)
                {
                    _casilla[Devol.Fila, Devol.Columna] = "O";
                    _seguir = false; return;
                } 
                if (_casilla[1, 1] == "O" && X == N - 1 && O == 1)
                {
                    Aleatorio(); return;
                }
                //---------------Diagonal 2-------------------------------------
                j = 2; O = 0; X = 0;
                for (int i = 0; i < N; i++, j--)
                {
                    Busqueda(i, j, 3);
                }
                if (_casilla[Devol.Fila, Devol.Columna] == "-" && X == N - 1 && O == 0)
                {
                    _casilla[Devol.Fila, Devol.Columna] = "O";
                    _seguir = false; return;
                }
                if (_casilla[1, 1] == "O" && X == N - 1 && O == 1)
                {
                    Aleatorio(); return;
                }
            }
            CubrirAtipicas();
        }
        /// <summary>
        /// La maquina evita la posible jugada triangulo por parte del jugador. Si el jugador ha puesto en el centro, comprueba
        /// si tambien ha puesto en una esquina, poniendo ella en las esquina contraria bloqueando la jugada triangulo.
        /// </summary>
        public void CubrirAtipicas()
        {
            if (_seguir && _casilla[1, 1] == "X")
                for (int i = 0; i <= N - 1; i += 2)
                    for (int j = 0; j <= N - 1; j += 2)
                        if (_casilla[i, j] == "X")
                            if (j == 2 && _casilla[i, j - 2] == "-")
                            {
                                _casilla[i, j - 2] = "O";
                                Devol.Fila = i; Devol.Columna = j - 2;
                                _seguir = false; return;
                            }
                            else if (j == 0 && _casilla[i, j + 2] == "-")
                            {
                                _casilla[i, j + 2] = "O";
                                Devol.Fila = i; Devol.Columna = j + 2;
                                _seguir = false; return;
                            }
            Esquina();
        }
        /// <summary>
        /// Coloca en la primera esquina libre.
        /// </summary>
        public void Esquina()
        {
            if (_seguir)
                for (int i = 0; i <= N - 1; i += 2)
                    for (int j = 0; j <= N - 1; j += 2)
                        if (_casilla[i, j] == "-")
                        {
                            _casilla[i, j] = "O";
                            Devol.Fila = i; Devol.Columna = j;
                            _seguir = false; return;
                        }
            Aleatorio();
        }
        /// <summary>
        /// Coloca en la primera posicion libre en eje "+".
        /// </summary>
        private void Aleatorio()
        {
            if (_seguir)
                for (int i = 0, j = 1; i < N - 1; i++, j++)
                {
                    if (_casilla[i, j] == "-")
                    {
                        _casilla[i, j] = "O";
                        Devol.Fila = i; Devol.Columna = j;
                        _seguir = false; return;
                    }
                    if (_casilla[j, i] == "-")
                    {
                        _casilla[j, i] = "O";
                        Devol.Fila = j; Devol.Columna = i;
                        _seguir = false; return;
                    }
                }
        }
        /// <summary>
        /// Recorre el array y va sumando en los contadores correpondientes si es "O" o "X" y si esta vacio guarda la posición.
        /// </summary>
        /// <param name="i1">Copia del incremento que recorre las filas</param>
        /// <param name="j1">Copia del incremento que recorre las columnas</param>
        /// <param name="t">Variable que recoge el tipo de busqueda que se requiere, 1 para las fila, 2 para columna y 3 para diagonal</param>
        public void Busqueda(int i1, int j1, int t)
        {
            int i = i1, j = j1;
            switch (t)
            {
                case 1: //Filas
                    for (j = 0; j < N; j++)
                        if (_casilla[i, j] == "-")
                        {
                            Devol.Fila = i;
                            Devol.Columna = j;
                        }
                        else if (_casilla[i, j] == "O")
                            O++;
                        else if (_casilla[i, j] == "X")
                            X++;
                    break;
                case 2: //Columnas
                    for (j = 0; j < N; j++)
                        if (_casilla[j, i] == "-")
                        {
                            Devol.Fila = j;
                            Devol.Columna = i;
                        }
                        else if (_casilla[j, i] == "O")
                            O++;
                        else if (_casilla[j, i] == "X")
                            X++;
                    break;
                case 3: //Diagonales
                    switch (_casilla[i, j])
                    {
                        case "-":
                            Devol.Fila = i;
                            Devol.Columna = j;
                            break;
                        case "O":
                            O++;
                            break;
                        case "X":
                            X++;
                            break;
                    }
                    break;
            }
        }
        /// <summary>
        /// Agrupa todos los metodos de ganar y devuelve la estructura con el ganador en caso de haberlo
        /// </summary>
        /// <param name="turno">Determina el turno de juego, "true" para jugador y "false" para la máquina</param>
        /// <returns></returns>
        public void Comprobar(bool turno)
        {
            GanaFilas(turno); GanaColumnas(turno); GanaDiagonal1(); GanaDiagonal2();
            if (_ganaX)
                Devol.Ganador = 1;
            else if (_ganaO)
                Devol.Ganador = 2;
        }
        /// <summary>
        /// Comprueba si hay tres "X" o "O" iguales en la misma fila
        /// </summary>
        /// <param name="turno">Determina el turno de juego, "true" para jugador y "false" para la máquina</param>
        public void GanaFilas(bool turno)
        {
            int cont = 0;
            bool gana = false;
            if (!_ganaX && !_ganaO)
            {
                string car;
                if (!turno)
                    car = "O";
                else
                    car = "X";
                for (int i = 0; i < N; i++)
                {
                    if (_casilla[Devol.Fila, i] == car)
                        cont++;
                    if (cont == 3)
                        gana = true;
                }
                if (!turno)
                    _ganaO = gana;
                else
                    _ganaX = gana;
            }
        }
        /// <summary>
        /// Comprueba si hay tres "X" o "O" iguales en la misma columna
        /// </summary>
        /// <param name="turno">Determina el turno de juego, "true" para jugador y "false" para la máquina</param>
        public void GanaColumnas(bool turno)
        {
            int cont = 0;
            bool gana = false;
            if (!_ganaX && !_ganaO)
            {
                string car;
                if (!turno)
                    car = "O";
                else
                    car = "X";

                for (int i = 0; i < N; i++)
                    if (_casilla[i, Devol.Columna] == car)
                        cont++;
                if (cont == 3)
                    gana = true;
                if (turno)
                    _ganaX = gana;
                else
                    _ganaO = gana;
            }
        }
        /// <summary>
        /// Comprueba que la diagonal dcha-izda tenga el mismo texto y pone a "true" la propiedad ganador correspondiente
        /// </summary>
        public void GanaDiagonal1()
        {
            int j = 0, o = 0, x = 0;
            if (!_ganaX && !_ganaO)
            {
                for (int i = 0; i < N; i++, j++)
                {
                    if (_casilla[i, j] == "O")
                        o++;
                    else if (_casilla[i, j] == "X")
                        x++;
                }
                if (x == 3)
                    _ganaX = true;
                if (o == 3)
                    _ganaO = true;
            }
        }
        /// <summary>
        /// Comprueba que la diagonal izda-dcha tenga el mismo texto y pone a "true" la propiedad ganador correspondiente
        /// </summary>
        public void GanaDiagonal2()
        {
            int j = 2, o = 0, x = 0;
            if (!_ganaX && !_ganaO)
            {
                for (int i = 0; i < N; i++, j--)
                {
                    if (_casilla[i, j] == "O")
                        o++;
                    else if (_casilla[i, j] == "X")
                        x++;
                }
                if (x == 3)
                    _ganaX = true;
                if (o == 3)
                    _ganaO = true;
            }
        }
        /// <summary>
        /// Si no ha ganado nadie, comprueba mediante una busqueda por toda la tabla que no hayan guiones(casillas vacias)
        /// </summary>
        /// <returns></returns>
        public int Empate()
        {
            if (!_ganaX || !_ganaO)
            {
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < N; j++)
                        if (_casilla[i, j] != "-")
                            _contador--; //  Se le resta uno a contador por cada campo que no tenga un "-" hasta llegar a 9
                if (_contador == 0)
                    return 1;
                _contador = 9;
            }
            return 0;
        }
    }
}