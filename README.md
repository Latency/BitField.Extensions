BitFields
=========

.NET API library for enum extensions


<p><img height=391 alt="Sample image" src="http://bio-hazard.us/bitfields/images/BitFields.jpg" width=600></p>
<ul>
  <li><a href="#introduction">Introduction</a>
  <li><a href="#background">Background</a>
  <li><a href="#using">Using the code</a>
  <li><a href="#points">Points of Interest</a>
  <li><a href="#references">References</a> </li>
  <li><a href="#license">License</a> </li>
</ul>
<a name="introduction"><h2>Introduction</h2></a>
<p>This article demonstrates a simple use of bit fields as flags for Windows forms. Bit fields allow packaging of data into simple structures, and they are particularly useful when bandwidth, memory or data storage is at a premium. This might not appear to be an issue with modern day equipment or every day applications, but we can save up to 16 times more memory and storage when using bit fields instead of other value types such as boolean.</p>
<a name="background"><h2>Background</h2></a>
<h3>Storage</h3>
<p>Consider a boolean value in .NET:</p><pre lang=cs><span class="code-keyword">bool</span> bVal;</pre>
<p>Boolean value data types are stored as 16-bit (2-byte) numbers that can only be true or false. Consider an unsigned 16-bit number which ranges from 0 to 65535:</p><pre lang=text>Decimal        Hexidecimal    Binary
0              0x0000         0000000000000000
65535          0xffff         1111111111111111</pre>
<p>When numeric data types are converted to boolean values, 0 becomes false and all other values become true. When Boolean values are converted to numeric types, false becomes 0 and true becomes -1 (using a signed number).</p>
<p>If we want to use a boolean value to represent a two-state value of a flag or setting in our program (true &lt;=&gt; on, false &lt;=&gt; off), then this would be stored as a 16-bit number.</p>
<p>Consider using a binary digit to represent the same two-state value: (1 &lt;=&gt; on, 0 &lt;=&gt; off):</p><pre lang=text>Decimal        Hexidecimal    Binary
0              0x0000         0000000000000000
1              0x0001         0000000000000001</pre>
<p>We can use this same 16-bit number to represent 16 unique settings by inspecting each digit and determining if it is 1/on or 0/off:</p><pre lang=text>Decimal        Hexidecimal    Binary
1              0x0001         0000000000000001
2              0x0002         0000000000000010
4              0x0004         0000000000000100
8              0x0008         0000000000001000
16             0x0010         0000000000010000
32             0x0020         0000000000100000
64             0x0040         0000000001000000
128            0x0080         0000000010000000
256            0x0100         0000000100000000
512            0x0200         0000001000000000
1024           0x0400         0000010000000000
2048           0x0800         0000100000000000
4096           0x1000         0001000000000000
8192           0x2000         0010000000000000
16384          0x4000         0100000000000000
32768          0x8000         1000000000000000</pre>
<p>With only 16 settings, this might not appear to be an issue and one would more than likely store the settings as Boolean values, however, storing a history of those settings can quickly add up, and saving space by a factor of 16 can make a difference. Ever tried loading a 100MB file into memory and then manipulating it? How about a 1.6GB file?</p>
<h3>Understanding bit shifting &lt;&lt;</h3><pre lang=cs>f1 = 0x01        <span class="code-comment">//</span><span class="code-comment"> 0x01        1    00000001
</span>f2 = f1 &lt;&lt; <span class="code-digit">1</span>,    <span class="code-comment">//</span><span class="code-comment"> 0x02        2    00000010
</span>f3 = f2 &lt;&lt; <span class="code-digit">1</span>,    <span class="code-comment">//</span><span class="code-comment"> 0x04        4    00000100
</span>f4 = f3 &lt;&lt; <span class="code-digit">1</span>,    <span class="code-comment">//</span><span class="code-comment"> 0x08        8    00001000</span></pre>
<p>Shifting to the Left or the Right.</p>
<p>There are two operators:</p>
<ul>
  <li><code lang=cs>&lt;&lt;</code> for shifting a specified number of bits to the left (towards the "high order" bits)
  <li><code lang=cs>&gt;&gt;</code> for shifting to the right. </li>
