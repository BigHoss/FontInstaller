warp-packer --arch windows-x64 --input_dir "%~dp0\FontInstaller\bin\Release\netcoreapp3.0\publish\win" --exec "FontInstaller.exe" --output "%~dp0\Release\win\FontInstaller.exe"

warp-packer --arch macos-x64 --input_dir "%~dp0\FontInstaller\bin\Release\netcoreapp3.0\publish\mac" --exec "FontInstaller" --output "%~dp0\Release\mac\FontInstaller"

pause