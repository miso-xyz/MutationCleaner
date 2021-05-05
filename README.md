# PointMutationRemover
This remover removes 2d point mutations. It's very basic so there is a slight possibility of it not working with some. Just a warning, BIN/DEBUG is NOT UPDATED by me anymore! Head on over to releases if you really want the new stuff m8

# Mod Improvements
<pre>
- Can now clean TimeSpan Mutations
- Solve simple math calculations
- Improvements on CUI
</pre>

# How to use
Drag & Drop to remove Point & TimeSpan Mutations

# Code Examples
**Point Mutation Example:**
```csharp
// Before
int test = new Point(123, 312).X
Console.WriteLine(test);

// After
int test = 123;
Console.WriteLine(test);
```

**TimeSpan Mutation Example:**
```csharp
// Before
this.button2.Size = new Size((int)new TimeSpan(0xF, 0x30, 0xB40, 0xC).TotalDays + 1, 0x13 + (((int)new TimeSpan(0x1C5, 0x30, 0xB40, 0xC).TotalDays < 0x418) ? 1 : 0));

// After
this.button2.Size = new Size(0x13 + 1, 0x13 + ((0x1C9 < 0x418) ? 1 : 0));
```

**Math Solver Example:**

PS: It does not support variable-based calculations
```csharp
// Before
this.ProgressBar1.Value = 8 + 9
this.ProgressBar2.Value = 8 - 9
this.ProgressBar3.Value = 8 * 9
this.ProgressBar4.Value = 8 ^ 9

// After
this.ProgressBar1.Value = 17
this.ProgressBar2.Value = -1
this.ProgressBar3.Value = 72
this.ProgressBar4.Value = 1
```

# Screenshot
![app](https://i.imgur.com/1CnH9MV.png)

(v1.0 screenshot)

![app](https://i.imgur.com/8PIdh3O.png)

# Credits
- <a href="https://github.com/DevT02">DevT02</a> - Original App Author
- <a href="https://github.com/bobRE12">bobRE12</a> - dmed a CrackMe
- 0xd4d (now wtfsck) - <a href="https://github.com/0xd4d/dnlib">dnlib</a>
