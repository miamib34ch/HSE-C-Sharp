namespace Lab15_WinForm_WorkWithFiles
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
            this.CreateArr = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.Vvod = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.AddRandom = new System.Windows.Forms.Button();
            this.SaveBinary = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.correct = new System.Windows.Forms.Button();
            this.show = new System.Windows.Forms.Button();
            this.LINQbutton = new System.Windows.Forms.Button();
            this.Deser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateArr
            // 
            this.CreateArr.Location = new System.Drawing.Point(11, 139);
            this.CreateArr.Name = "CreateArr";
            this.CreateArr.Size = new System.Drawing.Size(158, 37);
            this.CreateArr.TabIndex = 0;
            this.CreateArr.Text = "Добавить данные вручную";
            this.CreateArr.UseVisualStyleBackColor = true;
            this.CreateArr.Click += new System.EventHandler(this.CreateArr_Click);
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Enabled = false;
            this.Info.ForeColor = System.Drawing.Color.Black;
            this.Info.Location = new System.Drawing.Point(193, 55);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(25, 13);
            this.Info.TabIndex = 1;
            this.Info.Text = "Info";
            this.Info.Visible = false;
            // 
            // Vvod
            // 
            this.Vvod.Enabled = false;
            this.Vvod.Location = new System.Drawing.Point(195, 29);
            this.Vvod.Name = "Vvod";
            this.Vvod.Size = new System.Drawing.Size(593, 20);
            this.Vvod.TabIndex = 2;
            this.Vvod.Visible = false;
            this.Vvod.TextChanged += new System.EventHandler(this.Vvod_TextChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(11, 348);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(158, 36);
            this.Save.TabIndex = 3;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // AddRandom
            // 
            this.AddRandom.Location = new System.Drawing.Point(11, 97);
            this.AddRandom.Name = "AddRandom";
            this.AddRandom.Size = new System.Drawing.Size(158, 36);
            this.AddRandom.TabIndex = 4;
            this.AddRandom.Text = "Добавить данные случайно";
            this.AddRandom.UseVisualStyleBackColor = true;
            this.AddRandom.Click += new System.EventHandler(this.AddRandom_Click);
            // 
            // SaveBinary
            // 
            this.SaveBinary.Location = new System.Drawing.Point(11, 390);
            this.SaveBinary.Name = "SaveBinary";
            this.SaveBinary.Size = new System.Drawing.Size(158, 35);
            this.SaveBinary.TabIndex = 5;
            this.SaveBinary.Text = "Сохранить в двоичном";
            this.SaveBinary.UseVisualStyleBackColor = true;
            this.SaveBinary.Click += new System.EventHandler(this.SaveBinary_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "Открыть файл (.txt)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Open_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(11, 182);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(158, 36);
            this.delete.TabIndex = 7;
            this.delete.Text = "Удалить строку";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // correct
            // 
            this.correct.Location = new System.Drawing.Point(11, 224);
            this.correct.Name = "correct";
            this.correct.Size = new System.Drawing.Size(158, 36);
            this.correct.TabIndex = 8;
            this.correct.Text = "Корректировать строку";
            this.correct.UseVisualStyleBackColor = true;
            this.correct.Click += new System.EventHandler(this.correct_Click);
            // 
            // show
            // 
            this.show.Location = new System.Drawing.Point(11, 266);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(158, 35);
            this.show.TabIndex = 9;
            this.show.Text = "Показать строки";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // LINQbutton
            // 
            this.LINQbutton.Location = new System.Drawing.Point(11, 307);
            this.LINQbutton.Name = "LINQbutton";
            this.LINQbutton.Size = new System.Drawing.Size(158, 35);
            this.LINQbutton.TabIndex = 10;
            this.LINQbutton.Text = "LINQ-запросы";
            this.LINQbutton.UseVisualStyleBackColor = true;
            this.LINQbutton.Click += new System.EventHandler(this.LINQbutton_Click);
            // 
            // Deser
            // 
            this.Deser.Location = new System.Drawing.Point(11, 55);
            this.Deser.Name = "Deser";
            this.Deser.Size = new System.Drawing.Size(158, 36);
            this.Deser.TabIndex = 11;
            this.Deser.Text = "Открыть файл (.bin)";
            this.Deser.UseVisualStyleBackColor = true;
            this.Deser.Click += new System.EventHandler(this.Deser_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(814, 431);
            this.Controls.Add(this.Deser);
            this.Controls.Add(this.LINQbutton);
            this.Controls.Add(this.show);
            this.Controls.Add(this.correct);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SaveBinary);
            this.Controls.Add(this.AddRandom);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Vvod);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.CreateArr);
            this.Name = "Form1";
            this.Text = "Laba15";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateArr;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.TextBox Vvod;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button AddRandom;
        private System.Windows.Forms.Button SaveBinary;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button correct;
        private System.Windows.Forms.Button show;
        private System.Windows.Forms.Button LINQbutton;
        private System.Windows.Forms.Button Deser;
    }

}

