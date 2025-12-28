# DOTNET-PowershellWrapper

A .NET Framework console application that provides a wrapper to execute PowerShell scripts from within a C# application.
**Video Tutorial**  
[![Video Tutorial](https://img.youtube.com/vi/PjSVag-PVMg/0.jpg)](https://www.youtube.com/watch?v=PjSVag-PVMg)
## Features

- Execute PowerShell scripts from files
- Execute inline PowerShell commands directly
- Automatic bypass of PowerShell execution policy for the process
- Line-by-line script execution with individual output
- Self-contained executable (dependencies embedded via Costura.Fody)

## Requirements

- .NET Framework 4.8
- Windows OS with PowerShell

## Installation

### Build from Source

1. Clone the repository
2. Open `DorApplication.sln` in Visual Studio
3. Build the solution (Release/x64 recommended)

The compiled executable will be located in `bin\x64\Release\`

## Usage

```bash
DorApplication.exe -f <file_path>    # Execute PowerShell script from file
DorApplication.exe -s <script>       # Execute inline PowerShell command
```

### Command Line Options

| Option | Long Form | Description |
|--------|-----------|-------------|
| `-f` | `--file` | Specify a PowerShell script file to execute |
| `-s` | `--script` | Specify an inline PowerShell command to execute |

### Examples

**Execute a script file:**
```bash
DorApplication.exe -f "C:\Scripts\myscript.ps1"
```

**Execute an inline command:**
```bash
DorApplication.exe -s "Get-Service"
```

**Example script file content:**
```powershell
$file = New-Item -Path ".\hello.txt" -ItemType File -Force
Set-Content -Path $file.FullName -Value "Hello World"
Get-Service
```

## Project Structure

```
DOTNET-PowershellWrapper/
├── Program.cs              # Main application code
├── DorApplication.csproj   # Project file
├── DorApplication.sln      # Solution file
├── App.config              # Application configuration
├── FodyWeavers.xml         # Fody configuration for assembly embedding
├── packages.config         # NuGet dependencies
└── Properties/
    └── AssemblyInfo.cs     # Assembly metadata
```

## Dependencies

- **System.Management.Automation** - PowerShell SDK
- **Fody** - IL weaving
- **Costura.Fody** - Assembly embedding for self-contained executable

## How It Works

1. The application parses command-line arguments to determine execution mode
2. For file mode (`-f`): Reads the script file line-by-line and executes each line individually
3. For script mode (`-s`): Executes the provided command directly
4. Sets execution policy to `Bypass` for the process scope
5. Outputs results to the console

## Security Note

This application sets the PowerShell execution policy to `Bypass` for the process scope to allow script execution. Use responsibly and be aware of the security implications when running scripts from untrusted sources.

---

## Licenses

### Project License

Copyright 2023

### Third-Party Licenses

#### Fody (MIT License)

```
MIT License

Copyright (c) Simon Cropp

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
```

#### Microsoft .NET Library (Microsoft Software License)

The .NET libraries used in this project are licensed under the Microsoft Software License Terms for Microsoft .NET Library. Key terms include:

- You may install and use any number of copies of the software to design, develop and test your programs
- You may copy and distribute the object code form of the software
- The software is licensed "as-is" without warranty

For the full license text, see the `dotnet_library_license.txt` files in the packages directory.
