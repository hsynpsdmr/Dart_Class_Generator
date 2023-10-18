
namespace Dart_Class_Generator
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TB_Class_Name = new System.Windows.Forms.TextBox();
            this.L_Class_Name = new System.Windows.Forms.Label();
            this.RTB_Output = new System.Windows.Forms.RichTextBox();
            this.RTB_Parameters = new System.Windows.Forms.RichTextBox();
            this.CB_Source_Type = new System.Windows.Forms.ComboBox();
            this.L_Source_Type = new System.Windows.Forms.Label();
            this.B_Tool_Tip = new System.Windows.Forms.ToolTip(this.components);
            this.B_Design = new System.Windows.Forms.Button();
            this.B_Copy_All = new System.Windows.Forms.Button();
            this.B_Create = new System.Windows.Forms.Button();
            this.LL_Author = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // TB_Class_Name
            // 
            this.TB_Class_Name.Location = new System.Drawing.Point(86, 18);
            this.TB_Class_Name.Name = "TB_Class_Name";
            this.TB_Class_Name.Size = new System.Drawing.Size(176, 22);
            this.TB_Class_Name.TabIndex = 1;
            // 
            // L_Class_Name
            // 
            this.L_Class_Name.AutoSize = true;
            this.L_Class_Name.Location = new System.Drawing.Point(17, 21);
            this.L_Class_Name.Name = "L_Class_Name";
            this.L_Class_Name.Size = new System.Drawing.Size(82, 16);
            this.L_Class_Name.TabIndex = 2;
            this.L_Class_Name.Text = "Class Name";
            // 
            // RTB_Output
            // 
            this.RTB_Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB_Output.Location = new System.Drawing.Point(477, 55);
            this.RTB_Output.Name = "RTB_Output";
            this.RTB_Output.Size = new System.Drawing.Size(1034, 652);
            this.RTB_Output.TabIndex = 3;
            this.RTB_Output.TabStop = false;
            this.RTB_Output.Text = "";
            // 
            // RTB_Parameters
            // 
            this.RTB_Parameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RTB_Parameters.Location = new System.Drawing.Point(12, 55);
            this.RTB_Parameters.Name = "RTB_Parameters";
            this.RTB_Parameters.Size = new System.Drawing.Size(443, 652);
            this.RTB_Parameters.TabIndex = 2;
            this.RTB_Parameters.Text = "";
            this.RTB_Parameters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTB_Parameters_KeyDown);
            // 
            // CB_Source_Type
            // 
            this.CB_Source_Type.FormattingEnabled = true;
            this.CB_Source_Type.Location = new System.Drawing.Point(355, 18);
            this.CB_Source_Type.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Source_Type.Name = "CB_Source_Type";
            this.CB_Source_Type.Size = new System.Drawing.Size(100, 21);
            this.CB_Source_Type.TabIndex = 6;
            this.CB_Source_Type.TabStop = false;
            // 
            // L_Source_Type
            // 
            this.L_Source_Type.AutoSize = true;
            this.L_Source_Type.Location = new System.Drawing.Point(286, 20);
            this.L_Source_Type.Name = "L_Source_Type";
            this.L_Source_Type.Size = new System.Drawing.Size(86, 16);
            this.L_Source_Type.TabIndex = 7;
            this.L_Source_Type.Text = "Source Type";
            // 
            // B_Design
            // 
            this.B_Design.BackColor = System.Drawing.Color.Transparent;
            this.B_Design.BackgroundImage = global::Dart_Class_Generator.Properties.Resources.converter;
            this.B_Design.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Design.FlatAppearance.BorderSize = 0;
            this.B_Design.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Design.Location = new System.Drawing.Point(415, 55);
            this.B_Design.Margin = new System.Windows.Forms.Padding(0);
            this.B_Design.Name = "B_Design";
            this.B_Design.Size = new System.Drawing.Size(40, 40);
            this.B_Design.TabIndex = 8;
            this.B_Design.TabStop = false;
            this.B_Design.UseVisualStyleBackColor = false;
            this.B_Design.MouseHover += new System.EventHandler(this.B_Design_MouseHover);
            // 
            // B_Copy_All
            // 
            this.B_Copy_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Copy_All.BackColor = System.Drawing.Color.Transparent;
            this.B_Copy_All.BackgroundImage = global::Dart_Class_Generator.Properties.Resources.copy;
            this.B_Copy_All.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Copy_All.FlatAppearance.BorderSize = 0;
            this.B_Copy_All.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Copy_All.Location = new System.Drawing.Point(1470, 12);
            this.B_Copy_All.Margin = new System.Windows.Forms.Padding(0);
            this.B_Copy_All.Name = "B_Copy_All";
            this.B_Copy_All.Size = new System.Drawing.Size(40, 40);
            this.B_Copy_All.TabIndex = 5;
            this.B_Copy_All.TabStop = false;
            this.B_Copy_All.UseVisualStyleBackColor = false;
            this.B_Copy_All.Click += new System.EventHandler(this.B_Copy_All_Click);
            this.B_Copy_All.MouseHover += new System.EventHandler(this.B_Copy_All_MouseHover);
            // 
            // B_Create
            // 
            this.B_Create.BackColor = System.Drawing.Color.Transparent;
            this.B_Create.BackgroundImage = global::Dart_Class_Generator.Properties.Resources.create;
            this.B_Create.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Create.FlatAppearance.BorderSize = 0;
            this.B_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Create.Location = new System.Drawing.Point(477, 7);
            this.B_Create.Margin = new System.Windows.Forms.Padding(0);
            this.B_Create.Name = "B_Create";
            this.B_Create.Size = new System.Drawing.Size(40, 40);
            this.B_Create.TabIndex = 0;
            this.B_Create.TabStop = false;
            this.B_Create.UseVisualStyleBackColor = false;
            this.B_Create.Click += new System.EventHandler(this.B_Create_Click);
            this.B_Create.MouseHover += new System.EventHandler(this.B_Create_MouseHover);
            // 
            // LL_Author
            // 
            this.LL_Author.AutoSize = true;
            this.LL_Author.Location = new System.Drawing.Point(1404, 710);
            this.LL_Author.Name = "LL_Author";
            this.LL_Author.Size = new System.Drawing.Size(141, 16);
            this.LL_Author.TabIndex = 10;
            this.LL_Author.TabStop = true;
            this.LL_Author.Text = "created by hsynpsdmr";
            this.LL_Author.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Author_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1523, 732);
            this.Controls.Add(this.LL_Author);
            this.Controls.Add(this.B_Design);
            this.Controls.Add(this.L_Source_Type);
            this.Controls.Add(this.CB_Source_Type);
            this.Controls.Add(this.B_Copy_All);
            this.Controls.Add(this.RTB_Parameters);
            this.Controls.Add(this.RTB_Output);
            this.Controls.Add(this.L_Class_Name);
            this.Controls.Add(this.TB_Class_Name);
            this.Controls.Add(this.B_Create);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dart Class Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Create;
        private System.Windows.Forms.TextBox TB_Class_Name;
        private System.Windows.Forms.Label L_Class_Name;
        private System.Windows.Forms.RichTextBox RTB_Output;
        private System.Windows.Forms.RichTextBox RTB_Parameters;
        private System.Windows.Forms.Button B_Copy_All;
        private System.Windows.Forms.ComboBox CB_Source_Type;
        private System.Windows.Forms.Label L_Source_Type;
        private System.Windows.Forms.Button B_Design;
        private System.Windows.Forms.ToolTip B_Tool_Tip;
        private System.Windows.Forms.LinkLabel LL_Author;
    }
}

