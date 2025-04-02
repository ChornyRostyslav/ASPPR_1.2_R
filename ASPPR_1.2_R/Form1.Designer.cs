namespace ASPPR_1._2_R
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textZ = new System.Windows.Forms.TextBox();
            this.textOptimalSolution = new System.Windows.Forms.TextBox();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.numVar = new System.Windows.Forms.NumericUpDown();
            this.textConstraints = new System.Windows.Forms.TextBox();
            this.textObjective = new System.Windows.Forms.TextBox();
            this.textSupportSolution = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxSaveLog = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numVar)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(144, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "Обмеження:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(144, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Z:";
            // 
            // textZ
            // 
            this.textZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textZ.Location = new System.Drawing.Point(148, 394);
            this.textZ.Name = "textZ";
            this.textZ.Size = new System.Drawing.Size(239, 29);
            this.textZ.TabIndex = 15;
            // 
            // textOptimalSolution
            // 
            this.textOptimalSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOptimalSolution.Location = new System.Drawing.Point(148, 278);
            this.textOptimalSolution.Multiline = true;
            this.textOptimalSolution.Name = "textOptimalSolution";
            this.textOptimalSolution.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textOptimalSolution.Size = new System.Drawing.Size(239, 51);
            this.textOptimalSolution.TabIndex = 14;
            // 
            // buttonSolve
            // 
            this.buttonSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSolve.Location = new System.Drawing.Point(424, 126);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(120, 41);
            this.buttonSolve.TabIndex = 13;
            this.buttonSolve.Text = "Обчислити";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // numVar
            // 
            this.numVar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numVar.Location = new System.Drawing.Point(424, 55);
            this.numVar.Name = "numVar";
            this.numVar.Size = new System.Drawing.Size(120, 29);
            this.numVar.TabIndex = 12;
            // 
            // textConstraints
            // 
            this.textConstraints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textConstraints.Location = new System.Drawing.Point(148, 126);
            this.textConstraints.Multiline = true;
            this.textConstraints.Name = "textConstraints";
            this.textConstraints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textConstraints.Size = new System.Drawing.Size(239, 104);
            this.textConstraints.TabIndex = 11;
            // 
            // textObjective
            // 
            this.textObjective.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textObjective.Location = new System.Drawing.Point(148, 54);
            this.textObjective.Name = "textObjective";
            this.textObjective.Size = new System.Drawing.Size(239, 29);
            this.textObjective.TabIndex = 10;
            // 
            // textSupportSolution
            // 
            this.textSupportSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSupportSolution.Location = new System.Drawing.Point(424, 278);
            this.textSupportSolution.Multiline = true;
            this.textSupportSolution.Name = "textSupportSolution";
            this.textSupportSolution.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textSupportSolution.Size = new System.Drawing.Size(239, 51);
            this.textSupportSolution.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(144, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 24);
            this.label3.TabIndex = 21;
            this.label3.Text = "Оптимальний розв\'язок:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.Location = new System.Drawing.Point(420, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "Опорний розв\'язок:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label5.Location = new System.Drawing.Point(144, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 24);
            this.label5.TabIndex = 23;
            this.label5.Text = "Max (Z):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label6.Location = new System.Drawing.Point(420, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 24);
            this.label6.TabIndex = 24;
            this.label6.Text = "Кількість змінних:";
            // 
            // checkBoxSaveLog
            // 
            this.checkBoxSaveLog.AutoSize = true;
            this.checkBoxSaveLog.Location = new System.Drawing.Point(424, 187);
            this.checkBoxSaveLog.Name = "checkBoxSaveLog";
            this.checkBoxSaveLog.Size = new System.Drawing.Size(110, 17);
            this.checkBoxSaveLog.TabIndex = 25;
            this.checkBoxSaveLog.Text = "Логувати у файл";
            this.checkBoxSaveLog.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 450);
            this.Controls.Add(this.checkBoxSaveLog);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textSupportSolution);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textZ);
            this.Controls.Add(this.textOptimalSolution);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.numVar);
            this.Controls.Add(this.textConstraints);
            this.Controls.Add(this.textObjective);
            this.Name = "Form1";
            this.Text = "Chonryi R.S. 631";
            ((System.ComponentModel.ISupportInitialize)(this.numVar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textZ;
        private System.Windows.Forms.TextBox textOptimalSolution;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.NumericUpDown numVar;
        private System.Windows.Forms.TextBox textConstraints;
        private System.Windows.Forms.TextBox textObjective;
        private System.Windows.Forms.TextBox textSupportSolution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxSaveLog;
    }
}

