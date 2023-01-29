using System;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi_final
{
    public partial class Reversi : Form
    {
        static int rows = 6;
        static int columns = 6;

        int max = rows * columns;
        int afmetingen = 400 / (Math.Max(columns, rows));
        int aantal = 4;
        int kleur = 1;
        int[,] board = new int[rows, columns];

        Pen pen = new Pen(Color.Black);

        public Reversi()
        {
            InitializeComponent();
            Paint += TekenPanel;
            MouseClick += ClickPanel;
            Begin();
        }

        //Eerste 4 stenen  
        public void Begin()
        {
            int start_x = (rows / 2) - 1;
            int start_y = (columns / 2) - 1;

            board[start_x, start_y] = 1;
            board[start_x + 1, start_y] = -1;
            board[start_x, start_y + 1] = -1;
            board[start_x + 1, start_y + 1] = 1;
        }

        //Kliklocatie in array zetten + kleur toevoegen
        public void ClickPanel(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            Test.Text = "x=" + mea.X.ToString() + " y=" + mea.Y.ToString();

            int x = Convert.ToInt32(Convert.ToDouble((mea.X - 30) / afmetingen));
            int y = Convert.ToInt32(Convert.ToDouble((mea.Y - 30) / afmetingen));

            if (onBoard(x, y, 0, 0))
            {
                if (board[x, y] == 0 && aantal < max)
                {
                    board[x, y] = kleur;

                    if (IsValidMove(x, y))
                    {
                        Test.Text = "Valid";
                        drawTiles(x, y);
                        kleur *= -1;
                        aantal++;
                        Invalidate();
                    }
                    else
                    {
                        Test.Text = "Invalid";
                    }
                }
            }
        }

        public bool onBoard(int x, int y, int m, int n)
        {
            if (x + m >= 0 && x + m <= rows - 1 && y + n >= 0 && y + n <= columns - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void drawTiles (int x, int y)
        {
            for (int m = -1; m <= 1; m++)
            {
                for (int n = -1; n <= 1; n++)
                {
                    if (!(n == 0 && m == 0) && onBoard(x, y, m, n) && board[x + m, y + n] == kleur * -1)
                    {
                        int how_many = 0;

                        while (onBoard(x, y, m, n) && board[x + m, y + n] == kleur * -1)
                        {
                            x += m;
                            y += n;

                            how_many++;
                        }

                        if (onBoard(x, y, m, n) && board[x + m, y + n] == kleur)
                        {
                            for (int p = how_many; p > 0; p--)
                            {
                                board[x, y] = kleur;
                                x -= m;
                                y -= n;
                            }
                        }
                    }
                }
            }

        }

        public bool IsValidMove(int x, int y)
        {
            for (int m = -1; m <= 1; m++)
            {
                for (int n = -1; n <= 1; n++)
                {
                    if (!(n == 0 && m == 0) && onBoard(x, y, m, n) && board[x + m, y + n] == kleur * -1)
                    {
                        while (onBoard(x, y, m, n) && board[x + m, y + n] == kleur * -1)
                        {
                            x += m;
                            y += n;
                        }

                        if (onBoard(x, y, m, n) && board[x + m, y + n] == kleur)
                        {                            
                            return true;
                        }

                        return false;
                    }
                }
            }

            return false;
        }

        public void TekenPanel(object sender, PaintEventArgs pea)
        {
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    pea.Graphics.DrawRectangle(pen, x * afmetingen + 30, y * afmetingen + 30, afmetingen, afmetingen);

                    if (this.board[x, y] == 1)
                    {
                        pea.Graphics.FillEllipse(Brushes.Blue, x * afmetingen + 30, y * afmetingen + 30, afmetingen, afmetingen);
                    }
                    else if (this.board[x, y] == -1)
                    {
                        pea.Graphics.FillEllipse(Brushes.Red, x * afmetingen + 30, y * afmetingen + 30, afmetingen, afmetingen);
                    }
                }
            }
        }

    }
}