</ul>
<p>If a shift operation causes some number of bits to go outside of an underlying data type, then those bits are discarded. Empty bit positions created by the shift operation are always filled with 0s in a left shift operation and in a positive right shift operation. If a negative number of bit places is requested in a right shift operation <code lang=cs>f2 &gt;&gt; -<span class='cs-literal'>2</span></code>, then the vacated bit positions are filled with 1s.</p>
<h3>Understanding bitwise operations</h3>
<p>Bitwise operations are used to manipulate the bit field, and determine if a specified flag is set. The following truth tables illustrate the truth values of some operations:</p><pre lang=text>Mask OR Flag     Mask AND NOT Flag    Mask XOR Flag        
0 | 0 = 0        0 &amp; ~0 = 0           0 ^ 0 = 0                     
1 | 0 = 1        1 &amp; ~0 = 1           1 ^ 0 = 1                     
0 | 1 = 1        0 &amp; ~1 = 0           0 ^ 1 = 1                     
1 | 1 = 1        1 &amp; ~1 = 0           1 ^ 1 = 0</pre>
<a name="using"><h2>Using the code</h2></a>
<p>The <code>BitField</code> class/structure uses an enumeration to define the flags in the bit field. The field can store up to 64 unique flags using the 64-bit unsigned <code lang=cs><span class='cs-keyword'>ulong</span></code> value type. The flags can have any name, but be careful with the <code>Clear</code> flag as this has a special value that is used to clear and fill the entire bit field.</p><pre lang=cs>[Flags]
<span class="code-keyword">public</span> <span class="code-keyword">enum</span> Flag : <span class="code-keyword">ulong {</span>
  Clear  = 0x00,
  f1     = 0x01,
  f2     = f1 &lt;&lt; <span class="code-digit">1</span>,
  . . .
}</pre>
<p>Each <code>Flag</code> enumeration is a number that in binary form has one digit set to 1 and the rest set to 0. With this enumeration, there are exactly 64 distinct values with a single 1, and 2^64 (18446744073709551616) possible combinations of these 64 flags.</p>
<p>Some points to make about <code lang=cs>[FlagsAttribute] == [Flags]</code>:</p>
<ul>
  <li>An enumeration is treated as a bit field; that is, a mask comprised of a set of flags.
  <li>The results from bitwise operations are also bit fields.
  <li>Bit fields are generally used for lists of elements that might occur in combination, whereas enumeration constants are generally used for lists of mutually exclusive elements. Therefore, bit fields are designed to be combined to generate unnamed values, whereas enumerated constants are not. </li>
</ul>
<p>The bit field is stored in the variable <code>_Mask</code>, and external access is provided through the public properties <code lang=cs><span class='cs-keyword'>get</span></code> and <code lang=cs><span class='cs-keyword'>set</span></code>.</p><pre lang=cs><span class="code-keyword">private</span> <span class="code-keyword">ulong</span> _Mask;    
<span class="code-keyword">public</span> <span class="code-keyword">ulong</span> Mask {
  <span class="code-keyword">get {</span>
    <span class="code-keyword">return</span> _Mask;
  }
  <span class="code-keyword">set {</span>
    _Mask = value;
  }
}</pre>
<h3>Methods</h3>
<p>The <code>SetField</code> method sets the specified flag in the mask and turns all other flags off.</p>
<ul>
  <li>Bits that are set to 1 in the flag will be set to one in the mask.
  <li>Bits that are set to 0 in the flag will be set to zero in the mask. </li>
</ul><pre lang=cs><span class="code-keyword">private</span> <span class="code-keyword">void</span> SetField(Flag flg) {
  Mask = (<span class="code-keyword">ulong</span>)flg;
}</pre>
<p>This is particularly useful for setting all bits off using the <code>Flag.Clear</code> flag <code>SetField(Flag.Clear)</code>,</p><pre lang=text>
       Mask =  Flag.Clear
&lt;=&gt;    Mask =  0000000000000000000000000000000000000000000000000000000000000000</pre>
<p>or setting all bits on using the negation of the <code>Flag.Clear</code> flag <code>SetField(~Flag.Clear)</code>.</p><pre lang=text>       Mask = ~Flag.Clear
&lt;=&gt;    Mask = ~0000000000000000000000000000000000000000000000000000000000000000
&lt;=&gt;    Mask =  1111111111111111111111111111111111111111111111111111111111111111</pre>
<p>The <code>SetOn</code> method sets the specified flag(s) in the mask and leaves all other flags unchanged (using the binary bitwise inclusive OR operator).</p>
<ul>
  <li>Bits that are set to 1 in the flag will be set to one in the mask.
  <li>Bits that are set to 0 in the flag will be unchanged in the mask. </li>
</ul><pre lang=cs><span class="code-keyword">public</span> <span class="code-keyword">void</span> SetOn(Flag flg) {
  Mask |= (<span class="code-keyword">ulong</span>)flg;
}</pre>
<p>Since a flag has exactly one digit with a value of 1, and the rest of the digits 0, this will leave the mask unchanged, except for the position(s) where there is a value 1:</p>
<p>Consider this operation on a random 16-bit Mask:</p><pre lang=text>
           1101001000011001
    OR     F2
    -------------------------
