# SolidAppConsole

Purpose
-------
This small console application displays the SOLID principles (S, O, L, I, D). Each principle's content is loaded from text files in the Content folder so the displayed text can be edited without recompiling.

Requirements
------------
- .NET 10 SDK (the project targets net10.0).
- Windows Terminal (recommended) if you want to see emojis correctly in the output.

Why Windows Terminal
--------------------
The integrated Visual Studio console and the legacy cmd.exe do not always render emojis or perform proper font fallback. Windows Terminal provides reliable UTF-8 encoding and emoji font fallback, which is why the app tries to relaunch itself in Windows Terminal when started from the IDE.

How to run
----------
1. From Visual Studio
   - Run the project (F5). The app will attempt to open in Windows Terminal automatically. If Windows Terminal is not available, it will fall back to running the exe or using dotnet.

2. From a terminal (recommended to verify emoji support)
   - Open Windows Terminal.
   - Navigate to the project directory and run:
	 - dotnet run
	 - or execute the compiled binary: bin\\Debug\\net10.0\\SolidAppConsole.exe

Make sure that:
- Text files in Content/ are saved in UTF-8 encoding (Visual Studio: File → Save with Encoding → UTF-8).
- The font used by Windows Terminal supports emoji (the system typically falls back to Segoe UI Emoji).
