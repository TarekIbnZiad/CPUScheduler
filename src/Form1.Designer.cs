namespace CPU_Scheduling
{
    partial class CPU_Scheduler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBox_Algorithms = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_RoundRobin = new System.Windows.Forms.Button();
            this.btn_Priority_NP = new System.Windows.Forms.Button();
            this.btn_Priority_P = new System.Windows.Forms.Button();
            this.btn_SJF_NP = new System.Windows.Forms.Button();
            this.btn_SJF_P = new System.Windows.Forms.Button();
            this.btn_FCFS = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Load = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpBox_Algorithms.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBox_Algorithms
            // 
            this.grpBox_Algorithms.Controls.Add(this.label1);
            this.grpBox_Algorithms.Controls.Add(this.btn_RoundRobin);
            this.grpBox_Algorithms.Controls.Add(this.btn_Priority_NP);
            this.grpBox_Algorithms.Controls.Add(this.btn_Priority_P);
            this.grpBox_Algorithms.Controls.Add(this.btn_SJF_NP);
            this.grpBox_Algorithms.Controls.Add(this.btn_SJF_P);
            this.grpBox_Algorithms.Controls.Add(this.btn_FCFS);
            this.grpBox_Algorithms.Controls.Add(this.textBox1);
            this.grpBox_Algorithms.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBox_Algorithms.ForeColor = System.Drawing.SystemColors.InfoText;
            this.grpBox_Algorithms.Location = new System.Drawing.Point(120, 64);
            this.grpBox_Algorithms.Name = "grpBox_Algorithms";
            this.grpBox_Algorithms.Size = new System.Drawing.Size(199, 204);
            this.grpBox_Algorithms.TabIndex = 0;
            this.grpBox_Algorithms.TabStop = false;
            this.grpBox_Algorithms.Text = "Algorithms";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Q";
            // 
            // btn_RoundRobin
            // 
            this.btn_RoundRobin.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RoundRobin.Location = new System.Drawing.Point(18, 165);
            this.btn_RoundRobin.Name = "btn_RoundRobin";
            this.btn_RoundRobin.Size = new System.Drawing.Size(79, 23);
            this.btn_RoundRobin.TabIndex = 12;
            this.btn_RoundRobin.Text = "RoundRobin";
            this.btn_RoundRobin.UseVisualStyleBackColor = true;
            this.btn_RoundRobin.Click += new System.EventHandler(this.btn_RoundRobin_Click);
            // 
            // btn_Priority_NP
            // 
            this.btn_Priority_NP.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Priority_NP.Location = new System.Drawing.Point(18, 135);
            this.btn_Priority_NP.Name = "btn_Priority_NP";
            this.btn_Priority_NP.Size = new System.Drawing.Size(163, 23);
            this.btn_Priority_NP.TabIndex = 11;
            this.btn_Priority_NP.Text = "Priority_NP";
            this.btn_Priority_NP.UseVisualStyleBackColor = true;
            this.btn_Priority_NP.Click += new System.EventHandler(this.btn_Priority_NP_Click);
            // 
            // btn_Priority_P
            // 
            this.btn_Priority_P.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Priority_P.Location = new System.Drawing.Point(18, 106);
            this.btn_Priority_P.Name = "btn_Priority_P";
            this.btn_Priority_P.Size = new System.Drawing.Size(163, 23);
            this.btn_Priority_P.TabIndex = 10;
            this.btn_Priority_P.Text = "Priority_P";
            this.btn_Priority_P.UseVisualStyleBackColor = true;
            this.btn_Priority_P.Click += new System.EventHandler(this.btn_Priority_P_Click);
            // 
            // btn_SJF_NP
            // 
            this.btn_SJF_NP.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SJF_NP.Location = new System.Drawing.Point(18, 77);
            this.btn_SJF_NP.Name = "btn_SJF_NP";
            this.btn_SJF_NP.Size = new System.Drawing.Size(163, 23);
            this.btn_SJF_NP.TabIndex = 9;
            this.btn_SJF_NP.Text = "SJF_NP";
            this.btn_SJF_NP.UseVisualStyleBackColor = true;
            this.btn_SJF_NP.Click += new System.EventHandler(this.btn_SJF_NP_Click);
            // 
            // btn_SJF_P
            // 
            this.btn_SJF_P.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SJF_P.Location = new System.Drawing.Point(18, 48);
            this.btn_SJF_P.Name = "btn_SJF_P";
            this.btn_SJF_P.Size = new System.Drawing.Size(163, 23);
            this.btn_SJF_P.TabIndex = 8;
            this.btn_SJF_P.Text = "SJF_P";
            this.btn_SJF_P.UseVisualStyleBackColor = true;
            this.btn_SJF_P.Click += new System.EventHandler(this.btn_SJF_P_Click);
            // 
            // btn_FCFS
            // 
            this.btn_FCFS.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FCFS.Location = new System.Drawing.Point(18, 19);
            this.btn_FCFS.Name = "btn_FCFS";
            this.btn_FCFS.Size = new System.Drawing.Size(163, 23);
            this.btn_FCFS.TabIndex = 7;
            this.btn_FCFS.Text = "FCFS";
            this.btn_FCFS.UseVisualStyleBackColor = true;
            this.btn_FCFS.Click += new System.EventHandler(this.btn_FCFS_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(151, 167);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(30, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "4\r\n";
            // 
            // btn_Load
            // 
            this.btn_Load.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Load.Location = new System.Drawing.Point(12, 83);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(88, 43);
            this.btn_Load.TabIndex = 2;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(307, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "C:\\\\Users\\\\MTarek\\\\Desktop\\\\Input_Sheet.xls";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter a valid Data Sheet path";
            // 
            // CPU_Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 280);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.grpBox_Algorithms);
            this.Name = "CPU_Scheduler";
            this.Text = "CPU Scheduler";
            this.Load += new System.EventHandler(this.CPU_Scheduler_Load);
            this.grpBox_Algorithms.ResumeLayout(false);
            this.grpBox_Algorithms.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBox_Algorithms;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_SJF_NP;
        private System.Windows.Forms.Button btn_SJF_P;
        private System.Windows.Forms.Button btn_FCFS;
        private System.Windows.Forms.Button btn_Priority_P;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_RoundRobin;
        private System.Windows.Forms.Button btn_Priority_NP;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
    }
}

