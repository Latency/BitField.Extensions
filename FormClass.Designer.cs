using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;


namespace BitFields {
  public sealed partial class FormClass {
    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly Container components = null;

    /// <summary>
    ///   Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing) {
      if (disposing) {
        if (components != null)
          components.Dispose();
      }
      base.Dispose(disposing);
    }


    #region Windows Form Designer generated code

    /// <summary>
    ///   Required method for Designer support - do not modify
    ///   the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.textBoxHex = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.textBoxDec = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.textBoxBin = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.buttonClear = new System.Windows.Forms.Button();
      this.buttonAddFlag = new System.Windows.Forms.Button();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.buttonRemoveFlag = new System.Windows.Forms.Button();
      this.buttonFill = new System.Windows.Forms.Button();
      this.listBoxHistory = new System.Windows.Forms.ListBox();
      this.textBoxBinHistory = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.textBoxHexHistory = new System.Windows.Forms.TextBox();
      this.textBoxDecHistory = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.buttonRevert = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.comboBoxHistory = new System.Windows.Forms.ComboBox();
      this.label10 = new System.Windows.Forms.Label();
      this.checkBox10 = new System.Windows.Forms.CheckBox();
      this.checkBox9 = new System.Windows.Forms.CheckBox();
      this.checkBox8 = new System.Windows.Forms.CheckBox();
      this.checkBox7 = new System.Windows.Forms.CheckBox();
      this.checkBox6 = new System.Windows.Forms.CheckBox();
      this.checkBox5 = new System.Windows.Forms.CheckBox();
      this.checkBox4 = new System.Windows.Forms.CheckBox();
      this.checkBox3 = new System.Windows.Forms.CheckBox();
      this.checkBox2 = new System.Windows.Forms.CheckBox();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      this.SuspendLayout();
      // 
      // textBoxHex
      // 
      this.textBoxHex.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBoxHex.Location = new System.Drawing.Point(296, 72);
      this.textBoxHex.Name = "textBoxHex";
      this.textBoxHex.ReadOnly = true;
      this.textBoxHex.Size = new System.Drawing.Size(128, 20);
      this.textBoxHex.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(224, 72);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(72, 23);
      this.label1.TabIndex = 12;
      this.label1.Text = "Hexidecimal";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(248, 40);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(48, 23);
      this.label2.TabIndex = 13;
      this.label2.Text = "Decimal";
      // 
      // textBoxDec
      // 
      this.textBoxDec.Location = new System.Drawing.Point(296, 40);
      this.textBoxDec.Name = "textBoxDec";
      this.textBoxDec.ReadOnly = true;
      this.textBoxDec.Size = new System.Drawing.Size(128, 20);
      this.textBoxDec.TabIndex = 14;
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(256, 104);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(40, 23);
      this.label3.TabIndex = 15;
      this.label3.Text = "Binary";
      // 
      // textBoxBin
      // 
      this.textBoxBin.Location = new System.Drawing.Point(296, 104);
      this.textBoxBin.Name = "textBoxBin";
      this.textBoxBin.ReadOnly = true;
      this.textBoxBin.Size = new System.Drawing.Size(392, 20);
      this.textBoxBin.TabIndex = 16;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(320, 16);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 13);
      this.label4.TabIndex = 17;
      this.label4.Text = "BitField";
      // 
      // buttonClear
      // 
      this.buttonClear.Location = new System.Drawing.Point(296, 136);
      this.buttonClear.Name = "buttonClear";
      this.buttonClear.Size = new System.Drawing.Size(88, 23);
      this.buttonClear.TabIndex = 18;
      this.buttonClear.Text = "Clear BitField";
      this.buttonClear.Click += new System.EventHandler(this.button_Click);
      // 
      // buttonAddFlag
      // 
      this.buttonAddFlag.Location = new System.Drawing.Point(296, 168);
      this.buttonAddFlag.Name = "buttonAddFlag";
      this.buttonAddFlag.Size = new System.Drawing.Size(88, 23);
      this.buttonAddFlag.TabIndex = 20;
      this.buttonAddFlag.Text = "Add Flag";
      this.buttonAddFlag.Click += new System.EventHandler(this.button_Click);
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(248, 168);
      this.numericUpDown1.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
      this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(40, 20);
      this.numericUpDown1.TabIndex = 4;
      this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // buttonRemoveFlag
      // 
      this.buttonRemoveFlag.Location = new System.Drawing.Point(392, 168);
      this.buttonRemoveFlag.Name = "buttonRemoveFlag";
      this.buttonRemoveFlag.Size = new System.Drawing.Size(88, 23);
      this.buttonRemoveFlag.TabIndex = 21;
      this.buttonRemoveFlag.Text = "Remove Flag";
      this.buttonRemoveFlag.Click += new System.EventHandler(this.button_Click);
      // 
      // buttonFill
      // 
      this.buttonFill.Location = new System.Drawing.Point(392, 136);
      this.buttonFill.Name = "buttonFill";
      this.buttonFill.Size = new System.Drawing.Size(88, 23);
      this.buttonFill.TabIndex = 22;
      this.buttonFill.Text = "Fill BitField";
      this.buttonFill.Click += new System.EventHandler(this.button_Click);
      // 
      // listBoxHistory
      // 
      this.listBoxHistory.BackColor = System.Drawing.SystemColors.Window;
      this.listBoxHistory.Location = new System.Drawing.Point(16, 280);
      this.listBoxHistory.Name = "listBoxHistory";
      this.listBoxHistory.Size = new System.Drawing.Size(192, 147);
      this.listBoxHistory.TabIndex = 23;
      this.listBoxHistory.SelectedIndexChanged += new System.EventHandler(this.History_Click);
      // 
      // textBoxBinHistory
      // 
      this.textBoxBinHistory.Location = new System.Drawing.Point(296, 344);
      this.textBoxBinHistory.Name = "textBoxBinHistory";
      this.textBoxBinHistory.ReadOnly = true;
      this.textBoxBinHistory.Size = new System.Drawing.Size(392, 20);
      this.textBoxBinHistory.TabIndex = 25;
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(256, 344);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(40, 23);
      this.label5.TabIndex = 24;
      this.label5.Text = "Binary";
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(224, 312);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(72, 23);
      this.label6.TabIndex = 27;
      this.label6.Text = "Hexidecimal";
      // 
      // textBoxHexHistory
      // 
      this.textBoxHexHistory.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBoxHexHistory.Location = new System.Drawing.Point(296, 312);
      this.textBoxHexHistory.Name = "textBoxHexHistory";
      this.textBoxHexHistory.ReadOnly = true;
      this.textBoxHexHistory.Size = new System.Drawing.Size(128, 20);
      this.textBoxHexHistory.TabIndex = 26;
      // 
      // textBoxDecHistory
      // 
      this.textBoxDecHistory.Location = new System.Drawing.Point(296, 280);
      this.textBoxDecHistory.Name = "textBoxDecHistory";
      this.textBoxDecHistory.ReadOnly = true;
      this.textBoxDecHistory.Size = new System.Drawing.Size(128, 20);
      this.textBoxDecHistory.TabIndex = 29;
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(248, 280);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(48, 23);
      this.label7.TabIndex = 28;
      this.label7.Text = "Decimal";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(16, 256);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(76, 13);
      this.label8.TabIndex = 31;
      this.label8.Text = "BitField History";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(16, 240);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(672, 8);
      this.button1.TabIndex = 32;
      // 
      // buttonRevert
      // 
      this.buttonRevert.Location = new System.Drawing.Point(296, 376);
      this.buttonRevert.Name = "buttonRevert";
      this.buttonRevert.Size = new System.Drawing.Size(96, 23);
      this.buttonRevert.TabIndex = 33;
      this.buttonRevert.Text = "^ Revert Back ^";
      this.buttonRevert.Click += new System.EventHandler(this.History_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(16, 0);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(672, 8);
      this.button2.TabIndex = 34;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(320, 256);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(41, 13);
      this.label9.TabIndex = 35;
      this.label9.Text = "BitField";
      // 
      // comboBoxHistory
      // 
      this.comboBoxHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
      this.comboBoxHistory.Enabled = false;
      this.comboBoxHistory.FormattingEnabled = true;
      this.comboBoxHistory.Location = new System.Drawing.Point(477, 279);
      this.comboBoxHistory.Name = "comboBoxHistory";
      this.comboBoxHistory.Size = new System.Drawing.Size(211, 21);
      this.comboBoxHistory.TabIndex = 36;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(577, 256);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(33, 13);
      this.label10.TabIndex = 37;
      this.label10.Text = "Mask";
      // 
      // checkBox10
      // 
      this.checkBox10.Location = new System.Drawing.Point(120, 152);
      this.checkBox10.Name = "checkBox10";
      this.checkBox10.Size = new System.Drawing.Size(104, 24);
      this.checkBox10.TabIndex = 11;
      this.checkBox10.Text = "Flag 10";
      this.checkBox10.CheckedChanged += new System.EventHandler(this.CheckedChanged);
      // 
      // checkBox9
      // 
      this.checkBox9.Location = new System.Drawing.Point(120, 120);
      this.checkBox9.Name = "checkBox9";
      this.checkBox9.Size = new System.Drawing.Size(104, 24);
      this.checkBox9.TabIndex = 10;
      this.checkBox9.Text = "Flag 9";
      this.checkBox9.CheckedChanged += new System.EventHandler(this.CheckedChanged);
      // 
      // checkBox8
      // 
      this.checkBox8.Location = new System.Drawing.Point(120, 88);
      this.checkBox8.Name = "checkBox8";
      this.checkBox8.Size = new System.Drawing.Size(104, 24);
      this.checkBox8.TabIndex = 9;
      this.checkBox8.Text = "Flag 8";
      this.checkBox8.CheckedChanged += new System.EventHandler(this.CheckedChanged);
      // 
      // checkBox7
      // 
      this.checkBox7.Location = new System.Drawing.Point(120, 56);
      this.checkBox7.Name = "checkBox7";
      this.checkBox7.Size = new System.Drawing.Size(104, 24);
      this.checkBox7.TabIndex = 8;
      this.checkBox7.Text = "Flag 7";
      this.checkBox7.CheckedChanged += new System.EventHandler(this.CheckedChanged);
      // 
      // checkBox6
      // 
      this.checkBox6.Location = new System.Drawing.Point(120, 24);
      this.checkBox6.Name = "checkBox6";
      this.checkBox6.Size = new System.Drawing.Size(104, 24);
      this.checkBox6.TabIndex = 7;
      this.checkBox6.Text = "Flag 6";
      this.checkBox6.CheckedChanged += new System.EventHandler(this.CheckedChanged);
      // 
      // checkBox5
      // 
      this.checkBox5.Location = new System.Drawing.Point(16, 152);
      this.checkBox5.Name = "checkBox5";
      this.checkBox5.Size = new System.Drawing.Size(104, 24);
      this.checkBox5.TabIndex = 6;
      this.checkBox5.Text = "Flag 5";
      this.checkBox5.CheckedChanged += new System.EventHandler(this.CheckedChanged);
      // 
      // checkBox4
      // 
      this.checkBox4.Location = new System.Drawing.Point(16, 120);
      this.checkBox4.Name = "checkBox4";
      this.checkBox4.Size = new System.Drawing.Size(104, 24);
      this.checkBox4.TabIndex = 5;
      this.checkBox4.Text = "Flag 4";
      this.checkBox4.CheckedChanged += new System.EventHandler(this.CheckedChanged);
      // 
      // checkBox3
      // 
      this.checkBox3.Location = new System.Drawing.Point(16, 88);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new System.Drawing.Size(104, 24);
      this.checkBox3.TabIndex = 4;
      this.checkBox3.Text = "Flag 3";
      this.checkBox3.CheckedChanged += new System.EventHandler(this.CheckedChanged);
      // 
      // checkBox2
      // 
      this.checkBox2.Location = new System.Drawing.Point(16, 56);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size(104, 24);
      this.checkBox2.TabIndex = 3;
      this.checkBox2.Text = "Flag 2";
      this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckedChanged);
      // 
      // checkBox1
      // 
      this.checkBox1.Location = new System.Drawing.Point(16, 24);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(104, 24);
      this.checkBox1.TabIndex = 2;
      this.checkBox1.Text = "Flag 1";
      this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckedChanged);
      // 
      // FormClass
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(712, 439);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.comboBoxHistory);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.buttonRevert);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.textBoxDecHistory);
      this.Controls.Add(this.textBoxHexHistory);
      this.Controls.Add(this.textBoxBinHistory);
      this.Controls.Add(this.textBoxBin);
      this.Controls.Add(this.textBoxDec);
      this.Controls.Add(this.textBoxHex);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.listBoxHistory);
      this.Controls.Add(this.buttonFill);
      this.Controls.Add(this.buttonRemoveFlag);
      this.Controls.Add(this.numericUpDown1);
      this.Controls.Add(this.buttonAddFlag);
      this.Controls.Add(this.buttonClear);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.checkBox10);
      this.Controls.Add(this.checkBox9);
      this.Controls.Add(this.checkBox8);
      this.Controls.Add(this.checkBox7);
      this.Controls.Add(this.checkBox6);
      this.Controls.Add(this.checkBox5);
      this.Controls.Add(this.checkBox4);
      this.Controls.Add(this.checkBox3);
      this.Controls.Add(this.checkBox2);
      this.Controls.Add(this.checkBox1);
      this.Name = "FormClass";
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Button button1;
    private Button button2;
    private Button buttonAddFlag;
    private Button buttonClear;
    private Button buttonFill;
    private Button buttonRemoveFlag;
    private Button buttonRevert;

    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private CheckBox checkBox3;
    private CheckBox checkBox4;
    private CheckBox checkBox5;
    private CheckBox checkBox6;
    private CheckBox checkBox7;
    private CheckBox checkBox8;
    private CheckBox checkBox9;
    private CheckBox checkBox10;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private ListBox listBoxHistory;
    private NumericUpDown numericUpDown1;
    private TextBox textBoxBin;
    private TextBox textBoxBinHistory;
    private TextBox textBoxDec;
    private TextBox textBoxDecHistory;
    private TextBox textBoxHex;
    private TextBox textBoxHexHistory;
    private ComboBox comboBoxHistory;
  }
}