&lt;=&gt;        1101001000011001
    OR     0000000000000010
    -------------------------
&lt;=&gt;        1101001000011011</pre>
<p>This has the same effect as placing the digit 1 into the appropriate position in the Mask to set the flag to on.</p>
<p>The <code>SetOff</code> method sets the specified flag(s) off in the mask and leaves all other flags unchanged (using the unary bitwise complement NOT, followed by the binary bitwise AND operator).</p>
<ul>
  <li>Bits that are set to 1 in the flag will be set to zero in the mask.
  <li>Bits that are set to 0 in the flag will be unchanged in the mask. </li>
</ul><pre lang=cs><span class="code-keyword">public</span> <span class="code-keyword">void</span> SetOff(Flag flg) {
  Mask &amp;= ~(<span class="code-keyword">ulong</span>)flg;
}</pre>
<p>Since a flag has exactly one digit with a value of 1, and the rest of the digits 0, this will leave the mask unchanged, except for the position(s) where there is a value 1:</p>
<p>Consider this operation on a random 16-bit Mask:</p><pre lang=text>
            1101001000011001
    AND    ~F1
    --------------------------
&lt;=&gt;         1101001000011001
    AND    ~0000000000000001
    --------------------------
&lt;=&gt;         1101001000011001
    AND     1111111111111110
    --------------------------
&lt;=&gt;         1101001000011000</pre>
<p>This has the same effect as placing the digit 0 into the appropriate position in the Mask to set the flag to off.</p>
<p>The <code>SetToggle</code> method toggles the specified flag and leaves all other bits unchanged (using the binary bitwise exclusive OR, XOR operator).</p>
<ul>
  <li>Bits that are set to 1 in the flag will be toggled in the mask.
  <li>Bits that are set to 0 in the flag will be unchanged in the mask. </li>
</ul><pre lang=cs><span class="code-keyword">public</span> <span class="code-keyword">void</span> SetToggle(Flag flg) {
  Mask ^= (<span class="code-keyword">ulong</span>)flg;
}</pre>
<p>Since a flag has exactly one digit with a value of 1, and the rest of the digits 0, this will leave the mask unchanged, except for the position where there is a value 1:</p>
<p>Consider this operation on a random 16-bit Mask:</p><pre lang=text>
           1101001000011001
    XOR    F1
    -------------------------
&lt;=&gt;        1101001000011001
    XOR    0000000000000001
    -------------------------
