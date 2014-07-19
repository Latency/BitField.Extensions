// ****************************************************************************
// * Project:  BitFields
// * File:     FormClass.cs
// * Author:   Latency McLaughlin
// * Date:     07/15/2014
// ****************************************************************************

#if DEBUG
using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using AssemblyInfo;


namespace BitFields {
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

      Redraw(true);
      richTextBoxMask.Text = RedrawMask(_bitField);
    }

    /// <summary>
    ///   Update the Field strings
    /// </summary>
    private void Redraw(bool top) {
      var ctx = top ? new[] { textBoxDec, textBoxHex, textBoxBin } : new[] { textBoxDecHistory, textBoxHexHistory, textBoxBinHistory };
      ctx[0].Text = _bitField.ToString.Decimal();
      ctx[1].Text = _bitField.ToString.Hex();
      ctx[2].Text = _bitField.ToString.Binary().PadLeft(64, '0');
    }

    /// <summary>
    ///   If flag is set then check the checkbox
    /// </summary>
    /// <param name="flag"></param>
    /// <param name="cb"></param>
    private void SetFlags(Flag flag, CheckBox cb) {
      // if flag is set ensure the box is checked
      cb.Checked = _bitField.IsSet(flag);
    }

    /// <summary>
    ///   Iterate for each checkbox and ensure it is in the proper state
    /// </summary>
    private void RedrawCheckBox() {
      foreach (var c in Controls.OfType<CheckBox>())
        SetFlags((Flag) c.Tag, c);
    }

    /// <summary>
    ///   Updates a control with the enum flags set.
    /// </summary>
    /// <param name="hBitField"></param>
    /// <returns></returns>
    private static String RedrawMask(BitField hBitField) {
      // For ComboBox
      //var dataSource = EnumExtensions.GetAllSelectedItems<Flag>(hBitField.Mask).Where(enm => (int) enm != 0 || EnumExtensions.GetAllSelectedItems<Flag>(hBitField.Mask).Count() <= 1).Select(enm => enm.GetEnumDescription()).ToList();
      var collection = EnumExtensions.GetAllSelectedItems<Flag>(hBitField.Mask).ToList();
      var count = collection.Count();
      foreach (var enm in collection) {
        if (enm != 0 || count <= 1) {
          
        }
      }
      return collection
        .Where(enm => (int) enm != 0 || collection.Count() <= 1)
        .Aggregate(String.Empty, (current, enm) => current + ((current.Length > 0 ? " | " : String.Empty) + enm.GetEnumDescription()));
    }

    /// <summary>
    ///   Add the decimal equivilent of the current state to the listbox.
    /// </summary>
    /// <param name="bm"></param>
    private void AddToHistory(BitField bm) {
      //Add this item to history
      listBoxHistory.Items.Insert(0, bm.ToString.Decimal());
      listBoxHistory.SelectedIndex = 0;
    }

    #region Events

    /// <summary>
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
      richTextBoxMask.Text = RedrawMask(_bitField);
      RedrawCheckBox();
      Redraw(true);
    }

    /// <summary>
    ///   Methods to toggle the flag when the check box changes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Check_Changed(object sender, EventArgs e) {
      var cb = sender as CheckBox;
      if (cb != null) {
        var enm = (Flag) cb.Tag;
        //Check if toggle is required
        if (_bitField.IsSet(enm) != cb.Checked) {
          _bitField.Toggle(enm);
          AddToHistory(_bitField);
        }
      }
      Redraw(true);
      richTextBoxMask.Text = RedrawMask(_bitField);
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
      richTextBoxHistory.Text = RedrawMask(hBitField);

      switch (((Control) sender).Name.Substring("button".Length)) {
        case "Revert": // Refresh top pane
          _bitField = hBitField;
          RedrawCheckBox();
          richTextBoxMask.Text = RedrawMask(_bitField);
          Redraw(true);
          // Remove previous history states
          while (listBoxHistory.SelectedIndex != 0)
            listBoxHistory.Items.RemoveAt(0);
          break;
        default:
          Redraw(false);
          break;
      }
    }

    #endregion Events
  }
}
#endif