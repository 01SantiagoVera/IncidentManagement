# 📌 Sistema de Gestión de Incidencias  

Este proyecto es una aplicación web desarrollada en **ASP.NET MVC 5** para gestionar incidencias técnicas en una organización.  
Permite a los usuarios **registrar, consultar y actualizar incidencias**, asignarlas a técnicos y gestionar comentarios en tiempo real.  

## ✅ Requisitos Técnicos  

- 💻 **Visual Studio 2019 o superior**  
- 🔹 **.NET Framework 4.8**  
- 🛢 **SQL Server (Express o LocalDB)**  
- 📦 **Entity Framework 6**  

## 📂 Estructura del Proyecto  

La solución está organizada en **capas separadas** para una mejor arquitectura:  

1. **IncidentManagement.Web** → Capa MVC (Controladores y Vistas).  
2. **IncidentManagement.Services** → Lógica de negocio y validaciones.  
3. **IncidentManagement.Data** → Acceso a datos con Entity Framework.  
4. **IncidentManagement.Entities** → Modelos y entidades del sistema.  

## 🔥 Características Principales  

✅ **Gestión completa de incidencias (CRUD)**  
✅ **Filtrado y búsqueda por estado, prioridad, técnico, etc.**  
✅ **Sistema de comentarios en tiempo real (AJAX)**  
✅ **Reportes estadísticos de incidencias**  
✅ **Validaciones en el cliente y servidor**  
✅ **Implementación de Repository Pattern y Dependency Injection**  

## 🚀 Instalación y Configuración  

### 1️⃣ **Abrir la solución en Visual Studio**  
- Asegúrate de tener **.NET Framework 4.8** instalado.  

### 2️⃣ **Restaurar paquetes NuGet**  
Desde la consola de **Administrador de Paquetes NuGet** en Visual Studio:  
```powershell
Update-Package -Reinstall
```

### 3️⃣ **Configurar la base de datos**
Editar el archivo Web.config en la sección <connectionStrings> con los datos del servidor SQL:

```
<connectionStrings>
    <add name="DefaultConnection" 
         connectionString="Server=.\SQLEXPRESS;Database=IncidentDB;Trusted_Connection=True;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 4️⃣ **Ejecutar las migraciones de Entity Framework**
Desde la Consola de Administrador de Paquetes, ejecutar:
```
Add-Migration InitialCreate
Update-Database

```

### 5️⃣ **Ejecutar la aplicación**
Presiona F5 en Visual Studio o usa:
```
dotnet run
```
