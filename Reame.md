# Prueba Técnica con .NET y SQL Server

Este repositorio contiene una prueba técnica que utiliza .NET para el backend y SQL Server para la base de datos. Sigue los pasos a continuación para desplegar y probar la aplicación.

## Despliegue de la Aplicación

1. **Requisitos Previos:**
   - Docker instalado en tu máquina. Puedes descargarlo desde [Docker Hub](https://www.docker.com/get-started).

2. **Ejecución de la Aplicación:**
   En la raíz del proyecto, ejecuta el siguiente comando para iniciar los contenedores Docker en segundo plano:

   ```bash
   docker-compose up -d
   ```

   Esto iniciará los contenedores de .NET y SQL Server necesarios para la aplicación.

## Endpoints de la API

La API proporciona endpoints para gestionar los recursos de Employee, Status, Company y Rol. A continuación se detallan los endpoints disponibles junto con ejemplos de uso:

### Autenticación

- **Login**
  - **Método:** POST
  - **URL:** `http://localhost:8083/api/auth/login`
  - **Descripción:** Permite iniciar sesión para obtener acceso a los endpoints protegidos.
  - **Body:**
    ```json
    {
        "username": "example_user",
        "password": "password123"
    }
    ```

### Employee

- **Listar todos los empleados**
  - **Método:** GET
  - **URL:** `http://localhost:8083/api/employee/list`
  - **Descripción:** Obtiene todos los empleados registrados.
  - **Autenticación:** Requiere token JWT.

- **Obtener empleado por ID**
  - **Método:** GET
  - **URL:** `http://localhost:8083/api/employee/{id}`
  - **Descripción:** Obtiene un empleado específico por su ID.
  - **Autenticación:** Requiere token JWT.

- **Crear nuevo empleado**
  - **Método:** POST
  - **URL:** `http://localhost:8083/api/employee/create`
  - **Descripción:** Crea un nuevo empleado.
  - **Autenticación:** Requiere token JWT.
  - **Body:**
    ```json
    {
        "name": "Nombre del Empleado",
        "email": "email@example.com",
        "role": "Developer",
        "companyId": 1
    }
    ```

- **Actualizar empleado**
  - **Método:** PUT
  - **URL:** `http://localhost:8083/api/employee/update/{id}`
  - **Descripción:** Actualiza un empleado existente por su ID.
  - **Autenticación:** Requiere token JWT.
  - **Body:**
    ```json
    {
        "name": "Nuevo Nombre",
        "email": "nuevo_email@example.com",
        "role": "Analyst",
        "companyId": 2
    }
    ```

- **Eliminar empleado**
  - **Método:** DELETE
  - **URL:** `http://localhost:8083/api/employee/delete/{id}`
  - **Descripción:** Elimina un empleado por su ID.
  - **Autenticación:** Requiere token JWT.

### Status

- **Listar todos los estados**
  - **Método:** GET
  - **URL:** `http://localhost:8083/api/status/list`
  - **Descripción:** Obtiene todos los estados disponibles.
  - **Autenticación:** Requiere token JWT.

### Company

- **Listar todas las compañías**
  - **Método:** GET
  - **URL:** `http://localhost:8083/api/company/list`
  - **Descripción:** Obtiene todas las compañías registradas.
  - **Autenticación:** Requiere token JWT.

### Rol

- **Listar todos los roles**
  - **Método:** GET
  - **URL:** `http://localhost:8083/api/role/list`
  - **Descripción:** Obtiene todos los roles disponibles.
  - **Autenticación:** Requiere token JWT.

### Notas adicionales

- La base de datos de pruebas se utiliza automáticamente para ejecutar los tests, asegurando que los datos de producción no se vean afectados.
- Todos los endpoints, excepto `login` y `employee/list`, requieren autenticación mediante token JWT.

---

Este `README.md` proporciona una guía completa para desplegar la aplicación y utilizar los endpoints de la API, con ejemplos específicos de peticiones HTTP y requisitos de autenticación. Asegúrate de personalizarlo según las necesidades exactas y configuraciones de tu proyecto.