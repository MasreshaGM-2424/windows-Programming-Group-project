# Window Programming Pre-Mid Mock Exam

## Part 1: Software Development

### 1. Choosing the right SDLC model

For the flight-control software I would pick Waterfall, or Spiral. The software can't fail because people's lives depend on it. The requirements are clear and won't change much, so it makes sense to plan everything, write the documents and test carefully at each stage. Agile isn't a good fit here since it allows changes all the time and has less documentation.

About testing: in Waterfall, testing is planned carefully and done in its own phase after development, so every stage is checked before moving to the next one.

### 2. Hidden trade-offs of RAD

RAD is good because prototypes are built fast, users see results early and the product reaches the market quickly. The problem comes when we skip planning on a big or critical system:

- The foundation is weak. A prototype is made to show features, not to handle thousands of users, so it can't scale when it becomes the real product.
- There is no deep risk analysis, so security and performance problems are found late when they cost more to fix.
- Because of the deadline, teams cut down on testing and quality.
- It needs users available all the time. If they aren't, the prototype goes in the wrong direction.

It's like building a house without a blueprint. It goes up fast, but it cracks when you try to add more floors. So RAD is fine for small, low-risk projects but not for big or mission-critical ones.

### 3. Balancing development principles

- DRY: don't repeat the same code.
- KISS: keep it simple.
- YAGNI: don't build things you don't need yet.
- Separation of Concerns: each part of the program does one job.

DRY can go too far. If you try to remove every bit of repeated code, you may join things that only look the same into one big confusing method with lots of options. Then it's not simple anymore (breaks KISS) and you built flexibility nobody asked for (breaks YAGNI). Sometimes a little repetition is better than the wrong abstraction.

An example of over-engineering is a program that only adds two numbers. Instead of writing `a + b`, someone makes an interface, a factory, a service layer, a repository and a database layer "just in case". That is far too much for a small job.

### 4. The economics of testing

Fixing an error is cheapest early because mistakes grow over time. A wrong requirement becomes a wrong design, then wrong code, then wrong tests. If you find it after deployment, you have to fix all of that and the customer already suffered. Correcting a document is cheap, but fixing a live system is expensive.

Modern practices help catch problems early:

- TDD: you write the test first and then the code, so bugs show up within minutes.
- Continuous Integration: code is merged often and tested automatically, so problems appear quickly.
- Peer code reviews: another person reads your code and finds mistakes before they spread.

In Waterfall the testing comes late, so the mistakes pile up.

## Part 2: .NET, C# and Window Programming

### 5. MSIL, JIT and the platform independence paradox

C# code is compiled into MSIL, which is an in-between language that doesn't depend on any CPU. When the program runs, the JIT compiler changes the MSIL into real machine code for the computer it's running on.

The paradox is that MSIL is CPU-independent, yet .NET only ran on Windows. That's because CPU-independent is not the same as OS-independent. The old .NET Framework and CLR were made only for Windows, and libraries like WinForms and Win32 only work there. The code was portable but what it needed to run was not.

Mono is an open-source version of the .NET runtime that works on Linux, macOS, Android and others, so the same MSIL can run on those systems. Programs that use Windows-only features still won't work though.

### 6. Managed vs. unmanaged code

Managed code runs under the protection of the CLR. It gives us:

- Garbage collection, which cleans unused memory automatically.
- Type safety, so you can't use data as the wrong type.
- Metadata, where the program describes itself.
- Array bounds checking, so going past the end of an array gives an error and doesn't corrupt memory.

Unmanaged Win32 code (like C/C++) has none of this. You handle the memory yourself, so memory leaks and crashes are common.

All .NET languages compile into the same MSIL and follow the same Common Type System (CTS). For example, C# `string` and VB.NET `String` are both `System.String`. Since the languages agree on the types, one person can write a part in C# and another in VB.NET and they still work together.

### 7. Solving "DLL Hell"

Before .NET, many apps shared the same DLL files. When one app installed a different version of a shared DLL, it overwrote the old one and another app stopped working. That is DLL Hell.

.NET fixed it with these things:

- Assembly: the package (.exe or .dll) with your code. An app can keep its own private copy.
- Manifest: like the ID card of the assembly. It has its name, its version and the other assemblies it needs.
- Metadata: information about the types inside.
- Strong name: a unique name made from the name, version, public key and signature, so it can't be mixed up or faked.
- GAC (Global Assembly Cache): a shared place that keeps many versions of the same assembly side by side, so each app uses the version it needs.

A namespace and an assembly are not the same. A namespace is a logical grouping of classes, like a folder name that organizes code and avoids name clashes. An assembly is the physical file that gets deployed. One namespace can be spread over several assemblies, which is why writing `using` is not enough and you also have to add the assembly reference.

### 8. ADO.NET vs. Entity Framework and LINQ

With ADO.NET you open the connections yourself, write SQL as plain text and copy the data from tables into objects by hand. It gives full control but mistakes are easy. A typo in the SQL text only shows when the program runs, and you can forget to close a connection.

Entity Framework is an ORM. It maps database tables to C# classes so you work with objects and not raw SQL. LINQ lets you write queries in C#, and the compiler checks them for mistakes.

```csharp
var names = db.Employees.Where(e => e.Dept == "HR").Select(e => e.Name).ToList();
```

The good side is less code, fewer errors and faster development. The bad side is less control, and sometimes the SQL it generates is slow, so for very heavy tasks you may still use ADO.NET.

### 9. Event-driven programming

A console app starts at `Main()`, runs line by line and then ends. A WinForms app is different. `Main()` calls `Application.Run(new Form1())`, which starts the main loop, and then the program just waits for the user to do something.

When the user clicks a button:

1. The user clicks the button.
2. Windows turns the click into a message and puts it in the app's message queue.
3. The main loop takes the message and sends it to the button.
4. The button raises its Click event.
5. The subscribers of that event are notified. They are stored as delegates, which are references to methods.
6. The event handler (our method) runs.
7. The program goes back to the main loop and waits again.

```csharp
button1.Click += button1_Click;
button1.Click += (s, e) => MessageBox.Show("Hi!");

private void button1_Click(object sender, EventArgs e)
{
    MessageBox.Show("Clicked!");
}
```

## Group Members

1. Daniel Tsega - UUR00887/16
2. eyob tadesse - Id-uu87679R
3. Masresha Geremew - UU94367R
4. Biruck Tirusew - UUR00881/16