&lt;=&gt;        1101001000011000</pre>
<p>This has the same effect as placing the opposite digit in the appropriate position in the Mask to toggle the flag. Using this flag, we don't have to remember the previous state of the flag.</p>
<p>The <code>AnyOn</code> method checks if any of the specified flag(s) are set to on in the mask. It isolates the appropriate digit(s) and returns true if any are non zero, false otherwise.</p><pre lang=cs><span class="code-keyword">public</span> <span class="code-keyword">bool</span> AnyOn (Flag flg) {
  <span class="code-keyword">return</span> (Mask &amp; (<span class="code-keyword">ulong</span>)flg) != <span class="code-digit">0</span>;
}</pre>
<p>The <code>AllOn</code> method checks if all of the specified flag(s) are set to on in the mask. It isolates the appropriate digit(s) and returns true if they all are non zero, false otherwise.</p><pre lang=cs><span class="code-keyword">public</span> <span class="code-keyword">bool</span> AllOn (Flag flg) {
  <span class="code-keyword">return</span> (Mask &amp; (<span class="code-keyword">ulong</span>)flg) == (<span class="code-keyword">ulong</span>)flg;
}</pre>
<p>The <code>IsEqual</code> method checks if all of the specified flag(s) are the same as in the mask. It isolates the appropriate digit(s) and returns true if they are all the same, false otherwise.</p><pre lang=cs><span class="code-keyword">public</span> <span class="code-keyword">bool</span> IsEqual (Flag flg) {
  <span class="code-keyword">return</span> Mask == (<span class="code-keyword">ulong</span>)flg;
}</pre>
<p>The <code>DecimalToFlag</code> method converts a decimal value to a <code>Flag FlagsAttribute</code> value. The input can be a index between 0 and 64, and the output will be the <code>Flag</code> enumeration corresponding to that index. All it does is take the index, and shift a bit that many positions.</p><pre lang=cs><span class="code-keyword">public</span> <span class="code-keyword">static</span> Flag DecimalToFlag(<span class="code-keyword">decimal</span> dec) {
  Flag flg = Flag.Clear;
  <span class="code-keyword">ulong</span> tMsk = <span class="code-digit">0</span>;
  <span class="code-keyword">byte</span> shift;
  <span class="code-keyword">try {</span>
    shift = (<span class="code-keyword">byte</span>)dec;
    <span class="code-keyword">if</span> (shift &gt; <span class="code-digit">0</span> &amp;&amp; shift &lt;= <span class="code-digit">64</span>)
      tMsk = (<span class="code-keyword">ulong</span>) 0x01 &lt;&lt; (shift - <span class="code-digit">1</span>);
    flg = (Flag)tMsk;
  } catch (OverflowException e) {   <span class="code-comment">//</span><span class="code-comment">Byte cast operation</span>
    Console.WriteLine(<span class="code-string">"</span><span class="code-string">Exception caught in DecimalToFlag: {0}"</span>, e.ToString());
  }
  <span class="code-keyword">return</span> flg;
}</pre>
<p>The three methods <code>ToStringDec</code>, <code>ToStringHex</code>, <code>ToStringBin</code> return a string representation of the mask in decimal, hexadecimal, and binary notation respectively.</p>
<h4>Using the BitField class/structure.</h4>
<p>Instantiating the object is straight forward:</p><pre lang=cs>BitField bitField = <span class="code-keyword">new</span> BitField();</pre>
<p>When creating the <code lang=cs><span class='cs-keyword'>struct</span></code> object using the <code lang=cs><span class='cs-keyword'>new</span></code> operator, it gets created and the appropriate constructor is called. Unlike classes, <code lang=cs><span class='cs-keyword'>struct</span></code>s can be instantiated without using the <code lang=cs><span class='cs-keyword'>new</span></code> operator, so if you do not use <code lang=cs><span class='cs-keyword'>new</span></code>, the fields will remain unassigned and the object cannot be used until all of the fields are initialized.</p>
<p>This will create a new bit field and set all flags off. To set all flags on, you can call the method:</p><pre lang=cs>bitField.FillField();</pre>
<p>To set a flag, use:</p><pre lang=cs>bitField.SetOff(BitField.Flag.F1);       <span class="code-comment">//</span><span class="code-comment">Flag F1 off
</span>bitField.SetOn(BitField.Flag.F1);        <span class="code-comment">//</span><span class="code-comment">Flag F1 on
</span>bitField.SetToggle(BitField.Flag.F1);    <span class="code-comment">//</span><span class="code-comment">Flag F1 off
</span>bitField.SetToggle(BitField.Flag.F1);    <span class="code-comment">//</span><span class="code-comment">Flag F1 on</span></pre>
<p>To check if a Flag is on, use:</p><pre lang=cs><span class="code-keyword">if</span> (bitField.IsOn(BitField.Flag.f1)) {
  Console.WriteLine(<span class="code-string">"</span><span class="code-string">Flag F1 is On"</span>);
}</pre>
<a name="points"><h2>Points of Interest</h2></a>
<p>The mask value is a 64-bit number that can be stored, retrieved, or passed to other processes and applications that support 64-bit numbers. The <code>BitField</code> class/structure can then be used to retrieve and manipulate the mask. I did not find any resources that explains how bitwise operations are implemented in .NET, and if the operations are implemented efficiently. There might be ways to optimize the code but I have not found a good resource for this yet.</p>
<p>It is also important to note that there is some overhead in creating a class object, as classes are reference types and structures are value types. If this is an issue then it is possible to implement the bit field operations directly in your code, but that would defeat the purpose of the object-oriented model.</p>
<p>Another option to consider is using a structure instead of the class.</p>
<p>A structure can be preferable when:</p>
<ul>
  <li>You have a small amount of data less than 16-bytes, or 128-bits.
  <li>You perform a large number of operations on each instance and would incur performance degradation with heap management.
  <li>You have no need to inherit the structure or to specialize functionality among its instances.
  <li>You do not box and unbox the structure.
  <li>You are passing blittable data across a managed/unmanaged boundary. </li>
</ul>
<p>A class is preferable when:</p>
<ul>
  <li>You need to use inheritance and polymorphism.
  <li>You need to initialize one or more members at creation time.
  <li>You need to supply an un-parameterized constructor.
  <li>You need unlimited event handling support. </li>
</ul>
<p>A similar bit field class and bit field structure are included in the source code and demo project. Depending on the use, it might be preferable to use one over the other. It would be interesting to time them and compare actual results to see under which circumstances and how much more efficiently the system can handle the structure.</p><a name=history></a>
<a name="references"><h2>References</h2></a>
<p>Edward Smoljanovic, 20 Apr 2004 - Masks and flags using bit fields in .NET</p>
<a name="license"><h2>License</h2></a>
<div id="LicenseTerms">
  <p>
    <a href="http://www.gnu.org/copyleft/gpl.html">GNU LESSER GENERAL PUBLIC LICENSE</a>
    Version 3, 29 June 2007
  </p>
</div>