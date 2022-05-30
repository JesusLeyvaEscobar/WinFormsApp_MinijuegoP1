namespace WinFormsApp_MinijuegoP1
{
    public partial class Form1 : Form
    {
        bool turno = true; //true=Turno X entonces false=Turno Y
        int contadorTurno = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sobre del juego:\n\nCada jugador solo debe colocar su símbolo una vez por turno y " +
                "no debe ser sobre una casilla ya jugada. En caso de que el jugador haga trampa el ganador será el otro. " +
                "Se debe conseguir realizar una línea recta o diagonal por símbolo. \n\nHabilidades requeditas: " +
                "Estrategia\n\nAzar: No", "Ayuda");
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(turno)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            turno = !turno;
            b.Enabled = false;
            contadorTurno++;

            verificarGanador();
        }

        private void verificarGanador()
        {
            bool ganador = false;

            //Verificacion Horizontal
            if((buttonA1.Text == buttonA2.Text) && (buttonA2.Text == buttonA3.Text) && (!buttonA1.Enabled))
            {
                ganador = true;
            }
            else if ((buttonB1.Text == buttonB2.Text) && (buttonB2.Text == buttonB3.Text) && (!buttonB1.Enabled))
            {
                ganador = true;
            }
            else if ((buttonC1.Text == buttonC2.Text) && (buttonC2.Text == buttonC3.Text) && (!buttonC1.Enabled))
            {
                ganador = true;
            }

            //Verificacion vertical
            else if ((buttonA1.Text == buttonB1.Text) && (buttonB1.Text == buttonC1.Text) && (!buttonA1.Enabled))
            {
                ganador = true;
            }
            else if ((buttonA2.Text == buttonB2.Text) && (buttonB2.Text == buttonC2.Text) && (!buttonA2.Enabled))
            {
                ganador = true;
            }
            else if ((buttonA3.Text == buttonB3.Text) && (buttonB3.Text == buttonC3.Text) && (!buttonA3.Enabled))
            {
                ganador = true;
            }

            //Verificacion de diagonal
            else if ((buttonA1.Text == buttonB2.Text) && (buttonB2.Text == buttonC3.Text) && (!buttonA1.Enabled))
            {
                ganador = true;
            }
            else if ((buttonA3.Text == buttonB2.Text) && (buttonB2.Text == buttonC1.Text) && (!buttonC1.Enabled))
            {
                ganador = true;
            }

            if (ganador)
            {
                deshabilitarBotones();

                String jugadorGanarodor = "";
                if(turno)
                {
                    jugadorGanarodor = "O";
                }
                else
                {
                    jugadorGanarodor = "X";
                }

                MessageBox.Show(jugadorGanarodor + " Ganaste!", "Enhorabuena:");
            }
            else
            {
                if (contadorTurno == 9)
                    MessageBox.Show("Que partida mas cerrada! \nTenemos un empate", "Increible...");
            }

        }//Final verificarGanador

        private void deshabilitarBotones()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch {  }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turno = true;
            contadorTurno = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }
    }
}