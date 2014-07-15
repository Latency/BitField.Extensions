// ****************************************************************************
// * Project:  BitFields
// * File:     FormClass.cs
// * Author:   Latency McLaughlin
// * Date:     07/15/2014
// ****************************************************************************
using System;
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
      InitializeComponent();
      Text = Assembly.GetExecutingAssembly().Description();

      // Map the Enum to comboBox.Tag property
      //
      foreach (var c in Controls.OfType<CheckBox>())
        c.Tag = (Flag) Enum.Parse(typeof (Flag), 'F' + c.Name.Substring("chcekBox".Length));

      Redraw();
    }

    /// <summary>
    ///   Update the Field strings
    /// </summary>
    private void Redraw() {
      textBoxDec.Text = _bitField.ToStringDec();
      textBoxHex.Text = _bitField.ToStringHex();
      textBoxBin.Text = _bitField.ToStringBin();
    }

    /// <summary>
    ///   If flag is set then check the checkbox
    /// </summary>
    /// <param name="flag"></param>
    /// <param name="cb"></param>
    private void SetFlags(Flag flag, CheckBox cb) {
      // if flag is set ensure the box is checked
      cb.Checked = _bitField.AllOn(flag);
    }

    /// <summary>
    ///   Iterate for each checkbox and ensure it is in the proper state
    /// </summary>
    private void RedrawCheckbox() {
      foreach (var c in Controls.OfType<CheckBox>())
        SetFlags((Flag) c.Tag, c);
    }

    /// <summary>
    ///   Iterate for each flag selected and propogate the combobox
    /// </summary>
    private void RedrawCombobox(BitField hBitField) {
      comboBoxHistory.DataSource =
        EnumExtensions.GetAllSelectedItems<Flag>(hBitField.Mask).Where(enm => (int) enm != 0 || EnumExtensions.GetAllSelectedItems<Flag>(hBitField.Mask).Count() <= 1).Select(enm => enm.GetEnumDescription()).ToList();
      comboBoxHistory.Text = EnumExtensions.GetAllSelectedItems<Flag>(hBitField.Mask)
        .Where(enm => (int) enm != 0 || EnumExtensions.GetAllSelectedItems<Flag>(hBitField.Mask).Count() <= 1)
        .Aggregate(String.Empty, (current, enm) => current + ((current.Length > 0 ? " | " : String.Empty) + enm.GetEnumDescription()));
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button_Click(object sender, EventArgs e) {
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
      RedrawCheckbox();
      Redraw();
    }

    /// <summary>
    ///   Methods to toggle the flag when the check box changes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckedChanged(object sender, EventArgs e) {
      var cb = sender as CheckBox;
      if (cb != null) {
        var enm = (Flag) cb.Tag;
        //Check if toggle is required
        if (_bitField.AllOn(enm) != cb.Checked)
          Toggle(enm);
      }
      Redraw();
    }

    /// <summary>
    ///   Toggle the flag and add it to the history list
    /// </summary>
    /// <param name="flag"></param>
    private void Toggle(Flag flag) {
      _bitField.SetToggle(flag);
      AddToHistory(_bitField);
    }

    private void AddToHistory(BitField bm) {
      //Add this item to history
      listBoxHistory.Items.Insert(0, bm.ToStringDec());
      listBoxHistory.SelectedIndex = 0;
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
      var hBitField = new BitField {Mask = Convert.ToUInt64(sVal, 10)};
      RedrawCombobox(hBitField);

      switch (((Control) sender).Name.Substring("button".Length)) {
        case "Revert": // Refresh top pane
          _bitField = hBitField;
          RedrawCheckbox();
          Redraw();
          // Remove previous history states
          while (listBoxHistory.SelectedIndex != 0)
            listBoxHistory.Items.RemoveAt(0);
          break;
        default:
          textBoxDecHistory.Text = hBitField.ToStringDec();
          textBoxHexHistory.Text = hBitField.ToStringHex();
          textBoxBinHistory.Text = hBitField.ToStringBin();
          break;
      }
    }
  }
}