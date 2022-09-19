# ExternalServices
proyecto de servicios externos prueba TUYA

# Introducción
Para el desarrollo de la prueba técnica de TUYA realicé dos proyectos que funcionan en conjunto, uno de ellos es "ExternalServices" y el otro es "Payment". ExternalServices se desarrolló para exponer dos APIs (Facturación y pedidos) y adicioalmente para conectarse a la base de datos dbTuya y
crear los registros correspondientes a los procesos de facturación y toma de pedidos.

Para el desarrollo del proyecto ExternalServices, se crearon 3 capas:

1.Application: En esta capa va el proyecto web api con los controladores que se exponen para el proyecto "Payment", además de los parámetros de configuración en el archivo appsettings.json

2.Domain: En esta capa se encuentra la librería con todo lo realionado a la lógica del negocio.

3.Infraestructure: En esta capa se encuentra la librería con la implementación de entity framework (contexto y modelos).

El proyecto se desarrolló en .net core 3.1

# Funcionamiento
ExternalServices expone las APIs de facturación y pedidos (las cuales consume Payment), y guarda la información pertinente a dichos procesos en la base de datos dbTuya.

Antes de ejecutar el proyecto, debemos configurar las cadena de conexión a la base de datos, para ello debemos abrir el archivo appsettings.json, y 
configurar la variable "CadenaConexionDbTuya", teniendo en cuenta que dicha cadena de conexión tiene la siguiente estructura:

"Server=; Database=; User=; Password="

En caso de que no se requiera usuario/contraseña, podemos optar por la siguiente estructura:

"Server=; Database=; Trusted_Connection=True"

Por favor tener en cuenta el puerto por el cual se va a ejecutar cada proyecto, ya que en caso de ser diferente al 4202, se deberá cambiar la configuración en el proyecto Payment (para mas información leer el readme.md del repositorio de Payment).

# Uso de la base de datos dbTuya
Para el proyecto de ExternalServices se construyó una base de datos (dbTuya) con dos tablas, tblFacturacion y TblPedidos. En dichas tablas se verá reflejado el resultado de las transacciones y
datos adicionales de interés (suponiendo un escenario real). 
Es necesario aclarar que el numero de tarjeta cuenta con los 12 primeros digitos enmascarados.
