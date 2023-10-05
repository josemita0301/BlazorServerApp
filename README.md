<h1>BlazorServerAp</h1>

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
<h3>Explicación del funcionamiento del framework</h3>

<p>Si has escuchado sobre <strong>Blazor</strong>, seguramente sabes que es una revolución en el desarrollo web. Pero, ¿cómo funciona realmente? Vamos a explorarlo.</p>

<h4>1. WebAssembly (WASM)</h4>
<p>Para comenzar, es esencial entender qué es <strong>WebAssembly</strong> o WASM. Piensa en él como un tipo especial de código que se ejecuta en tu navegador, casi tan rápido como el código nativo. Lo genial es que permite que código escrito en lenguajes como C/C++ o Rust se ejecute directamente en el navegador.</p>

<h4>2. MonoWASM</h4>
<p>Seguramente has oído hablar de .NET. Bueno, <strong>Mono</strong> es como un primo de .NET, y <strong>MonoWASM</strong> es una versión especial de Mono que se ejecuta en WebAssembly. En términos sencillos, actúa como una pequeña máquina virtual .NET, pero en tu navegador.</p>

<h4>3. Blazor</h4>
<p>Finalmente, llegamos a <strong>Blazor</strong>. Este genial framework te permite construir aplicaciones web con C#. Y gracias a MonoWASM, esas aplicaciones se ejecutan directamente en tu navegador. Imagina construir componentes web, similar a como lo harías con React o Angular, pero con C#. ¡Es impresionante!</p>

<p>Y una cosa más: Blazor tiene dos sabores. Uno, llamado <strong>Blazor WebAssembly</strong>, ejecuta todo en el navegador. El otro, <strong>Blazor Server</strong>, ejecuta el código en el servidor, y solo envía los cambios y eventos de la interfaz al navegador.</p>

<p>Así que, si eres un fanático de C# y quieres darle un giro a la programación web, ¡Blazor es el camino a seguir!</p>


<h3>Aspectos generales de la arquitectura de la solución</h3>
<p>
La aplicación se integra con Firebase para manejar autenticación de usuarios, almacenamiento de imágenes y como base de datos para las publicaciones. Firebase proporciona soluciones escalables y en tiempo real para nuestras necesidades.
</p>
