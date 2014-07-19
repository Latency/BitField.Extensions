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
        cb.Text = String.Format("Flag {0:D2}", (idx + 1));
        cb.Tag = (Flag) Enum.Parse(typeof(Flag), "F" + (idx + 1));
        cb.Click += Check_Changed;
        last = cb;
        // Add control to form
        splitContainer1.Panel1.Controls.Add(last);
      }

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
        String.Empty, (current, enm) => current + ((current.Length > 0 ? " | " : String.Empty) + enm.GetEnumDescription())
      );
    }

    /// <summary>
    ///   Iterate for each checkbox and ensure it is in the proper state
    /// </summary>
    private void RedrawCheckBoxes() {
      foreach (var c in splitContainer1.Panel1.Controls.OfType<CheckBox>())
        c.Checked = _bitField.IsSet((Flag) c.Tag);
    }

    /// <summary>
    ///   Add the decimal equivilent of the current state to the listbox.
    /// </summary>
    /// <param name="bm"></param>
    private void AddToHistory(BitField bm) {
      listBoxHistory.Items.Insert(0, bm.ToString.Decimal());
      // TODO:  Fix event triggering duplicate invocation
      //listBoxHistory.SelectedIndex = 0;
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
        case "AddFlag": // Add the specified flag to the bitField.
          _bitField.SetOn(BitField.DecimalToFlag(numericUpDown1.Value));
          break;
        case "RemoveFlag": // Remove the specified flag to the bitField.
          _bitField.SetOff(BitField.DecimalToFlag(numericUpDown1.Value));
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
      var enm = (Flag) cb.Tag;
      _bitField.Toggle(enm);
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
      if (sVal == String.Empty)
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
  }
}