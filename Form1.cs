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
        private Color blackPieceColor = Color.Black; // 黑棋子的默認顏色
        private Color whitePieceColor = Color.White; // 白棋子的默認顏色
        private Stack<Point> movesHistory = new Stack<Point>(); // 保存每個棋子的位置
    




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
                        Tag = new Point(i, j), // 用於存儲位置
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
            movesHistory.Push(position); // 將新棋子的位置添加到歷史記錄中

            btn.Text = isBlackTurn ? "●" : "○";
            btn.ForeColor = isBlackTurn ? blackPieceColor : whitePieceColor;
            isBlackTurn = !isBlackTurn;

            // 檢查是否有玩家獲勝
            CheckWinner();
            UpdateCurrentPlayerLabel();
           
        }

        // 在適當的地方更新當前玩家的標籤，例如在每次輪到新玩家時
        private void UpdateCurrentPlayerLabel()
        {
            l1blCurrentPlayer.Font = new Font(l1blCurrentPlayer.Font.FontFamily, 16, FontStyle.Regular);
            string currentPlayer = isBlackTurn ? "玩家1" : "玩家2";
            l1blCurrentPlayer.Text = $"當前玩家：{currentPlayer}";
        }
        

        // 3. 顏色選擇
        // 添加一個顏色選擇器或提供預定義的顏色選項按鈕。
        // 示例：黑棋子的顏色選擇
        private void btnBlackColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog(); // 創建一個顏色對話框
            if (colorDialog.ShowDialog() == DialogResult.OK) // 如果玩家選擇了一個顏色並按下了確定按鈕
            {
                blackPieceColor = colorDialog.Color; // 將玩家選擇的顏色設置為黑色棋子的顏色
            }
        }
        private void btnWhiteColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog(); // 創建一個顏色對話框
            if (colorDialog.ShowDialog() == DialogResult.OK) // 如果玩家選擇了一個顏色並按下了確定按鈕
            {
                whitePieceColor = colorDialog.Color; // 將玩家選擇的顏色設置為白色棋子的顏色
            }
        }

        // 4. 悔棋功能
        // 使用堆棧跟蹤遊戲狀態，以允許撤銷動作。
        // 示例：撤銷按鈕點擊事件
        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (movesHistory.Count == 0)
                return;

            Point lastMove = movesHistory.Pop(); // 從歷史記錄中取出上一個位置
            Button btn = board[lastMove.X, lastMove.Y];
            btn.Text = "";
            btn.ForeColor = Color.Black; // 或者您可以將其設置為空的初始顏色
            isBlackTurn = !isBlackTurn; // 切換回上一個玩家的回合
        }


        private void CheckWinner()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (board[i, j].Text != "")
                    {
                        if (CheckDirection(i, j, 1, 0) || // 檢查水平
                            CheckDirection(i, j, 0, 1) || // 檢查垂直
                            CheckDirection(i, j, 1, 1) || // 檢查對角線
                            CheckDirection(i, j, 1, -1))  // 檢查反對角線
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


