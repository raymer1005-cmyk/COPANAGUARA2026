# Team Na' Guara - Copa Pachacámac 2025 (ASP.NET Core .NET 9)

Proyecto listo para abrir en Visual Studio o ejecutar con dotnet CLI.

Características:
- Inscripción de equipos y registro de jugadoras con foto y documento.
- Validaciones: extensiones JPG/JPEG/PNG/PDF, tamaño máximo 4 MB por archivo.
- Archivos guardados localmente en wwwroot/uploads/photos y wwwroot/uploads/docs.
- Panel admin protegido por login (admin / Copa2025!).
- Base de datos SQLite creada automáticamente en el primer inicio (teamnaguara.db).

Ejecutar (CLI):
1. dotnet restore
2. dotnet run
3. Abrir https://localhost:5001

Rutas:
- /Teams/Register
- /Players/Register
- /Account/Login (admin/admin: admin / Copa2025!)
- /Admin/Index
