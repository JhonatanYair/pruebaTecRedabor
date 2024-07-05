# Prueba Técnica con .NET y SQL Server

Este repositorio contiene una prueba técnica que utiliza .NET para el backend y SQL Server para la base de datos, este proeycto utiliza el patron CQRS. Sigue los pasos a continuación para desplegar y probar la aplicación.

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
  - **URL:** `http://localhost:8086/api/Employee/login`
  - **Descripción:** Permite iniciar sesión para obtener acceso a los endpoints protegidos.
  - **Body:**
    ```json
    {
        "email": "usuario1@gmail.com",
        "password": "enter12345"
    }
    ```

### Employee

- **Listar todos los empleados**
  - **Método:** GET
  - **URL:** `http://localhost:8086/api/Employee`
  - **Descripción:** Obtiene todos los empleados registrados.
  - **Autenticación:** Requiere token JWT.

- **Obtener empleado por ID**
  - **Método:** GET
  - **URL:** `http://localhost:8086/api/Employee/{id}`
  - **Descripción:** Obtiene un empleado específico por su ID.
  - **Autenticación:** Requiere token JWT.

- **Crear nuevo empleado**
  - **Método:** POST
  - **URL:** `http://localhost:8086/api/Employee`
  - **Descripción:** Crea un nuevo empleado.
  - **Body:**
    ```json
    {
      "name": "Nombre del Empleado",
      "email": "email@example.com",
      "telephone": "300000000",
      "fax": "Fax",
      "password": "password",
      "portalId": 1,
      "companyId": 1,
      "roleId": 1,
      "statusId": 1
    }
    ```

- **Actualizar empleado**
  - **Método:** PUT
  - **URL:** `http://localhost:8086/api/Employee/{id}`
  - **Descripción:** Actualiza un empleado existente por su ID.
  - **Autenticación:** Requiere token JWT.
  - **Body:**
    ```json
    {
      "id": 1,
      "name": "Nombre del Empleado editado",
      "email": "email@example.com",
      "telephone": "300000000",
      "fax": "Fax",
      "password": "password",
      "portalId": 1,
      "companyId": 1,
      "roleId": 1,
      "statusId": 1
    }
    ```

- **Eliminar empleado**
  - **Método:** DELETE
  - **URL:** `http://localhost:8086/api/Employee/{id}`
  - **Descripción:** Elimina un empleado por su ID.
  - **Autenticación:** Requiere token JWT.

### Status

- **Listar todos los estados**
  - **Método:** GET
  - **URL:** `http://localhost:8086/api/Status`
  - **Descripción:** Obtiene todos los estados disponibles.

- **Obtener estado por ID**
  - **Método:** GET
  - **URL:** `http://localhost:8086/api/Status/{id}`
  - **Descripción:** Obtiene un estado específico por su ID.

- **Crear nuevo estado**
  - **Método:** POST
  - **URL:** `http://localhost:8086/api/Status`
  - **Descripción:** Crea un nuevo estado.
  - **Body:**
    ```json
    {
      "name": "Nombre del Estado",
    }
    ```

- **Actualizar estado**
  - **Método:** PUT
  - **URL:** `http://localhost:8086/api/Status/{id}`
  - **Descripción:** Actualiza un estado existente por su ID.
  - **Body:**
    ```json
    {
      "id": 1,
      "name": "Nombre del Estado editado",
    }
    ```

- **Eliminar estado**
  - **Método:** DELETE
  - **URL:** `http://localhost:8086/api/Status/{id}`
  - **Descripción:** Elimina un estado por su ID.
  - **Autenticación:** Requiere token JWT.

### Company

- **Listar todas las compañías**
  - **Método:** GET
  - **URL:** `http://localhost:8086/api/Company`
  - **Descripción:** Obtiene todas las compañías registradas.
  - **Autenticación:** Requiere token JWT.

  - **Obtener compañía por ID**
  - **Método:** GET
  - **URL:** `http://localhost:8086/api/Company/{id}`
  - **Descripción:** Obtiene una compañía específico por su ID.
  - **Autenticación:** Requiere token JWT.

- **Crear nuevo compañía**
  - **Método:** POST
  - **URL:** `http://localhost:8086/api/Company`
  - **Descripción:** Crea una nueva compañía.
  - **Autenticación:** Requiere token JWT.
  - **Body:**
    ```json
    {
      "name": "Nombre de la compañía",
    }
    ```

- **Actualizar compañía**
  - **Método:** PUT
  - **URL:** `http://localhost:8086/api/Company/{id}`
  - **Descripción:** Actualiza una compañía existente por su ID.
  - **Autenticación:** Requiere token JWT.

  - **Body:**
    ```json
    {
      "id": 1,
      "name": "Nombre de la compañía editada",
    }
    ```

- **Eliminar compañía**
  - **Método:** DELETE
  - **URL:** `http://localhost:8086/api/Company/{id}`
  - **Descripción:** Elimina una compañía por su ID.
  - **Autenticación:** Requiere token JWT.

### Rol

- **Listar todos los roles**
  - **Método:** GET
  - **URL:** `http://localhost:8086/api/Rol`
  - **Descripción:** Obtiene todos los roles disponibles.
  - **Autenticación:** Requiere token JWT.

    - **Obtener rol por ID**
  - **Método:** GET
  - **URL:** `http://localhost:8086/api/Rol/{id}`
  - **Descripción:** Obtiene un rol específico por su ID.
  - **Autenticación:** Requiere token JWT.

- **Crear nuevo roles**
  - **Método:** POST
  - **URL:** `http://localhost:8086/api/Rol`
  - **Descripción:** Crea un nuevo roles.
  - **Autenticación:** Requiere token JWT.
  - **Body:**
    ```json
    {
      "name": "Nombre del rol",
    }
    ```

- **Actualizar rol**
  - **Método:** PUT
  - **URL:** `http://localhost:8086/api/Rol/{id}`
  - **Descripción:** Actualiza un rol existente por su ID.
  - **Autenticación:** Requiere token JWT.

  - **Body:**
    ```json
    {
      "id": 1,
      "name": "Nombre del rol editada",
    }
    ```

- **Eliminar rol**
  - **Método:** DELETE
  - **URL:** `http://localhost:8086/api/Rol/{id}`
  - **Descripción:** Elimina un rol por su ID.
  - **Autenticación:** Requiere token JWT.

### Notas adicionales

- La base de datos de pruebas se utiliza automáticamente para ejecutar los tests, asegurando que los datos de producción no se vean afectados.