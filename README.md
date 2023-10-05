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

<h2>Acquitectura</h2>
<h3>Introducción a Blazor y WebAssembly</h3>

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
