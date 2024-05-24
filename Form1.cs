using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace GomokuGame
{
    public partial class Form1 : Form
    {
        private const int BoardSize = 15;
        private const int CellSize = 30;
        private Button[,] board;
        private bool isBlackTurn = true;
        private Color blackPieceColor = Color.Black; // �´Ѥl���q�{�C��
        private Color whitePieceColor = Color.White; // �մѤl���q�{�C��
        private Stack<Point> movesHistory = new Stack<Point>(); // �O�s�C�ӴѤl����m
    




        public Form1()
        {
            InitializeComponent();
            InitializeBoard();
            this.BackColor = Color.FromArgb(204, 187, 136);  // Set form background color to a lighter coffee color
        }
       

        private void InitializeBoard()
        {
            board = new Button[BoardSize, BoardSize];
            Color cellColor = Color.FromArgb(204, 187, 136); // Sandy or earthy yellow
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Button btn = new Button
                    {
                        Width = CellSize,
                        Height = CellSize,
                        Location = new Point(i * CellSize, j * CellSize),
                        Tag = new Point(i, j), // �Ω�s�x��m
                        BackColor = cellColor // Set the background color of the button to the sandy or earthy yellow
                    };
                    btn.Click += Btn_Click;
                    board[i, j] = btn;
                    panel1.Controls.Add(btn);
                }
            }
            panel1.Width = BoardSize * CellSize;
            panel1.Height = BoardSize * CellSize;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null || btn.Text != "")
                return;

            Point position = (Point)btn.Tag;
            movesHistory.Push(position); // �N�s�Ѥl����m�K�[����v�O����

            btn.Text = isBlackTurn ? "��" : "��";
            btn.ForeColor = isBlackTurn ? blackPieceColor : whitePieceColor;
            isBlackTurn = !isBlackTurn;

            // �ˬd�O�_�����a���
            CheckWinner();
            UpdateCurrentPlayerLabel();
           
        }

        // �b�A���a���s��e���a�����ҡA�Ҧp�b�C������s���a��
        private void UpdateCurrentPlayerLabel()
        {
            l1blCurrentPlayer.Font = new Font(l1blCurrentPlayer.Font.FontFamily, 16, FontStyle.Regular);
            string currentPlayer = isBlackTurn ? "���a1" : "���a2";
            l1blCurrentPlayer.Text = $"��e���a�G{currentPlayer}";
        }
        

        // 3. �C����
        // �K�[�@���C���ܾ��δ��ѹw�w�q���C��ﶵ���s�C
        // �ܨҡG�´Ѥl���C����
        private void btnBlackColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog(); // �Ыؤ@���C���ܮ�
            if (colorDialog.ShowDialog() == DialogResult.OK) // �p�G���a��ܤF�@���C��ë��U�F�T�w���s
            {
                blackPieceColor = colorDialog.Color; // �N���a��ܪ��C��]�m���¦�Ѥl���C��
            }
        }
        private void btnWhiteColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog(); // �Ыؤ@���C���ܮ�
            if (colorDialog.ShowDialog() == DialogResult.OK) // �p�G���a��ܤF�@���C��ë��U�F�T�w���s
            {
                whitePieceColor = colorDialog.Color; // �N���a��ܪ��C��]�m���զ�Ѥl���C��
            }
        }

        // 4. ���ѥ\��
        // �ϥΰ�̸��ܹC�����A�A�H���\�M�P�ʧ@�C
        // �ܨҡG�M�P���s�I���ƥ�
        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (movesHistory.Count == 0)
                return;

            Point lastMove = movesHistory.Pop(); // �q���v�O�������X�W�@�Ӧ�m
            Button btn = board[lastMove.X, lastMove.Y];
            btn.Text = "";
            btn.ForeColor = Color.Black; // �Ϊ̱z�i�H�N��]�m���Ū���l�C��
            isBlackTurn = !isBlackTurn; // �����^�W�@�Ӫ��a���^�X
        }


        private void CheckWinner()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (board[i, j].Text != "")
                    {
                        if (CheckDirection(i, j, 1, 0) || // �ˬd����
                            CheckDirection(i, j, 0, 1) || // �ˬd����
                            CheckDirection(i, j, 1, 1) || // �ˬd�﨤�u
                            CheckDirection(i, j, 1, -1))  // �ˬd�Ϲ﨤�u
                        {
                            MessageBox.Show($"{board[i, j].Text} Wins!");
                            ResetBoard();
                            return;
                        }
                    }
                }
            }
        }

        private bool CheckDirection(int x, int y, int dx, int dy)
        {
            string current = board[x, y].Text;
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                int nx = x + i * dx;
                int ny = y + i * dy;
                if (nx < 0 || ny < 0 || nx >= BoardSize || ny >= BoardSize)
                    return false;
                if (board[nx, ny].Text == current)
                    count++;
                else
                    break;
            }
            return count == 5;
        }

        private void ResetBoard()
        {
            foreach (var btn in board)
            {
                btn.Text = "";
            }
            isBlackTurn = true;
        }
    }
}


