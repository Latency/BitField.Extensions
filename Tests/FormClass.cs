// ****************************************************************************
// * Project:  BitFields
// * File:     FormClass.cs
// * Author:   Latency McLaughlin
// * Date:     07/15/2014
// ****************************************************************************

using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using AssemblyInfo;
using BitFields;

namespace Tests {
  /// <summary>
  ///   Summary description for FormClass.
  /// </summary>
  public sealed partial class FormClass : Form {
    private BitField _bitField;

    public FormClass() {
      // Instantiate the bitField object
      _bitField = new BitField();

      //
      // Required for Windows Form Designer support
      //
      #region Form Designer

      InitializeComponent();
      Text = Assembly.GetExecutingAssembly().Description();

      // Dynamic creation for checkboxes
      var offset = new Point(65, 30);
      CheckBox last = null;
      for (var idx = 0; idx < 64; idx++) {
        var cb = new CheckBox();
        if (last == null) { // Iniitalize last instance
          last = cb;
          last.Location = new Point(0, -25);
        }
        cb.AutoSize = true;
        cb.Location = (idx % 5) == 0 ? new Point(5, last.Location.Y + offset.Y) : new Point(last.Location.X + offset.X, last.Location.Y);
        cb.Name = "checkBox" + (idx + 1);
        cb.Text = $"Bit {(idx + 1):D2}";
        cb.Tag = (Flag) Enum.Parse(typeof(Flag), "F" + (idx + 1));
        cb.Click += Check_Changed;
        toolTip1.SetToolTip(cb, $"Check here to toggle '{cb.Text}'!");
        last = cb;
        // Add control to form
        splitContainer1.Panel1.Controls.Add(last);
      }

      toolTip1.SetToolTip(SpinBox, "Used in conjunction with the (re)set button!");
      toolTip1.SetToolTip(buttonSetBit, "Click here to set a bit denoted by the spinbox!");
      toolTip1.SetToolTip(buttonResetBit, "Click here to reset the bit denoted by the spinbox!");
      toolTip1.SetToolTip(buttonClear, "Click here to reset all bits!");
      toolTip1.SetToolTip(buttonFill, "Click here to set all bits!");

      #endregion Form Designer

      // Map the Enum to comboBox.Tag property
      foreach (var c in Controls.OfType<CheckBox>())
        c.Tag = (Flag) Enum.Parse(typeof (Flag), 'F' + c.Name.Substring("chcekBox".Length));

      Redraw(_bitField, true);
    }

    /// <summary>
    ///   Update the Field strings
    /// </summary>
    private void Redraw(BitField bitfield, bool top) {
      var ctx = top ? new Control[] { textBoxDec, textBoxHex, textBoxBin, richTextBoxMask }
                    : new Control[] { textBoxDecHistory, textBoxHexHistory, textBoxBinHistory, richTextBoxHistory };
      ctx[0].Text = bitfield.ToString.Decimal();
      ctx[1].Text = bitfield.ToString.Hex();
      ctx[2].Text = bitfield.ToString.Binary().PadLeft(64, '0');
      ctx[3].Text = EnumExtensions.GetAllSelectedItems<Flag>(bitfield.Mask).ToList().Aggregate(
        string.Empty, (current, enm) => current + ((current.Length > 0 ? " | " : string.Empty) + enm.GetEnumDescription())
      );
      SpinBox_ValueChanged(null, null);
    }

    /// <summary>
    ///   Iterate for each checkbox and ensure it is in the proper state
    /// </summary>
    private void RedrawCheckBoxes() {
      foreach (var c in splitContainer1.Panel1.Controls.OfType<CheckBox>())
        c.Checked = _bitField.IsSet(Convert.ToUInt64((Flag) c.Tag));
    }

    /// <summary>
    ///   Add the decimal equivilent of the current state to the listbox.
    /// </summary>
    /// <param name="bm"></param>
    private void AddToHistory(BitField bm) {
      listBoxHistory.Items.Insert(0, bm.ToString.Decimal());
      listBoxHistory.SelectedIndex = 0;
    }

    #region Events

    /// <summary>
    ///  Events for button clicks.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click(object sender, EventArgs e) {
      var btn = (Button) sender;
      switch (btn.Name.Substring("button".Length)) {
        case "Clear": // Clear the bitField by turning all flags off.
          _bitField.ClearField();
          break;
        case "Fill": // Fill the bit Field by turning all flags on.
          _bitField.FillField();
          break;
        case "SetBit": // Add the specified flag to the bitField.
          _bitField.SetOn(BitField.DecimalToFlag(SpinBox.Value));
          break;
        case "ResetBit": // Remove the specified flag to the bitField.
          _bitField.SetOff(BitField.DecimalToFlag(SpinBox.Value));
          break;
        default:
          throw new ArgumentException("Button must be named 'button[Clear|Fill|AddFlag|RemoveFlag]'");
      }
      AddToHistory(_bitField);
      RedrawCheckBoxes();
      Redraw(_bitField, true);
    }

    /// <summary>
    ///   Methods to toggle the flag when the check box changes.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Check_Changed(object sender, EventArgs e) {
      var cb = (CheckBox) sender;
      _bitField.Toggle(Convert.ToUInt64((Flag) cb.Tag));
      AddToHistory(_bitField);
      Redraw(_bitField, true);
    }

    /// <summary>
    ///   Get the selected item from the history list and polulates the necessary controls.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void History_Click(object sender, EventArgs e) {
      var sVal = listBoxHistory.SelectedItem.ToString();
      if (sVal == string.Empty)
        return;

      var hBitField = new BitField { Mask = Convert.ToUInt64(sVal, 10) };

      switch (((Control) sender).Name.Substring("button".Length)) {
        case "Revert": // Refresh top pane
          // Restore current mask.
          _bitField = hBitField;
          // Remove previous history states
          while (listBoxHistory.SelectedIndex != 0)
            listBoxHistory.Items.RemoveAt(0);
          // Redraw controls
          RedrawCheckBoxes();
          Redraw(hBitField, true);
          break;
        default:
          Redraw(hBitField, false);
          break;
      }
      buttonRevert.Visible = (_bitField.Mask != hBitField.Mask);
    }

    #endregion Events

    private void SpinBox_ValueChanged(object sender, EventArgs e) {
      var test = _bitField.IsSet(BitField.DecimalToFlag(SpinBox.Value));
      buttonSetBit.Enabled = !test;
      buttonResetBit.Enabled = test;
    }

    private void pictureBoxLogo_Click(object sender, EventArgs e) {
      System.Diagnostics.Process.Start("https://github.com/Latency/Bitfields");
    }
  }
}