<h1>BlazorServerApp</h1>
<h2>Framework</h2>

<h3>Blazor Server-Side</h3>

<p>
Blazor permite crear aplicaciones web utilizando .NET. Existen dos enfoques principales: Server-Side y Client-Side. En esta aplicación, hemos elegido trabajar con Blazor Server-Side. 
</p>
<p>
Una de las principales ventajas de Blazor Server-Side es que permite manejar una base de datos directamente desde el backend del código, permitiendo operaciones más integradas y fluidas. Por otro lado, Blazor Client-Side, también conocido como WebAssembly, se ejecuta de manera más rápida, pero no posee la misma facilidad para manejar bases de datos directamente. En lugar de eso, realiza llamadas a APIs para obtener o manipular datos.
</p>
<p>
Blazor como framework es revolucionario ya que permite que el navegador interprete C# directamente. Es un framework orientado a componentes, lo que implica que se debe apuntar a que los componentes sean reutilizables y modulares.
</p>

<h2>Descripción de la aplicación</h2>

<p>
La aplicación es una red social destinada a eventos, celebraciones y días internacionales en países hispanohablantes. Los usuarios tendrán acceso a un calendario general y podrán visualizar y compartir DIY (Hazlo Tú Mismo) para festividades, utilizando materiales comunes y accesibles.
</p>

<h3>Características principales:</h3>

<ol>
    <li><strong>Calendario General</strong>: Donde se muestran los días festivos y celebraciones de los países hispanohablantes.</li>
    <li><strong>Publicaciones DIY</strong>: Los usuarios pueden subir y compartir sus propias creaciones con instrucciones, links a videos, insumos utilizados, costos, tiempo de realización, entre otros detalles.</li>
    <li><strong>Filtro Personalizado</strong>: Los usuarios pueden filtrar las publicaciones según sus necesidades y preferencias.</li>
    <li><strong>Búsqueda por Material</strong>: Si un usuario tiene ciertos materiales a mano, puede buscar proyectos que los utilicen.</li>
    <li><strong>Calendario Personal</strong>: Dependiendo del avance del proyecto, cada usuario podrá tener un calendario propio para fechas personales importantes.</li>
</ol>

<h2>Tecnologías y herramientas</h2>

<h3>Firebase</h3>

<p>
La aplicación se integra con Firebase para manejar autenticación de usuarios y como base de datos para las publicaciones. Firebase proporciona soluciones escalables y en tiempo real para nuestras necesidades.
</p>

<h3>Modelo-Vista-Controlador (MVC)</h3>

<p>
Para mantener el código organizado y facilitar su mantenimiento, se ha decidido utilizar el patrón arquitectónico Modelo-Vista-Controlador (MVC). Esto nos permite separar la lógica de negocio, la interfaz de usuario y el acceso a los datos.
</p>

<h2>Acquitectura del frameWork</h2>
<h3>Introducción a Blazor y WebAssembly</h3>
<img src="https://github.com/josemita0301/BlazorServerApp/blob/9faf3953afbc287ed4351f76ebf1c20dab74e24a/Blazor%20Framework.png" style = "align-center">

<p>El marco de desarrollo web <strong>Blazor</strong>, desarrollado por Microsoft, ha generado un notable interés en la comunidad de desarrollo debido a su capacidad para permitir la construcción de aplicaciones web utilizando C# en lugar de JavaScript. La base de esta innovación se encuentra en la tecnología conocida como WebAssembly (WASM).</p>

<h4>1. WebAssembly (WASM)</h4>
<p><strong>WebAssembly</strong> es un formato de código binario diseñado para ser un objetivo de compilación eficiente para lenguajes de alto nivel como C/C++ y Rust. Esta tecnología permite que el código se ejecute en navegadores a velocidades cercanas al rendimiento nativo.</p>

<h4>2. MonoWASM</h4>
<p>El proyecto <strong>Mono</strong> representa una implementación de código abierto del marco .NET. <strong>MonoWASM</strong> es una versión adaptada de Mono diseñada para ejecutarse sobre WebAssembly. Esencialmente, actúa como un intérprete de .NET dentro del contexto del navegador, facilitando la ejecución del código C#.</p>

<h4>3. Blazor</h4>
<p><strong>Blazor</strong> aprovecha las capacidades de MonoWASM y WASM para ejecutar aplicaciones web escritas en C#. Las aplicaciones se construyen utilizando un modelo de componentes, similar a frameworks modernos como React o Angular. Blazor se presenta en dos variantes principales:</p>
<ul>
    <li><strong>Blazor WebAssembly</strong>: La aplicación y sus dependencias se descargan y ejecutan en el navegador utilizando WebAssembly.</li>
    <li><strong>Blazor Server</strong>: El código C# se ejecuta en el servidor y solo los eventos y actualizaciones de la interfaz de usuario se transmiten al navegador mediante una conexión en tiempo real.</li>
