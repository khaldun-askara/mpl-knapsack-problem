namespace Knapsack_problem_interface
{
    partial class frm_knapsack_problem_interface
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
            this.btn_input_add = new System.Windows.Forms.Button();
            this.lbl_select = new System.Windows.Forms.Label();
            this.cmB_select = new System.Windows.Forms.ComboBox();
            this.dgv_items = new System.Windows.Forms.DataGridView();
            this.lbl_list = new System.Windows.Forms.Label();
            this.btn_solver_add = new System.Windows.Forms.Button();
            this.lbl_capasity = new System.Windows.Forms.Label();
            this.txtB_capacity = new System.Windows.Forms.TextBox();
            this.btn_solve = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_items)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_input_add
            // 
            this.btn_input_add.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_input_add.Location = new System.Drawing.Point(241, 84);
            this.btn_input_add.Name = "btn_input_add";
            this.btn_input_add.Size = new System.Drawing.Size(327, 47);
            this.btn_input_add.TabIndex = 0;
            this.btn_input_add.Text = "Загрузить готовый список";
            this.btn_input_add.UseVisualStyleBackColor = true;
            this.btn_input_add.Click += new System.EventHandler(this.btn_input_add_Click);
            // 
            // lbl_select
            // 
            this.lbl_select.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_select.AutoSize = true;
            this.lbl_select.Location = new System.Drawing.Point(238, 200);
            this.lbl_select.Name = "lbl_select";
            this.lbl_select.Size = new System.Drawing.Size(307, 17);
            this.lbl_select.TabIndex = 2;
            this.lbl_select.Text = "Выбрать алгоритм решения из добавленных:";
            // 
            // cmB_select
            // 
            this.cmB_select.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmB_select.FormattingEnabled = true;
            this.cmB_select.Location = new System.Drawing.Point(241, 220);
            this.cmB_select.Name = "cmB_select";
            this.cmB_select.Size = new System.Drawing.Size(327, 24);
            this.cmB_select.TabIndex = 3;
            this.cmB_select.SelectedIndexChanged += new System.EventHandler(this.cmB_select_SelectedIndexChanged);
            // 
            // dgv_items
            // 
            this.dgv_items.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgv_items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_items.Location = new System.Drawing.Point(127, 424);
            this.dgv_items.Name = "dgv_items";
            this.dgv_items.RowHeadersWidth = 51;
            this.dgv_items.RowTemplate.Height = 24;
            this.dgv_items.Size = new System.Drawing.Size(555, 150);
            this.dgv_items.TabIndex = 4;
            this.dgv_items.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_items_RowValidating);
            // 
            // lbl_list
            // 
            this.lbl_list.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_list.AutoSize = true;
            this.lbl_list.Location = new System.Drawing.Point(124, 391);
            this.lbl_list.Name = "lbl_list";
            this.lbl_list.Size = new System.Drawing.Size(134, 17);
            this.lbl_list.TabIndex = 5;
            this.lbl_list.Text = "Список предметов:";
            // 
            // btn_solver_add
            // 
            this.btn_solver_add.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_solver_add.Location = new System.Drawing.Point(241, 137);
            this.btn_solver_add.Name = "btn_solver_add";
            this.btn_solver_add.Size = new System.Drawing.Size(327, 47);
            this.btn_solver_add.TabIndex = 7;
            this.btn_solver_add.Text = "Добавить алгоритм";
            this.btn_solver_add.UseVisualStyleBackColor = true;
            this.btn_solver_add.Click += new System.EventHandler(this.btn_solver_add_Click);
            // 
            // lbl_capasity
            // 
            this.lbl_capasity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_capasity.AutoSize = true;
            this.lbl_capasity.Location = new System.Drawing.Point(238, 268);
            this.lbl_capasity.Name = "lbl_capasity";
            this.lbl_capasity.Size = new System.Drawing.Size(157, 17);
            this.lbl_capasity.TabIndex = 8;
            this.lbl_capasity.Text = "Вместимость рюкзака:";
            // 
            // txtB_capacity
            // 
            this.txtB_capacity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtB_capacity.Location = new System.Drawing.Point(427, 265);
            this.txtB_capacity.Name = "txtB_capacity";
            this.txtB_capacity.Size = new System.Drawing.Size(141, 22);
            this.txtB_capacity.TabIndex = 9;
            this.txtB_capacity.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_solve
            // 
            this.btn_solve.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_solve.Location = new System.Drawing.Point(241, 304);
            this.btn_solve.Name = "btn_solve";
            this.btn_solve.Size = new System.Drawing.Size(327, 47);
            this.btn_solve.TabIndex = 10;
            this.btn_solve.Text = "Найти ответ";
            this.btn_solve.UseVisualStyleBackColor = true;
            this.btn_solve.Click += new System.EventHandler(this.btn_solve_Click);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_save.Location = new System.Drawing.Point(532, 388);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(150, 23);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "Сохранить список";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // frm_knapsack_problem_interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 653);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_solve);
            this.Controls.Add(this.txtB_capacity);
            this.Controls.Add(this.lbl_capasity);
            this.Controls.Add(this.btn_solver_add);
            this.Controls.Add(this.lbl_list);
            this.Controls.Add(this.dgv_items);
            this.Controls.Add(this.cmB_select);
            this.Controls.Add(this.lbl_select);
            this.Controls.Add(this.btn_input_add);
            this.Name = "frm_knapsack_problem_interface";
            this.Text = "Задача о ранце";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_items)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_input_add;
        private System.Windows.Forms.Label lbl_select;
        private System.Windows.Forms.ComboBox cmB_select;
        private System.Windows.Forms.DataGridView dgv_items;
        private System.Windows.Forms.Label lbl_list;
        private System.Windows.Forms.Button btn_solver_add;
        private System.Windows.Forms.Label lbl_capasity;
        private System.Windows.Forms.TextBox txtB_capacity;
        private System.Windows.Forms.Button btn_solve;
        private System.Windows.Forms.Button btn_save;
    }
}

