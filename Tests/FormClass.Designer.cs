using System.ComponentModel;
using System.Windows.Forms;

namespace Tests {
  public sealed partial class FormClass {

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
      this.components = new System.ComponentModel.Container();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.listBoxHistory = new System.Windows.Forms.ListBox();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.richTextBoxMask = new System.Windows.Forms.RichTextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.textBoxBin = new System.Windows.Forms.TextBox();
      this.textBoxDec = new System.Windows.Forms.TextBox();
      this.textBoxHex = new System.Windows.Forms.TextBox();
      this.buttonFill = new System.Windows.Forms.Button();
      this.buttonResetBit = new System.Windows.Forms.Button();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.buttonSetBit = new System.Windows.Forms.Button();
      this.buttonClear = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.richTextBoxHistory = new System.Windows.Forms.RichTextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.buttonRevert = new System.Windows.Forms.Button();
      this.textBoxDecHistory = new System.Windows.Forms.TextBox();
      this.textBoxHexHistory = new System.Windows.Forms.TextBox();
      this.textBoxBinHistory = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.BackColor = System.Drawing.Color.LightBlue;
      this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Size = new System.Drawing.Size(968, 420);
      this.splitContainer1.SplitterDistance = 332;
      this.splitContainer1.TabIndex = 92;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.splitContainer1.Panel1MinSize = 330;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
      this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
      this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.splitContainer1.Panel2MinSize = 125;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.listBoxHistory);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
      this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(142, 416);
      this.groupBox1.TabIndex = 63;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "History";
      // 
      // listBoxHistory
      // 
      this.listBoxHistory.BackColor = System.Drawing.SystemColors.Window;
      this.listBoxHistory.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listBoxHistory.Location = new System.Drawing.Point(3, 16);
      this.listBoxHistory.Name = "listBoxHistory";
      this.listBoxHistory.Size = new System.Drawing.Size(136, 397);
      this.listBoxHistory.TabIndex = 38;
      this.listBoxHistory.SelectedIndexChanged += new System.EventHandler(this.History_Click);
      // 
      // splitContainer2
      // 
      this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Right;
      this.splitContainer2.Location = new System.Drawing.Point(145, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      this.splitContainer2.Size = new System.Drawing.Size(483, 416);
      this.splitContainer2.SplitterDistance = 232;
      this.splitContainer2.TabIndex = 62;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.richTextBoxMask);
      this.splitContainer2.Panel1.Controls.Add(this.label4);
      this.splitContainer2.Panel1.Controls.Add(this.textBoxBin);
      this.splitContainer2.Panel1.Controls.Add(this.textBoxDec);
      this.splitContainer2.Panel1.Controls.Add(this.textBoxHex);
      this.splitContainer2.Panel1.Controls.Add(this.buttonFill);
      this.splitContainer2.Panel1.Controls.Add(this.buttonResetBit);
      this.splitContainer2.Panel1.Controls.Add(this.numericUpDown1);
      this.splitContainer2.Panel1.Controls.Add(this.buttonSetBit);
      this.splitContainer2.Panel1.Controls.Add(this.buttonClear);
      this.splitContainer2.Panel1.Controls.Add(this.label3);
      this.splitContainer2.Panel1.Controls.Add(this.label2);
      this.splitContainer2.Panel1.Controls.Add(this.label1);
      this.splitContainer2.Panel1MinSize = 215;
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.richTextBoxHistory);
      this.splitContainer2.Panel2.Controls.Add(this.label10);
      this.splitContainer2.Panel2.Controls.Add(this.buttonRevert);
      this.splitContainer2.Panel2.Controls.Add(this.textBoxDecHistory);
      this.splitContainer2.Panel2.Controls.Add(this.textBoxHexHistory);
      this.splitContainer2.Panel2.Controls.Add(this.textBoxBinHistory);
      this.splitContainer2.Panel2.Controls.Add(this.label7);
      this.splitContainer2.Panel2.Controls.Add(this.label6);
      this.splitContainer2.Panel2.Controls.Add(this.label5);
      this.splitContainer2.Panel2MinSize = 180;
      // 
      // richTextBoxMask
      // 
      this.richTextBoxMask.DetectUrls = false;
      this.richTextBoxMask.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
      this.richTextBoxMask.Location = new System.Drawing.Point(80, 105);
      this.richTextBoxMask.Name = "richTextBoxMask";
      this.richTextBoxMask.ReadOnly = true;
      this.richTextBoxMask.Size = new System.Drawing.Size(392, 69);
      this.richTextBoxMask.TabIndex = 76;
      this.richTextBoxMask.Text = "";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(8, 105);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(70, 20);
      this.label4.TabIndex = 75;
      this.label4.Text = "Mask";
      this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // textBoxBin
      // 
      this.textBoxBin.Location = new System.Drawing.Point(80, 75);
      this.textBoxBin.Name = "textBoxBin";
      this.textBoxBin.ReadOnly = true;
      this.textBoxBin.Size = new System.Drawing.Size(392, 20);
      this.textBoxBin.TabIndex = 68;
      // 
      // textBoxDec
      // 
      this.textBoxDec.Location = new System.Drawing.Point(80, 15);
      this.textBoxDec.Name = "textBoxDec";
      this.textBoxDec.ReadOnly = true;
      this.textBoxDec.Size = new System.Drawing.Size(128, 20);
      this.textBoxDec.TabIndex = 66;
      // 
      // textBoxHex
      // 
      this.textBoxHex.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBoxHex.Location = new System.Drawing.Point(80, 45);
      this.textBoxHex.Name = "textBoxHex";
      this.textBoxHex.ReadOnly = true;
      this.textBoxHex.Size = new System.Drawing.Size(128, 20);
      this.textBoxHex.TabIndex = 62;
      // 
      // buttonFill
      // 
      this.buttonFill.Location = new System.Drawing.Point(365, 184);
      this.buttonFill.Name = "buttonFill";
      this.buttonFill.Size = new System.Drawing.Size(88, 23);
      this.buttonFill.TabIndex = 73;
      this.buttonFill.Text = "Fill BitField";
      this.buttonFill.Click += new System.EventHandler(this.Button_Click);
      // 
      // buttonResetBit
      // 
      this.buttonResetBit.Location = new System.Drawing.Point(175, 184);
      this.buttonResetBit.Name = "buttonResetBit";
      this.buttonResetBit.Size = new System.Drawing.Size(88, 23);
      this.buttonResetBit.TabIndex = 72;
      this.buttonResetBit.Text = "Reset Bit";
      this.buttonResetBit.Click += new System.EventHandler(this.Button_Click);
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(33, 187);
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
      this.numericUpDown1.TabIndex = 63;
      this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // buttonSetBit
      // 
      this.buttonSetBit.Location = new System.Drawing.Point(79, 184);
      this.buttonSetBit.Name = "buttonSetBit";
      this.buttonSetBit.Size = new System.Drawing.Size(88, 23);
      this.buttonSetBit.TabIndex = 71;
      this.buttonSetBit.Text = "Set Bit";
      this.buttonSetBit.Click += new System.EventHandler(this.Button_Click);
      // 
      // buttonClear
      // 
      this.buttonClear.Location = new System.Drawing.Point(269, 184);
      this.buttonClear.Name = "buttonClear";
      this.buttonClear.Size = new System.Drawing.Size(88, 23);
      this.buttonClear.TabIndex = 70;
      this.buttonClear.Text = "Clear BitField";
      this.buttonClear.Click += new System.EventHandler(this.Button_Click);
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(8, 75);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(70, 20);
      this.label3.TabIndex = 67;
      this.label3.Text = "Binary";
      this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(8, 15);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(70, 20);
      this.label2.TabIndex = 65;
      this.label2.Text = "Decimal";
      this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(8, 45);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(70, 20);
      this.label1.TabIndex = 64;
      this.label1.Text = "Hexidecimal";
      this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // richTextBoxHistory
      // 
      this.richTextBoxHistory.DetectUrls = false;
      this.richTextBoxHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
      this.richTextBoxHistory.Location = new System.Drawing.Point(80, 105);
      this.richTextBoxHistory.Name = "richTextBoxHistory";
      this.richTextBoxHistory.ReadOnly = true;
      this.richTextBoxHistory.Size = new System.Drawing.Size(392, 69);
      this.richTextBoxHistory.TabIndex = 77;
      this.richTextBoxHistory.Text = "";
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point(8, 105);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(70, 20);
      this.label10.TabIndex = 59;
      this.label10.Text = "Mask";
      this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // buttonRevert
      // 
      this.buttonRevert.AutoSize = true;
      this.buttonRevert.Location = new System.Drawing.Point(280, 15);
      this.buttonRevert.Name = "buttonRevert";
      this.buttonRevert.Size = new System.Drawing.Size(101, 23);
      this.buttonRevert.TabIndex = 56;
      this.buttonRevert.Text = "▲ Revert Back ▲";
      this.buttonRevert.Visible = false;
      this.buttonRevert.Click += new System.EventHandler(this.History_Click);
      // 
      // textBoxDecHistory
      // 
      this.textBoxDecHistory.Location = new System.Drawing.Point(80, 15);
      this.textBoxDecHistory.Name = "textBoxDecHistory";
      this.textBoxDecHistory.ReadOnly = true;
      this.textBoxDecHistory.Size = new System.Drawing.Size(128, 20);
      this.textBoxDecHistory.TabIndex = 55;
      // 
      // textBoxHexHistory
      // 
      this.textBoxHexHistory.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBoxHexHistory.Location = new System.Drawing.Point(80, 45);
      this.textBoxHexHistory.Name = "textBoxHexHistory";
      this.textBoxHexHistory.ReadOnly = true;
      this.textBoxHexHistory.Size = new System.Drawing.Size(128, 20);
      this.textBoxHexHistory.TabIndex = 52;
      // 
      // textBoxBinHistory
      // 
      this.textBoxBinHistory.Location = new System.Drawing.Point(80, 75);
      this.textBoxBinHistory.Name = "textBoxBinHistory";
      this.textBoxBinHistory.ReadOnly = true;
      this.textBoxBinHistory.Size = new System.Drawing.Size(392, 20);
      this.textBoxBinHistory.TabIndex = 51;
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(8, 15);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(70, 20);
      this.label7.TabIndex = 54;
      this.label7.Text = "Decimal";
      this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(8, 45);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(70, 20);
      this.label6.TabIndex = 53;
      this.label6.Text = "Hexidecimal";
      this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(8, 75);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(70, 20);
      this.label5.TabIndex = 50;
      this.label5.Text = "Binary";
      this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // FormClass
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(968, 420);
      this.Controls.Add(this.splitContainer1);
      this.MinimumSize = new System.Drawing.Size(976, 457);
      this.Name = "FormClass";
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.Panel2.PerformLayout();
      this.splitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private SplitContainer splitContainer1;
    private GroupBox groupBox1;
    private ListBox listBoxHistory;
    private SplitContainer splitContainer2;
    private TextBox textBoxBin;
    private TextBox textBoxDec;
    private TextBox textBoxHex;
    private Button buttonFill;
    private Button buttonResetBit;
    private NumericUpDown numericUpDown1;
    private Button buttonSetBit;
    private Button buttonClear;
    private Label label3;
    private Label label2;
    private Label label1;
    private Label label10;
    private Button buttonRevert;
    private TextBox textBoxDecHistory;
    private TextBox textBoxHexHistory;
    private TextBox textBoxBinHistory;
    private Label label7;
    private Label label6;
    private Label label5;
    private Label label4;
    private RichTextBox richTextBoxMask;
    private RichTextBox richTextBoxHistory;
    private ToolTip toolTip1;
    private IContainer components;

  }
}