</ul>

<h1>Descripción de la Arquitectura de Mi Proyecto</h1>

<img src="https://github.com/josemita0301/BlazorServerApp/blob/0b32f32600716e1deb8c221d787b7a560efc26b3/Title%20Page.png" style = "align-center">

<p>Estoy desarrollando una solución en .NET. Mi proyecto principal se construye con Blazor Server Side y se encarga de la capa de <strong>Presentación</strong>. Aquí gestiono la interacción del usuario con la interfaz, mostrando la información y capturando sus acciones. Aunque Blazor no sigue estrictamente el patrón MVC, he estructurado este proyecto de manera similar con componentes que actúan como vistas, lógica de componentes que funcionan como controladores y modelos de datos.</p>

<h2>Lógica de Negocio</h2>
<p>El núcleo de mi aplicación reside en el proyecto de <strong>Servicios</strong>, donde he encapsulado la lógica central como encriptación, helpers y requests a la API. Esta capa se encarga de las operaciones cruciales y de la lógica del negocio.</p>

<p>Adicionalmente, para garantizar la seguridad de los usuarios, me conecto a una API de Google para autenticarlos. Esto garantiza que cada usuario es quien dice ser y me proporciona una capa adicional de seguridad.</p>

<h2>Acceso a Datos</h2>
<p>La persistencia de datos es manejada por Firebase. Gracias a un paquete NuGet en C#, puedo interactuar fácilmente con esta base de datos, realizando operaciones CRUD y gestionando la información de los usuarios y otros datos relevantes.</p>

<h1>Login</h1>
<p>En este caso el login lo hemos realizaod con identity al importando el paquete NuGET de Identity y despues añadiendolo a las dependencias del program.cs. Despues de tener esa dependencia lo que debemos de hacer es crear un AuthenticationProvider perosnalizado para que podamos estbalecer nosotros mismos los claims o datos que queremos que se guarden del usuario. Esto es util ya que podriamos por ejemplo asignar roles. Finalmente mediante los componentes de authorizationviews en las vistas injectamos la dependencia del AuthenticationStatePorvider personalizado y mediante AuthorizationViews podemos escoger que es lo que ve el usuario autenticado o que ha iniciado sesion y lo que no puede ser el usuario que no ha iniciado sesiòn</p>

<h1>Diagrama del login</h1>
<p>En este caso el login lo hemos realizaod con identity al importando el paquete NuGET de Identity y despues añadiendolo a las dependencias del program.cs. Despues de tener esa dependencia lo que debemos de hacer es crear un AuthenticationProvider perosnalizado para que podamos estbalecer nosotros mismos los claims o datos que queremos que se guarden del usuario. Esto es util ya que podriamos por ejemplo asignar roles. Finalmente mediante los componentes de authorizationviews en las vistas injectamos la dependencia del AuthenticationStatePorvider personalizado y mediante AuthorizationViews podemos escoger que es lo que ve el usuario autenticado o que ha iniciado sesion y lo que no puede ser el usuario que no ha iniciado sesiòn</p>


<h2>Explicaciôn del diagrama del login (Diagrama de actividades)</h2>
<img src="diagramaLogin.jpeg" style = "align-center">


<h2>Explicaciôn del diagrama del login (Diagrama de actividades)</h2>
<p>EN cuanto a la explicación detallada del diagrama de actividad:

Inicio del Programa: El proceso comienza cuando un usuario intenta iniciar sesión en el sistema.

Validación de Credenciales: Se realiza una verificación para determinar si el usuario proporcionó credenciales válidas. Esto podría incluir un nombre de usuario y una contraseña.

Llamada al Método LoginUser en UserController: Si las credenciales son válidas, se llama al método LoginUser en la clase UserController. Este método se encarga de la lógica de autenticación.

Verificación de Credenciales en la Base de Datos: El método LoginUser en UserController realiza la verificación de las credenciales en la base de datos.

Credenciales Correctas: Si las credenciales son correctas, se procede a actualizar el estado de autenticación llamando al método UpdateAuthenticationState en la clase CustomAuthenticationStateProvider.

Almacenamiento de Información del Usuario en la Sesión: Se almacena la información del usuario en la sesión. En este caso, el método SetAsync en _sessionStorage se utiliza para almacenar información del usuario.

Permitir el Acceso al Sistema: Con las credenciales verificadas y la sesión actualizada, se permite el acceso al sistema.

Credenciales Incorrectas: Si las credenciales no son correctas, se muestra un mensaje de error al usuario. Este flujo puede incluir otras actividades, como bloquear la cuenta después de varios intentos fallidos, dependiendo de los requisitos de seguridad.

Fin del Programa: El proceso concluye, ya sea con el acceso al sistema o con un mensaje de error.
</p>