namespace GomokuGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            InitializeUndoButton = new Button();
            btnBlackColor = new Button();
            btnWhiteColor = new Button();
            lblCurrentPlayer = new Label();
            l1blCurrentPlayer = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(514, 426);
            panel1.TabIndex = 0;
            // 
            // InitializeUndoButton
            // 
            InitializeUndoButton.Location = new Point(595, 161);
            InitializeUndoButton.Name = "InitializeUndoButton";
            InitializeUndoButton.Size = new Size(94, 42);
            InitializeUndoButton.TabIndex = 1;
            InitializeUndoButton.Text = "撤回";
            InitializeUndoButton.UseVisualStyleBackColor = true;
            InitializeUndoButton.Click += btnUndo_Click;
            // 
            // btnBlackColor
            // 
            btnBlackColor.Location = new Point(532, 238);
            btnBlackColor.Name = "btnBlackColor";
            btnBlackColor.Size = new Size(94, 42);
            btnBlackColor.TabIndex = 2;
            btnBlackColor.Text = "玩家1顏色";
            btnBlackColor.UseVisualStyleBackColor = true;
            btnBlackColor.Click += btnBlackColor_Click;
            // 
            // btnWhiteColor
            // 
            btnWhiteColor.Location = new Point(654, 238);
            btnWhiteColor.Name = "btnWhiteColor";
            btnWhiteColor.Size = new Size(94, 42);
            btnWhiteColor.TabIndex = 3;
            btnWhiteColor.Text = "玩家2顏色";
            btnWhiteColor.UseVisualStyleBackColor = true;
            btnWhiteColor.Click += btnWhiteColor_Click;
            // 
            // lblCurrentPlayer
            // 
            lblCurrentPlayer.AutoSize = true;
            lblCurrentPlayer.Location = new Point(563, 298);
            lblCurrentPlayer.Name = "lblCurrentPlayer";
            lblCurrentPlayer.Size = new Size(0, 19);
            lblCurrentPlayer.TabIndex = 4;
            // 
            // l1blCurrentPlayer
            // 
            l1blCurrentPlayer.AutoSize = true;
            l1blCurrentPlayer.Location = new Point(532, 34);
            l1blCurrentPlayer.Name = "l1blCurrentPlayer";
            l1blCurrentPlayer.Size = new Size(39, 19);
            l1blCurrentPlayer.TabIndex = 5;
            l1blCurrentPlayer.Text = "玩家";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(l1blCurrentPlayer);
            Controls.Add(lblCurrentPlayer);
            Controls.Add(btnWhiteColor);
            Controls.Add(btnBlackColor);
            Controls.Add(InitializeUndoButton);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button InitializeUndoButton;
        private Button btnBlackColor;
        private Button btnWhiteColor;
        private Label lblCurrentPlayer;
        private Label l1blCurrentPlayer;
    }
}
